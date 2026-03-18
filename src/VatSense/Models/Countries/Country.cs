using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;
using VatSense.Exceptions;

namespace VatSense.Models.Countries;

[JsonConverter(typeof(JsonModelConverter<Country, CountryFromRaw>))]
public sealed record class Country : JsonModel
{
    /// <summary>
    /// 2-character ISO 3166-1 alpha-2 country code.
    /// </summary>
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

    public string? CountryName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country_name", value);
        }
    }

    /// <summary>
    /// Whether the country is subject to EU VAT.
    /// </summary>
    public bool? Eu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("eu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eu", value);
        }
    }

    public double? Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("latitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("latitude", value);
        }
    }

    public double? Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("longitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("longitude", value);
        }
    }

    public ApiEnum<string, global::VatSense.Models.Countries.Object>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::VatSense.Models.Countries.Object>
            >("object");
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

    /// <summary>
    /// Whether the country is subject to VAT/GST.
    /// </summary>
    public bool? Vat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("vat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vat", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.CountryName;
        _ = this.Eu;
        _ = this.Latitude;
        _ = this.Longitude;
        this.Object?.Validate();
        _ = this.Vat;
    }

    public Country() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Country(Country country)
        : base(country) { }
#pragma warning restore CS8618

    public Country(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Country(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryFromRaw.FromRawUnchecked"/>
    public static Country FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryFromRaw : IFromRawJson<Country>
{
    /// <inheritdoc/>
    public Country FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Country.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ObjectConverter))]
public enum Object
{
    Country,
}

sealed class ObjectConverter : JsonConverter<global::VatSense.Models.Countries.Object>
{
    public override global::VatSense.Models.Countries.Object Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "country" => global::VatSense.Models.Countries.Object.Country,
            _ => (global::VatSense.Models.Countries.Object)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::VatSense.Models.Countries.Object value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::VatSense.Models.Countries.Object.Country => "country",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
