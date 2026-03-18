using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;

namespace Vatsense.Models.Rates;

[JsonConverter(typeof(JsonModelConverter<FindRate, FindRateFromRaw>))]
public sealed record class FindRate : JsonModel
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

    public RateWithTaxRate? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RateWithTaxRate>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
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
        this.Data?.Validate();
        _ = this.Success;
    }

    public FindRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FindRate(FindRate findRate)
        : base(findRate) { }
#pragma warning restore CS8618

    public FindRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FindRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FindRateFromRaw.FromRawUnchecked"/>
    public static FindRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FindRateFromRaw : IFromRawJson<FindRate>
{
    /// <inheritdoc/>
    public FindRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FindRate.FromRawUnchecked(rawData);
}
