using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;

namespace Vatsense.Models.Batches;

/// <summary>
/// A row to check, with company details for matching.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchRow, BatchRowFromRaw>))]
public sealed record class BatchRow : JsonModel
{
    /// <summary>
    /// The VAT number, with its country code or with <see cref="CountryCode"/>.
    /// </summary>
    public string? VatNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vat_number");
        }
        init { this._rawData.Set("vat_number", value); }
    }

    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    public string? CompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_name");
        }
        init { this._rawData.Set("company_name", value); }
    }

    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    public string? AddressLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address_line_2");
        }
        init { this._rawData.Set("address_line_2", value); }
    }

    public string? Postcode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postcode");
        }
        init { this._rawData.Set("postcode", value); }
    }

    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.VatNumber;
        _ = this.CountryCode;
        _ = this.CompanyName;
        _ = this.Address;
        _ = this.Street;
        _ = this.AddressLine2;
        _ = this.Postcode;
        _ = this.City;
    }

    public BatchRow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchRow(BatchRow other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchRow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchRow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchRowFromRaw.FromRawUnchecked"/>
    public static BatchRow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchRowFromRaw : IFromRawJson<BatchRow>
{
    /// <inheritdoc/>
    public BatchRow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchRow.FromRawUnchecked(rawData);
}
