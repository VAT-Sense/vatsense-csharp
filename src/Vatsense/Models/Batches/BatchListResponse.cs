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
/// A page of batches.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchListResponse, BatchListResponseFromRaw>))]
public sealed record class BatchListResponse : JsonModel
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

    public BatchListData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchListData>("data");
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

    public BatchListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchListResponse(BatchListResponse other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListResponseFromRaw.FromRawUnchecked"/>
    public static BatchListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchListResponseFromRaw : IFromRawJson<BatchListResponse>
{
    /// <inheritdoc/>
    public BatchListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A page of batches.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchListData, BatchListDataFromRaw>))]
public sealed record class BatchListData : JsonModel
{
    public IReadOnlyList<Batch>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Batch>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Batch>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.Page;
        _ = this.Limit;
        _ = this.Total;
        _ = this.HasMore;
    }

    public BatchListData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchListData(BatchListData other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchListData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchListDataFromRaw.FromRawUnchecked"/>
    public static BatchListData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchListDataFromRaw : IFromRawJson<BatchListData>
{
    /// <inheritdoc/>
    public BatchListData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchListData.FromRawUnchecked(rawData);
}
