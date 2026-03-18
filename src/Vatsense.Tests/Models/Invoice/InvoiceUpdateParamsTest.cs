using System;
using System.Collections.Generic;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Invoice;
using Vatsense.Models.Invoice.Item;

namespace Vatsense.Tests.Models.Invoice;

public class InvoiceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            Business = new()
            {
                Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
                Name = "VAT Sense",
                VatNumber = "GB12345678",
                BankAccount = "bank_account",
                CompanyNumber = "9839222",
                Email = "dev@stainless.com",
                Logo = "https://example.com",
                Phone = "phone",
                Website = "https://example.com",
            },
            CurrencyCode = "USD",
            Date = "2018-06-03 14:02:00",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
            TaxPoint = "2018-06-03 14:02:00",
            Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
            Customer = new()
            {
                Name = "Demo Co.",
                Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
                CompanyNumber = "5584922",
                CountryCode = "country_code",
                Email = "dev@stainless.com",
                Logo = "https://example.com",
                VatNumber = "GB912343332",
            },
            HasVat = true,
            InvoiceNumber = "203",
            IsCopy = true,
            IsReverseCharge = true,
            Notes = "notes",
            PadInvoiceNumber = 2,
            Serial = "serial",
            TaxType = InvoiceUpdateParamsTaxType.Incl,
            Type = InvoiceUpdateParamsType.Sale,
            ZeroRated = true,
        };

        string expectedInvoiceID = "in5aeae457cda2a";
        InvoiceBusinessInput expectedBusiness = new()
        {
            Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
            Name = "VAT Sense",
            VatNumber = "GB12345678",
            BankAccount = "bank_account",
            CompanyNumber = "9839222",
            Email = "dev@stainless.com",
            Logo = "https://example.com",
            Phone = "phone",
            Website = "https://example.com",
        };
        string expectedCurrencyCode = "USD";
        string expectedDate = "2018-06-03 14:02:00";
        List<InvoiceItemInput> expectedItems =
        [
            new()
            {
                Item = "Standard payment plan",
                PriceEach = 19.99,
                Quantity = 1,
                VatRate = 20,
                DiscountRate = 40,
            },
        ];
        string expectedTaxPoint = "2018-06-03 14:02:00";
        InvoiceConversionInput expectedConversion = new() { CurrencyCode = "GBP", Rate = 1.523 };
        InvoiceCustomerInput expectedCustomer = new()
        {
            Name = "Demo Co.",
            Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
            CompanyNumber = "5584922",
            CountryCode = "country_code",
            Email = "dev@stainless.com",
            Logo = "https://example.com",
            VatNumber = "GB912343332",
        };
        bool expectedHasVat = true;
        string expectedInvoiceNumber = "203";
        bool expectedIsCopy = true;
        bool expectedIsReverseCharge = true;
        string expectedNotes = "notes";
        long expectedPadInvoiceNumber = 2;
        string expectedSerial = "serial";
        ApiEnum<string, InvoiceUpdateParamsTaxType> expectedTaxType =
            InvoiceUpdateParamsTaxType.Incl;
        ApiEnum<string, InvoiceUpdateParamsType> expectedType = InvoiceUpdateParamsType.Sale;
        bool expectedZeroRated = true;

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedBusiness, parameters.Business);
        Assert.Equal(expectedCurrencyCode, parameters.CurrencyCode);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedItems.Count, parameters.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], parameters.Items[i]);
        }
        Assert.Equal(expectedTaxPoint, parameters.TaxPoint);
        Assert.Equal(expectedConversion, parameters.Conversion);
        Assert.Equal(expectedCustomer, parameters.Customer);
        Assert.Equal(expectedHasVat, parameters.HasVat);
        Assert.Equal(expectedInvoiceNumber, parameters.InvoiceNumber);
        Assert.Equal(expectedIsCopy, parameters.IsCopy);
        Assert.Equal(expectedIsReverseCharge, parameters.IsReverseCharge);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedPadInvoiceNumber, parameters.PadInvoiceNumber);
        Assert.Equal(expectedSerial, parameters.Serial);
        Assert.Equal(expectedTaxType, parameters.TaxType);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedZeroRated, parameters.ZeroRated);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            Business = new()
            {
                Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
                Name = "VAT Sense",
                VatNumber = "GB12345678",
                BankAccount = "bank_account",
                CompanyNumber = "9839222",
                Email = "dev@stainless.com",
                Logo = "https://example.com",
                Phone = "phone",
                Website = "https://example.com",
            },
            CurrencyCode = "USD",
            Date = "2018-06-03 14:02:00",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
            TaxPoint = "2018-06-03 14:02:00",
        };

        Assert.Null(parameters.Conversion);
        Assert.False(parameters.RawBodyData.ContainsKey("conversion"));
        Assert.Null(parameters.Customer);
        Assert.False(parameters.RawBodyData.ContainsKey("customer"));
        Assert.Null(parameters.HasVat);
        Assert.False(parameters.RawBodyData.ContainsKey("has_vat"));
        Assert.Null(parameters.InvoiceNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("invoice_number"));
        Assert.Null(parameters.IsCopy);
        Assert.False(parameters.RawBodyData.ContainsKey("is_copy"));
        Assert.Null(parameters.IsReverseCharge);
        Assert.False(parameters.RawBodyData.ContainsKey("is_reverse_charge"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.PadInvoiceNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("pad_invoice_number"));
        Assert.Null(parameters.Serial);
        Assert.False(parameters.RawBodyData.ContainsKey("serial"));
        Assert.Null(parameters.TaxType);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_type"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.ZeroRated);
        Assert.False(parameters.RawBodyData.ContainsKey("zero_rated"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            Business = new()
            {
                Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
                Name = "VAT Sense",
                VatNumber = "GB12345678",
                BankAccount = "bank_account",
                CompanyNumber = "9839222",
                Email = "dev@stainless.com",
                Logo = "https://example.com",
                Phone = "phone",
                Website = "https://example.com",
            },
            CurrencyCode = "USD",
            Date = "2018-06-03 14:02:00",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
            TaxPoint = "2018-06-03 14:02:00",

            // Null should be interpreted as omitted for these properties
            Conversion = null,
            Customer = null,
            HasVat = null,
            InvoiceNumber = null,
            IsCopy = null,
            IsReverseCharge = null,
            Notes = null,
            PadInvoiceNumber = null,
            Serial = null,
            TaxType = null,
            Type = null,
            ZeroRated = null,
        };

        Assert.Null(parameters.Conversion);
        Assert.False(parameters.RawBodyData.ContainsKey("conversion"));
        Assert.Null(parameters.Customer);
        Assert.False(parameters.RawBodyData.ContainsKey("customer"));
        Assert.Null(parameters.HasVat);
        Assert.False(parameters.RawBodyData.ContainsKey("has_vat"));
        Assert.Null(parameters.InvoiceNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("invoice_number"));
        Assert.Null(parameters.IsCopy);
        Assert.False(parameters.RawBodyData.ContainsKey("is_copy"));
        Assert.Null(parameters.IsReverseCharge);
        Assert.False(parameters.RawBodyData.ContainsKey("is_reverse_charge"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.PadInvoiceNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("pad_invoice_number"));
        Assert.Null(parameters.Serial);
        Assert.False(parameters.RawBodyData.ContainsKey("serial"));
        Assert.Null(parameters.TaxType);
        Assert.False(parameters.RawBodyData.ContainsKey("tax_type"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
        Assert.Null(parameters.ZeroRated);
        Assert.False(parameters.RawBodyData.ContainsKey("zero_rated"));
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceUpdateParams parameters = new()
        {
            InvoiceID = "in5aeae457cda2a",
            Business = new()
            {
                Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
                Name = "VAT Sense",
                VatNumber = "GB12345678",
                BankAccount = "bank_account",
                CompanyNumber = "9839222",
                Email = "dev@stainless.com",
                Logo = "https://example.com",
                Phone = "phone",
                Website = "https://example.com",
            },
            CurrencyCode = "USD",
            Date = "2018-06-03 14:02:00",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
            TaxPoint = "2018-06-03 14:02:00",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(new Uri("https://api.vatsense.com/1.0/invoice/in5aeae457cda2a"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            Business = new()
            {
                Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
                Name = "VAT Sense",
                VatNumber = "GB12345678",
                BankAccount = "bank_account",
                CompanyNumber = "9839222",
                Email = "dev@stainless.com",
                Logo = "https://example.com",
                Phone = "phone",
                Website = "https://example.com",
            },
            CurrencyCode = "USD",
            Date = "2018-06-03 14:02:00",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
            TaxPoint = "2018-06-03 14:02:00",
            Conversion = new() { CurrencyCode = "GBP", Rate = 1.523 },
            Customer = new()
            {
                Name = "Demo Co.",
                Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
                CompanyNumber = "5584922",
                CountryCode = "country_code",
                Email = "dev@stainless.com",
                Logo = "https://example.com",
                VatNumber = "GB912343332",
            },
            HasVat = true,
            InvoiceNumber = "203",
            IsCopy = true,
            IsReverseCharge = true,
            Notes = "notes",
            PadInvoiceNumber = 2,
            Serial = "serial",
            TaxType = InvoiceUpdateParamsTaxType.Incl,
            Type = InvoiceUpdateParamsType.Sale,
            ZeroRated = true,
        };

        InvoiceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InvoiceUpdateParamsTaxTypeTest : TestBase
{
    [Theory]
    [InlineData(InvoiceUpdateParamsTaxType.Incl)]
    [InlineData(InvoiceUpdateParamsTaxType.Excl)]
    public void Validation_Works(InvoiceUpdateParamsTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceUpdateParamsTaxType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceUpdateParamsTaxType.Incl)]
    [InlineData(InvoiceUpdateParamsTaxType.Excl)]
    public void SerializationRoundtrip_Works(InvoiceUpdateParamsTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceUpdateParamsTaxType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsTaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsTaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceUpdateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(InvoiceUpdateParamsType.Sale)]
    [InlineData(InvoiceUpdateParamsType.Refund)]
    public void Validation_Works(InvoiceUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceUpdateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvoiceUpdateParamsType.Sale)]
    [InlineData(InvoiceUpdateParamsType.Refund)]
    public void SerializationRoundtrip_Works(InvoiceUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvoiceUpdateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvoiceUpdateParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
