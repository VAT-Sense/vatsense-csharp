using System;
using Vatsense.Models.Invoice;

namespace Vatsense.Tests.Models.Invoice;

public class InvoiceRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceRetrieveParams { InvoiceID = "in5aeae457cda2a" };

        string expectedInvoiceID = "in5aeae457cda2a";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceRetrieveParams parameters = new() { InvoiceID = "in5aeae457cda2a" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(new Uri("https://api.vatsense.com/1.0/invoice/in5aeae457cda2a"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceRetrieveParams { InvoiceID = "in5aeae457cda2a" };

        InvoiceRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
