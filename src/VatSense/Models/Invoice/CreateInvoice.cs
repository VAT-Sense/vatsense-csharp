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

[JsonConverter(typeof(JsonModelConverter<CreateInvoice, CreateInvoiceFromRaw>))]
public sealed record class CreateInvoice : JsonModel
{
    public required InvoiceBusinessInput Business
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InvoiceBusinessInput>("business");
        }
        init { this._rawData.Set("business", value); }
    }

    /// <summary>
    /// The 3-character currency code the invoice is billed in.
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
    /// The date the invoice was issued (YYYY-MM-DD or YYYY-MM-DD HH:MM:SS).
    /// </summary>
    public required string Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    public required IReadOnlyList<InvoiceItemInput> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InvoiceItemInput>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceItemInput>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The tax point or "time of supply" (YYYY-MM-DD or YYYY-MM-DD HH:MM:SS).
    /// </summary>
    public required string TaxPoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tax_point");
        }
        init { this._rawData.Set("tax_point", value); }
    }

    public InvoiceConversionInput? Conversion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvoiceConversionInput>("conversion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversion", value);
        }
    }

    public InvoiceCustomerInput? Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvoiceCustomerInput>("customer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customer", value);
        }
    }

    /// <summary>
    /// Whether the invoice is subject to VAT.
    /// </summary>
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

    /// <summary>
    /// A unique invoice number. If not provided, defaults to an auto-incremented number.
    /// </summary>
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
    /// Whether the invoice is a copy of a primary invoice.
    /// </summary>
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

    /// <summary>
    /// Whether the invoice is zero-rated due to reverse charge.
    /// </summary>
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

    /// <summary>
    /// Any additional notes for the invoice.
    /// </summary>
    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("notes", value);
        }
    }

    /// <summary>
    /// Pad the auto-generated invoice number with leading zeros to this length.
    /// </summary>
    public long? PadInvoiceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pad_invoice_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pad_invoice_number", value);
        }
    }

    /// <summary>
    /// A serial prepended to the auto-generated invoice number. Each unique serial
    /// has its own auto-increment range.
    /// </summary>
    public string? Serial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("serial");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("serial", value);
        }
    }

    /// <summary>
    /// Whether item prices include or exclude VAT.
    /// </summary>
    public ApiEnum<string, CreateInvoiceTaxType>? TaxType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreateInvoiceTaxType>>(
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

    /// <summary>
    /// The type of invoice.
    /// </summary>
    public ApiEnum<string, CreateInvoiceType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreateInvoiceType>>("type");
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

    /// <summary>
    /// Whether the invoice has been zero-rated.
    /// </summary>
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
        this.Business.Validate();
        _ = this.CurrencyCode;
        _ = this.Date;
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.TaxPoint;
        this.Conversion?.Validate();
        this.Customer?.Validate();
        _ = this.HasVat;
        _ = this.InvoiceNumber;
        _ = this.IsCopy;
        _ = this.IsReverseCharge;
        _ = this.Notes;
        _ = this.PadInvoiceNumber;
        _ = this.Serial;
        this.TaxType?.Validate();
        this.Type?.Validate();
        _ = this.ZeroRated;
    }

    public CreateInvoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateInvoice(CreateInvoice createInvoice)
        : base(createInvoice) { }
#pragma warning restore CS8618

    public CreateInvoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateInvoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateInvoiceFromRaw.FromRawUnchecked"/>
    public static CreateInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateInvoiceFromRaw : IFromRawJson<CreateInvoice>
{
    /// <inheritdoc/>
    public CreateInvoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreateInvoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether item prices include or exclude VAT.
/// </summary>
[JsonConverter(typeof(CreateInvoiceTaxTypeConverter))]
public enum CreateInvoiceTaxType
{
    Incl,
    Excl,
}

sealed class CreateInvoiceTaxTypeConverter : JsonConverter<CreateInvoiceTaxType>
{
    public override CreateInvoiceTaxType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incl" => CreateInvoiceTaxType.Incl,
            "excl" => CreateInvoiceTaxType.Excl,
            _ => (CreateInvoiceTaxType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateInvoiceTaxType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateInvoiceTaxType.Incl => "incl",
                CreateInvoiceTaxType.Excl => "excl",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of invoice.
/// </summary>
[JsonConverter(typeof(CreateInvoiceTypeConverter))]
public enum CreateInvoiceType
{
    Sale,
    Refund,
}

sealed class CreateInvoiceTypeConverter : JsonConverter<CreateInvoiceType>
{
    public override CreateInvoiceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sale" => CreateInvoiceType.Sale,
            "refund" => CreateInvoiceType.Refund,
            _ => (CreateInvoiceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateInvoiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateInvoiceType.Sale => "sale",
                CreateInvoiceType.Refund => "refund",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
