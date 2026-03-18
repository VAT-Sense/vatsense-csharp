using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Rates;

[JsonConverter(typeof(JsonModelConverter<RateListTypesResponse, RateListTypesResponseFromRaw>))]
public sealed record class RateListTypesResponse : JsonModel
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

    public IReadOnlyList<string>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
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
        _ = this.Data;
        _ = this.Success;
    }

    public RateListTypesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateListTypesResponse(RateListTypesResponse rateListTypesResponse)
        : base(rateListTypesResponse) { }
#pragma warning restore CS8618

    public RateListTypesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateListTypesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateListTypesResponseFromRaw.FromRawUnchecked"/>
    public static RateListTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateListTypesResponseFromRaw : IFromRawJson<RateListTypesResponse>
{
    /// <inheritdoc/>
    public RateListTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RateListTypesResponse.FromRawUnchecked(rawData);
}
