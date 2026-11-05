using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Vatsense;
using Vatsense.Models.Invoice;
using Vatsense.Models.Invoice.Item;
using Vatsense.Models.Rates;
using Vatsense.Models.Validate;

namespace Vatsense.Tests;

/// <summary>
/// The API additions of November 2026, sent through a mocked HTTP handler.
/// </summary>
public class ApiAdditionsTest
{
    static (VatSenseClient Client, List<(HttpRequestMessage Request, string? Body)> Sent) Capture(
        string answer
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
                async (HttpRequestMessage request, CancellationToken _) =>
                {
                    string? body =
                        request.Content == null ? null : await request.Content.ReadAsStringAsync();
                    sent.Add((request, body));
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(
                            answer,
                            System.Text.Encoding.UTF8,
                            "application/json"
                        ),
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

    static InvoiceCreateParams Invoice(string? idempotencyKey, string? originalInvoiceId) =>
        new()
        {
            Business = new()
            {
                Name = "VAT Sense",
                Address = "London",
                VatNumber = "GB12345678",
            },
            CurrencyCode = "GBP",
            Date = "2026-11-05",
            TaxPoint = "2026-11-05",
            Items =
            [
                new InvoiceItemInput()
                {
                    Item = "Plan",
                    PriceEach = 10,
                    Quantity = 1,
                    VatRate = 20,
                },
            ],
            OriginalInvoiceId = originalInvoiceId,
            IdempotencyKey = idempotencyKey,
        };

    [Fact]
    public async Task InvoiceCreate_SendsIdempotencyKeyHeader()
    {
        var (client, sent) = Capture("{\"success\":true,\"code\":200,\"data\":{}}");

        await client.Invoice.Create(
            Invoice("order-203", "in5aeae457cda2a"),
            TestContext.Current.CancellationToken
        );

        var (request, body) = sent.Single();
        Assert.Equal("order-203", request.Headers.GetValues("Idempotency-Key").Single());
        using var json = JsonDocument.Parse(body!);
        Assert.Equal(
            "in5aeae457cda2a",
            json.RootElement.GetProperty("original_invoice_id").GetString()
        );
        Assert.False(json.RootElement.TryGetProperty("Idempotency-Key", out _));
    }

    [Fact]
    public async Task InvoiceCreate_WithoutKey_SendsNoHeader()
    {
        var (client, sent) = Capture("{\"success\":true,\"code\":200,\"data\":{}}");

        await client.Invoice.Create(Invoice(null, null), TestContext.Current.CancellationToken);

        Assert.False(sent.Single().Request.Headers.Contains("Idempotency-Key"));
    }

    [Fact]
    public async Task Validate_SendsMatchParameters_AndReadsMatch()
    {
        var (client, sent) = Capture(
            "{\"success\":true,\"code\":200,\"data\":{\"valid\":true,\"match\":{\"result\":\"likely\",\"score\":90,\"fields\":{\"company_name\":{\"result\":\"match\",\"score\":100,\"vies\":null}}}}}"
        );

        var result = await client.Validate.Check(
            new ValidateCheckParams()
            {
                VatNumber = "GB288305674",
                MatchCompanyName = "Weio Ltd",
                MatchPostcode = "SW3 1GL",
            },
            TestContext.Current.CancellationToken
        );

        var query = sent.Single().Request.RequestUri!.Query;
        Assert.Contains("match_company_name=Weio%20Ltd", query);
        Assert.Contains("match_postcode=SW3%201GL", query);
        Assert.Equal("likely", result.Data!.Match!.Result);
        Assert.Equal(90, result.Data.Match.Score);
        Assert.Equal(100, result.Data.Match.Fields!["company_name"].Score);
        Assert.Null(result.Data.Match.Fields["company_name"].Vies);
        result.Validate();
    }

    [Fact]
    public async Task RateList_SendsProvinces()
    {
        var (client, sent) = Capture("{\"success\":true,\"code\":200,\"data\":[]}");

        await client.Rates.List(
            new RateListParams() { Provinces = false },
            TestContext.Current.CancellationToken
        );

        Assert.Contains("provinces=false", sent.Single().Request.RequestUri!.Query);
    }
}
