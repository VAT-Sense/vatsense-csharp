using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;

namespace Vatsense.Models.Invoice;

[JsonConverter(typeof(JsonModelConverter<InvoiceDeleteResponse, InvoiceDeleteResponseFromRaw>))]
public sealed record class InvoiceDeleteResponse : JsonModel
{
    public required long Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Success;
    }

    public InvoiceDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceDeleteResponse(InvoiceDeleteResponse invoiceDeleteResponse)
        : base(invoiceDeleteResponse) { }
#pragma warning restore CS8618

    public InvoiceDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceDeleteResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceDeleteResponseFromRaw : IFromRawJson<InvoiceDeleteResponse>
{
    /// <inheritdoc/>
    public InvoiceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceDeleteResponse.FromRawUnchecked(rawData);
}
