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
/// Convert a foreign currency amount to either GBP or EUR using official exchange rates.
///
/// <para>GBP rates are from HMRC (updated on the 1st of every month). EUR rates
/// are from the European Central Bank (updated around 16:00 CET on working days).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CurrencyConvertParams : ParamsBase
{
    /// <summary>
    /// The amount to convert. Must be a string with exactly 2 decimal places (e.g. "39.99").
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("amount");
        }
        init { this._rawQueryData.Set("amount", value); }
    }

    /// <summary>
    /// The 3-character source currency code (e.g. "USD", "CAD").
    /// </summary>
    public required string From
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("from");
        }
        init { this._rawQueryData.Set("from", value); }
    }

    /// <summary>
    /// The 3-character target currency code. Must be either "GBP" or "EUR".
    /// </summary>
    public required ApiEnum<string, CurrencyConvertParamsTo> To
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, CurrencyConvertParamsTo>>(
                "to"
            );
        }
        init { this._rawQueryData.Set("to", value); }
    }

    public CurrencyConvertParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyConvertParams(CurrencyConvertParams currencyConvertParams)
        : base(currencyConvertParams) { }
#pragma warning restore CS8618

    public CurrencyConvertParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyConvertParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CurrencyConvertParams FromRawUnchecked(
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

    public virtual bool Equals(CurrencyConvertParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/currency/convert")
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
[JsonConverter(typeof(CurrencyConvertParamsToConverter))]
public enum CurrencyConvertParamsTo
{
    Gbp,
    Eur,
}

sealed class CurrencyConvertParamsToConverter : JsonConverter<CurrencyConvertParamsTo>
{
    public override CurrencyConvertParamsTo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GBP" => CurrencyConvertParamsTo.Gbp,
            "EUR" => CurrencyConvertParamsTo.Eur,
            _ => (CurrencyConvertParamsTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CurrencyConvertParamsTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CurrencyConvertParamsTo.Gbp => "GBP",
                CurrencyConvertParamsTo.Eur => "EUR",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
