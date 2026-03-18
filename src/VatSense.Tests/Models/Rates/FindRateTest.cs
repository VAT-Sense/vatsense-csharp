using System.Text.Json;
using VatSense.Core;
using VatSense.Models.Rates;

namespace VatSense.Tests.Models.Rates;

public class FindRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FindRate
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = RateWithTaxRateObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
            },
            Success = true,
        };

        long expectedCode = 200;
        RateWithTaxRate expectedData = new()
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = RateWithTaxRateObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
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
        var model = new FindRate
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = RateWithTaxRateObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FindRate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FindRate
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = RateWithTaxRateObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FindRate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        RateWithTaxRate expectedData = new()
        {
            CountryCode = "FR",
            CountryName = "France",
            Eu = true,
            Object = RateWithTaxRateObject.Rate,
            TaxRate = new()
            {
                Class = "standard",
                Description = "",
                Object = TaxRateObject.TaxRate,
                Rate = 20,
                Types = false,
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
        var model = new FindRate
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = RateWithTaxRateObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FindRate { };

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
        var model = new FindRate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FindRate
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
        var model = new FindRate
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
        var model = new FindRate
        {
            Code = 200,
            Data = new()
            {
                CountryCode = "FR",
                CountryName = "France",
                Eu = true,
                Object = RateWithTaxRateObject.Rate,
                TaxRate = new()
                {
                    Class = "standard",
                    Description = "",
                    Object = TaxRateObject.TaxRate,
                    Rate = 20,
                    Types = false,
                },
            },
            Success = true,
        };

        FindRate copied = new(model);

        Assert.Equal(model, copied);
    }
}
