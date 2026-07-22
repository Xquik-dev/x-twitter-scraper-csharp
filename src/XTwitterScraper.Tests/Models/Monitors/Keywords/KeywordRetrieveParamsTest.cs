using System;
using XTwitterScraper.Models.Monitors.Keywords;

namespace XTwitterScraper.Tests.Models.Monitors.Keywords;

public class KeywordRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KeywordRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        KeywordRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/monitors/keywords/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KeywordRetrieveParams { ID = "id" };

        KeywordRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
