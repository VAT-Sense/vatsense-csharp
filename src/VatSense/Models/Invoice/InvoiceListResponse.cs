using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Invoice;

[JsonConverter(typeof(JsonModelConverter<InvoiceListResponse, InvoiceListResponseFromRaw>))]
public sealed record class InvoiceListResponse : JsonModel
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

    public IReadOnlyList<InvoiceInvoice>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InvoiceInvoice>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<InvoiceInvoice>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.Success;
    }

    public InvoiceListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListResponse(InvoiceListResponse invoiceListResponse)
        : base(invoiceListResponse) { }
#pragma warning restore CS8618

    public InvoiceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListResponseFromRaw : IFromRawJson<InvoiceListResponse>
{
    /// <inheritdoc/>
    public InvoiceListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceListResponse.FromRawUnchecked(rawData);
}
