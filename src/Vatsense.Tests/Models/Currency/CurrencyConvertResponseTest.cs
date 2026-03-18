using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Currency;

namespace Vatsense.Tests.Models.Currency;

public class CurrencyConvertResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencyConvertResponse
        {
            Code = 200,
            Data = new()
            {
                Amount = 39.99,
                Converted = 28.43,
                From = "USD",
                Object = CurrencyConvertResponseDataObject.Conversion,
                Rate = 1.4065,
                To = "GBP",
            },
            Success = true,
        };

        long expectedCode = 200;
        CurrencyConvertResponseData expectedData = new()
        {
            Amount = 39.99,
            Converted = 28.43,
            From = "USD",
            Object = CurrencyConvertResponseDataObject.Conversion,
            Rate = 1.4065,
            To = "GBP",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencyConvertResponse
        {
            Code = 200,
            Data = new()
            {
                Amount = 39.99,
                Converted = 28.43,
                From = "USD",
                Object = CurrencyConvertResponseDataObject.Conversion,
                Rate = 1.4065,
                To = "GBP",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyConvertResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencyConvertResponse
        {
            Code = 200,
            Data = new()
            {
                Amount = 39.99,
                Converted = 28.43,
                From = "USD",
                Object = CurrencyConvertResponseDataObject.Conversion,
                Rate = 1.4065,
                To = "GBP",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyConvertResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        CurrencyConvertResponseData expectedData = new()
        {
            Amount = 39.99,
            Converted = 28.43,
            From = "USD",
            Object = CurrencyConvertResponseDataObject.Conversion,
            Rate = 1.4065,
            To = "GBP",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencyConvertResponse
        {
            Code = 200,
            Data = new()
            {
                Amount = 39.99,
                Converted = 28.43,
                From = "USD",
                Object = CurrencyConvertResponseDataObject.Conversion,
                Rate = 1.4065,
                To = "GBP",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CurrencyConvertResponse { };

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
        var model = new CurrencyConvertResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CurrencyConvertResponse
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
        var model = new CurrencyConvertResponse
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
        var model = new CurrencyConvertResponse
        {
            Code = 200,
            Data = new()
            {
                Amount = 39.99,
                Converted = 28.43,
                From = "USD",
                Object = CurrencyConvertResponseDataObject.Conversion,
                Rate = 1.4065,
                To = "GBP",
            },
            Success = true,
        };

        CurrencyConvertResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyConvertResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencyConvertResponseData
        {
            Amount = 39.99,
            Converted = 28.43,
            From = "USD",
            Object = CurrencyConvertResponseDataObject.Conversion,
            Rate = 1.4065,
            To = "GBP",
        };

        double expectedAmount = 39.99;
        double expectedConverted = 28.43;
        string expectedFrom = "USD";
        ApiEnum<string, CurrencyConvertResponseDataObject> expectedObject =
            CurrencyConvertResponseDataObject.Conversion;
        double expectedRate = 1.4065;
        string expectedTo = "GBP";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedConverted, model.Converted);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedRate, model.Rate);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencyConvertResponseData
        {
            Amount = 39.99,
            Converted = 28.43,
            From = "USD",
            Object = CurrencyConvertResponseDataObject.Conversion,
            Rate = 1.4065,
            To = "GBP",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyConvertResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencyConvertResponseData
        {
            Amount = 39.99,
            Converted = 28.43,
            From = "USD",
            Object = CurrencyConvertResponseDataObject.Conversion,
            Rate = 1.4065,
            To = "GBP",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyConvertResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 39.99;
        double expectedConverted = 28.43;
        string expectedFrom = "USD";
        ApiEnum<string, CurrencyConvertResponseDataObject> expectedObject =
            CurrencyConvertResponseDataObject.Conversion;
        double expectedRate = 1.4065;
        string expectedTo = "GBP";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedConverted, deserialized.Converted);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedRate, deserialized.Rate);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencyConvertResponseData
        {
            Amount = 39.99,
            Converted = 28.43,
            From = "USD",
            Object = CurrencyConvertResponseDataObject.Conversion,
            Rate = 1.4065,
            To = "GBP",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CurrencyConvertResponseData { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Converted);
        Assert.False(model.RawData.ContainsKey("converted"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CurrencyConvertResponseData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CurrencyConvertResponseData
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Converted = null,
            From = null,
            Object = null,
            Rate = null,
            To = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Converted);
        Assert.False(model.RawData.ContainsKey("converted"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CurrencyConvertResponseData
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Converted = null,
            From = null,
            Object = null,
            Rate = null,
            To = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CurrencyConvertResponseData
        {
            Amount = 39.99,
            Converted = 28.43,
            From = "USD",
            Object = CurrencyConvertResponseDataObject.Conversion,
            Rate = 1.4065,
            To = "GBP",
        };

        CurrencyConvertResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyConvertResponseDataObjectTest : TestBase
{
    [Theory]
    [InlineData(CurrencyConvertResponseDataObject.Conversion)]
    public void Validation_Works(CurrencyConvertResponseDataObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CurrencyConvertResponseDataObject> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CurrencyConvertResponseDataObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CurrencyConvertResponseDataObject.Conversion)]
    public void SerializationRoundtrip_Works(CurrencyConvertResponseDataObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CurrencyConvertResponseDataObject> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CurrencyConvertResponseDataObject>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CurrencyConvertResponseDataObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CurrencyConvertResponseDataObject>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
