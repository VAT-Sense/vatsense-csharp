using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Invoice.Item;
using System = System;

namespace Vatsense.Models.Invoice;

/// <summary>
/// Create a new VAT-compliant invoice. VAT Sense will automatically calculate the
/// totals based on the items provided.
///
/// <para>Not available with sandbox API keys.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required InvoiceBusinessInput Business
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<InvoiceBusinessInput>("business");
        }
        init { this._rawBodyData.Set("business", value); }
    }

    /// <summary>
    /// The 3-character currency code the invoice is billed in.
    /// </summary>
    public required string CurrencyCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("currency_code");
        }
        init { this._rawBodyData.Set("currency_code", value); }
    }

    /// <summary>
    /// The date the invoice was issued (YYYY-MM-DD or YYYY-MM-DD HH:MM:SS).
    /// </summary>
    public required string Date
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("date");
        }
        init { this._rawBodyData.Set("date", value); }
    }

    public required IReadOnlyList<InvoiceItemInput> Items
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<InvoiceItemInput>>("items");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<InvoiceItemInput>>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("tax_point");
        }
        init { this._rawBodyData.Set("tax_point", value); }
    }

    public InvoiceConversionInput? Conversion
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoiceConversionInput>("conversion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("conversion", value);
        }
    }

    public InvoiceCustomerInput? Customer
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<InvoiceCustomerInput>("customer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("customer", value);
        }
    }

    /// <summary>
    /// Whether the invoice is subject to VAT.
    /// </summary>
    public bool? HasVat
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("has_vat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("has_vat", value);
        }
    }

    /// <summary>
    /// A unique invoice number. If not provided, defaults to an auto-incremented number.
    /// </summary>
    public string? InvoiceNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("invoice_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("invoice_number", value);
        }
    }

    /// <summary>
    /// Whether the invoice is a copy of a primary invoice.
    /// </summary>
    public bool? IsCopy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("is_copy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("is_copy", value);
        }
    }

    /// <summary>
    /// Whether the invoice is zero-rated due to reverse charge.
    /// </summary>
    public bool? IsReverseCharge
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("is_reverse_charge");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("is_reverse_charge", value);
        }
    }

    /// <summary>
    /// Any additional notes for the invoice.
    /// </summary>
    public string? Notes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("notes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("notes", value);
        }
    }

    /// <summary>
    /// Pad the auto-generated invoice number with leading zeros to this length.
    /// </summary>
    public long? PadInvoiceNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("pad_invoice_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("pad_invoice_number", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("serial");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("serial", value);
        }
    }

    /// <summary>
    /// Whether item prices include or exclude VAT.
    /// </summary>
    public ApiEnum<string, TaxType>? TaxType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TaxType>>("tax_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tax_type", value);
        }
    }

    /// <summary>
    /// The type of invoice.
    /// </summary>
    public ApiEnum<string, global::Vatsense.Models.Invoice.Type>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, global::Vatsense.Models.Invoice.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    /// <summary>
    /// Whether the invoice has been zero-rated.
    /// </summary>
    public bool? ZeroRated
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("zero_rated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("zero_rated", value);
        }
    }

    public InvoiceCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceCreateParams(InvoiceCreateParams invoiceCreateParams)
        : base(invoiceCreateParams)
    {
        this._rawBodyData = new(invoiceCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvoiceCreateParams(
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
    InvoiceCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InvoiceCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(InvoiceCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/invoice")
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

/// <summary>
/// Whether item prices include or exclude VAT.
/// </summary>
[JsonConverter(typeof(TaxTypeConverter))]
public enum TaxType
{
    Incl,
    Excl,
}

sealed class TaxTypeConverter : JsonConverter<TaxType>
{
    public override TaxType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incl" => TaxType.Incl,
            "excl" => TaxType.Excl,
            _ => (TaxType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, TaxType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxType.Incl => "incl",
                TaxType.Excl => "excl",
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
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Sale,
    Refund,
}

sealed class TypeConverter : JsonConverter<global::Vatsense.Models.Invoice.Type>
{
    public override global::Vatsense.Models.Invoice.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sale" => global::Vatsense.Models.Invoice.Type.Sale,
            "refund" => global::Vatsense.Models.Invoice.Type.Refund,
            _ => (global::Vatsense.Models.Invoice.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Vatsense.Models.Invoice.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Vatsense.Models.Invoice.Type.Sale => "sale",
                global::Vatsense.Models.Invoice.Type.Refund => "refund",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
