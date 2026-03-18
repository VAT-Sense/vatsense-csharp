using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;
using Vatsense.Exceptions;

namespace Vatsense.Models.Validate;

[JsonConverter(typeof(JsonModelConverter<ValidateCheckResponse, ValidateCheckResponseFromRaw>))]
public sealed record class ValidateCheckResponse : JsonModel
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

    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
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

    public ValidateCheckResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValidateCheckResponse(ValidateCheckResponse validateCheckResponse)
        : base(validateCheckResponse) { }
#pragma warning restore CS8618

    public ValidateCheckResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidateCheckResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValidateCheckResponseFromRaw.FromRawUnchecked"/>
    public static ValidateCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValidateCheckResponseFromRaw : IFromRawJson<ValidateCheckResponse>
{
    /// <inheritdoc/>
    public ValidateCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValidateCheckResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public Company? Company
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Company>("company");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company", value);
        }
    }

    /// <summary>
    /// Official consultation number (only returned when requester_vat_number is provided).
    /// </summary>
    public string? ConsultationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("consultation_number");
        }
        init { this._rawData.Set("consultation_number", value); }
    }

    /// <summary>
    /// Whether the VAT/EORI number is valid.
    /// </summary>
    public bool? Valid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("valid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("valid", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Company?.Validate();
        _ = this.ConsultationNumber;
        _ = this.Valid;
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

[JsonConverter(typeof(CompanyConverter))]
public record class Company : ModelBase
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

    public string? CompanyAddress
    {
        get
        {
            return Match<string?>(
                validation: (x) => x.CompanyAddress,
                eoriValidation: (x) => x.CompanyAddress
            );
        }
    }

    public string? CompanyName
    {
        get
        {
            return Match<string?>(
                validation: (x) => x.CompanyName,
                eoriValidation: (x) => x.CompanyName
            );
        }
    }

    public string? CountryCode
    {
        get
        {
            return Match<string?>(
                validation: (x) => x.CountryCode,
                eoriValidation: (x) => x.CountryCode
            );
        }
    }

    public Company(ValidationCompany value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Company(EoriValidationCompany value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Company(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ValidationCompany"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickValidation(out var value)) {
    ///     // `value` is of type `ValidationCompany`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickValidation([NotNullWhen(true)] out ValidationCompany? value)
    {
        value = this.Value as ValidationCompany;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EoriValidationCompany"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEoriValidation(out var value)) {
    ///     // `value` is of type `EoriValidationCompany`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEoriValidation([NotNullWhen(true)] out EoriValidationCompany? value)
    {
        value = this.Value as EoriValidationCompany;
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
    ///     (ValidationCompany value) =&gt; {...},
    ///     (EoriValidationCompany value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ValidationCompany> validation,
        Action<EoriValidationCompany> eoriValidation
    )
    {
        switch (this.Value)
        {
            case ValidationCompany value:
                validation(value);
                break;
            case EoriValidationCompany value:
                eoriValidation(value);
                break;
            default:
                throw new VatSenseInvalidDataException("Data did not match any variant of Company");
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
    ///     (ValidationCompany value) =&gt; {...},
    ///     (EoriValidationCompany value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ValidationCompany, T> validation,
        Func<EoriValidationCompany, T> eoriValidation
    )
    {
        return this.Value switch
        {
            ValidationCompany value => validation(value),
            EoriValidationCompany value => eoriValidation(value),
            _ => throw new VatSenseInvalidDataException(
                "Data did not match any variant of Company"
            ),
        };
    }

    public static implicit operator Company(ValidationCompany value) => new(value);

    public static implicit operator Company(EoriValidationCompany value) => new(value);

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
            throw new VatSenseInvalidDataException("Data did not match any variant of Company");
        }
        this.Switch(
            (validation) => validation.Validate(),
            (eoriValidation) => eoriValidation.Validate()
        );
    }

    public virtual bool Equals(Company? other) =>
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
            ValidationCompany _ => 0,
            EoriValidationCompany _ => 1,
            _ => -1,
        };
    }
}

sealed class CompanyConverter : JsonConverter<Company>
{
    public override Company? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ValidationCompany>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is VatSenseInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<EoriValidationCompany>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is VatSenseInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Company value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ValidationCompany, ValidationCompanyFromRaw>))]
public sealed record class ValidationCompany : JsonModel
{
    public string? CompanyAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company_address", value);
        }
    }

    public string? CompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company_name", value);
        }
    }

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

    /// <summary>
    /// The VAT number (without country code prefix).
    /// </summary>
    public string? VatNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vat_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vat_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompanyAddress;
        _ = this.CompanyName;
        _ = this.CountryCode;
        _ = this.VatNumber;
    }

    public ValidationCompany() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValidationCompany(ValidationCompany validationCompany)
        : base(validationCompany) { }
#pragma warning restore CS8618

    public ValidationCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidationCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValidationCompanyFromRaw.FromRawUnchecked"/>
    public static ValidationCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValidationCompanyFromRaw : IFromRawJson<ValidationCompany>
{
    /// <inheritdoc/>
    public ValidationCompany FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValidationCompany.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<EoriValidationCompany, EoriValidationCompanyFromRaw>))]
public sealed record class EoriValidationCompany : JsonModel
{
    public string? CompanyAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company_address", value);
        }
    }

    public string? CompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("company_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company_name", value);
        }
    }

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

    /// <summary>
    /// The EORI number (without country code prefix).
    /// </summary>
    public string? EoriNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("eori_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("eori_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CompanyAddress;
        _ = this.CompanyName;
        _ = this.CountryCode;
        _ = this.EoriNumber;
    }

    public EoriValidationCompany() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EoriValidationCompany(EoriValidationCompany eoriValidationCompany)
        : base(eoriValidationCompany) { }
#pragma warning restore CS8618

    public EoriValidationCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EoriValidationCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EoriValidationCompanyFromRaw.FromRawUnchecked"/>
    public static EoriValidationCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EoriValidationCompanyFromRaw : IFromRawJson<EoriValidationCompany>
{
    /// <inheritdoc/>
    public EoriValidationCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EoriValidationCompany.FromRawUnchecked(rawData);
}
