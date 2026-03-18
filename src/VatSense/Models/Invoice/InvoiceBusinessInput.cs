using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Invoice;

[JsonConverter(typeof(JsonModelConverter<InvoiceBusinessInput, InvoiceBusinessInputFromRaw>))]
public sealed record class InvoiceBusinessInput : JsonModel
{
    /// <summary>
    /// Your business trading address.
    /// </summary>
    public required string Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <summary>
    /// Your business trading name.
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

    /// <summary>
    /// Your business VAT number.
    /// </summary>
    public required string VatNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vat_number");
        }
        init { this._rawData.Set("vat_number", value); }
    }

    public string? BankAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bank_account");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bank_account", value);
        }
    }

    /// <summary>
    /// Your business company number.
    /// </summary>
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
    /// URL to your company logo (HTTPS only, .svg/.jpg/.png). Recommended 240px
    /// by 60px.
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

    public string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("website", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.Name;
        _ = this.VatNumber;
        _ = this.BankAccount;
        _ = this.CompanyNumber;
        _ = this.Email;
        _ = this.Logo;
        _ = this.Phone;
        _ = this.Website;
    }

    public InvoiceBusinessInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceBusinessInput(InvoiceBusinessInput invoiceBusinessInput)
        : base(invoiceBusinessInput) { }
#pragma warning restore CS8618

    public InvoiceBusinessInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceBusinessInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceBusinessInputFromRaw.FromRawUnchecked"/>
    public static InvoiceBusinessInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceBusinessInputFromRaw : IFromRawJson<InvoiceBusinessInput>
{
    /// <inheritdoc/>
    public InvoiceBusinessInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceBusinessInput.FromRawUnchecked(rawData);
}
