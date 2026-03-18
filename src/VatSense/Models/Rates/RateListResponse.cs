using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Rates;

[JsonConverter(typeof(JsonModelConverter<RateListResponse, RateListResponseFromRaw>))]
public sealed record class RateListResponse : JsonModel
{
    public long? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public IReadOnlyList<Rate>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Rate>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Rate>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.Success;
    }

    public RateListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateListResponse(RateListResponse rateListResponse)
        : base(rateListResponse) { }
#pragma warning restore CS8618

    public RateListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateListResponseFromRaw.FromRawUnchecked"/>
    public static RateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateListResponseFromRaw : IFromRawJson<RateListResponse>
{
    /// <inheritdoc/>
    public RateListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RateListResponse.FromRawUnchecked(rawData);
}
