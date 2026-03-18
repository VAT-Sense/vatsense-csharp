using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Validate;

namespace Vatsense.Tests.Models.Validate;

public class ValidateCheckResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValidateCheckResponse
        {
            Code = 200,
            Data = new()
            {
                Company = new ValidationCompany()
                {
                    CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                    CompanyName = "WEIO LTD",
                    CountryCode = "GB",
                    VatNumber = "288305674",
                },
                ConsultationNumber = "WAPIAAAAXT9mrLue",
                Valid = true,
            },
            Success = true,
        };

        long expectedCode = 200;
        Data expectedData = new()
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            ConsultationNumber = "WAPIAAAAXT9mrLue",
            Valid = true,
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ValidateCheckResponse
        {
            Code = 200,
            Data = new()
            {
                Company = new ValidationCompany()
                {
                    CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                    CompanyName = "WEIO LTD",
                    CountryCode = "GB",
                    VatNumber = "288305674",
                },
                ConsultationNumber = "WAPIAAAAXT9mrLue",
                Valid = true,
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidateCheckResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValidateCheckResponse
        {
            Code = 200,
            Data = new()
            {
                Company = new ValidationCompany()
                {
                    CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                    CompanyName = "WEIO LTD",
                    CountryCode = "GB",
                    VatNumber = "288305674",
                },
                ConsultationNumber = "WAPIAAAAXT9mrLue",
                Valid = true,
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidateCheckResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        Data expectedData = new()
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            ConsultationNumber = "WAPIAAAAXT9mrLue",
            Valid = true,
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ValidateCheckResponse
        {
            Code = 200,
            Data = new()
            {
                Company = new ValidationCompany()
                {
                    CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                    CompanyName = "WEIO LTD",
                    CountryCode = "GB",
                    VatNumber = "288305674",
                },
                ConsultationNumber = "WAPIAAAAXT9mrLue",
                Valid = true,
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ValidateCheckResponse { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ValidateCheckResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ValidateCheckResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Data = null,
            Success = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ValidateCheckResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Data = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ValidateCheckResponse
        {
            Code = 200,
            Data = new()
            {
                Company = new ValidationCompany()
                {
                    CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                    CompanyName = "WEIO LTD",
                    CountryCode = "GB",
                    VatNumber = "288305674",
                },
                ConsultationNumber = "WAPIAAAAXT9mrLue",
                Valid = true,
            },
            Success = true,
        };

        ValidateCheckResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            ConsultationNumber = "WAPIAAAAXT9mrLue",
            Valid = true,
        };

        Company expectedCompany = new ValidationCompany()
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };
        string expectedConsultationNumber = "WAPIAAAAXT9mrLue";
        bool expectedValid = true;

        Assert.Equal(expectedCompany, model.Company);
        Assert.Equal(expectedConsultationNumber, model.ConsultationNumber);
        Assert.Equal(expectedValid, model.Valid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            ConsultationNumber = "WAPIAAAAXT9mrLue",
            Valid = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            ConsultationNumber = "WAPIAAAAXT9mrLue",
            Valid = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Company expectedCompany = new ValidationCompany()
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };
        string expectedConsultationNumber = "WAPIAAAAXT9mrLue";
        bool expectedValid = true;

        Assert.Equal(expectedCompany, deserialized.Company);
        Assert.Equal(expectedConsultationNumber, deserialized.ConsultationNumber);
        Assert.Equal(expectedValid, deserialized.Valid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            ConsultationNumber = "WAPIAAAAXT9mrLue",
            Valid = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { ConsultationNumber = "WAPIAAAAXT9mrLue" };

        Assert.Null(model.Company);
        Assert.False(model.RawData.ContainsKey("company"));
        Assert.Null(model.Valid);
        Assert.False(model.RawData.ContainsKey("valid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { ConsultationNumber = "WAPIAAAAXT9mrLue" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            ConsultationNumber = "WAPIAAAAXT9mrLue",

            // Null should be interpreted as omitted for these properties
            Company = null,
            Valid = null,
        };

        Assert.Null(model.Company);
        Assert.False(model.RawData.ContainsKey("company"));
        Assert.Null(model.Valid);
        Assert.False(model.RawData.ContainsKey("valid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ConsultationNumber = "WAPIAAAAXT9mrLue",

            // Null should be interpreted as omitted for these properties
            Company = null,
            Valid = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            Valid = true,
        };

        Assert.Null(model.ConsultationNumber);
        Assert.False(model.RawData.ContainsKey("consultation_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            Valid = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            Valid = true,

            ConsultationNumber = null,
        };

        Assert.Null(model.ConsultationNumber);
        Assert.True(model.RawData.ContainsKey("consultation_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            Valid = true,

            ConsultationNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Company = new ValidationCompany()
            {
                CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
                CompanyName = "WEIO LTD",
                CountryCode = "GB",
                VatNumber = "288305674",
            },
            ConsultationNumber = "WAPIAAAAXT9mrLue",
            Valid = true,
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CompanyTest : TestBase
{
    [Fact]
    public void ValidationValidationWorks()
    {
        Company value = new ValidationCompany()
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };
        value.Validate();
    }

    [Fact]
    public void EoriValidationValidationWorks()
    {
        Company value = new EoriValidationCompany()
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "EXAMPLE LTD",
            CountryCode = "GB",
            EoriNumber = "123456789123",
        };
        value.Validate();
    }

    [Fact]
    public void ValidationSerializationRoundtripWorks()
    {
        Company value = new ValidationCompany()
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Company>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EoriValidationSerializationRoundtripWorks()
    {
        Company value = new EoriValidationCompany()
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "EXAMPLE LTD",
            CountryCode = "GB",
            EoriNumber = "123456789123",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Company>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ValidationCompanyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };

        string expectedCompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF";
        string expectedCompanyName = "WEIO LTD";
        string expectedCountryCode = "GB";
        string expectedVatNumber = "288305674";

        Assert.Equal(expectedCompanyAddress, model.CompanyAddress);
        Assert.Equal(expectedCompanyName, model.CompanyName);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedVatNumber, model.VatNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationCompany>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationCompany>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF";
        string expectedCompanyName = "WEIO LTD";
        string expectedCountryCode = "GB";
        string expectedVatNumber = "288305674";

        Assert.Equal(expectedCompanyAddress, deserialized.CompanyAddress);
        Assert.Equal(expectedCompanyName, deserialized.CompanyName);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedVatNumber, deserialized.VatNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ValidationCompany { };

        Assert.Null(model.CompanyAddress);
        Assert.False(model.RawData.ContainsKey("company_address"));
        Assert.Null(model.CompanyName);
        Assert.False(model.RawData.ContainsKey("company_name"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ValidationCompany { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ValidationCompany
        {
            // Null should be interpreted as omitted for these properties
            CompanyAddress = null,
            CompanyName = null,
            CountryCode = null,
            VatNumber = null,
        };

        Assert.Null(model.CompanyAddress);
        Assert.False(model.RawData.ContainsKey("company_address"));
        Assert.Null(model.CompanyName);
        Assert.False(model.RawData.ContainsKey("company_name"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.VatNumber);
        Assert.False(model.RawData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ValidationCompany
        {
            // Null should be interpreted as omitted for these properties
            CompanyAddress = null,
            CompanyName = null,
            CountryCode = null,
            VatNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "WEIO LTD",
            CountryCode = "GB",
            VatNumber = "288305674",
        };

        ValidationCompany copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EoriValidationCompanyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EoriValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "EXAMPLE LTD",
            CountryCode = "GB",
            EoriNumber = "123456789123",
        };

        string expectedCompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF";
        string expectedCompanyName = "EXAMPLE LTD";
        string expectedCountryCode = "GB";
        string expectedEoriNumber = "123456789123";

        Assert.Equal(expectedCompanyAddress, model.CompanyAddress);
        Assert.Equal(expectedCompanyName, model.CompanyName);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedEoriNumber, model.EoriNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EoriValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "EXAMPLE LTD",
            CountryCode = "GB",
            EoriNumber = "123456789123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EoriValidationCompany>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EoriValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "EXAMPLE LTD",
            CountryCode = "GB",
            EoriNumber = "123456789123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EoriValidationCompany>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF";
        string expectedCompanyName = "EXAMPLE LTD";
        string expectedCountryCode = "GB";
        string expectedEoriNumber = "123456789123";

        Assert.Equal(expectedCompanyAddress, deserialized.CompanyAddress);
        Assert.Equal(expectedCompanyName, deserialized.CompanyName);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedEoriNumber, deserialized.EoriNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EoriValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "EXAMPLE LTD",
            CountryCode = "GB",
            EoriNumber = "123456789123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EoriValidationCompany { };

        Assert.Null(model.CompanyAddress);
        Assert.False(model.RawData.ContainsKey("company_address"));
        Assert.Null(model.CompanyName);
        Assert.False(model.RawData.ContainsKey("company_name"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.EoriNumber);
        Assert.False(model.RawData.ContainsKey("eori_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EoriValidationCompany { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EoriValidationCompany
        {
            // Null should be interpreted as omitted for these properties
            CompanyAddress = null,
            CompanyName = null,
            CountryCode = null,
            EoriNumber = null,
        };

        Assert.Null(model.CompanyAddress);
        Assert.False(model.RawData.ContainsKey("company_address"));
        Assert.Null(model.CompanyName);
        Assert.False(model.RawData.ContainsKey("company_name"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.EoriNumber);
        Assert.False(model.RawData.ContainsKey("eori_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EoriValidationCompany
        {
            // Null should be interpreted as omitted for these properties
            CompanyAddress = null,
            CompanyName = null,
            CountryCode = null,
            EoriNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EoriValidationCompany
        {
            CompanyAddress = "142 CROMWELL ROAD\nLONDON\nGREATER LONDON\n\n\nSW7 4EF",
            CompanyName = "EXAMPLE LTD",
            CountryCode = "GB",
            EoriNumber = "123456789123",
        };

        EoriValidationCompany copied = new(model);

        Assert.Equal(model, copied);
    }
}
