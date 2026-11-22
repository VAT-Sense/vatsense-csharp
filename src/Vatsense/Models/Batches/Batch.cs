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
/// A batch of VAT numbers checked together.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Batch, BatchFromRaw>))]
public sealed record class Batch : JsonModel
{
    /// <summary>
    /// Always <c>batch</c>.
    /// </summary>
    public string? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    /// <summary>
    /// The batch's ID, such as <c>bat_...</c>.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The batch's number on your account.
    /// </summary>
    public long? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("number");
        }
        init { this._rawData.Set("number", value); }
    }

    /// <summary>
    /// <c>draft</c>, <c>queued</c>, <c>checking</c>, <c>paused</c>, <c>complete</c> or <c>expired</c>.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Why the batch is paused, if it is.
    /// </summary>
    public string? PauseReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pause_reason");
        }
        init { this._rawData.Set("pause_reason", value); }
    }

    /// <summary>
    /// Where the batch came from: <c>api</c> or <c>dashboard</c>.
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// False for a batch made with a test key.
    /// </summary>
    public bool? Livemode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("livemode");
        }
        init { this._rawData.Set("livemode", value); }
    }

    /// <summary>
    /// Your own label for the batch.
    /// </summary>
    public string? Reference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reference");
        }
        init { this._rawData.Set("reference", value); }
    }

    /// <summary>
    /// Whether the batch is a free trial batch.
    /// </summary>
    public bool? Trial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("trial");
        }
        init { this._rawData.Set("trial", value); }
    }

    /// <summary>
    /// Row counts.
    /// </summary>
    public BatchRows? Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchRows>("rows");
        }
        init { this._rawData.Set("rows", value); }
    }

    /// <summary>
    /// Result counts so far.
    /// </summary>
    public BatchResults? Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchResults>("results");
        }
        init { this._rawData.Set("results", value); }
    }

    /// <summary>
    /// Requests the batch has used so far.
    /// </summary>
    public long? RequestsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests_used");
        }
        init { this._rawData.Set("requests_used", value); }
    }

    /// <summary>
    /// Whether each check sends your requester VAT number.
    /// </summary>
    public bool? Consultation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("consultation");
        }
        init { this._rawData.Set("consultation", value); }
    }

    /// <summary>
    /// Whether a paused batch continues when your requests renew.
    /// </summary>
    public bool? AutoContinue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_continue");
        }
        init { this._rawData.Set("auto_continue", value); }
    }

    /// <summary>
    /// Whether the batch may run into overage.
    /// </summary>
    public bool? UsesOverage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("uses_overage");
        }
        init { this._rawData.Set("uses_overage", value); }
    }

    /// <summary>
    /// When the batch was made (ISO 8601).
    /// </summary>
    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// When checking started.
    /// </summary>
    public string? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("started_at");
        }
        init { this._rawData.Set("started_at", value); }
    }

    /// <summary>
    /// When checking should finish, while it runs.
    /// </summary>
    public string? EstimatedFinishAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("estimated_finish_at");
        }
        init { this._rawData.Set("estimated_finish_at", value); }
    }

    /// <summary>
    /// When checking finished.
    /// </summary>
    public string? FinishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("finished_at");
        }
        init { this._rawData.Set("finished_at", value); }
    }

    /// <summary>
    /// When the batch and its results are deleted.
    /// </summary>
    public string? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// What the batch needs against what your account has left.
    /// </summary>
    public BatchQuote? Quote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchQuote>("quote");
        }
        init { this._rawData.Set("quote", value); }
    }

    /// <summary>
    /// The batch's page in the dashboard.
    /// </summary>
    public string? DashboardUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dashboard_url");
        }
        init { this._rawData.Set("dashboard_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Object;
        _ = this.ID;
        _ = this.Number;
        _ = this.Status;
        _ = this.PauseReason;
        _ = this.Source;
        _ = this.Livemode;
        _ = this.Reference;
        _ = this.Trial;
        this.Rows?.Validate();
        this.Results?.Validate();
        _ = this.RequestsUsed;
        _ = this.Consultation;
        _ = this.AutoContinue;
        _ = this.UsesOverage;
        _ = this.CreatedAt;
        _ = this.StartedAt;
        _ = this.EstimatedFinishAt;
        _ = this.FinishedAt;
        _ = this.ExpiresAt;
        this.Quote?.Validate();
        _ = this.DashboardUrl;
    }

    public Batch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Batch(Batch other)
        : base(other) { }
#pragma warning restore CS8618

    public Batch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Batch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchFromRaw.FromRawUnchecked"/>
    public static Batch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchFromRaw : IFromRawJson<Batch>
{
    /// <inheritdoc/>
    public Batch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Batch.FromRawUnchecked(rawData);
}

/// <summary>
/// Row counts of a batch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchRows, BatchRowsFromRaw>))]
public sealed record class BatchRows : JsonModel
{
    /// <summary>
    /// Rows in the batch.
    /// </summary>
    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// Rows that need a check.
    /// </summary>
    public long? ToCheck
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("to_check");
        }
        init { this._rawData.Set("to_check", value); }
    }

    /// <summary>
    /// Rows checked so far.
    /// </summary>
    public long? Done
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("done");
        }
        init { this._rawData.Set("done", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Total;
        _ = this.ToCheck;
        _ = this.Done;
    }

    public BatchRows() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchRows(BatchRows other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchRows(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchRows(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchRowsFromRaw.FromRawUnchecked"/>
    public static BatchRows FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchRowsFromRaw : IFromRawJson<BatchRows>
{
    /// <inheritdoc/>
    public BatchRows FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchRows.FromRawUnchecked(rawData);
}

/// <summary>
/// Result counts of a batch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchResults, BatchResultsFromRaw>))]
public sealed record class BatchResults : JsonModel
{
    public long? Valid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("valid");
        }
        init { this._rawData.Set("valid", value); }
    }

    public long? Invalid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("invalid");
        }
        init { this._rawData.Set("invalid", value); }
    }

    public long? NotChecked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("not_checked");
        }
        init { this._rawData.Set("not_checked", value); }
    }

    public long? Unsupported
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("unsupported");
        }
        init { this._rawData.Set("unsupported", value); }
    }

    public long? Duplicate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duplicate");
        }
        init { this._rawData.Set("duplicate", value); }
    }

    public long? Retrying
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("retrying");
        }
        init { this._rawData.Set("retrying", value); }
    }

    public long? Repaired
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("repaired");
        }
        init { this._rawData.Set("repaired", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Valid;
        _ = this.Invalid;
        _ = this.NotChecked;
        _ = this.Unsupported;
        _ = this.Duplicate;
        _ = this.Retrying;
        _ = this.Repaired;
    }

    public BatchResults() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResults(BatchResults other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchResults(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResults(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchResultsFromRaw.FromRawUnchecked"/>
    public static BatchResults FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchResultsFromRaw : IFromRawJson<BatchResults>
{
    /// <inheritdoc/>
    public BatchResults FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchResults.FromRawUnchecked(rawData);
}

/// <summary>
/// A batch's quote.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchQuote, BatchQuoteFromRaw>))]
public sealed record class BatchQuote : JsonModel
{
    /// <summary>
    /// Requests the batch needs.
    /// </summary>
    public long? RequestsNeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests_needed");
        }
        init { this._rawData.Set("requests_needed", value); }
    }

    /// <summary>
    /// Requests your account has left.
    /// </summary>
    public long? RequestsLeft
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests_left");
        }
        init { this._rawData.Set("requests_left", value); }
    }

    /// <summary>
    /// Requests missing, if any.
    /// </summary>
    public long? Shortfall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("shortfall");
        }
        init { this._rawData.Set("shortfall", value); }
    }

    /// <summary>
    /// Whether your requests cover the batch.
    /// </summary>
    public bool? Covered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("covered");
        }
        init { this._rawData.Set("covered", value); }
    }

    /// <summary>
    /// Whether overage is on for your account.
    /// </summary>
    public bool? OverageOn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("overage_on");
        }
        init { this._rawData.Set("overage_on", value); }
    }

    /// <summary>
    /// When your requests renew.
    /// </summary>
    public string? RenewsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("renews_at");
        }
        init { this._rawData.Set("renews_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestsNeeded;
        _ = this.RequestsLeft;
        _ = this.Shortfall;
        _ = this.Covered;
        _ = this.OverageOn;
        _ = this.RenewsAt;
    }

    public BatchQuote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchQuote(BatchQuote other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchQuote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchQuote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchQuoteFromRaw.FromRawUnchecked"/>
    public static BatchQuote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchQuoteFromRaw : IFromRawJson<BatchQuote>
{
    /// <inheritdoc/>
    public BatchQuote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchQuote.FromRawUnchecked(rawData);
}
