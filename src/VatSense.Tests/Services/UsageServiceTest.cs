using System.Threading.Tasks;

namespace VatSense.Tests.Services;

public class UsageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var usage = await this.client.Usage.Retrieve(new(), TestContext.Current.CancellationToken);
        usage.Validate();
    }
}
