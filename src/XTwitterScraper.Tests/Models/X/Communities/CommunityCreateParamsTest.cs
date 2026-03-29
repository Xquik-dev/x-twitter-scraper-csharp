using System;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CommunityCreateParams
        {
            Account = "account",
            Name = "name",
            Description = "description",
        };

        string expectedAccount = "account";
        string expectedName = "name";
        string expectedDescription = "description";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CommunityCreateParams { Account = "account", Name = "name" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CommunityCreateParams
        {
            Account = "account",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        CommunityCreateParams parameters = new() { Account = "account", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/communities"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CommunityCreateParams
        {
            Account = "account",
            Name = "name",
            Description = "description",
        };

        CommunityCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
