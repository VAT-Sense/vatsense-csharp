using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Invoice.Item;
using System = System;

namespace VatSense.Models.Invoice;

[JsonConverter(typeof(JsonModelConverter<InvoiceInvoice, InvoiceInvoiceFromRaw>))]
public sealed record class InvoiceInvoice : JsonModel
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

    public Business? Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Business>("business");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("business", value);
        }
    }

    public InvoiceConversionInput? Conversion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvoiceConversionInput>("conversion");
        }
        init { this._rawData.Set("conversion", value); }
    }

    public System::DateTimeOffset? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
        }
    }

    public string? CurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_code", value);
        }
    }

    public Customer? Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Customer>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    public string? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("date", value);
        }
    }

    public bool? HasVat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_vat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_vat", value);
        }
    }

    public string? InvoiceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invoice_number", value);
        }
    }

    /// <summary>
    /// Unique URL to view the invoice. Append "/pdf" to download a PDF copy.
    /// </summary>
    public string? InvoiceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invoice_url", value);
        }
    }

    public bool? IsCopy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_copy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_copy", value);
        }
    }

    public bool? IsReverseCharge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_reverse_charge");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_reverse_charge", value);
        }
    }

    public IReadOnlyList<InvoiceItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InvoiceItem>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<InvoiceItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init { this._rawData.Set("notes", value); }
    }

    public long? NumItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("num_items", value);
        }
    }

    public ApiEnum<string, global::VatSense.Models.Invoice.Object>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::VatSense.Models.Invoice.Object>
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

    public string? TaxPoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_point");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_point", value);
        }
    }

    public ApiEnum<string, InvoiceInvoiceTaxType>? TaxType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InvoiceInvoiceTaxType>>(
                "tax_type"
            );
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

    public Totals? Totals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Totals>("totals");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totals", value);
        }
    }

    public ApiEnum<string, InvoiceInvoiceType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InvoiceInvoiceType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public System::DateTimeOffset? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
        }
    }

    public bool? ZeroRated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("zero_rated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("zero_rated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Business?.Validate();
        this.Conversion?.Validate();
        _ = this.Created;
        _ = this.CurrencyCode;
        this.Customer?.Validate();
        _ = this.Date;
        _ = this.HasVat;
        _ = this.InvoiceNumber;
        _ = this.InvoiceUrl;
        _ = this.IsCopy;
        _ = this.IsReverseCharge;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Notes;
        _ = this.NumItems;
        this.Object?.Validate();
        _ = this.TaxPoint;
        this.TaxType?.Validate();
        this.Totals?.Validate();
        this.Type?.Validate();
        _ = this.Updated;
        _ = this.ZeroRated;
    }

    public InvoiceInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceInvoice(InvoiceInvoice invoiceInvoice)
        : base(invoiceInvoice) { }
#pragma warning restore CS8618

    public InvoiceInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceInvoiceFromRaw.FromRawUnchecked"/>
    public static InvoiceInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceInvoiceFromRaw : IFromRawJson<InvoiceInvoice>
{
    /// <inheritdoc/>
    public InvoiceInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceInvoice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Business, BusinessFromRaw>))]
public sealed record class Business : JsonModel
{
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    public string? CompanyNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company_number", value);
        }
    }

    public string? Logo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logo");
        }
        init { this._rawData.Set("logo", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? VatNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vat_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vat_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.CompanyNumber;
        _ = this.Logo;
        _ = this.Name;
        _ = this.VatNumber;
    }

    public Business() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Business(Business business)
        : base(business) { }
#pragma warning restore CS8618

    public Business(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Business(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BusinessFromRaw.FromRawUnchecked"/>
    public static Business FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BusinessFromRaw : IFromRawJson<Business>
{
    /// <inheritdoc/>
    public Business FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Business.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Customer, CustomerFromRaw>))]
public sealed record class Customer : JsonModel
{
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    public string? CompanyNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company_number", value);
        }
    }

    public string? Logo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logo");
        }
        init { this._rawData.Set("logo", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? VatNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vat_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vat_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.CompanyNumber;
        _ = this.Logo;
        _ = this.Name;
        _ = this.VatNumber;
    }

    public Customer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Customer(Customer customer)
        : base(customer) { }
#pragma warning restore CS8618

    public Customer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerFromRaw.FromRawUnchecked"/>
    public static Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerFromRaw : IFromRawJson<Customer>
{
    /// <inheritdoc/>
    public Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Customer.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::VatSense.Models.Invoice.ObjectConverter))]
public enum Object
{
    Invoice,
}

sealed class ObjectConverter : JsonConverter<global::VatSense.Models.Invoice.Object>
{
    public override global::VatSense.Models.Invoice.Object Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invoice" => global::VatSense.Models.Invoice.Object.Invoice,
            _ => (global::VatSense.Models.Invoice.Object)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::VatSense.Models.Invoice.Object value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::VatSense.Models.Invoice.Object.Invoice => "invoice",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceInvoiceTaxTypeConverter))]
public enum InvoiceInvoiceTaxType
{
    Incl,
    Excl,
}

sealed class InvoiceInvoiceTaxTypeConverter : JsonConverter<InvoiceInvoiceTaxType>
{
    public override InvoiceInvoiceTaxType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incl" => InvoiceInvoiceTaxType.Incl,
            "excl" => InvoiceInvoiceTaxType.Excl,
            _ => (InvoiceInvoiceTaxType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceInvoiceTaxType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceInvoiceTaxType.Incl => "incl",
                InvoiceInvoiceTaxType.Excl => "excl",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Totals, TotalsFromRaw>))]
public sealed record class Totals : JsonModel
{
    /// <summary>
    /// Total discount amount.
    /// </summary>
    public double? Discount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("discount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount", value);
        }
    }

    /// <summary>
    /// Total before VAT.
    /// </summary>
    public double? Subtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("subtotal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subtotal", value);
        }
    }

    /// <summary>
    /// Grand total.
    /// </summary>
    public double? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    /// <summary>
    /// Total VAT amount.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Discount;
        _ = this.Subtotal;
        _ = this.Total;
        _ = this.Vat;
    }

    public Totals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Totals(Totals totals)
        : base(totals) { }
#pragma warning restore CS8618

    public Totals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Totals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TotalsFromRaw.FromRawUnchecked"/>
    public static Totals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TotalsFromRaw : IFromRawJson<Totals>
{
    /// <inheritdoc/>
    public Totals FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Totals.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InvoiceInvoiceTypeConverter))]
public enum InvoiceInvoiceType
{
    Sale,
    Refund,
}

sealed class InvoiceInvoiceTypeConverter : JsonConverter<InvoiceInvoiceType>
{
    public override InvoiceInvoiceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sale" => InvoiceInvoiceType.Sale,
            "refund" => InvoiceInvoiceType.Refund,
            _ => (InvoiceInvoiceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceInvoiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceInvoiceType.Sale => "sale",
                InvoiceInvoiceType.Refund => "refund",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
