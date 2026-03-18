using System;
using VatSense.Models.Invoice.Item;

namespace VatSense.Tests.Models.Invoice.Item;

public class ItemRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
        };

        string expectedInvoiceID = "in5aeae457cda2a";
        string expectedItemID = "ii5aeae457ce201";

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedItemID, parameters.ItemID);
    }

    [Fact]
    public void Url_Works()
    {
        ItemRetrieveParams parameters = new()
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri("https://api.vatsense.com/1.0/invoice/in5aeae457cda2a/item/ii5aeae457ce201"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemRetrieveParams
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
        };

        ItemRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
