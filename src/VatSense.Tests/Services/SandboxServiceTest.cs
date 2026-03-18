using System.Threading.Tasks;

namespace VatSense.Tests.Services;

public class SandboxServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GenerateKey_Works()
    {
        var response = await this.client.Sandbox.GenerateKey(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
