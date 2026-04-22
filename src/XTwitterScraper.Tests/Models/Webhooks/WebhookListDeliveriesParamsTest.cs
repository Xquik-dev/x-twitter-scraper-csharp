using System;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookListDeliveriesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookListDeliveriesParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookListDeliveriesParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/webhooks/id/deliveries"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookListDeliveriesParams { ID = "id" };

        WebhookListDeliveriesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
