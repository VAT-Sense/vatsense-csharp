using System.Text.Json;
using VatSense.Core;
using VatSense.Models.Invoice.Item;

namespace VatSense.Tests.Models.Invoice.Item;

public class InvoiceItemInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
            DiscountRate = 40,
        };

        string expectedItem = "Standard payment plan";
        double expectedPriceEach = 19.99;
        double expectedQuantity = 1;
        double expectedVatRate = 20;
        double expectedDiscountRate = 40;

        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedPriceEach, model.PriceEach);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedVatRate, model.VatRate);
        Assert.Equal(expectedDiscountRate, model.DiscountRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
            DiscountRate = 40,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceItemInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
            DiscountRate = 40,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceItemInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedItem = "Standard payment plan";
        double expectedPriceEach = 19.99;
        double expectedQuantity = 1;
        double expectedVatRate = 20;
        double expectedDiscountRate = 40;

        Assert.Equal(expectedItem, deserialized.Item);
        Assert.Equal(expectedPriceEach, deserialized.PriceEach);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedVatRate, deserialized.VatRate);
        Assert.Equal(expectedDiscountRate, deserialized.DiscountRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
            DiscountRate = 40,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
        };

        Assert.Null(model.DiscountRate);
        Assert.False(model.RawData.ContainsKey("discount_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,

            // Null should be interpreted as omitted for these properties
            DiscountRate = null,
        };

        Assert.Null(model.DiscountRate);
        Assert.False(model.RawData.ContainsKey("discount_rate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,

            // Null should be interpreted as omitted for these properties
            DiscountRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceItemInput
        {
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
            DiscountRate = 40,
        };

        InvoiceItemInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
