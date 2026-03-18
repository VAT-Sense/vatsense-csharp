using System;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Currency;

namespace Vatsense.Tests.Models.Currency;

public class CurrencyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CurrencyListParams { From = "USD,CAD,AUD", To = To.Gbp };

        string expectedFrom = "USD,CAD,AUD";
        ApiEnum<string, To> expectedTo = To.Gbp;

        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedTo, parameters.To);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CurrencyListParams { };

        Assert.Null(parameters.From);
        Assert.False(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CurrencyListParams
        {
            // Null should be interpreted as omitted for these properties
            From = null,
            To = null,
        };

        Assert.Null(parameters.From);
        Assert.False(parameters.RawQueryData.ContainsKey("from"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void Url_Works()
    {
        CurrencyListParams parameters = new() { From = "USD,CAD,AUD", To = To.Gbp };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri("https://api.vatsense.com/1.0/currency?from=USD%2cCAD%2cAUD&to=GBP"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CurrencyListParams { From = "USD,CAD,AUD", To = To.Gbp };

        CurrencyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ToTest : TestBase
{
    [Theory]
    [InlineData(To.Gbp)]
    [InlineData(To.Eur)]
    public void Validation_Works(To rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, To> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(To.Gbp)]
    [InlineData(To.Eur)]
    public void SerializationRoundtrip_Works(To rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, To> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, To>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
