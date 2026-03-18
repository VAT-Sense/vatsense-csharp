using System.Text.Json;
using VatSense.Core;
using VatSense.Models.Usage;

namespace VatSense.Tests.Models.Usage;

public class UsageRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                Requests = new()
                {
                    Remaining = 77,
                    Total = 100,
                    Used = 23,
                },
            },
            Success = true,
        };

        long expectedCode = 200;
        Data expectedData = new()
        {
            Requests = new()
            {
                Remaining = 77,
                Total = 100,
                Used = 23,
            },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                Requests = new()
                {
                    Remaining = 77,
                    Total = 100,
                    Used = 23,
                },
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                Requests = new()
                {
                    Remaining = 77,
                    Total = 100,
                    Used = 23,
                },
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        Data expectedData = new()
        {
            Requests = new()
            {
                Remaining = 77,
                Total = 100,
                Used = 23,
            },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                Requests = new()
                {
                    Remaining = 77,
                    Total = 100,
                    Used = 23,
                },
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageRetrieveResponse { };

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
        var model = new UsageRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UsageRetrieveResponse
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
        var model = new UsageRetrieveResponse
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
        var model = new UsageRetrieveResponse
        {
            Code = 200,
            Data = new()
            {
                Requests = new()
                {
                    Remaining = 77,
                    Total = 100,
                    Used = 23,
                },
            },
            Success = true,
        };

        UsageRetrieveResponse copied = new(model);

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
            Requests = new()
            {
                Remaining = 77,
                Total = 100,
                Used = 23,
            },
        };

        Requests expectedRequests = new()
        {
            Remaining = 77,
            Total = 100,
            Used = 23,
        };

        Assert.Equal(expectedRequests, model.Requests);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Requests = new()
            {
                Remaining = 77,
                Total = 100,
                Used = 23,
            },
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
            Requests = new()
            {
                Remaining = 77,
                Total = 100,
                Used = 23,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Requests expectedRequests = new()
        {
            Remaining = 77,
            Total = 100,
            Used = 23,
        };

        Assert.Equal(expectedRequests, deserialized.Requests);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Requests = new()
            {
                Remaining = 77,
                Total = 100,
                Used = 23,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.Requests);
        Assert.False(model.RawData.ContainsKey("requests"));
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
            Requests = null,
        };

        Assert.Null(model.Requests);
        Assert.False(model.RawData.ContainsKey("requests"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            Requests = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Requests = new()
            {
                Remaining = 77,
                Total = 100,
                Used = 23,
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequestsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Requests
        {
            Remaining = 77,
            Total = 100,
            Used = 23,
        };

        long expectedRemaining = 77;
        long expectedTotal = 100;
        long expectedUsed = 23;

        Assert.Equal(expectedRemaining, model.Remaining);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedUsed, model.Used);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Requests
        {
            Remaining = 77,
            Total = 100,
            Used = 23,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Requests>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Requests
        {
            Remaining = 77,
            Total = 100,
            Used = 23,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Requests>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedRemaining = 77;
        long expectedTotal = 100;
        long expectedUsed = 23;

        Assert.Equal(expectedRemaining, deserialized.Remaining);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedUsed, deserialized.Used);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Requests
        {
            Remaining = 77,
            Total = 100,
            Used = 23,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Requests { };

        Assert.Null(model.Remaining);
        Assert.False(model.RawData.ContainsKey("remaining"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Used);
        Assert.False(model.RawData.ContainsKey("used"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Requests { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Requests
        {
            // Null should be interpreted as omitted for these properties
            Remaining = null,
            Total = null,
            Used = null,
        };

        Assert.Null(model.Remaining);
        Assert.False(model.RawData.ContainsKey("remaining"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
        Assert.Null(model.Used);
        Assert.False(model.RawData.ContainsKey("used"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Requests
        {
            // Null should be interpreted as omitted for these properties
            Remaining = null,
            Total = null,
            Used = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Requests
        {
            Remaining = 77,
            Total = 100,
            Used = 23,
        };

        Requests copied = new(model);

        Assert.Equal(model, copied);
    }
}
