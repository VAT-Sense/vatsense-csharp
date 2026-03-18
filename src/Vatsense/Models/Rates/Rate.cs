using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;
using Vatsense.Exceptions;

namespace Vatsense.Models.Rates;

[JsonConverter(typeof(JsonModelConverter<Rate, RateFromRaw>))]
public sealed record class Rate : JsonModel
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
    /// Whether the country is an EU member.
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

    public ApiEnum<string, global::Vatsense.Models.Rates.Object>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Vatsense.Models.Rates.Object>
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
    /// A list of other tax rates. Null if no additional rates exist.
    /// </summary>
    public IReadOnlyList<Other>? Other
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Other>>("other");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Other>?>(
                "other",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public TaxRate? Standard
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TaxRate>("standard");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("standard", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.CountryName;
        _ = this.Eu;
        this.Object?.Validate();
        foreach (var item in this.Other ?? [])
        {
            item.Validate();
        }
        this.Standard?.Validate();
    }

    public Rate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rate(Rate rate)
        : base(rate) { }
#pragma warning restore CS8618

    public Rate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateFromRaw.FromRawUnchecked"/>
    public static Rate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateFromRaw : IFromRawJson<Rate>
{
    /// <inheritdoc/>
    public Rate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ObjectConverter))]
public enum Object
{
    Rate,
}

sealed class ObjectConverter : JsonConverter<global::Vatsense.Models.Rates.Object>
{
    public override global::Vatsense.Models.Rates.Object Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rate" => global::Vatsense.Models.Rates.Object.Rate,
            _ => (global::Vatsense.Models.Rates.Object)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Vatsense.Models.Rates.Object value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Vatsense.Models.Rates.Object.Rate => "rate",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Other, OtherFromRaw>))]
public sealed record class Other : JsonModel
{
    /// <summary>
    /// The rate class (e.g. "standard", "reduced", "zero").
    /// </summary>
    public string? Class
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class", value);
        }
    }

    /// <summary>
    /// A description of what goods/services this rate applies to.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public ApiEnum<string, TaxRateObject>? Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TaxRateObject>>("object");
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
    /// The tax rate percentage.
    /// </summary>
    public double? Rate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// Comma-separated list of product types this rate applies to, or false if it
    /// applies generally.
    /// </summary>
    public Types? Types
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Types>("types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("types", value);
        }
    }

    /// <summary>
    /// The province this rate applies to, if applicable.
    /// </summary>
    public string? Province
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("province");
        }
        init { this._rawData.Set("province", value); }
    }

    public static implicit operator TaxRate(Other other) =>
        new()
        {
            Class = other.Class,
            Description = other.Description,
            Object = other.Object,
            Rate = other.Rate,
            Types = other.Types,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Class;
        _ = this.Description;
        this.Object?.Validate();
        _ = this.Rate;
        this.Types?.Validate();
        _ = this.Province;
    }

    public Other() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Other(Other other)
        : base(other) { }
#pragma warning restore CS8618

    public Other(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Other(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OtherFromRaw.FromRawUnchecked"/>
    public static Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OtherFromRaw : IFromRawJson<Other>
{
    /// <inheritdoc/>
    public Other FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Other.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The province this rate applies to, if applicable.
    /// </summary>
    public string? Province
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("province");
        }
        init { this._rawData.Set("province", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Province;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}
