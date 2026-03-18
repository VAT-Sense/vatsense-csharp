using System;
using VatSense.Models.Invoice.Item;

namespace VatSense.Tests.Models.Invoice.Item;

public class ItemUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
            DiscountRate = 40,
        };

        string expectedInvoiceID = "in5aeae457cda2a";
        string expectedItemID = "ii5aeae457ce201";
        string expectedItem = "Standard payment plan";
        double expectedPriceEach = 19.99;
        double expectedQuantity = 1;
        double expectedVatRate = 20;
        double expectedDiscountRate = 40;

        Assert.Equal(expectedInvoiceID, parameters.InvoiceID);
        Assert.Equal(expectedItemID, parameters.ItemID);
        Assert.Equal(expectedItem, parameters.Item);
        Assert.Equal(expectedPriceEach, parameters.PriceEach);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(expectedVatRate, parameters.VatRate);
        Assert.Equal(expectedDiscountRate, parameters.DiscountRate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ItemUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
        };

        Assert.Null(parameters.DiscountRate);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_rate"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ItemUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,

            // Null should be interpreted as omitted for these properties
            DiscountRate = null,
        };

        Assert.Null(parameters.DiscountRate);
        Assert.False(parameters.RawBodyData.ContainsKey("discount_rate"));
    }

    [Fact]
    public void Url_Works()
    {
        ItemUpdateParams parameters = new()
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
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
        var parameters = new ItemUpdateParams
        {
            InvoiceID = "in5aeae457cda2a",
            ItemID = "ii5aeae457ce201",
            Item = "Standard payment plan",
            PriceEach = 19.99,
            Quantity = 1,
            VatRate = 20,
            DiscountRate = 40,
        };

        ItemUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
