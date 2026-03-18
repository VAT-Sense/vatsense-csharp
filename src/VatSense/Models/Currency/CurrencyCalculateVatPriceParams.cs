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
/// Calculate the inclusive and exclusive VAT price on a given amount and VAT rate.
/// This is a standalone calculation that does not look up rates by country.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CurrencyCalculateVatPriceParams : ParamsBase
{
    /// <summary>
    /// The price to calculate on. Must be a string with exactly 2 decimal places
    /// (e.g. "30.00", "59.95").
    /// </summary>
    public required string Price
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("price");
        }
        init { this._rawQueryData.Set("price", value); }
    }

    /// <summary>
    /// Whether the provided price is inclusive or exclusive of VAT.
    /// </summary>
    public required ApiEnum<string, TaxType> TaxType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, TaxType>>("tax_type");
        }
        init { this._rawQueryData.Set("tax_type", value); }
    }

    /// <summary>
    /// A percentage VAT rate to use for the calculation.
    /// </summary>
    public required double VatRate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<double>("vat_rate");
        }
        init { this._rawQueryData.Set("vat_rate", value); }
    }

    public CurrencyCalculateVatPriceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyCalculateVatPriceParams(
        CurrencyCalculateVatPriceParams currencyCalculateVatPriceParams
    )
        : base(currencyCalculateVatPriceParams) { }
#pragma warning restore CS8618

    public CurrencyCalculateVatPriceParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyCalculateVatPriceParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CurrencyCalculateVatPriceParams FromRawUnchecked(
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

    public virtual bool Equals(CurrencyCalculateVatPriceParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/currency/price")
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
/// Whether the provided price is inclusive or exclusive of VAT.
/// </summary>
[JsonConverter(typeof(TaxTypeConverter))]
public enum TaxType
{
    Incl,
    Excl,
}

sealed class TaxTypeConverter : JsonConverter<TaxType>
{
    public override TaxType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incl" => TaxType.Incl,
            "excl" => TaxType.Excl,
            _ => (TaxType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, TaxType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxType.Incl => "incl",
                TaxType.Excl => "excl",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
