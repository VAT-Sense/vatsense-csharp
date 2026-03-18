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
/// Update an existing invoice. Only the fields provided will be updated.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InvoiceID { get; init; }

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
    public ApiEnum<string, InvoiceUpdateParamsTaxType>? TaxType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InvoiceUpdateParamsTaxType>>(
                "tax_type"
            );
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
    public ApiEnum<string, InvoiceUpdateParamsType>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InvoiceUpdateParamsType>>(
                "type"
            );
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

    public InvoiceUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceUpdateParams(InvoiceUpdateParams invoiceUpdateParams)
        : base(invoiceUpdateParams)
    {
        this.InvoiceID = invoiceUpdateParams.InvoiceID;

        this._rawBodyData = new(invoiceUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvoiceUpdateParams(
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
    InvoiceUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string invoiceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InvoiceID = invoiceID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InvoiceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string invoiceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            invoiceID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["InvoiceID"] = JsonSerializer.SerializeToElement(this.InvoiceID),
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

    public virtual bool Equals(InvoiceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.InvoiceID?.Equals(other.InvoiceID) ?? other.InvoiceID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/invoice/{0}", this.InvoiceID)
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

/// <summary>
/// Whether item prices include or exclude VAT.
/// </summary>
[JsonConverter(typeof(InvoiceUpdateParamsTaxTypeConverter))]
public enum InvoiceUpdateParamsTaxType
{
    Incl,
    Excl,
}

sealed class InvoiceUpdateParamsTaxTypeConverter : JsonConverter<InvoiceUpdateParamsTaxType>
{
    public override InvoiceUpdateParamsTaxType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "incl" => InvoiceUpdateParamsTaxType.Incl,
            "excl" => InvoiceUpdateParamsTaxType.Excl,
            _ => (InvoiceUpdateParamsTaxType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceUpdateParamsTaxType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceUpdateParamsTaxType.Incl => "incl",
                InvoiceUpdateParamsTaxType.Excl => "excl",
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
[JsonConverter(typeof(InvoiceUpdateParamsTypeConverter))]
public enum InvoiceUpdateParamsType
{
    Sale,
    Refund,
}

sealed class InvoiceUpdateParamsTypeConverter : JsonConverter<InvoiceUpdateParamsType>
{
    public override InvoiceUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sale" => InvoiceUpdateParamsType.Sale,
            "refund" => InvoiceUpdateParamsType.Refund,
            _ => (InvoiceUpdateParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceUpdateParamsType.Sale => "sale",
                InvoiceUpdateParamsType.Refund => "refund",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
