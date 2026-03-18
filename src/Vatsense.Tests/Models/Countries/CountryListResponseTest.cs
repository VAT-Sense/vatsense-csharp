using System.Collections.Generic;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Countries;

namespace Vatsense.Tests.Models.Countries;

public class CountryListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CountryListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "GB",
                    CountryName = "United Kingdom",
                    Eu = false,
                    Latitude = 54,
                    Longitude = -2,
                    Object = Object.Country,
                    Vat = true,
                },
            ],
            Success = true,
        };

        long expectedCode = 200;
        List<Country> expectedData =
        [
            new()
            {
                CountryCode = "GB",
                CountryName = "United Kingdom",
                Eu = false,
                Latitude = 54,
                Longitude = -2,
                Object = Object.Country,
                Vat = true,
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
        var model = new CountryListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "GB",
                    CountryName = "United Kingdom",
                    Eu = false,
                    Latitude = 54,
                    Longitude = -2,
                    Object = Object.Country,
                    Vat = true,
                },
            ],
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CountryListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "GB",
                    CountryName = "United Kingdom",
                    Eu = false,
                    Latitude = 54,
                    Longitude = -2,
                    Object = Object.Country,
                    Vat = true,
                },
            ],
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        List<Country> expectedData =
        [
            new()
            {
                CountryCode = "GB",
                CountryName = "United Kingdom",
                Eu = false,
                Latitude = 54,
                Longitude = -2,
                Object = Object.Country,
                Vat = true,
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
        var model = new CountryListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "GB",
                    CountryName = "United Kingdom",
                    Eu = false,
                    Latitude = 54,
                    Longitude = -2,
                    Object = Object.Country,
                    Vat = true,
                },
            ],
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CountryListResponse { };

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
        var model = new CountryListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CountryListResponse
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
        var model = new CountryListResponse
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
        var model = new CountryListResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "GB",
                    CountryName = "United Kingdom",
                    Eu = false,
                    Latitude = 54,
                    Longitude = -2,
                    Object = Object.Country,
                    Vat = true,
                },
            ],
            Success = true,
        };

        CountryListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
