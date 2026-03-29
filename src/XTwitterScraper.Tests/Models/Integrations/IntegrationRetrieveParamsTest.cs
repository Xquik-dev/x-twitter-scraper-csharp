using System;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/integrations/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationRetrieveParams { ID = "id" };

        IntegrationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
