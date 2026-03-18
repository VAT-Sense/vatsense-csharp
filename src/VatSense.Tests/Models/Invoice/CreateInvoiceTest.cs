using System.Collections.Generic;
using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Invoice;
using VatSense.Models.Invoice.Item;

namespace VatSense.Tests.Models.Invoice;

public class CreateInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateInvoice
        {
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
            TaxType = CreateInvoiceTaxType.Incl,
            Type = CreateInvoiceType.Sale,
            ZeroRated = true,
        };

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
        ApiEnum<string, CreateInvoiceTaxType> expectedTaxType = CreateInvoiceTaxType.Incl;
        ApiEnum<string, CreateInvoiceType> expectedType = CreateInvoiceType.Sale;
        bool expectedZeroRated = true;

        Assert.Equal(expectedBusiness, model.Business);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedTaxPoint, model.TaxPoint);
        Assert.Equal(expectedConversion, model.Conversion);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedHasVat, model.HasVat);
        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedIsCopy, model.IsCopy);
        Assert.Equal(expectedIsReverseCharge, model.IsReverseCharge);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedPadInvoiceNumber, model.PadInvoiceNumber);
        Assert.Equal(expectedSerial, model.Serial);
        Assert.Equal(expectedTaxType, model.TaxType);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedZeroRated, model.ZeroRated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateInvoice
        {
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
            TaxType = CreateInvoiceTaxType.Incl,
            Type = CreateInvoiceType.Sale,
            ZeroRated = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateInvoice
        {
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
            TaxType = CreateInvoiceTaxType.Incl,
            Type = CreateInvoiceType.Sale,
            ZeroRated = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        ApiEnum<string, CreateInvoiceTaxType> expectedTaxType = CreateInvoiceTaxType.Incl;
        ApiEnum<string, CreateInvoiceType> expectedType = CreateInvoiceType.Sale;
        bool expectedZeroRated = true;

        Assert.Equal(expectedBusiness, deserialized.Business);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedTaxPoint, deserialized.TaxPoint);
        Assert.Equal(expectedConversion, deserialized.Conversion);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedHasVat, deserialized.HasVat);
        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedIsCopy, deserialized.IsCopy);
        Assert.Equal(expectedIsReverseCharge, deserialized.IsReverseCharge);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedPadInvoiceNumber, deserialized.PadInvoiceNumber);
        Assert.Equal(expectedSerial, deserialized.Serial);
        Assert.Equal(expectedTaxType, deserialized.TaxType);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedZeroRated, deserialized.ZeroRated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateInvoice
        {
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
            TaxType = CreateInvoiceTaxType.Incl,
            Type = CreateInvoiceType.Sale,
            ZeroRated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateInvoice
        {
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

        Assert.Null(model.Conversion);
        Assert.False(model.RawData.ContainsKey("conversion"));
        Assert.Null(model.Customer);
        Assert.False(model.RawData.ContainsKey("customer"));
        Assert.Null(model.HasVat);
        Assert.False(model.RawData.ContainsKey("has_vat"));
        Assert.Null(model.InvoiceNumber);
        Assert.False(model.RawData.ContainsKey("invoice_number"));
        Assert.Null(model.IsCopy);
        Assert.False(model.RawData.ContainsKey("is_copy"));
        Assert.Null(model.IsReverseCharge);
        Assert.False(model.RawData.ContainsKey("is_reverse_charge"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PadInvoiceNumber);
        Assert.False(model.RawData.ContainsKey("pad_invoice_number"));
        Assert.Null(model.Serial);
        Assert.False(model.RawData.ContainsKey("serial"));
        Assert.Null(model.TaxType);
        Assert.False(model.RawData.ContainsKey("tax_type"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.ZeroRated);
        Assert.False(model.RawData.ContainsKey("zero_rated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateInvoice
        {
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateInvoice
        {
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

        Assert.Null(model.Conversion);
        Assert.False(model.RawData.ContainsKey("conversion"));
        Assert.Null(model.Customer);
        Assert.False(model.RawData.ContainsKey("customer"));
        Assert.Null(model.HasVat);
        Assert.False(model.RawData.ContainsKey("has_vat"));
        Assert.Null(model.InvoiceNumber);
        Assert.False(model.RawData.ContainsKey("invoice_number"));
        Assert.Null(model.IsCopy);
        Assert.False(model.RawData.ContainsKey("is_copy"));
        Assert.Null(model.IsReverseCharge);
        Assert.False(model.RawData.ContainsKey("is_reverse_charge"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.PadInvoiceNumber);
        Assert.False(model.RawData.ContainsKey("pad_invoice_number"));
        Assert.Null(model.Serial);
        Assert.False(model.RawData.ContainsKey("serial"));
        Assert.Null(model.TaxType);
        Assert.False(model.RawData.ContainsKey("tax_type"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.ZeroRated);
        Assert.False(model.RawData.ContainsKey("zero_rated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateInvoice
        {
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateInvoice
        {
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
            TaxType = CreateInvoiceTaxType.Incl,
            Type = CreateInvoiceType.Sale,
            ZeroRated = true,
        };

        CreateInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreateInvoiceTaxTypeTest : TestBase
{
    [Theory]
    [InlineData(CreateInvoiceTaxType.Incl)]
    [InlineData(CreateInvoiceTaxType.Excl)]
    public void Validation_Works(CreateInvoiceTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateInvoiceTaxType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateInvoiceTaxType.Incl)]
    [InlineData(CreateInvoiceTaxType.Excl)]
    public void SerializationRoundtrip_Works(CreateInvoiceTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateInvoiceTaxType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceTaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceTaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateInvoiceTypeTest : TestBase
{
    [Theory]
    [InlineData(CreateInvoiceType.Sale)]
    [InlineData(CreateInvoiceType.Refund)]
    public void Validation_Works(CreateInvoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateInvoiceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateInvoiceType.Sale)]
    [InlineData(CreateInvoiceType.Refund)]
    public void SerializationRoundtrip_Works(CreateInvoiceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateInvoiceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreateInvoiceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
