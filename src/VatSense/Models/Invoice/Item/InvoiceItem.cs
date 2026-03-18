using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;
using VatSense.Exceptions;
using System = System;

namespace VatSense.Models.Invoice.Item;

[JsonConverter(typeof(JsonModelConverter<InvoiceItem, InvoiceItemFromRaw>))]
public sealed record class InvoiceItem : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public double? DiscountRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("discount_rate");
        }
        init { this._rawData.Set("discount_rate", value); }
    }

    public string? Item
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("item");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("item", value);
        }
    }

    public ApiEnum<string, Object>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Object>>("object");
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

    public double? PriceEach
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price_each");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price_each", value);
        }
    }

    public double? PriceTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("price_total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price_total", value);
        }
    }

    public double? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

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
        _ = this.ID;
        _ = this.DiscountRate;
        _ = this.Item;
        this.Object?.Validate();
        _ = this.PriceEach;
        _ = this.PriceTotal;
        _ = this.Quantity;
        _ = this.VatRate;
    }

    public InvoiceItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceItem(InvoiceItem invoiceItem)
        : base(invoiceItem) { }
#pragma warning restore CS8618

    public InvoiceItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceItemFromRaw.FromRawUnchecked"/>
    public static InvoiceItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceItemFromRaw : IFromRawJson<InvoiceItem>
{
    /// <inheritdoc/>
    public InvoiceItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ObjectConverter))]
public enum Object
{
    Item,
}

sealed class ObjectConverter : JsonConverter<Object>
{
    public override Object Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item" => Object.Item,
            _ => (Object)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Object value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Object.Item => "item",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
