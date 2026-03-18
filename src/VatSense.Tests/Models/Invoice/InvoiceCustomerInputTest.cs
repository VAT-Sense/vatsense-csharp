using System.Text.Json;
using VatSense.Core;
using VatSense.Models.Invoice;

namespace VatSense.Tests.Models.Invoice;

public class InvoiceCustomerInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceCustomerInput
        {
            Name = "Demo Co.",
            Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
            CompanyNumber = "5584922",
            CountryCode = "country_code",
            Email = "dev@stainless.com",
            Logo = "https://example.com",
            VatNumber = "GB912343332",
        };

        string expectedName = "Demo Co.";
        string expectedAddress = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom";
        string expectedCompanyNumber = "5584922";
        string expectedCountryCode = "country_code";
        string expectedEmail = "dev@stainless.com";
        string expectedLogo = "https://example.com";
        string expectedVatNumber = "GB912343332";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCompanyNumber, model.CompanyNumber);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedLogo, model.Logo);
        Assert.Equal(expectedVatNumber, model.VatNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceCustomerInput
        {
            Name = "Demo Co.",
            Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
            CompanyNumber = "5584922",
            CountryCode = "country_code",
            Email = "dev@stainless.com",
            Logo = "https://example.com",
            VatNumber = "GB912343332",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceCustomerInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceCustomerInput
        {
            Name = "Demo Co.",
            Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
            CompanyNumber = "5584922",
            CountryCode = "country_code",
            Email = "dev@stainless.com",
            Logo = "https://example.com",
            VatNumber = "GB912343332",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceCustomerInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "Demo Co.";
        string expectedAddress = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom";
        string expectedCompanyNumber = "5584922";
        string expectedCountryCode = "country_code";
        string expectedEmail = "dev@stainless.com";
        string expectedLogo = "https://example.com";
        string expectedVatNumber = "GB912343332";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCompanyNumber, deserialized.CompanyNumber);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedLogo, deserialized.Logo);
        Assert.Equal(expectedVatNumber, deserialized.VatNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceCustomerInput
        {
            Name = "Demo Co.",
            Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
            CompanyNumber = "5584922",
            CountryCode = "country_code",
            Email = "dev@stainless.com",
            Logo = "https://example.com",
            VatNumber = "GB912343332",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceCustomerInput { Name = "Demo Co." };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Logo);
        Assert.False(model.RawData.ContainsKey("logo"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceCustomerInput { Name = "Demo Co." };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InvoiceCustomerInput
        {
            Name = "Demo Co.",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CompanyNumber = null,
            CountryCode = null,
            Email = null,
            Logo = null,
            VatNumber = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.CompanyNumber);
        Assert.False(model.RawData.ContainsKey("company_number"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Logo);
        Assert.False(model.RawData.ContainsKey("logo"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceCustomerInput
        {
            Name = "Demo Co.",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CompanyNumber = null,
            CountryCode = null,
            Email = null,
            Logo = null,
            VatNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceCustomerInput
        {
            Name = "Demo Co.",
            Address = "65 Demo Road\nLondon\nSW1 3DE\nUnited Kingdom",
            CompanyNumber = "5584922",
            CountryCode = "country_code",
            Email = "dev@stainless.com",
            Logo = "https://example.com",
            VatNumber = "GB912343332",
        };

        InvoiceCustomerInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
