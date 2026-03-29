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
            Account = "account",
            CommunityName = "community_name",
        };

        string expectedID = "id";
        string expectedAccount = "account";
        string expectedCommunityName = "community_name";

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
            Account = "account",
            CommunityName = "community_name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/communities/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CommunityDeleteParams
        {
            ID = "id",
            Account = "account",
            CommunityName = "community_name",
        };

        CommunityDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
