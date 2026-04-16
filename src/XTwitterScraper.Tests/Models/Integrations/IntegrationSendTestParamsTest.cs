using System;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationSendTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationSendTestParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationSendTestParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/integrations/id/test"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationSendTestParams { ID = "id" };

        IntegrationSendTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
