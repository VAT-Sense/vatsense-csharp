using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;

namespace Vatsense.Models.Invoice.Item;

[JsonConverter(typeof(JsonModelConverter<InvoiceItemInput, InvoiceItemInputFromRaw>))]
public sealed record class InvoiceItemInput : JsonModel
{
    /// <summary>
    /// The description of the line item.
    /// </summary>
    public required string Item
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item");
        }
        init { this._rawData.Set("item", value); }
    }

    /// <summary>
    /// The price per item. Must be a decimal with 2 decimal places.
    /// </summary>
    public required double PriceEach
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("price_each");
        }
        init { this._rawData.Set("price_each", value); }
    }

    /// <summary>
    /// The quantity of the item.
    /// </summary>
    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// A percentage VAT rate for this item.
    /// </summary>
    public required double VatRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("vat_rate");
        }
        init { this._rawData.Set("vat_rate", value); }
    }

    /// <summary>
    /// A percentage discount to apply to the price.
    /// </summary>
    public double? DiscountRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("discount_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount_rate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Item;
        _ = this.PriceEach;
        _ = this.Quantity;
        _ = this.VatRate;
        _ = this.DiscountRate;
    }

    public InvoiceItemInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceItemInput(InvoiceItemInput invoiceItemInput)
        : base(invoiceItemInput) { }
#pragma warning restore CS8618

    public InvoiceItemInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceItemInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceItemInputFromRaw.FromRawUnchecked"/>
    public static InvoiceItemInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceItemInputFromRaw : IFromRawJson<InvoiceItemInput>
{
    /// <inheritdoc/>
    public InvoiceItemInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceItemInput.FromRawUnchecked(rawData);
}
