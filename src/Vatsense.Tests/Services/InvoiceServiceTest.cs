using System.Threading.Tasks;

namespace Vatsense.Tests.Services;

public class InvoiceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var invoiceResponse = await this.client.Invoice.Create(
            new()
            {
                Business = new()
                {
                    Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
                    Name = "VAT Sense",
                    VatNumber = "GB12345678",
                    BankAccount = "bank_account",
                    CompanyNumber = "9839222",
                    Email = "dev@stainless.com",
                    Logo = "https://example.com",
                    Phone = "phone",
                    Website = "https://example.com",
                },
                CurrencyCode = "USD",
                Date = "2018-06-03 14:02:00",
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
                TaxPoint = "2018-06-03 14:02:00",
            },
            TestContext.Current.CancellationToken
        );
        invoiceResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var invoiceResponse = await this.client.Invoice.Retrieve(
            "in5aeae457cda2a",
            new(),
            TestContext.Current.CancellationToken
        );
        invoiceResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var invoiceResponse = await this.client.Invoice.Update(
            "in5aeae457cda2a",
            new()
            {
                Business = new()
                {
                    Address = "123 Example Street\nLondon\nSW3 1GL\nUnited Kingdom",
                    Name = "VAT Sense",
                    VatNumber = "GB12345678",
                    BankAccount = "bank_account",
                    CompanyNumber = "9839222",
                    Email = "dev@stainless.com",
                    Logo = "https://example.com",
                    Phone = "phone",
                    Website = "https://example.com",
                },
                CurrencyCode = "USD",
                Date = "2018-06-03 14:02:00",
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
                TaxPoint = "2018-06-03 14:02:00",
            },
            TestContext.Current.CancellationToken
        );
        invoiceResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var invoices = await this.client.Invoice.List(new(), TestContext.Current.CancellationToken);
        invoices.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var invoice = await this.client.Invoice.Delete(
            "in5aeae457cda2a",
            new(),
            TestContext.Current.CancellationToken
        );
        invoice.Validate();
    }
}
