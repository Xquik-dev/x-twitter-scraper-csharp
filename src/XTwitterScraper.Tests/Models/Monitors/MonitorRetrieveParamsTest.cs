using System;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MonitorRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        MonitorRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/monitors/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MonitorRetrieveParams { ID = "id" };

        MonitorRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
