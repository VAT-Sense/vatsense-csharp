using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Invoice;

namespace Vatsense.Tests.Models.Invoice;

public class InvoiceDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceDeleteResponse { Code = 200, Success = true };

        long expectedCode = 200;
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceDeleteResponse { Code = 200, Success = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceDeleteResponse { Code = 200, Success = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvoiceDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 200;
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceDeleteResponse { Code = 200, Success = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvoiceDeleteResponse { Code = 200, Success = true };

        InvoiceDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
