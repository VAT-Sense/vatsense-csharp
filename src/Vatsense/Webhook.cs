using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Vatsense.Exceptions;

namespace Vatsense;

/// <summary>
/// Checks the <c>VatSense-Signature</c> header of webhook events.
///
/// <para>Every event is a signed JSON <c>POST</c> with a header such as
/// <c>t=1793365200,v1=5257a8...</c>: <c>v1</c> is the hex HMAC-SHA256 of the timestamp,
/// a full stop and the raw request body, keyed with the endpoint's signing secret
/// (<c>whsec_...</c>). For 24 hours after a secret is rolled the header carries a
/// second <c>v1</c>, so any match is accepted.</para>
/// </summary>
public static class Webhook
{
    /// <summary>
    /// The name of the header that carries the signature.
    /// </summary>
    public const string SignatureHeader = "VatSense-Signature";

    /// <summary>
    /// Events whose timestamp is further than this from now are refused.
    /// </summary>
    public static readonly TimeSpan DefaultTolerance = TimeSpan.FromMinutes(5);

    /// <summary>
    /// Checks an event's signature header against its raw body, exactly as received.
    /// </summary>
    /// <param name="payload">The raw request body.</param>
    /// <param name="header">The value of the <c>VatSense-Signature</c> header.</param>
    /// <param name="secret">The endpoint's signing secret, starting <c>whsec_</c>.</param>
    /// <param name="tolerance">How old an event may be; <see cref="TimeSpan.Zero"/> or less skips the check. Defaults to 5 minutes.</param>
    /// <param name="now">The current time, for tests.</param>
    /// <exception cref="WebhookSignatureException">The signature is missing, malformed, too old or does not match.</exception>
    public static void VerifySignature(
        string payload,
        string? header,
        string secret,
        TimeSpan? tolerance = null,
        DateTimeOffset? now = null
    )
    {
        if (string.IsNullOrEmpty(header))
        {
            throw new WebhookSignatureException("The VatSense-Signature header is missing.");
        }

        long? timestamp = null;
        var signatures = new List<string>();
        foreach (var part in header!.Split(','))
        {
            var index = part.IndexOf('=');
            if (index <= 0)
            {
                continue;
            }
            var key = part.Substring(0, index).Trim();
            var value = part.Substring(index + 1).Trim();
            if (key == "t")
            {
                if (
                    long.TryParse(
                        value,
                        NumberStyles.None,
                        CultureInfo.InvariantCulture,
                        out var parsed
                    )
                )
                {
                    timestamp = parsed;
                }
            }
            else if (key == "v1" && value.Length > 0)
            {
                signatures.Add(value.ToLowerInvariant());
            }
        }

        if (timestamp == null || signatures.Count == 0)
        {
            throw new WebhookSignatureException(
                "The VatSense-Signature header has no timestamp or no v1 signature."
            );
        }

        var limit = tolerance ?? DefaultTolerance;
        if (limit > TimeSpan.Zero)
        {
            var current = (now ?? DateTimeOffset.UtcNow).ToUnixTimeSeconds();
            if (Math.Abs(current - timestamp.Value) > (long)limit.TotalSeconds)
            {
                throw new WebhookSignatureException(
                    "The event's timestamp is outside the tolerance."
                );
            }
        }

        var expected = Sign(timestamp.Value, payload, secret);
        foreach (var signature in signatures)
        {
            if (FixedTimeEquals(expected, signature))
            {
                return;
            }
        }

        throw new WebhookSignatureException("No signature matches the payload.");
    }

    /// <summary>
    /// Checks the signature, then parses the event.
    /// </summary>
    /// <returns>The event, with <c>id</c>, <c>type</c>, <c>created</c>, <c>livemode</c> and <c>data.object</c>.</returns>
    /// <exception cref="WebhookSignatureException">The signature does not check out, or the payload is not a JSON object.</exception>
    public static WebhookEvent ConstructEvent(
        string payload,
        string? header,
        string secret,
        TimeSpan? tolerance = null,
        DateTimeOffset? now = null
    )
    {
        VerifySignature(payload, header, secret, tolerance, now);
        JsonElement root;
        try
        {
            using var document = JsonDocument.Parse(payload);
            root = document.RootElement.Clone();
        }
        catch (JsonException e)
        {
            throw new WebhookSignatureException("The payload is not JSON.", e);
        }
        if (root.ValueKind != JsonValueKind.Object)
        {
            throw new WebhookSignatureException("The payload is not a JSON object.");
        }
        return new WebhookEvent(root);
    }

    static string Sign(long timestamp, string payload, string secret)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var hash = hmac.ComputeHash(
            Encoding.UTF8.GetBytes(timestamp.ToString(CultureInfo.InvariantCulture) + "." + payload)
        );
        var hex = new StringBuilder(hash.Length * 2);
        foreach (var b in hash)
        {
            hex.Append(b.ToString("x2", CultureInfo.InvariantCulture));
        }
        return hex.ToString();
    }

    static bool FixedTimeEquals(string a, string b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }
        var diff = 0;
        for (var i = 0; i < a.Length; i++)
        {
            diff |= a[i] ^ b[i];
        }
        return diff == 0;
    }
}

/// <summary>
/// A webhook event whose signature has been checked.
/// </summary>
public sealed class WebhookEvent
{
    internal WebhookEvent(JsonElement raw)
    {
        Raw = raw;
    }

    /// <summary>
    /// The whole event as JSON.
    /// </summary>
    public JsonElement Raw { get; }

    /// <summary>
    /// The event's ID, such as <c>evt_...</c>. The same event can arrive more than once.
    /// </summary>
    public string? ID => Text("id");

    /// <summary>
    /// The event's type, such as <c>batch.completed</c>.
    /// </summary>
    public string? Type => Text("type");

    /// <summary>
    /// When the event happened, in Unix seconds.
    /// </summary>
    public long? Created =>
        Raw.TryGetProperty("created", out var v) && v.ValueKind == JsonValueKind.Number
            ? v.GetInt64()
            : null;

    /// <summary>
    /// False for an event from test mode.
    /// </summary>
    public bool? Livemode =>
        Raw.TryGetProperty("livemode", out var v)
        && (v.ValueKind == JsonValueKind.True || v.ValueKind == JsonValueKind.False)
            ? v.GetBoolean()
            : null;

    /// <summary>
    /// The event's <c>data.object</c>, such as the batch for a <c>batch.*</c> event.
    /// </summary>
    public JsonElement? DataObject =>
        Raw.TryGetProperty("data", out var data)
        && data.ValueKind == JsonValueKind.Object
        && data.TryGetProperty("object", out var obj)
            ? obj
            : null;

    string? Text(string name) =>
        Raw.TryGetProperty(name, out var v) && v.ValueKind == JsonValueKind.String
            ? v.GetString()
            : null;
}
