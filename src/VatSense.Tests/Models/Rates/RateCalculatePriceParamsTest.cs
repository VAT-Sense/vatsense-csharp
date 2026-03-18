using System;
using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Rates;

namespace VatSense.Tests.Models.Rates;

public class RateCalculatePriceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RateCalculatePriceParams
        {
            Price = "20.00",
            TaxType = TaxType.Excl,
            CountryCode = "GB",
            Eu = true,
            IPAddress = "86.27.166.97",
            ProvinceCode = "ON",
            Type = "ebooks",
        };

        string expectedPrice = "20.00";
        ApiEnum<string, TaxType> expectedTaxType = TaxType.Excl;
        string expectedCountryCode = "GB";
        bool expectedEu = true;
        string expectedIPAddress = "86.27.166.97";
        string expectedProvinceCode = "ON";
        string expectedType = "ebooks";

        Assert.Equal(expectedPrice, parameters.Price);
        Assert.Equal(expectedTaxType, parameters.TaxType);
        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedEu, parameters.Eu);
        Assert.Equal(expectedIPAddress, parameters.IPAddress);
        Assert.Equal(expectedProvinceCode, parameters.ProvinceCode);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RateCalculatePriceParams { Price = "20.00", TaxType = TaxType.Excl };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("country_code"));
        Assert.Null(parameters.Eu);
        Assert.False(parameters.RawQueryData.ContainsKey("eu"));
        Assert.Null(parameters.IPAddress);
        Assert.False(parameters.RawQueryData.ContainsKey("ip_address"));
        Assert.Null(parameters.ProvinceCode);
        Assert.False(parameters.RawQueryData.ContainsKey("province_code"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RateCalculatePriceParams
        {
            Price = "20.00",
            TaxType = TaxType.Excl,

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            Eu = null,
            IPAddress = null,
            ProvinceCode = null,
            Type = null,
        };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("country_code"));
        Assert.Null(parameters.Eu);
        Assert.False(parameters.RawQueryData.ContainsKey("eu"));
        Assert.Null(parameters.IPAddress);
        Assert.False(parameters.RawQueryData.ContainsKey("ip_address"));
        Assert.Null(parameters.ProvinceCode);
        Assert.False(parameters.RawQueryData.ContainsKey("province_code"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        RateCalculatePriceParams parameters = new()
        {
            Price = "20.00",
            TaxType = TaxType.Excl,
            CountryCode = "GB",
            Eu = true,
            IPAddress = "86.27.166.97",
            ProvinceCode = "ON",
            Type = "ebooks",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri(
                "https://api.vatsense.com/1.0/rates/price?price=20.00&tax_type=excl&country_code=GB&eu=true&ip_address=86.27.166.97&province_code=ON&type=ebooks"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RateCalculatePriceParams
        {
            Price = "20.00",
            TaxType = TaxType.Excl,
            CountryCode = "GB",
            Eu = true,
            IPAddress = "86.27.166.97",
            ProvinceCode = "ON",
            Type = "ebooks",
        };

        RateCalculatePriceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TaxTypeTest : TestBase
{
    [Theory]
    [InlineData(TaxType.Incl)]
    [InlineData(TaxType.Excl)]
    public void Validation_Works(TaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TaxType.Incl)]
    [InlineData(TaxType.Excl)]
    public void SerializationRoundtrip_Works(TaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
