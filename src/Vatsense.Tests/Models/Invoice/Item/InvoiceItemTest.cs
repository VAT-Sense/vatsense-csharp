using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Invoice.Item;

namespace Vatsense.Tests.Models.Invoice.Item;

public class InvoiceItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            DiscountRate = 40,
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,
        };

        string expectedID = "ii5aeae457ce201";
        double expectedDiscountRate = 40;
        string expectedItem = "Standard payment plan";
        ApiEnum<string, Object> expectedObject = Object.Item;
        double expectedPriceEach = 19.99;
        double expectedPriceTotal = 11.99;
        double expectedQuantity = 1;
        double expectedVatRate = 20;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDiscountRate, model.DiscountRate);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedPriceEach, model.PriceEach);
        Assert.Equal(expectedPriceTotal, model.PriceTotal);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedVatRate, model.VatRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            DiscountRate = 40,
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            DiscountRate = 40,
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ii5aeae457ce201";
        double expectedDiscountRate = 40;
        string expectedItem = "Standard payment plan";
        ApiEnum<string, Object> expectedObject = Object.Item;
        double expectedPriceEach = 19.99;
        double expectedPriceTotal = 11.99;
        double expectedQuantity = 1;
        double expectedVatRate = 20;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDiscountRate, deserialized.DiscountRate);
        Assert.Equal(expectedItem, deserialized.Item);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedPriceEach, deserialized.PriceEach);
        Assert.Equal(expectedPriceTotal, deserialized.PriceTotal);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedVatRate, deserialized.VatRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            DiscountRate = 40,
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceItem { DiscountRate = 40 };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Item);
        Assert.False(model.RawData.ContainsKey("item"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.PriceEach);
        Assert.False(model.RawData.ContainsKey("price_each"));
        Assert.Null(model.PriceTotal);
        Assert.False(model.RawData.ContainsKey("price_total"));
        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
        Assert.Null(model.VatRate);
        Assert.False(model.RawData.ContainsKey("vat_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceItem { DiscountRate = 40 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InvoiceItem
        {
            DiscountRate = 40,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Item = null,
            Object = null,
            PriceEach = null,
            PriceTotal = null,
            Quantity = null,
            VatRate = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Item);
        Assert.False(model.RawData.ContainsKey("item"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.PriceEach);
        Assert.False(model.RawData.ContainsKey("price_each"));
        Assert.Null(model.PriceTotal);
        Assert.False(model.RawData.ContainsKey("price_total"));
        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
        Assert.Null(model.VatRate);
        Assert.False(model.RawData.ContainsKey("vat_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceItem
        {
            DiscountRate = 40,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Item = null,
            Object = null,
            PriceEach = null,
            PriceTotal = null,
            Quantity = null,
            VatRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,
        };

        Assert.Null(model.DiscountRate);
        Assert.False(model.RawData.ContainsKey("discount_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,

            DiscountRate = null,
        };

        Assert.Null(model.DiscountRate);
        Assert.True(model.RawData.ContainsKey("discount_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,

            DiscountRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceItem
        {
            ID = "ii5aeae457ce201",
            DiscountRate = 40,
            Item = "Standard payment plan",
            Object = Object.Item,
            PriceEach = 19.99,
            PriceTotal = 11.99,
            Quantity = 1,
            VatRate = 20,
        };

        InvoiceItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(Object.Item)]
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
    [InlineData(Object.Item)]
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
