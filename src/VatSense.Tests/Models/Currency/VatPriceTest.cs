using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Currency;

namespace VatSense.Tests.Models.Currency;

public class VatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VatPrice
        {
            Object = Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };

        ApiEnum<string, Object> expectedObject = Object.VatPrice;
        double expectedPrice = 20;
        double expectedPriceExclVat = 20;
        double expectedPriceInclVat = 21.1;
        ApiEnum<string, VatPriceTaxType> expectedTaxType = VatPriceTaxType.Excl;
        double expectedVat = 1.1;
        double expectedVatRate = 5.5;

        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedPrice, model.Price);
        Assert.Equal(expectedPriceExclVat, model.PriceExclVat);
        Assert.Equal(expectedPriceInclVat, model.PriceInclVat);
        Assert.Equal(expectedTaxType, model.TaxType);
        Assert.Equal(expectedVat, model.Vat);
        Assert.Equal(expectedVatRate, model.VatRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VatPrice
        {
            Object = Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VatPrice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VatPrice
        {
            Object = Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Object> expectedObject = Object.VatPrice;
        double expectedPrice = 20;
        double expectedPriceExclVat = 20;
        double expectedPriceInclVat = 21.1;
        ApiEnum<string, VatPriceTaxType> expectedTaxType = VatPriceTaxType.Excl;
        double expectedVat = 1.1;
        double expectedVatRate = 5.5;

        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.Equal(expectedPriceExclVat, deserialized.PriceExclVat);
        Assert.Equal(expectedPriceInclVat, deserialized.PriceInclVat);
        Assert.Equal(expectedTaxType, deserialized.TaxType);
        Assert.Equal(expectedVat, deserialized.Vat);
        Assert.Equal(expectedVatRate, deserialized.VatRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VatPrice
        {
            Object = Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VatPrice { };

        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceExclVat);
        Assert.False(model.RawData.ContainsKey("price_excl_vat"));
        Assert.Null(model.PriceInclVat);
        Assert.False(model.RawData.ContainsKey("price_incl_vat"));
        Assert.Null(model.TaxType);
        Assert.False(model.RawData.ContainsKey("tax_type"));
        Assert.Null(model.Vat);
        Assert.False(model.RawData.ContainsKey("vat"));
        Assert.Null(model.VatRate);
        Assert.False(model.RawData.ContainsKey("vat_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VatPrice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VatPrice
        {
            // Null should be interpreted as omitted for these properties
            Object = null,
            Price = null,
            PriceExclVat = null,
            PriceInclVat = null,
            TaxType = null,
            Vat = null,
            VatRate = null,
        };

        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.PriceExclVat);
        Assert.False(model.RawData.ContainsKey("price_excl_vat"));
        Assert.Null(model.PriceInclVat);
        Assert.False(model.RawData.ContainsKey("price_incl_vat"));
        Assert.Null(model.TaxType);
        Assert.False(model.RawData.ContainsKey("tax_type"));
        Assert.Null(model.Vat);
        Assert.False(model.RawData.ContainsKey("vat"));
        Assert.Null(model.VatRate);
        Assert.False(model.RawData.ContainsKey("vat_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VatPrice
        {
            // Null should be interpreted as omitted for these properties
            Object = null,
            Price = null,
            PriceExclVat = null,
            PriceInclVat = null,
            TaxType = null,
            Vat = null,
            VatRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VatPrice
        {
            Object = Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };

        VatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(Object.VatPrice)]
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
    [InlineData(Object.VatPrice)]
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

public class VatPriceTaxTypeTest : TestBase
{
    [Theory]
    [InlineData(VatPriceTaxType.Incl)]
    [InlineData(VatPriceTaxType.Excl)]
    public void Validation_Works(VatPriceTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VatPriceTaxType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VatPriceTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VatPriceTaxType.Incl)]
    [InlineData(VatPriceTaxType.Excl)]
    public void SerializationRoundtrip_Works(VatPriceTaxType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VatPriceTaxType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VatPriceTaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VatPriceTaxType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VatPriceTaxType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
