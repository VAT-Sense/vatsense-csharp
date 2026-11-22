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
/// A batch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchResponse, BatchResponseFromRaw>))]
public sealed record class BatchResponse : JsonModel
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

    public Batch? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Batch>("data");
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

    public BatchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResponse(BatchResponse other)
        : base(other) { }
#pragma warning restore CS8618

    public BatchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchResponseFromRaw.FromRawUnchecked"/>
    public static BatchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchResponseFromRaw : IFromRawJson<BatchResponse>
{
    /// <inheritdoc/>
    public BatchResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchResponse.FromRawUnchecked(rawData);
}
