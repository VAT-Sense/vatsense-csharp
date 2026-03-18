using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Countries;

namespace VatSense.Tests.Models.Countries;

public class CountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Country
        {
            CountryCode = "GB",
            CountryName = "United Kingdom",
            Eu = false,
            Latitude = 54,
            Longitude = -2,
            Object = Object.Country,
            Vat = true,
        };

        string expectedCountryCode = "GB";
        string expectedCountryName = "United Kingdom";
        bool expectedEu = false;
        double expectedLatitude = 54;
        double expectedLongitude = -2;
        ApiEnum<string, Object> expectedObject = Object.Country;
        bool expectedVat = true;

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCountryName, model.CountryName);
        Assert.Equal(expectedEu, model.Eu);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedVat, model.Vat);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Country
        {
            CountryCode = "GB",
            CountryName = "United Kingdom",
            Eu = false,
            Latitude = 54,
            Longitude = -2,
            Object = Object.Country,
            Vat = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Country>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Country
        {
            CountryCode = "GB",
            CountryName = "United Kingdom",
            Eu = false,
            Latitude = 54,
            Longitude = -2,
            Object = Object.Country,
            Vat = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Country>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountryCode = "GB";
        string expectedCountryName = "United Kingdom";
        bool expectedEu = false;
        double expectedLatitude = 54;
        double expectedLongitude = -2;
        ApiEnum<string, Object> expectedObject = Object.Country;
        bool expectedVat = true;

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCountryName, deserialized.CountryName);
        Assert.Equal(expectedEu, deserialized.Eu);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedVat, deserialized.Vat);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Country
        {
            CountryCode = "GB",
            CountryName = "United Kingdom",
            Eu = false,
            Latitude = 54,
            Longitude = -2,
            Object = Object.Country,
            Vat = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Country { };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("country_name"));
        Assert.Null(model.Eu);
        Assert.False(model.RawData.ContainsKey("eu"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Vat);
        Assert.False(model.RawData.ContainsKey("vat"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Country { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Country
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Latitude = null,
            Longitude = null,
            Object = null,
            Vat = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("country_name"));
        Assert.Null(model.Eu);
        Assert.False(model.RawData.ContainsKey("eu"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Vat);
        Assert.False(model.RawData.ContainsKey("vat"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Country
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Latitude = null,
            Longitude = null,
            Object = null,
            Vat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Country
        {
            CountryCode = "GB",
            CountryName = "United Kingdom",
            Eu = false,
            Latitude = 54,
            Longitude = -2,
            Object = Object.Country,
            Vat = true,
        };

        Country copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(Object.Country)]
    public void Validation_Works(Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Object> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Object.Country)]
    public void SerializationRoundtrip_Works(Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Object> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Object>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
