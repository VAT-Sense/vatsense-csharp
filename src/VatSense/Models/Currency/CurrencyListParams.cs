using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;
using VatSense.Exceptions;

namespace VatSense.Models.Currency;

/// <summary>
/// Returns a list of all currency conversion rates sourced from HMRC (GBP) and the
/// European Central Bank (EUR).
///
/// <para>You can optionally filter by source and target currency.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CurrencyListParams : ParamsBase
{
    /// <summary>
    /// The 3-character currency code(s) to convert from (e.g. "USD", "CAD"). Can
    /// be a comma-separated list without spaces (e.g. "USD,CAD,AUD").
    /// </summary>
    public string? From
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("from", value);
        }
    }

    /// <summary>
    /// The 3-character target currency code. Must be either "GBP" or "EUR".
    /// </summary>
    public ApiEnum<string, To>? To
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, To>>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("to", value);
        }
    }

    public CurrencyListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyListParams(CurrencyListParams currencyListParams)
        : base(currencyListParams) { }
#pragma warning restore CS8618

    public CurrencyListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CurrencyListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CurrencyListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/currency")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The 3-character target currency code. Must be either "GBP" or "EUR".
/// </summary>
[JsonConverter(typeof(ToConverter))]
public enum To
{
    Gbp,
    Eur,
}

sealed class ToConverter : JsonConverter<To>
{
    public override To Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GBP" => To.Gbp,
            "EUR" => To.Eur,
            _ => (To)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, To value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                To.Gbp => "GBP",
                To.Eur => "EUR",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
