using System;
using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Currency;

namespace VatSense.Tests.Models.Currency;

public class CurrencyConvertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CurrencyConvertParams
        {
            Amount = "39.99",
            From = "USD",
            To = CurrencyConvertParamsTo.Gbp,
        };

        string expectedAmount = "39.99";
        string expectedFrom = "USD";
        ApiEnum<string, CurrencyConvertParamsTo> expectedTo = CurrencyConvertParamsTo.Gbp;

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedFrom, parameters.From);
        Assert.Equal(expectedTo, parameters.To);
    }

    [Fact]
    public void Url_Works()
    {
        CurrencyConvertParams parameters = new()
        {
            Amount = "39.99",
            From = "USD",
            To = CurrencyConvertParamsTo.Gbp,
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri("https://api.vatsense.com/1.0/currency/convert?amount=39.99&from=USD&to=GBP"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CurrencyConvertParams
        {
            Amount = "39.99",
            From = "USD",
            To = CurrencyConvertParamsTo.Gbp,
        };

        CurrencyConvertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CurrencyConvertParamsToTest : TestBase
{
    [Theory]
    [InlineData(CurrencyConvertParamsTo.Gbp)]
    [InlineData(CurrencyConvertParamsTo.Eur)]
    public void Validation_Works(CurrencyConvertParamsTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CurrencyConvertParamsTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CurrencyConvertParamsTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CurrencyConvertParamsTo.Gbp)]
    [InlineData(CurrencyConvertParamsTo.Eur)]
    public void SerializationRoundtrip_Works(CurrencyConvertParamsTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CurrencyConvertParamsTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CurrencyConvertParamsTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CurrencyConvertParamsTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CurrencyConvertParamsTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
