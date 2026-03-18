using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;

namespace Vatsense.Models.Invoice;

[JsonConverter(typeof(JsonModelConverter<InvoiceCustomerInput, InvoiceCustomerInputFromRaw>))]
public sealed record class InvoiceCustomerInput : JsonModel
{
    /// <summary>
    /// The customer's trading name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

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

    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// URL to the customer logo (HTTPS only, .jpg/.png).
    /// </summary>
    public string? Logo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logo", value);
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
        _ = this.Name;
        _ = this.Address;
        _ = this.CompanyNumber;
        _ = this.CountryCode;
        _ = this.Email;
        _ = this.Logo;
        _ = this.VatNumber;
    }

    public InvoiceCustomerInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceCustomerInput(InvoiceCustomerInput invoiceCustomerInput)
        : base(invoiceCustomerInput) { }
#pragma warning restore CS8618

    public InvoiceCustomerInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceCustomerInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceCustomerInputFromRaw.FromRawUnchecked"/>
    public static InvoiceCustomerInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceCustomerInput(string name)
        : this()
    {
        this.Name = name;
    }
}

class InvoiceCustomerInputFromRaw : IFromRawJson<InvoiceCustomerInput>
{
    /// <inheritdoc/>
    public InvoiceCustomerInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceCustomerInput.FromRawUnchecked(rawData);
}
