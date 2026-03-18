using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;
using VatSense.Exceptions;

namespace VatSense.Models.Currency;

[JsonConverter(typeof(JsonModelConverter<CurrencyConvertResponse, CurrencyConvertResponseFromRaw>))]
public sealed record class CurrencyConvertResponse : JsonModel
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

    public CurrencyConvertResponseData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CurrencyConvertResponseData>("data");
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

    public CurrencyConvertResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyConvertResponse(CurrencyConvertResponse currencyConvertResponse)
        : base(currencyConvertResponse) { }
#pragma warning restore CS8618

    public CurrencyConvertResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyConvertResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyConvertResponseFromRaw.FromRawUnchecked"/>
    public static CurrencyConvertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyConvertResponseFromRaw : IFromRawJson<CurrencyConvertResponse>
{
    /// <inheritdoc/>
    public CurrencyConvertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CurrencyConvertResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<CurrencyConvertResponseData, CurrencyConvertResponseDataFromRaw>)
)]
public sealed record class CurrencyConvertResponseData : JsonModel
{
    /// <summary>
    /// The original amount.
    /// </summary>
    public double? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    /// <summary>
    /// The converted amount.
    /// </summary>
    public double? Converted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("converted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("converted", value);
        }
    }

    public string? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    public ApiEnum<string, CurrencyConvertResponseDataObject>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CurrencyConvertResponseDataObject>
            >("object");
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

    /// <summary>
    /// The exchange rate used.
    /// </summary>
    public double? Rate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    public string? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Converted;
        _ = this.From;
        this.Object?.Validate();
        _ = this.Rate;
        _ = this.To;
    }

    public CurrencyConvertResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyConvertResponseData(CurrencyConvertResponseData currencyConvertResponseData)
        : base(currencyConvertResponseData) { }
#pragma warning restore CS8618

    public CurrencyConvertResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyConvertResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyConvertResponseDataFromRaw.FromRawUnchecked"/>
    public static CurrencyConvertResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyConvertResponseDataFromRaw : IFromRawJson<CurrencyConvertResponseData>
{
    /// <inheritdoc/>
    public CurrencyConvertResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CurrencyConvertResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CurrencyConvertResponseDataObjectConverter))]
public enum CurrencyConvertResponseDataObject
{
    Conversion,
}

sealed class CurrencyConvertResponseDataObjectConverter
    : JsonConverter<CurrencyConvertResponseDataObject>
{
    public override CurrencyConvertResponseDataObject Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "conversion" => CurrencyConvertResponseDataObject.Conversion,
            _ => (CurrencyConvertResponseDataObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CurrencyConvertResponseDataObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CurrencyConvertResponseDataObject.Conversion => "conversion",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
