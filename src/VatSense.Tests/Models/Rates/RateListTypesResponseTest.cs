using System.Collections.Generic;
using System.Text.Json;
using VatSense.Core;
using VatSense.Models.Rates;

namespace VatSense.Tests.Models.Rates;

public class RateListTypesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateListTypesResponse
        {
            Code = 200,
            Data =
            [
                "accommodation",
                "admission to cultural events",
                "admission to entertainment events",
                "admission to sporting events",
                "advertising",
                "agricultural supplies",
                "baby foodstuffs",
                "bikes",
                "books",
                "childrens clothing",
                "domestic fuel",
                "domestic services",
                "ebooks",
                "electricity",
                "electronic services",
                "foodstuffs",
                "hotels",
                "medical",
                "newspapers",
                "passenger transport",
                "pharmaceuticals",
                "property renovations",
                "restaurants",
                "social housing",
                "water",
                "wine",
            ],
            Success = true,
        };

        long expectedCode = 200;
        List<string> expectedData =
        [
            "accommodation",
            "admission to cultural events",
            "admission to entertainment events",
            "admission to sporting events",
            "advertising",
            "agricultural supplies",
            "baby foodstuffs",
            "bikes",
            "books",
            "childrens clothing",
            "domestic fuel",
            "domestic services",
            "ebooks",
            "electricity",
            "electronic services",
            "foodstuffs",
            "hotels",
            "medical",
            "newspapers",
            "passenger transport",
            "pharmaceuticals",
            "property renovations",
            "restaurants",
            "social housing",
            "water",
            "wine",
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
        var model = new RateListTypesResponse
        {
            Code = 200,
            Data =
            [
                "accommodation",
                "admission to cultural events",
                "admission to entertainment events",
                "admission to sporting events",
                "advertising",
                "agricultural supplies",
                "baby foodstuffs",
                "bikes",
                "books",
                "childrens clothing",
                "domestic fuel",
                "domestic services",
                "ebooks",
                "electricity",
                "electronic services",
                "foodstuffs",
                "hotels",
                "medical",
                "newspapers",
                "passenger transport",
                "pharmaceuticals",
                "property renovations",
                "restaurants",
                "social housing",
                "water",
                "wine",
            ],
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateListTypesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RateListTypesResponse
        {
            Code = 200,
            Data =
            [
                "accommodation",
                "admission to cultural events",
                "admission to entertainment events",
                "admission to sporting events",
                "advertising",
                "agricultural supplies",
                "baby foodstuffs",
                "bikes",
                "books",
                "childrens clothing",
                "domestic fuel",
                "domestic services",
                "ebooks",
                "electricity",
                "electronic services",
                "foodstuffs",
                "hotels",
                "medical",
                "newspapers",
                "passenger transport",
                "pharmaceuticals",
                "property renovations",
                "restaurants",
                "social housing",
                "water",
                "wine",
            ],
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateListTypesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        List<string> expectedData =
        [
            "accommodation",
            "admission to cultural events",
            "admission to entertainment events",
            "admission to sporting events",
            "advertising",
            "agricultural supplies",
            "baby foodstuffs",
            "bikes",
            "books",
            "childrens clothing",
            "domestic fuel",
            "domestic services",
            "ebooks",
            "electricity",
            "electronic services",
            "foodstuffs",
            "hotels",
            "medical",
            "newspapers",
            "passenger transport",
            "pharmaceuticals",
            "property renovations",
            "restaurants",
            "social housing",
            "water",
            "wine",
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
        var model = new RateListTypesResponse
        {
            Code = 200,
            Data =
            [
                "accommodation",
                "admission to cultural events",
                "admission to entertainment events",
                "admission to sporting events",
                "advertising",
                "agricultural supplies",
                "baby foodstuffs",
                "bikes",
                "books",
                "childrens clothing",
                "domestic fuel",
                "domestic services",
                "ebooks",
                "electricity",
                "electronic services",
                "foodstuffs",
                "hotels",
                "medical",
                "newspapers",
                "passenger transport",
                "pharmaceuticals",
                "property renovations",
                "restaurants",
                "social housing",
                "water",
                "wine",
            ],
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RateListTypesResponse { };

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
        var model = new RateListTypesResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RateListTypesResponse
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
        var model = new RateListTypesResponse
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
        var model = new RateListTypesResponse
        {
            Code = 200,
            Data =
            [
                "accommodation",
                "admission to cultural events",
                "admission to entertainment events",
                "admission to sporting events",
                "advertising",
                "agricultural supplies",
                "baby foodstuffs",
                "bikes",
                "books",
                "childrens clothing",
                "domestic fuel",
                "domestic services",
                "ebooks",
                "electricity",
                "electronic services",
                "foodstuffs",
                "hotels",
                "medical",
                "newspapers",
                "passenger transport",
                "pharmaceuticals",
                "property renovations",
                "restaurants",
                "social housing",
                "water",
                "wine",
            ],
            Success = true,
        };

        RateListTypesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
