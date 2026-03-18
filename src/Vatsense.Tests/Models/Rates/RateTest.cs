using System.Collections.Generic;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Rates;

namespace Vatsense.Tests.Models.Rates;

public class RateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        string expectedCountryCode = "FR";
        string expectedCountryName = "France";
        bool expectedEu = true;
        ApiEnum<string, Object> expectedObject = Object.Rate;
        List<Other> expectedOther =
        [
            new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
                Province = "province",
            },
        ];
        TaxRate expectedStandard = new()
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCountryName, model.CountryName);
        Assert.Equal(expectedEu, model.Eu);
        Assert.Equal(expectedObject, model.Object);
        Assert.NotNull(model.Other);
        Assert.Equal(expectedOther.Count, model.Other.Count);
        for (int i = 0; i < expectedOther.Count; i++)
        {
            Assert.Equal(expectedOther[i], model.Other[i]);
        }
        Assert.Equal(expectedStandard, model.Standard);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rate>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCountryCode = "FR";
        string expectedCountryName = "France";
        bool expectedEu = true;
        ApiEnum<string, Object> expectedObject = Object.Rate;
        List<Other> expectedOther =
        [
            new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
                Province = "province",
            },
        ];
        TaxRate expectedStandard = new()
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCountryName, deserialized.CountryName);
        Assert.Equal(expectedEu, deserialized.Eu);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.NotNull(deserialized.Other);
        Assert.Equal(expectedOther.Count, deserialized.Other.Count);
        for (int i = 0; i < expectedOther.Count; i++)
        {
            Assert.Equal(expectedOther[i], deserialized.Other[i]);
        }
        Assert.Equal(expectedStandard, deserialized.Standard);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rate
        {
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("country_name"));
        Assert.Null(model.Eu);
        Assert.False(model.RawData.ContainsKey("eu"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Standard);
        Assert.False(model.RawData.ContainsKey("standard"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rate
        {
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Rate
        {
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Object = null,
            Standard = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.CountryName);
        Assert.False(model.RawData.ContainsKey("country_name"));
        Assert.Null(model.Eu);
        Assert.False(model.RawData.ContainsKey("eu"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Standard);
        Assert.False(model.RawData.ContainsKey("standard"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rate
        {
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            CountryName = null,
            Eu = null,
            Object = null,
            Standard = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        Assert.Null(model.Other);
        Assert.False(model.RawData.ContainsKey("other"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },

            Other = null,
        };

        Assert.Null(model.Other);
        Assert.True(model.RawData.ContainsKey("other"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },

            Other = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rate
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = Object.Rate,
            Other =
            [
                new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                    Province = "province",
                },
            ],
            Standard = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
            },
        };

        Rate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(Object.Rate)]
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
    [InlineData(Object.Rate)]
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

public class OtherTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
            Province = "province",
        };

        string expectedClass = "standard";
        string expectedDescription = "";
        ApiEnum<string, TaxRateObject> expectedObject = TaxRateObject.TaxRate;
        double expectedRate = 20;
        Types expectedTypes = false;
        string expectedProvince = "province";

        Assert.Equal(expectedClass, model.Class);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedRate, model.Rate);
        Assert.Equal(expectedTypes, model.Types);
        Assert.Equal(expectedProvince, model.Province);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
            Province = "province",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Other>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
            Province = "province",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Other>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedClass = "standard";
        string expectedDescription = "";
        ApiEnum<string, TaxRateObject> expectedObject = TaxRateObject.TaxRate;
        double expectedRate = 20;
        Types expectedTypes = false;
        string expectedProvince = "province";

        Assert.Equal(expectedClass, deserialized.Class);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedRate, deserialized.Rate);
        Assert.Equal(expectedTypes, deserialized.Types);
        Assert.Equal(expectedProvince, deserialized.Province);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
            Province = "province",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Other { Province = "province" };

        Assert.Null(model.Class);
        Assert.False(model.RawData.ContainsKey("class"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Types);
        Assert.False(model.RawData.ContainsKey("types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Other { Province = "province" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Other
        {
            Province = "province",

            // Null should be interpreted as omitted for these properties
            Class = null,
            Description = null,
            Object = null,
            Rate = null,
            Types = null,
        };

        Assert.Null(model.Class);
        Assert.False(model.RawData.ContainsKey("class"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Types);
        Assert.False(model.RawData.ContainsKey("types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Other
        {
            Province = "province",

            // Null should be interpreted as omitted for these properties
            Class = null,
            Description = null,
            Object = null,
            Rate = null,
            Types = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        Assert.Null(model.Province);
        Assert.False(model.RawData.ContainsKey("province"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,

            Province = null,
        };

        Assert.Null(model.Province);
        Assert.True(model.RawData.ContainsKey("province"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,

            Province = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Other
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
            Province = "province",
        };

        Other copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { Province = "province" };

        string expectedProvince = "province";

        Assert.Equal(expectedProvince, model.Province);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1 { Province = "province" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1 { Province = "province" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProvince = "province";

        Assert.Equal(expectedProvince, deserialized.Province);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1 { Province = "province" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { };

        Assert.Null(model.Province);
        Assert.False(model.RawData.ContainsKey("province"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntersectionMember1 { Province = null };

        Assert.Null(model.Province);
        Assert.True(model.RawData.ContainsKey("province"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1 { Province = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntersectionMember1 { Province = "province" };

        IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
