using System;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookTestParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookTestParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/webhooks/id/test"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookTestParams { ID = "id" };

        WebhookTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
