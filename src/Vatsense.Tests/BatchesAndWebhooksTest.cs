using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Vatsense;
using Vatsense.Exceptions;
using Vatsense.Models.Batches;
using Vatsense.Models.Validate;

namespace Vatsense.Tests;

/// <summary>
/// Batches, consultation_optional, confirmation_number and webhook signatures.
/// </summary>
public class BatchesAndWebhooksTest
{
    const string BatchJson =
        "{\"success\":true,\"code\":201,\"data\":{\"object\":\"batch\",\"id\":\"bat_1\",\"number\":7,\"status\":\"queued\",\"livemode\":false,\"rows\":{\"total\":2,\"to_check\":2,\"done\":0},\"results\":{\"valid\":0,\"invalid\":0},\"quote\":{\"requests_needed\":2,\"covered\":true}}}";

    static (VatSenseClient Client, List<(HttpRequestMessage Request, string? Body)> Sent) Capture(
        string answer,
        string mediaType = "application/json"
    )
    {
        var sent = new List<(HttpRequestMessage, string?)>();
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns(
                async (HttpRequestMessage request, CancellationToken ct) =>
                {
                    string? body = null;
                    if (request.Content != null)
                    {
#if NET
                        body = await request.Content.ReadAsStringAsync(ct);
#else
                        body = await request.Content.ReadAsStringAsync();
#endif
                    }
                    sent.Add((request, body));
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(answer, System.Text.Encoding.UTF8, mediaType),
                    };
                }
            );

        VatSenseClient client = new()
        {
            HttpClient = new HttpClient(handlerMock.Object),
            BaseUrl = "http://localhost",
            Username = "user",
            Password = "key",
            MaxRetries = 0,
        };
        return (client, sent);
    }

    [Fact]
    public async Task Create_SendsBodyAndIdempotencyKey()
    {
        var (client, sent) = Capture(BatchJson);

        var batch = await client.Batches.Create(
            new BatchCreateParams()
            {
                Numbers = ["GB288305674", "FR12345678901"],
                Reference = "November",
                Shortfall = BatchShortfall.Pause,
                IdempotencyKey = "november-1",
            },
            TestContext.Current.CancellationToken
        );

        var (request, body) = sent.Single();
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("http://localhost/batches", request.RequestUri!.ToString());
        Assert.Equal("november-1", request.Headers.GetValues("Idempotency-Key").Single());
        using var json = JsonDocument.Parse(body!);
        Assert.Equal(2, json.RootElement.GetProperty("numbers").GetArrayLength());
        Assert.Equal("pause", json.RootElement.GetProperty("shortfall").GetString());
        Assert.False(json.RootElement.TryGetProperty("rows", out _));
        Assert.Equal("bat_1", batch.Data!.ID);
        Assert.Equal(7, batch.Data.Number);
        Assert.False(batch.Data.Livemode);
        Assert.Equal(2, batch.Data.Rows!.ToCheck);
        Assert.True(batch.Data.Quote!.Covered);
        batch.Validate();
    }

    [Fact]
    public async Task Create_SendsRows()
    {
        var (client, sent) = Capture(BatchJson);

        await client.Batches.Create(
            new BatchCreateParams()
            {
                Rows =
                [
                    new BatchRow()
                    {
                        VatNumber = "GB288305674",
                        CompanyName = "Weio Ltd",
                        AddressLine2 = "Floor 2",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );

        using var json = JsonDocument.Parse(sent.Single().Body!);
        var row = json.RootElement.GetProperty("rows")[0];
        Assert.Equal("Weio Ltd", row.GetProperty("company_name").GetString());
        Assert.Equal("Floor 2", row.GetProperty("address_line_2").GetString());
    }

    [Fact]
    public async Task List_SendsQuery()
    {
        var (client, sent) = Capture(
            "{\"success\":true,\"code\":200,\"data\":{\"data\":[{\"id\":\"bat_1\"}],\"page\":2,\"limit\":10,\"total\":11,\"has_more\":false}}"
        );

        var page = await client.Batches.List(
            new BatchListParams() { Page = 2, Limit = 10 },
            TestContext.Current.CancellationToken
        );

        var query = sent.Single().Request.RequestUri!.Query;
        Assert.Contains("page=2", query);
        Assert.Contains("limit=10", query);
        Assert.Equal("bat_1", page.Data!.Data!.Single().ID);
        Assert.Equal(11, page.Data.Total);
        page.Validate();
    }

    [Theory]
    [InlineData("start", "/batches/bat_1/start")]
    [InlineData("pause", "/batches/bat_1/pause")]
    [InlineData("continue", "/batches/bat_1/continue")]
    [InlineData("complete", "/batches/bat_1/complete")]
    [InlineData("retrieve", "/batches/bat_1")]
    public async Task Actions_UseTheBatchPath(string action, string path)
    {
        var (client, sent) = Capture(BatchJson);
        var ct = TestContext.Current.CancellationToken;

        var task = action switch
        {
            "start" => client.Batches.Start("bat_1", cancellationToken: ct),
            "pause" => client.Batches.Pause("bat_1", cancellationToken: ct),
            "continue" => client.Batches.Continue(
                "bat_1",
                new() { Shortfall = BatchShortfall.Overage },
                ct
            ),
            "complete" => client.Batches.Complete("bat_1", cancellationToken: ct),
            _ => client.Batches.Retrieve("bat_1", cancellationToken: ct),
        };
        await task;

        var (request, body) = sent.Single();
        Assert.Equal("http://localhost" + path, request.RequestUri!.ToString());
        Assert.Equal(action == "retrieve" ? HttpMethod.Get : HttpMethod.Post, request.Method);
        if (action == "continue")
        {
            Assert.Contains("\"shortfall\":\"overage\"", body);
        }
    }

    [Fact]
    public async Task Delete_ReadsDeleted()
    {
        var (client, sent) = Capture(
            "{\"success\":true,\"code\":200,\"data\":{\"object\":\"batch\",\"id\":\"bat_1\",\"deleted\":true}}"
        );

        var deleted = await client.Batches.Delete(
            "bat_1",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpMethod.Delete, sent.Single().Request.Method);
        Assert.True(deleted.Data!.Deleted);
    }

    [Fact]
    public async Task Results_PagesAndReadsRows()
    {
        var (client, sent) = Capture(
            "{\"success\":true,\"code\":200,\"data\":{\"data\":[{\"row\":1,\"vat_number\":\"GB288305674\",\"result\":\"valid\",\"confirmation_number\":\"VS-1\",\"match\":{\"result\":\"likely\",\"score\":90,\"fields\":{\"name\":{\"sent\":\"Weio\",\"result\":\"match\",\"score\":100,\"vies\":\"WEIO LTD\"}}}}],\"has_more\":true,\"next_after\":1}}"
        );

        var page = await client.Batches.Results(
            "bat_1",
            new() { After = 0, Limit = 1000 },
            TestContext.Current.CancellationToken
        );

        var uri = sent.Single().Request.RequestUri!;
        Assert.Equal("/batches/bat_1/results", uri.AbsolutePath);
        Assert.Contains("after=0", uri.Query);
        var row = page.Data!.Data!.Single();
        Assert.Equal("valid", row.Result);
        Assert.Equal("VS-1", row.ConfirmationNumber);
        Assert.Equal(100, row.Match!.Fields!["name"].Score);
        Assert.True(page.Data.HasMore);
        Assert.Equal(1, page.Data.NextAfter);
        page.Validate();
    }

    [Fact]
    public async Task ResultsCsv_ReturnsText()
    {
        var (client, sent) = Capture("row,vat_number\n1,GB288305674\n", "text/csv");

        var csv = await client.Batches.ResultsCsv(
            "bat_1",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal("/batches/bat_1/results.csv", sent.Single().Request.RequestUri!.AbsolutePath);
        Assert.StartsWith("row,vat_number", csv);
    }

    [Fact]
    public async Task Retrieve_EscapesTheID()
    {
        var (client, sent) = Capture(BatchJson);

        await client.Batches.Retrieve(
            "bat/../x",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal(
            "/batches/bat%2F..%2Fx",
            sent.Single()
                .Request.RequestUri!.GetComponents(
                    UriComponents.Path | UriComponents.KeepDelimiter,
                    UriFormat.UriEscaped
                )
        );
    }

    [Fact]
    public async Task Validate_SendsConsultationOptional_AndReadsConfirmationNumber()
    {
        var (client, sent) = Capture(
            "{\"success\":true,\"code\":200,\"data\":{\"valid\":true,\"confirmation_number\":\"VS-2\"}}"
        );

        var result = await client.Validate.Check(
            new ValidateCheckParams()
            {
                VatNumber = "FR12345678901",
                RequesterVatNumber = "FR98765432101",
                ConsultationOptional = true,
            },
            TestContext.Current.CancellationToken
        );

        Assert.Contains("consultation_optional=true", sent.Single().Request.RequestUri!.Query);
        Assert.Equal("VS-2", result.Data!.ConfirmationNumber);
        result.Validate();
    }

    const string Secret = "whsec_test";
    const string Payload =
        "{\"id\":\"evt_1\",\"type\":\"batch.completed\",\"created\":1793365200,\"livemode\":true,\"data\":{\"object\":{\"id\":\"bat_1\"}}}";
    static readonly DateTimeOffset Now = DateTimeOffset.FromUnixTimeSeconds(1793365200);

    static string Sign(long t, string payload, string secret = Secret)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(t + "." + payload));
        return string.Concat(hash.Select(b => b.ToString("x2")));
    }

    [Fact]
    public void ConstructEvent_AcceptsAValidSignature()
    {
        var header = "t=1793365200,v1=" + Sign(1793365200, Payload);

        var e = Webhook.ConstructEvent(Payload, header, Secret, now: Now);

        Assert.Equal("evt_1", e.ID);
        Assert.Equal("batch.completed", e.Type);
        Assert.Equal(1793365200, e.Created);
        Assert.True(e.Livemode);
        Assert.Equal("bat_1", e.DataObject!.Value.GetProperty("id").GetString());
    }

    [Fact]
    public void VerifySignature_AcceptsEitherSecretDuringARoll()
    {
        var header =
            "t=1793365200,v1="
            + Sign(1793365200, Payload, "whsec_old")
            + ",v1="
            + Sign(1793365200, Payload);

        Webhook.VerifySignature(Payload, header, Secret, now: Now);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("v1=abc")]
    [InlineData("t=1793365200")]
    [InlineData("t=1793365200,v1=00")]
    public void VerifySignature_RefusesBadHeaders(string? header)
    {
        Assert.Throws<WebhookSignatureException>(() =>
            Webhook.VerifySignature(Payload, header, Secret, now: Now)
        );
    }

    [Fact]
    public void VerifySignature_RefusesAChangedBody()
    {
        var header = "t=1793365200,v1=" + Sign(1793365200, Payload);

        Assert.Throws<WebhookSignatureException>(() =>
            Webhook.VerifySignature(Payload.Replace("true", "false"), header, Secret, now: Now)
        );
    }

    [Fact]
    public void VerifySignature_RefusesAnOldEvent_UnlessToleranceIsOff()
    {
        var header = "t=1793365200,v1=" + Sign(1793365200, Payload);
        var later = Now.AddSeconds(301);

        Assert.Throws<WebhookSignatureException>(() =>
            Webhook.VerifySignature(Payload, header, Secret, now: later)
        );
        Webhook.VerifySignature(Payload, header, Secret, TimeSpan.Zero, later);
    }
}
