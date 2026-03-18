using System.Text.Json;
using Vatsense.Exceptions;
using Vatsense.Models.Rates;
using Countries = Vatsense.Models.Countries;
using Currency = Vatsense.Models.Currency;
using Invoice = Vatsense.Models.Invoice;
using Item = Vatsense.Models.Invoice.Item;

namespace Vatsense.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Object>(),
            new ApiEnumConverter<string, RateWithTaxRateObject>(),
            new ApiEnumConverter<string, TaxRateObject>(),
            new ApiEnumConverter<string, DataObject>(),
            new ApiEnumConverter<string, TaxType>(),
            new ApiEnumConverter<string, Countries::Object>(),
            new ApiEnumConverter<string, Countries::DataObject>(),
            new ApiEnumConverter<string, Currency::Object>(),
            new ApiEnumConverter<string, Currency::VatPriceTaxType>(),
            new ApiEnumConverter<string, Currency::DataObject>(),
            new ApiEnumConverter<string, Currency::CurrencyConvertResponseDataObject>(),
            new ApiEnumConverter<string, Currency::To>(),
            new ApiEnumConverter<string, Currency::TaxType>(),
            new ApiEnumConverter<string, Currency::CurrencyConvertParamsTo>(),
            new ApiEnumConverter<string, Invoice::CreateInvoiceTaxType>(),
            new ApiEnumConverter<string, Invoice::CreateInvoiceType>(),
            new ApiEnumConverter<string, Invoice::Object>(),
            new ApiEnumConverter<string, Invoice::InvoiceInvoiceTaxType>(),
            new ApiEnumConverter<string, Invoice::InvoiceInvoiceType>(),
            new ApiEnumConverter<string, Invoice::TaxType>(),
            new ApiEnumConverter<string, Invoice::Type>(),
            new ApiEnumConverter<string, Invoice::InvoiceUpdateParamsTaxType>(),
            new ApiEnumConverter<string, Invoice::InvoiceUpdateParamsType>(),
            new ApiEnumConverter<string, Item::Object>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="VatSenseInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
