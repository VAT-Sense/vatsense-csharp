using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Invoice.Item;

namespace Vatsense.Tests.Models.Invoice.Item;

public class ItemRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                ID = "ii5aeae457ce201",
                DiscountRate = 40,
                Item = "Standard payment plan",
                Object = Object.Item,
                PriceEach = 19.99,
                PriceTotal = 11.99,
                Quantity = 1,
                VatRate = 20,
            },
            Success = true,
        };

        long expectedCode = 200;
        InvoiceItem expectedData = new()
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
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                ID = "ii5aeae457ce201",
                DiscountRate = 40,
                Item = "Standard payment plan",
                Object = Object.Item,
                PriceEach = 19.99,
                PriceTotal = 11.99,
                Quantity = 1,
                VatRate = 20,
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                ID = "ii5aeae457ce201",
                DiscountRate = 40,
                Item = "Standard payment plan",
                Object = Object.Item,
                PriceEach = 19.99,
                PriceTotal = 11.99,
                Quantity = 1,
                VatRate = 20,
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        InvoiceItem expectedData = new()
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
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                ID = "ii5aeae457ce201",
                DiscountRate = 40,
                Item = "Standard payment plan",
                Object = Object.Item,
                PriceEach = 19.99,
                PriceTotal = 11.99,
                Quantity = 1,
                VatRate = 20,
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ItemRetrieveResponse { };

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
        var model = new ItemRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ItemRetrieveResponse
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
        var model = new ItemRetrieveResponse
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
        var model = new ItemRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                ID = "ii5aeae457ce201",
                DiscountRate = 40,
                Item = "Standard payment plan",
                Object = Object.Item,
                PriceEach = 19.99,
                PriceTotal = 11.99,
                Quantity = 1,
                VatRate = 20,
            },
            Success = true,
        };

        ItemRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
