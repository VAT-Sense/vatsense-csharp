using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;
using VatSense.Exceptions;

namespace VatSense.Models.Currency;

[JsonConverter(typeof(JsonModelConverter<VatPrice, VatPriceFromRaw>))]
public sealed record class VatPrice : JsonModel
{
    public ApiEnum<string, global::VatSense.Models.Currency.Object>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::VatSense.Models.Currency.Object>
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
    /// The price provided.
    /// </summary>
    public double? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price", value);
        }
    }

    /// <summary>
    /// The calculated price exclusive of VAT.
    /// </summary>
    public double? PriceExclVat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price_excl_vat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price_excl_vat", value);
        }
    }

    /// <summary>
    /// The calculated price inclusive of VAT.
    /// </summary>
    public double? PriceInclVat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price_incl_vat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price_incl_vat", value);
        }
    }

    /// <summary>
    /// Whether the price is inclusive or exclusive of VAT.
    /// </summary>
    public ApiEnum<string, VatPriceTaxType>? TaxType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VatPriceTaxType>>("tax_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_type", value);
        }
    }

    /// <summary>
    /// The total VAT amount.
    /// </summary>
    public double? Vat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("vat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vat", value);
        }
    }

    /// <summary>
    /// The VAT rate percentage.
    /// </summary>
    public double? VatRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("vat_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vat_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Object?.Validate();
        _ = this.Price;
        _ = this.PriceExclVat;
        _ = this.PriceInclVat;
        this.TaxType?.Validate();
        _ = this.Vat;
        _ = this.VatRate;
    }

    public VatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VatPrice(VatPrice vatPrice)
        : base(vatPrice) { }
#pragma warning restore CS8618

    public VatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VatPriceFromRaw.FromRawUnchecked"/>
    public static VatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VatPriceFromRaw : IFromRawJson<VatPrice>
{
    /// <inheritdoc/>
    public VatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VatPrice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ObjectConverter))]
public enum Object
{
    VatPrice,
}

sealed class ObjectConverter : JsonConverter<global::VatSense.Models.Currency.Object>
{
    public override global::VatSense.Models.Currency.Object Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vat_price" => global::VatSense.Models.Currency.Object.VatPrice,
            _ => (global::VatSense.Models.Currency.Object)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::VatSense.Models.Currency.Object value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::VatSense.Models.Currency.Object.VatPrice => "vat_price",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the price is inclusive or exclusive of VAT.
/// </summary>
[JsonConverter(typeof(VatPriceTaxTypeConverter))]
public enum VatPriceTaxType
{
    Incl,
    Excl,
}

sealed class VatPriceTaxTypeConverter : JsonConverter<VatPriceTaxType>
{
    public override VatPriceTaxType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incl" => VatPriceTaxType.Incl,
            "excl" => VatPriceTaxType.Excl,
            _ => (VatPriceTaxType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VatPriceTaxType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VatPriceTaxType.Incl => "incl",
                VatPriceTaxType.Excl => "excl",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
