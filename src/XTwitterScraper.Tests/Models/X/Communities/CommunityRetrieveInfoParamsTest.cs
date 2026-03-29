using System;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityRetrieveInfoParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CommunityRetrieveInfoParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CommunityRetrieveInfoParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/communities/id/info"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CommunityRetrieveInfoParams { ID = "id" };

        CommunityRetrieveInfoParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
