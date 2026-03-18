using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Invoice;

namespace Vatsense.Tests.Models.Invoice;

public class InvoiceConversionInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceConversionInput { CurrencyCode = "GBP", Rate = 1.523 };

        string expectedCurrencyCode = "GBP";
        double expectedRate = 1.523;

        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedRate, model.Rate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceConversionInput { CurrencyCode = "GBP", Rate = 1.523 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceConversionInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceConversionInput { CurrencyCode = "GBP", Rate = 1.523 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceConversionInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyCode = "GBP";
        double expectedRate = 1.523;

        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedRate, deserialized.Rate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceConversionInput { CurrencyCode = "GBP", Rate = 1.523 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceConversionInput { CurrencyCode = "GBP", Rate = 1.523 };

        InvoiceConversionInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
