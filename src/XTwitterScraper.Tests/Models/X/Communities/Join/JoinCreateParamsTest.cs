using System;
using XTwitterScraper.Models.X.Communities.Join;

namespace XTwitterScraper.Tests.Models.X.Communities.Join;

public class JoinCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JoinCreateParams { ID = "id", Account = "@elonmusk" };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        JoinCreateParams parameters = new() { ID = "id", Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/communities/id/join"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JoinCreateParams { ID = "id", Account = "@elonmusk" };

        JoinCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
