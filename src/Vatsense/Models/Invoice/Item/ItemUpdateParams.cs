using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Vatsense.Core;

namespace Vatsense.Models.Invoice.Item;

/// <summary>
/// Update a specific line item on an invoice.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ItemUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string InvoiceID { get; init; }

    public string? ItemID { get; init; }

    /// <summary>
    /// The description of the line item.
    /// </summary>
    public required string Item
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("item");
        }
        init { this._rawBodyData.Set("item", value); }
    }

    /// <summary>
    /// The price per item. Must be a decimal with 2 decimal places.
    /// </summary>
    public required double PriceEach
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<double>("price_each");
        }
        init { this._rawBodyData.Set("price_each", value); }
    }

    /// <summary>
    /// The quantity of the item.
    /// </summary>
    public required double Quantity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawBodyData.Set("quantity", value); }
    }

    /// <summary>
    /// A percentage VAT rate for this item.
    /// </summary>
    public required double VatRate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<double>("vat_rate");
        }
        init { this._rawBodyData.Set("vat_rate", value); }
    }

    /// <summary>
    /// A percentage discount to apply to the price.
    /// </summary>
    public double? DiscountRate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("discount_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("discount_rate", value);
        }
    }

    public ItemUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemUpdateParams(ItemUpdateParams itemUpdateParams)
        : base(itemUpdateParams)
    {
        this.InvoiceID = itemUpdateParams.InvoiceID;
        this.ItemID = itemUpdateParams.ItemID;

        this._rawBodyData = new(itemUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ItemUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string invoiceID,
        string itemID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InvoiceID = invoiceID;
        this.ItemID = itemID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ItemUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string invoiceID,
        string itemID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            invoiceID,
            itemID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InvoiceID"] = JsonSerializer.SerializeToElement(this.InvoiceID),
                    ["ItemID"] = JsonSerializer.SerializeToElement(this.ItemID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ItemUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.InvoiceID.Equals(other.InvoiceID)
            && (this.ItemID?.Equals(other.ItemID) ?? other.ItemID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoice/{0}/item/{1}", this.InvoiceID, this.ItemID)
        )
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
