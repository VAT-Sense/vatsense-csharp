using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Rates;
using Currency = VatSense.Models.Currency;

namespace VatSense.Tests.Models.Rates;

public class RateCalculatePriceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateCalculatePriceResponse
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = DataObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
                VatPrice = new()
                {
                    Object = Currency::Object.VatPrice,
                    Price = 20,
                    PriceExclVat = 20,
                    PriceInclVat = 21.1,
                    TaxType = Currency::VatPriceTaxType.Excl,
                    Vat = 1.1,
                    VatRate = 5.5,
                },
            },
            Success = true,
        };

        long expectedCode = 200;
        Data expectedData = new()
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = DataObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
            VatPrice = new()
            {
                Object = Currency::Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = Currency::VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RateCalculatePriceResponse
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = DataObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
                VatPrice = new()
                {
                    Object = Currency::Object.VatPrice,
                    Price = 20,
                    PriceExclVat = 20,
                    PriceInclVat = 21.1,
                    TaxType = Currency::VatPriceTaxType.Excl,
                    Vat = 1.1,
                    VatRate = 5.5,
                },
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateCalculatePriceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RateCalculatePriceResponse
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = DataObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
                VatPrice = new()
                {
                    Object = Currency::Object.VatPrice,
                    Price = 20,
                    PriceExclVat = 20,
                    PriceInclVat = 21.1,
                    TaxType = Currency::VatPriceTaxType.Excl,
                    Vat = 1.1,
                    VatRate = 5.5,
                },
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateCalculatePriceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        Data expectedData = new()
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = DataObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
            VatPrice = new()
            {
                Object = Currency::Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = Currency::VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RateCalculatePriceResponse
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = DataObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
                VatPrice = new()
                {
                    Object = Currency::Object.VatPrice,
                    Price = 20,
                    PriceExclVat = 20,
                    PriceInclVat = 21.1,
                    TaxType = Currency::VatPriceTaxType.Excl,
                    Vat = 1.1,
                    VatRate = 5.5,
                },
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RateCalculatePriceResponse { };

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
        var model = new RateCalculatePriceResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RateCalculatePriceResponse
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
        var model = new RateCalculatePriceResponse
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
        var model = new RateCalculatePriceResponse
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = DataObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
                VatPrice = new()
                {
                    Object = Currency::Object.VatPrice,
                    Price = 20,
                    PriceExclVat = 20,
                    PriceInclVat = 21.1,
                    TaxType = Currency::VatPriceTaxType.Excl,
                    Vat = 1.1,
                    VatRate = 5.5,
                },
            },
            Success = true,
        };

        RateCalculatePriceResponse copied = new(model);

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
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = DataObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
            VatPrice = new()
            {
                Object = Currency::Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = Currency::VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
        };

        string expectedCountryCode = "FR";
        string expectedCountryName = "France";
        bool expectedEu = true;
        ApiEnum<string, DataObject> expectedObject = DataObject.Rate;
        TaxRate expectedTaxRate = new()
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };
        Currency::VatPrice expectedVatPrice = new()
        {
            Object = Currency::Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = Currency::VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCountryName, model.CountryName);
        Assert.Equal(expectedEu, model.Eu);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedTaxRate, model.TaxRate);
        Assert.Equal(expectedVatPrice, model.VatPrice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = DataObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
            VatPrice = new()
            {
                Object = Currency::Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = Currency::VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
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
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = DataObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
            VatPrice = new()
            {
                Object = Currency::Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = Currency::VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCountryCode = "FR";
        string expectedCountryName = "France";
        bool expectedEu = true;
        ApiEnum<string, DataObject> expectedObject = DataObject.Rate;
        TaxRate expectedTaxRate = new()
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };
        Currency::VatPrice expectedVatPrice = new()
        {
            Object = Currency::Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = Currency::VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCountryName, deserialized.CountryName);
        Assert.Equal(expectedEu, deserialized.Eu);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
        Assert.Equal(expectedVatPrice, deserialized.VatPrice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = DataObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
            VatPrice = new()
            {
                Object = Currency::Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = Currency::VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("country_name"));
        Assert.Null(model.Eu);
        Assert.False(model.RawData.ContainsKey("eu"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.TaxRate);
        Assert.False(model.RawData.ContainsKey("tax_rate"));
        Assert.Null(model.VatPrice);
        Assert.False(model.RawData.ContainsKey("vat_price"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Object = null,
            TaxRate = null,
            VatPrice = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("country_name"));
        Assert.Null(model.Eu);
        Assert.False(model.RawData.ContainsKey("eu"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.TaxRate);
        Assert.False(model.RawData.ContainsKey("tax_rate"));
        Assert.Null(model.VatPrice);
        Assert.False(model.RawData.ContainsKey("vat_price"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Object = null,
            TaxRate = null,
            VatPrice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = DataObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
            VatPrice = new()
            {
                Object = Currency::Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = Currency::VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataObjectTest : TestBase
{
    [Theory]
    [InlineData(DataObject.Rate)]
    public void Validation_Works(DataObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataObject> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataObject.Rate)]
    public void SerializationRoundtrip_Works(DataObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataObject> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
