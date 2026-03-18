using System;
using VatSense;

namespace VatSense.Tests;

public class TestBase
{
    protected IVatSenseClient client;

    public TestBase()
    {
        client = new VatSenseClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            Username = "My Username",
            Password = "My Password",
        };
    }
}
