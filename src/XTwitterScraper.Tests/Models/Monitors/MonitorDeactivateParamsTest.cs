using System;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorDeactivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MonitorDeactivateParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MonitorDeactivateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/monitors/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MonitorDeactivateParams { ID = "id" };

        MonitorDeactivateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
