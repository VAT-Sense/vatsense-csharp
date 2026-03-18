using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;
using Vatsense.Exceptions;

namespace Vatsense.Models.Rates;

[JsonConverter(typeof(JsonModelConverter<TaxRate, TaxRateFromRaw>))]
public sealed record class TaxRate : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Class;
        _ = this.Description;
        this.Object?.Validate();
        _ = this.Rate;
        this.Types?.Validate();
    }

    public TaxRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TaxRate(TaxRate taxRate)
        : base(taxRate) { }
#pragma warning restore CS8618

    public TaxRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TaxRateFromRaw.FromRawUnchecked"/>
    public static TaxRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TaxRateFromRaw : IFromRawJson<TaxRate>
{
    /// <inheritdoc/>
    public TaxRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TaxRate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TaxRateObjectConverter))]
public enum TaxRateObject
{
    TaxRate,
}

sealed class TaxRateObjectConverter : JsonConverter<TaxRateObject>
{
    public override TaxRateObject Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tax_rate" => TaxRateObject.TaxRate,
            _ => (TaxRateObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxRateObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxRateObject.TaxRate => "tax_rate",
                _ => throw new VatSenseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Comma-separated list of product types this rate applies to, or false if it applies generally.
/// </summary>
[JsonConverter(typeof(TypesConverter))]
public record class Types : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Types(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Types(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Types(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="VatSenseInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<string> @string, Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new VatSenseInvalidDataException("Data did not match any variant of Types");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="VatSenseInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<string, T> @string, Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            bool value => @bool(value),
            _ => throw new VatSenseInvalidDataException("Data did not match any variant of Types"),
        };
    }

    public static implicit operator Types(string value) => new(value);

    public static implicit operator Types(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="VatSenseInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new VatSenseInvalidDataException("Data did not match any variant of Types");
        }
    }

    public virtual bool Equals(Types? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            bool _ => 1,
            _ => -1,
        };
    }
}

sealed class TypesConverter : JsonConverter<Types>
{
    public override Types? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is VatSenseInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is VatSenseInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Types value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
