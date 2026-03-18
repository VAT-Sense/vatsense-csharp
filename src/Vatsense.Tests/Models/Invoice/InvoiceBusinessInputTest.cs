using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Invoice;

namespace Vatsense.Tests.Models.Invoice;

public class InvoiceBusinessInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceBusinessInput
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

        string expectedAddress = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom";
        string expectedName = "VAT Sense";
        string expectedVatNumber = "GB12345678";
        string expectedBankAccount = "bank_account";
        string expectedCompanyNumber = "9839222";
        string expectedEmail = "dev@stainless.com";
        string expectedLogo = "https://example.com";
        string expectedPhone = "phone";
        string expectedWebsite = "https://example.com";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedVatNumber, model.VatNumber);
        Assert.Equal(expectedBankAccount, model.BankAccount);
        Assert.Equal(expectedCompanyNumber, model.CompanyNumber);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedLogo, model.Logo);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedWebsite, model.Website);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceBusinessInput
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceBusinessInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceBusinessInput
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceBusinessInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddress = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom";
        string expectedName = "VAT Sense";
        string expectedVatNumber = "GB12345678";
        string expectedBankAccount = "bank_account";
        string expectedCompanyNumber = "9839222";
        string expectedEmail = "dev@stainless.com";
        string expectedLogo = "https://example.com";
        string expectedPhone = "phone";
        string expectedWebsite = "https://example.com";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedVatNumber, deserialized.VatNumber);
        Assert.Equal(expectedBankAccount, deserialized.BankAccount);
        Assert.Equal(expectedCompanyNumber, deserialized.CompanyNumber);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedLogo, deserialized.Logo);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedWebsite, deserialized.Website);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceBusinessInput
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceBusinessInput
        {
            Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
            Name = "VAT Sense",
            VatNumber = "GB12345678",
        };

        Assert.Null(model.BankAccount);
        Assert.False(model.RawData.ContainsKey("bank_account"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Logo);
        Assert.False(model.RawData.ContainsKey("logo"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceBusinessInput
        {
            Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
            Name = "VAT Sense",
            VatNumber = "GB12345678",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InvoiceBusinessInput
        {
            Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
            Name = "VAT Sense",
            VatNumber = "GB12345678",

            // Null should be interpreted as omitted for these properties
            BankAccount = null,
            CompanyNumber = null,
            Email = null,
            Logo = null,
            Phone = null,
            Website = null,
        };

        Assert.Null(model.BankAccount);
        Assert.False(model.RawData.ContainsKey("bank_account"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Logo);
        Assert.False(model.RawData.ContainsKey("logo"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceBusinessInput
        {
            Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
            Name = "VAT Sense",
            VatNumber = "GB12345678",

            // Null should be interpreted as omitted for these properties
            BankAccount = null,
            CompanyNumber = null,
            Email = null,
            Logo = null,
            Phone = null,
            Website = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceBusinessInput
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

        InvoiceBusinessInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
