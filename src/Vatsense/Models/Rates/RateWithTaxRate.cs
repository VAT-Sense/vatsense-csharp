using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;
using Vatsense.Exceptions;

namespace Vatsense.Models.Rates;

[JsonConverter(typeof(JsonModelConverter<RateWithTaxRate, RateWithTaxRateFromRaw>))]
public sealed record class RateWithTaxRate : JsonModel
{
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    public string? CountryName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_name", value);
        }
    }

    public bool? Eu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("eu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eu", value);
        }
    }

    public ApiEnum<string, RateWithTaxRateObject>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RateWithTaxRateObject>>("object");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    public TaxRate? TaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TaxRate>("tax_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.CountryName;
        _ = this.Eu;
        this.Object?.Validate();
        this.TaxRate?.Validate();
    }

    public RateWithTaxRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateWithTaxRate(RateWithTaxRate rateWithTaxRate)
        : base(rateWithTaxRate) { }
#pragma warning restore CS8618

    public RateWithTaxRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateWithTaxRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateWithTaxRateFromRaw.FromRawUnchecked"/>
    public static RateWithTaxRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateWithTaxRateFromRaw : IFromRawJson<RateWithTaxRate>
{
    /// <inheritdoc/>
    public RateWithTaxRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RateWithTaxRate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RateWithTaxRateObjectConverter))]
public enum RateWithTaxRateObject
{
    Rate,
}

sealed class RateWithTaxRateObjectConverter : JsonConverter<RateWithTaxRateObject>
{
    public override RateWithTaxRateObject Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rate" => RateWithTaxRateObject.Rate,
            _ => (RateWithTaxRateObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RateWithTaxRateObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RateWithTaxRateObject.Rate => "rate",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
