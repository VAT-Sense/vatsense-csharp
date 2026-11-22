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
/// One row of a batch's results.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchResult, BatchResultFromRaw>))]
public sealed record class BatchResult : JsonModel
{
    /// <summary>
    /// The row's number in the batch, from 1.
    /// </summary>
    public long? Row
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("row");
        }
        init { this._rawData.Set("row", value); }
    }

    /// <summary>
    /// The VAT number as sent.
    /// </summary>
    public string? VatNumberUploaded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vat_number_uploaded");
        }
        init { this._rawData.Set("vat_number_uploaded", value); }
    }

    /// <summary>
    /// The country as sent.
    /// </summary>
    public string? CountryUploaded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_uploaded");
        }
        init { this._rawData.Set("country_uploaded", value); }
    }

    /// <summary>
    /// The VAT number as checked.
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

    /// <summary>
    /// The country code as checked.
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <summary>
    /// Who answered.
    /// </summary>
    public string? Authority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authority");
        }
        init { this._rawData.Set("authority", value); }
    }

    /// <summary>
    /// <c>valid</c>, <c>invalid</c>, <c>not_checked</c>, <c>unsupported</c> or <c>duplicate</c>.
    /// </summary>
    public string? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Why a number was not checked.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Whether the number was tidied before the check.
    /// </summary>
    public bool? Repaired
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("repaired");
        }
        init { this._rawData.Set("repaired", value); }
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

    public string? CompanyAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_address");
        }
        init { this._rawData.Set("company_address", value); }
    }

    public string? ConsultationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("consultation_number");
        }
        init { this._rawData.Set("consultation_number", value); }
    }

    /// <summary>
    /// VAT Sense's own reference for the check (beta). Not an official number.
    /// </summary>
    public string? ConfirmationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("confirmation_number");
        }
        init { this._rawData.Set("confirmation_number", value); }
    }

    public string? CheckedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checked_at");
        }
        init { this._rawData.Set("checked_at", value); }
    }

    /// <summary>
    /// For a duplicate, the row it repeats.
    /// </summary>
    public long? DuplicateOfRow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duplicate_of_row");
        }
        init { this._rawData.Set("duplicate_of_row", value); }
    }

    /// <summary>
    /// Company matching, for rows sent with company details.
    /// </summary>
    public BatchResultMatch? Match
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchResultMatch>("match");
        }
        init { this._rawData.Set("match", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Row;
        _ = this.VatNumberUploaded;
        _ = this.CountryUploaded;
        _ = this.VatNumber;
        _ = this.CountryCode;
        _ = this.Authority;
        _ = this.Result;
        _ = this.Reason;
        _ = this.Repaired;
        _ = this.CompanyName;
        _ = this.CompanyAddress;
        _ = this.ConsultationNumber;
        _ = this.ConfirmationNumber;
        _ = this.CheckedAt;
        _ = this.DuplicateOfRow;
        this.Match?.Validate();
    }

    public BatchResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResult(BatchResult other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchResultFromRaw.FromRawUnchecked"/>
    public static BatchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchResultFromRaw : IFromRawJson<BatchResult>
{
    /// <inheritdoc/>
    public BatchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Company matching of one row.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchResultMatch, BatchResultMatchFromRaw>))]
public sealed record class BatchResultMatch : JsonModel
{
    public string? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    public long? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    public IReadOnlyDictionary<string, BatchResultMatchField>? Fields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Dictionary<string, BatchResultMatchField>>(
                "fields"
            );
        }
        init
        {
            this._rawData.Set<Dictionary<string, BatchResultMatchField>?>(
                "fields",
                value == null ? null : Enumerable.ToDictionary(value, (e) => e.Key, (e) => e.Value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Result;
        _ = this.Score;
        foreach (var item in this.Fields?.Values ?? [])
        {
            item.Validate();
        }
    }

    public BatchResultMatch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResultMatch(BatchResultMatch other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchResultMatch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResultMatch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchResultMatchFromRaw.FromRawUnchecked"/>
    public static BatchResultMatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchResultMatchFromRaw : IFromRawJson<BatchResultMatch>
{
    /// <inheritdoc/>
    public BatchResultMatch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchResultMatch.FromRawUnchecked(rawData);
}

/// <summary>
/// Matching of one company field.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchResultMatchField, BatchResultMatchFieldFromRaw>))]
public sealed record class BatchResultMatchField : JsonModel
{
    public string? Sent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sent");
        }
        init { this._rawData.Set("sent", value); }
    }

    public string? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    public long? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    public string? Vies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vies");
        }
        init { this._rawData.Set("vies", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Sent;
        _ = this.Result;
        _ = this.Score;
        _ = this.Vies;
    }

    public BatchResultMatchField() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResultMatchField(BatchResultMatchField other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchResultMatchField(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResultMatchField(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchResultMatchFieldFromRaw.FromRawUnchecked"/>
    public static BatchResultMatchField FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchResultMatchFieldFromRaw : IFromRawJson<BatchResultMatchField>
{
    /// <inheritdoc/>
    public BatchResultMatchField FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchResultMatchField.FromRawUnchecked(rawData);
}
