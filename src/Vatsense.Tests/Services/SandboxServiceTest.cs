using System.Threading.Tasks;

namespace Vatsense.Tests.Services;

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
