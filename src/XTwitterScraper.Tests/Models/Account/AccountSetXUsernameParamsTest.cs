using System;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Tests.Models.Account;

public class AccountSetXUsernameParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountSetXUsernameParams { Username = "elonmusk" };

        string expectedUsername = "elonmusk";

        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        AccountSetXUsernameParams parameters = new() { Username = "elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/account/x-identity"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountSetXUsernameParams { Username = "elonmusk" };

        AccountSetXUsernameParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
