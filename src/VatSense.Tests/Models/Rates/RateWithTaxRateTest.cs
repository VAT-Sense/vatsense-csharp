using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Rates;

namespace VatSense.Tests.Models.Rates;

public class RateWithTaxRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateWithTaxRate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = RateWithTaxRateObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        string expectedCountryCode = "FR";
        string expectedCountryName = "France";
        bool expectedEu = true;
        ApiEnum<string, RateWithTaxRateObject> expectedObject = RateWithTaxRateObject.Rate;
        TaxRate expectedTaxRate = new()
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCountryName, model.CountryName);
        Assert.Equal(expectedEu, model.Eu);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedTaxRate, model.TaxRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RateWithTaxRate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = RateWithTaxRateObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateWithTaxRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RateWithTaxRate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = RateWithTaxRateObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateWithTaxRate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountryCode = "FR";
        string expectedCountryName = "France";
        bool expectedEu = true;
        ApiEnum<string, RateWithTaxRateObject> expectedObject = RateWithTaxRateObject.Rate;
        TaxRate expectedTaxRate = new()
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCountryName, deserialized.CountryName);
        Assert.Equal(expectedEu, deserialized.Eu);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedTaxRate, deserialized.TaxRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RateWithTaxRate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = RateWithTaxRateObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RateWithTaxRate { };

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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RateWithTaxRate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RateWithTaxRate
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Object = null,
            TaxRate = null,
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RateWithTaxRate
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Object = null,
            TaxRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RateWithTaxRate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = RateWithTaxRateObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        RateWithTaxRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RateWithTaxRateObjectTest : TestBase
{
    [Theory]
    [InlineData(RateWithTaxRateObject.Rate)]
    public void Validation_Works(RateWithTaxRateObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RateWithTaxRateObject> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RateWithTaxRateObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RateWithTaxRateObject.Rate)]
    public void SerializationRoundtrip_Works(RateWithTaxRateObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RateWithTaxRateObject> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RateWithTaxRateObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RateWithTaxRateObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RateWithTaxRateObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
