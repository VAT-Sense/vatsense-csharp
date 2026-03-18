using System.Text.Json;
using VatSense.Core;
using VatSense.Models.Currency;

namespace VatSense.Tests.Models.Currency;

public class CurrencyCalculateVatPriceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencyCalculateVatPriceResponse
        {
            Code = 200,
            Data = new()
            {
                Object = Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
            Success = true,
        };

        long expectedCode = 200;
        VatPrice expectedData = new()
        {
            Object = Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencyCalculateVatPriceResponse
        {
            Code = 200,
            Data = new()
            {
                Object = Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyCalculateVatPriceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencyCalculateVatPriceResponse
        {
            Code = 200,
            Data = new()
            {
                Object = Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyCalculateVatPriceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        VatPrice expectedData = new()
        {
            Object = Object.VatPrice,
            Price = 20,
            PriceExclVat = 20,
            PriceInclVat = 21.1,
            TaxType = VatPriceTaxType.Excl,
            Vat = 1.1,
            VatRate = 5.5,
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencyCalculateVatPriceResponse
        {
            Code = 200,
            Data = new()
            {
                Object = Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CurrencyCalculateVatPriceResponse { };

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
        var model = new CurrencyCalculateVatPriceResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CurrencyCalculateVatPriceResponse
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
        var model = new CurrencyCalculateVatPriceResponse
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
        var model = new CurrencyCalculateVatPriceResponse
        {
            Code = 200,
            Data = new()
            {
                Object = Object.VatPrice,
                Price = 20,
                PriceExclVat = 20,
                PriceInclVat = 21.1,
                TaxType = VatPriceTaxType.Excl,
                Vat = 1.1,
                VatRate = 5.5,
            },
            Success = true,
        };

        CurrencyCalculateVatPriceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
