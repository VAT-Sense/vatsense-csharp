using System.Collections.Generic;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Rates;

namespace Vatsense.Tests.Models.Rates;

public class RateListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RateListResponse
        {
            Code = 200,
            Data =
            [
                new()
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
                },
            ],
            Success = true,
        };

        long expectedCode = 200;
        List<Rate> expectedData =
        [
            new()
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
        var model = new RateListResponse
        {
            Code = 200,
            Data =
            [
                new()
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
                },
            ],
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RateListResponse
        {
            Code = 200,
            Data =
            [
                new()
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
                },
            ],
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RateListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        List<Rate> expectedData =
        [
            new()
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
        var model = new RateListResponse
        {
            Code = 200,
            Data =
            [
                new()
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
                },
            ],
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RateListResponse { };

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
        var model = new RateListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RateListResponse
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
        var model = new RateListResponse
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
        var model = new RateListResponse
        {
            Code = 200,
            Data =
            [
                new()
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
                },
            ],
            Success = true,
        };

        RateListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
