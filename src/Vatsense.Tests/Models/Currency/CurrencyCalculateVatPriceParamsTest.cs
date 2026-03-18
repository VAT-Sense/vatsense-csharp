using System;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Currency;

namespace Vatsense.Tests.Models.Currency;

public class CurrencyCalculateVatPriceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CurrencyCalculateVatPriceParams
        {
            Price = "20.00",
            TaxType = TaxType.Excl,
            VatRate = 5,
        };

        string expectedPrice = "20.00";
        ApiEnum<string, TaxType> expectedTaxType = TaxType.Excl;
        double expectedVatRate = 5;

        Assert.Equal(expectedPrice, parameters.Price);
        Assert.Equal(expectedTaxType, parameters.TaxType);
        Assert.Equal(expectedVatRate, parameters.VatRate);
    }

    [Fact]
    public void Url_Works()
    {
        CurrencyCalculateVatPriceParams parameters = new()
        {
            Price = "20.00",
            TaxType = TaxType.Excl,
            VatRate = 5,
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri(
                "https://api.vatsense.com/1.0/currency/price?price=20.00&tax_type=excl&vat_rate=5"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CurrencyCalculateVatPriceParams
        {
            Price = "20.00",
            TaxType = TaxType.Excl,
            VatRate = 5,
        };

        CurrencyCalculateVatPriceParams copied = new(parameters);

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
