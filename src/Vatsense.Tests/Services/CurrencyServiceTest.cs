using System.Threading.Tasks;
using Vatsense.Models.Currency;

namespace Vatsense.Tests.Services;

public class CurrencyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var currencies = await this.client.Currency.List(
            new(),
            TestContext.Current.CancellationToken
        );
        currencies.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CalculateVatPrice_Works()
    {
        var response = await this.client.Currency.CalculateVatPrice(
            new()
            {
                Price = "20.00",
                TaxType = TaxType.Excl,
                VatRate = 5,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Convert_Works()
    {
        var response = await this.client.Currency.Convert(
            new()
            {
                Amount = "39.99",
                From = "USD",
                To = CurrencyConvertParamsTo.Gbp,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
