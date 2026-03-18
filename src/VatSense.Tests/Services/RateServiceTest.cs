using System.Threading.Tasks;
using VatSense.Models.Rates;

namespace VatSense.Tests.Services;

public class RateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var rates = await this.client.Rates.List(new(), TestContext.Current.CancellationToken);
        rates.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CalculatePrice_Works()
    {
        var response = await this.client.Rates.CalculatePrice(
            new() { Price = "20.00", TaxType = TaxType.Excl },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Details_Works()
    {
        var findRate = await this.client.Rates.Details(
            new(),
            TestContext.Current.CancellationToken
        );
        findRate.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Find_Works()
    {
        var findRate = await this.client.Rates.Find(new(), TestContext.Current.CancellationToken);
        findRate.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListTypes_Works()
    {
        var response = await this.client.Rates.ListTypes(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
