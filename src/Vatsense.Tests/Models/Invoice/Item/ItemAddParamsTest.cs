using System;
using System.Collections.Generic;
using Vatsense.Models.Invoice.Item;

namespace Vatsense.Tests.Models.Invoice.Item;

public class ItemAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemAddParams
        {
            InvoiceID = "in5aeae457cda2a",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
        };

        string expectedInvoiceID = "in5aeae457cda2a";
        List<InvoiceItemInput> expectedItems =
        [
            new()
            {
                Item = "Standard payment plan",
                PriceEach = 19.99,
                Quantity = 1,
                VatRate = 20,
                DiscountRate = 40,
            },
        ];

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedItems.Count, parameters.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], parameters.Items[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ItemAddParams parameters = new()
        {
            InvoiceID = "in5aeae457cda2a",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(new Uri("https://api.vatsense.com/1.0/invoice/in5aeae457cda2a/item"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemAddParams
        {
            InvoiceID = "in5aeae457cda2a",
            Items =
            [
                new()
                {
                    Item = "Standard payment plan",
                    PriceEach = 19.99,
                    Quantity = 1,
                    VatRate = 20,
                    DiscountRate = 40,
                },
            ],
        };

        ItemAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
