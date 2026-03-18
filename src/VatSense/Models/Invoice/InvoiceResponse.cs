using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Invoice;

[JsonConverter(typeof(JsonModelConverter<InvoiceResponse, InvoiceResponseFromRaw>))]
public sealed record class InvoiceResponse : JsonModel
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

    public InvoiceInvoice? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvoiceInvoice>("data");
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

    public InvoiceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceResponse(InvoiceResponse invoiceResponse)
        : base(invoiceResponse) { }
#pragma warning restore CS8618

    public InvoiceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceResponseFromRaw : IFromRawJson<InvoiceResponse>
{
    /// <inheritdoc/>
    public InvoiceResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceResponse.FromRawUnchecked(rawData);
}
