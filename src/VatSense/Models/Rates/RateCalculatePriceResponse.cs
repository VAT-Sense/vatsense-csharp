using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;
using VatSense.Exceptions;
using Currency = VatSense.Models.Currency;

namespace VatSense.Models.Rates;

[JsonConverter(
    typeof(JsonModelConverter<RateCalculatePriceResponse, RateCalculatePriceResponseFromRaw>)
)]
public sealed record class RateCalculatePriceResponse : JsonModel
{
    public long? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        this.Data?.Validate();
        _ = this.Success;
    }

    public RateCalculatePriceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateCalculatePriceResponse(RateCalculatePriceResponse rateCalculatePriceResponse)
        : base(rateCalculatePriceResponse) { }
#pragma warning restore CS8618

    public RateCalculatePriceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateCalculatePriceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateCalculatePriceResponseFromRaw.FromRawUnchecked"/>
    public static RateCalculatePriceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateCalculatePriceResponseFromRaw : IFromRawJson<RateCalculatePriceResponse>
{
    /// <inheritdoc/>
    public RateCalculatePriceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RateCalculatePriceResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public ApiEnum<string, DataObject>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataObject>>("object");
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

    public Currency::VatPrice? VatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Currency::VatPrice>("vat_price");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vat_price", value);
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
        this.VatPrice?.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataObjectConverter))]
public enum DataObject
{
    Rate,
}

sealed class DataObjectConverter : JsonConverter<DataObject>
{
    public override DataObject Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rate" => DataObject.Rate,
            _ => (DataObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataObject.Rate => "rate",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
