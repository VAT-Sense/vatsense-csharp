using System.Collections.Generic;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Countries;

namespace Vatsense.Tests.Models.Countries;

public class CountryListProvincesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CountryListProvincesResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "CA",
                    Object = DataObject.Province,
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario",
                },
            ],
            Success = true,
        };

        long expectedCode = 200;
        List<Data> expectedData =
        [
            new()
            {
                CountryCode = "CA",
                Object = DataObject.Province,
                ProvinceCode = "ON",
                ProvinceName = "Ontario",
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
        var model = new CountryListProvincesResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "CA",
                    Object = DataObject.Province,
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario",
                },
            ],
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryListProvincesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CountryListProvincesResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "CA",
                    Object = DataObject.Province,
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario",
                },
            ],
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CountryListProvincesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        List<Data> expectedData =
        [
            new()
            {
                CountryCode = "CA",
                Object = DataObject.Province,
                ProvinceCode = "ON",
                ProvinceName = "Ontario",
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
        var model = new CountryListProvincesResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "CA",
                    Object = DataObject.Province,
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario",
                },
            ],
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CountryListProvincesResponse { };

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
        var model = new CountryListProvincesResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CountryListProvincesResponse
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
        var model = new CountryListProvincesResponse
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
        var model = new CountryListProvincesResponse
        {
            Code = 200,
            Data =
            [
                new()
                {
                    CountryCode = "CA",
                    Object = DataObject.Province,
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario",
                },
            ],
            Success = true,
        };

        CountryListProvincesResponse copied = new(model);

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
            CountryCode = "CA",
            Object = DataObject.Province,
            ProvinceCode = "ON",
            ProvinceName = "Ontario",
        };

        string expectedCountryCode = "CA";
        ApiEnum<string, DataObject> expectedObject = DataObject.Province;
        string expectedProvinceCode = "ON";
        string expectedProvinceName = "Ontario";

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedProvinceCode, model.ProvinceCode);
        Assert.Equal(expectedProvinceName, model.ProvinceName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            CountryCode = "CA",
            Object = DataObject.Province,
            ProvinceCode = "ON",
            ProvinceName = "Ontario",
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
            CountryCode = "CA",
            Object = DataObject.Province,
            ProvinceCode = "ON",
            ProvinceName = "Ontario",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCountryCode = "CA";
        ApiEnum<string, DataObject> expectedObject = DataObject.Province;
        string expectedProvinceCode = "ON";
        string expectedProvinceName = "Ontario";

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedProvinceCode, deserialized.ProvinceCode);
        Assert.Equal(expectedProvinceName, deserialized.ProvinceName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            CountryCode = "CA",
            Object = DataObject.Province,
            ProvinceCode = "ON",
            ProvinceName = "Ontario",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.ProvinceCode);
        Assert.False(model.RawData.ContainsKey("province_code"));
        Assert.Null(model.ProvinceName);
        Assert.False(model.RawData.ContainsKey("province_name"));
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
            CountryCode = null,
            Object = null,
            ProvinceCode = null,
            ProvinceName = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.ProvinceCode);
        Assert.False(model.RawData.ContainsKey("province_code"));
        Assert.Null(model.ProvinceName);
        Assert.False(model.RawData.ContainsKey("province_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            Object = null,
            ProvinceCode = null,
            ProvinceName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            CountryCode = "CA",
            Object = DataObject.Province,
            ProvinceCode = "ON",
            ProvinceName = "Ontario",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataObjectTest : TestBase
{
    [Theory]
    [InlineData(DataObject.Province)]
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
    [InlineData(DataObject.Province)]
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
