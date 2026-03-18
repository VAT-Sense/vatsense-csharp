using System.Threading.Tasks;

namespace Vatsense.Tests.Services;

public class CountryServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var countries = await this.client.Countries.List(
            new(),
            TestContext.Current.CancellationToken
        );
        countries.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListProvinces_Works()
    {
        var response = await this.client.Countries.ListProvinces(
            new() { CountryCode = "CA" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
