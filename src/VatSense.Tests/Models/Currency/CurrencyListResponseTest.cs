using System.Collections.Generic;
using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Currency;

namespace VatSense.Tests.Models.Currency;

public class CurrencyListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencyListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    From = "USD",
                    Object = DataObject.ConvertRate,
                    Rate = 1.4065,
                    To = "GBP",
                },
            ],
            Success = true,
        };

        long expectedCode = 200;
        List<Data> expectedData =
        [
            new()
            {
                From = "USD",
                Object = DataObject.ConvertRate,
                Rate = 1.4065,
                To = "GBP",
            },
        ];
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencyListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    From = "USD",
                    Object = DataObject.ConvertRate,
                    Rate = 1.4065,
                    To = "GBP",
                },
            ],
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencyListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    From = "USD",
                    Object = DataObject.ConvertRate,
                    Rate = 1.4065,
                    To = "GBP",
                },
            ],
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        List<Data> expectedData =
        [
            new()
            {
                From = "USD",
                Object = DataObject.ConvertRate,
                Rate = 1.4065,
                To = "GBP",
            },
        ];
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencyListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    From = "USD",
                    Object = DataObject.ConvertRate,
                    Rate = 1.4065,
                    To = "GBP",
                },
            ],
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CurrencyListResponse { };

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
        var model = new CurrencyListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CurrencyListResponse
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
        var model = new CurrencyListResponse
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
        var model = new CurrencyListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    From = "USD",
                    Object = DataObject.ConvertRate,
                    Rate = 1.4065,
                    To = "GBP",
                },
            ],
            Success = true,
        };

        CurrencyListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            From = "USD",
            Object = DataObject.ConvertRate,
            Rate = 1.4065,
            To = "GBP",
        };

        string expectedFrom = "USD";
        ApiEnum<string, DataObject> expectedObject = DataObject.ConvertRate;
        double expectedRate = 1.4065;
        string expectedTo = "GBP";

        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedRate, model.Rate);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            From = "USD",
            Object = DataObject.ConvertRate,
            Rate = 1.4065,
            To = "GBP",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            From = "USD",
            Object = DataObject.ConvertRate,
            Rate = 1.4065,
            To = "GBP",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFrom = "USD";
        ApiEnum<string, DataObject> expectedObject = DataObject.ConvertRate;
        double expectedRate = 1.4065;
        string expectedTo = "GBP";

        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedRate, deserialized.Rate);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            From = "USD",
            Object = DataObject.ConvertRate,
            Rate = 1.4065,
            To = "GBP",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

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
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            From = null,
            Object = null,
            Rate = null,
            To = null,
        };

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
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
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
        var model = new Data
        {
            From = "USD",
            Object = DataObject.ConvertRate,
            Rate = 1.4065,
            To = "GBP",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataObjectTest : TestBase
{
    [Theory]
    [InlineData(DataObject.ConvertRate)]
    public void Validation_Works(DataObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataObject> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataObject.ConvertRate)]
    public void SerializationRoundtrip_Works(DataObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataObject> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
