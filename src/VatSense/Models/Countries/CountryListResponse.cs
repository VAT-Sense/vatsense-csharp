using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Countries;

[JsonConverter(typeof(JsonModelConverter<CountryListResponse, CountryListResponseFromRaw>))]
public sealed record class CountryListResponse : JsonModel
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

    public IReadOnlyList<Country>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Country>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Country>?>(
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

    public CountryListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryListResponse(CountryListResponse countryListResponse)
        : base(countryListResponse) { }
#pragma warning restore CS8618

    public CountryListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryListResponseFromRaw.FromRawUnchecked"/>
    public static CountryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryListResponseFromRaw : IFromRawJson<CountryListResponse>
{
    /// <inheritdoc/>
    public CountryListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CountryListResponse.FromRawUnchecked(rawData);
}
