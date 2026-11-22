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
/// A page of a batch's results.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchResultsResponse, BatchResultsResponseFromRaw>))]
public sealed record class BatchResultsResponse : JsonModel
{
    /// <summary>
    /// The HTTP status code.
    /// </summary>
    public long? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    public BatchResultsData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchResultsData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Whether the request succeeded.
    /// </summary>
    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        this.Data?.Validate();
        _ = this.Success;
    }

    public BatchResultsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResultsResponse(BatchResultsResponse other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchResultsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResultsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchResultsResponseFromRaw.FromRawUnchecked"/>
    public static BatchResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchResultsResponseFromRaw : IFromRawJson<BatchResultsResponse>
{
    /// <inheritdoc/>
    public BatchResultsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BatchResultsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A page of a batch's results.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchResultsData, BatchResultsDataFromRaw>))]
public sealed record class BatchResultsData : JsonModel
{
    public IReadOnlyList<BatchResult>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BatchResult>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BatchResult>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// Pass as <c>After</c> for the next page.
    /// </summary>
    public long? NextAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("next_after");
        }
        init { this._rawData.Set("next_after", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextAfter;
    }

    public BatchResultsData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResultsData(BatchResultsData other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchResultsData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResultsData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchResultsDataFromRaw.FromRawUnchecked"/>
    public static BatchResultsData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchResultsDataFromRaw : IFromRawJson<BatchResultsData>
{
    /// <inheritdoc/>
    public BatchResultsData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchResultsData.FromRawUnchecked(rawData);
}
