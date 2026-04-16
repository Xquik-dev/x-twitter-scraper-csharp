using System;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookDeactivateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookDeactivateParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookDeactivateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/webhooks/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookDeactivateParams { ID = "id" };

        WebhookDeactivateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
