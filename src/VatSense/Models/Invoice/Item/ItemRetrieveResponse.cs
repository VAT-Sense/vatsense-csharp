using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Invoice.Item;

[JsonConverter(typeof(JsonModelConverter<ItemRetrieveResponse, ItemRetrieveResponseFromRaw>))]
public sealed record class ItemRetrieveResponse : JsonModel
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

    public InvoiceItem? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvoiceItem>("data");
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

    public ItemRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemRetrieveResponse(ItemRetrieveResponse itemRetrieveResponse)
        : base(itemRetrieveResponse) { }
#pragma warning restore CS8618

    public ItemRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ItemRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemRetrieveResponseFromRaw : IFromRawJson<ItemRetrieveResponse>
{
    /// <inheritdoc/>
    public ItemRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ItemRetrieveResponse.FromRawUnchecked(rawData);
}
