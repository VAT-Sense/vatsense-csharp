using System.Threading.Tasks;

namespace Vatsense.Tests.Services.Invoice;

public class ItemServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var item = await this.client.Invoice.Item.Retrieve(
            "ii5aeae457ce201",
            new() { InvoiceID = "in5aeae457cda2a" },
            TestContext.Current.CancellationToken
        );
        item.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var invoiceResponse = await this.client.Invoice.Item.Update(
            "ii5aeae457ce201",
            new()
            {
                InvoiceID = "in5aeae457cda2a",
                Item = "Standard payment plan",
                PriceEach = 19.99,
                Quantity = 1,
                VatRate = 20,
            },
            TestContext.Current.CancellationToken
        );
        invoiceResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var invoiceResponse = await this.client.Invoice.Item.Delete(
            "ii5aeae457ce201",
            new() { InvoiceID = "in5aeae457cda2a" },
            TestContext.Current.CancellationToken
        );
        invoiceResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var invoiceResponse = await this.client.Invoice.Item.Add(
            "in5aeae457cda2a",
            new()
            {
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
            },
            TestContext.Current.CancellationToken
        );
        invoiceResponse.Validate();
    }
}
