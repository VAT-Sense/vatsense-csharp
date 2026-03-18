using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Invoice;

[JsonConverter(typeof(JsonModelConverter<InvoiceConversionInput, InvoiceConversionInputFromRaw>))]
public sealed record class InvoiceConversionInput : JsonModel
{
    /// <summary>
    /// The 3-character currency code for the conversion.
    /// </summary>
    public required string CurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency_code");
        }
        init { this._rawData.Set("currency_code", value); }
    }

    /// <summary>
    /// The rate of conversion.
    /// </summary>
    public required double Rate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("rate");
        }
        init { this._rawData.Set("rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyCode;
        _ = this.Rate;
    }

    public InvoiceConversionInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceConversionInput(InvoiceConversionInput invoiceConversionInput)
        : base(invoiceConversionInput) { }
#pragma warning restore CS8618

    public InvoiceConversionInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceConversionInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceConversionInputFromRaw.FromRawUnchecked"/>
    public static InvoiceConversionInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceConversionInputFromRaw : IFromRawJson<InvoiceConversionInput>
{
    /// <inheritdoc/>
    public InvoiceConversionInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceConversionInput.FromRawUnchecked(rawData);
}
