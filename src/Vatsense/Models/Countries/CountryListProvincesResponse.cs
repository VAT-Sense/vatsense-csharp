using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;
using Vatsense.Exceptions;

namespace Vatsense.Models.Countries;

[JsonConverter(
    typeof(JsonModelConverter<CountryListProvincesResponse, CountryListProvincesResponseFromRaw>)
)]
public sealed record class CountryListProvincesResponse : JsonModel
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

    public IReadOnlyList<Data>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
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

    public CountryListProvincesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryListProvincesResponse(CountryListProvincesResponse countryListProvincesResponse)
        : base(countryListProvincesResponse) { }
#pragma warning restore CS8618

    public CountryListProvincesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryListProvincesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryListProvincesResponseFromRaw.FromRawUnchecked"/>
    public static CountryListProvincesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryListProvincesResponseFromRaw : IFromRawJson<CountryListProvincesResponse>
{
    /// <inheritdoc/>
    public CountryListProvincesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CountryListProvincesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    public ApiEnum<string, DataObject>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataObject>>("object");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    public string? ProvinceCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("province_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("province_code", value);
        }
    }

    public string? ProvinceName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("province_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("province_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        this.Object?.Validate();
        _ = this.ProvinceCode;
        _ = this.ProvinceName;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataObjectConverter))]
public enum DataObject
{
    Province,
}

sealed class DataObjectConverter : JsonConverter<DataObject>
{
    public override DataObject Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "province" => DataObject.Province,
            _ => (DataObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataObject.Province => "province",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
