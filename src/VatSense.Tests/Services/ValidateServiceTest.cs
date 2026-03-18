using System.Threading.Tasks;

namespace VatSense.Tests.Services;

public class ValidateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Check_Works()
    {
        var response = await this.client.Validate.Check(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
