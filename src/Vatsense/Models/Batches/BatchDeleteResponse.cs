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
/// A deleted draft.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchDeleteResponse, BatchDeleteResponseFromRaw>))]
public sealed record class BatchDeleteResponse : JsonModel
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

    public BatchDeleteData? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BatchDeleteData>("data");
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

    public BatchDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchDeleteResponse(BatchDeleteResponse other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchDeleteResponseFromRaw.FromRawUnchecked"/>
    public static BatchDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchDeleteResponseFromRaw : IFromRawJson<BatchDeleteResponse>
{
    /// <inheritdoc/>
    public BatchDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A deleted draft.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchDeleteData, BatchDeleteDataFromRaw>))]
public sealed record class BatchDeleteData : JsonModel
{
    public string? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public bool? Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("deleted");
        }
        init { this._rawData.Set("deleted", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Object;
        _ = this.ID;
        _ = this.Deleted;
    }

    public BatchDeleteData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchDeleteData(BatchDeleteData other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchDeleteData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchDeleteData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchDeleteDataFromRaw.FromRawUnchecked"/>
    public static BatchDeleteData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchDeleteDataFromRaw : IFromRawJson<BatchDeleteData>
{
    /// <inheritdoc/>
    public BatchDeleteData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchDeleteData.FromRawUnchecked(rawData);
}
