using System;
using XTwitterScraper;

namespace XTwitterScraper.Tests;

public class TestBase
{
    protected IXTwitterScraperClient client;

    public TestBase()
    {
        client = new XTwitterScraperClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
