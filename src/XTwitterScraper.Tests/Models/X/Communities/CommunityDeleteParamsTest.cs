using System;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CommunityDeleteParams
        {
            ID = "id",
            Account = "@elonmusk",
            CommunityName = "Tesla Fans",
        };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";
        string expectedCommunityName = "Tesla Fans";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedCommunityName, parameters.CommunityName);
    }

    [Fact]
    public void Url_Works()
    {
        CommunityDeleteParams parameters = new()
        {
            ID = "id",
            Account = "@elonmusk",
            CommunityName = "Tesla Fans",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/communities/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CommunityDeleteParams
        {
            ID = "id",
            Account = "@elonmusk",
            CommunityName = "Tesla Fans",
        };

        CommunityDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
