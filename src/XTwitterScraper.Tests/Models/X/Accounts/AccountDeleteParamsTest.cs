using System;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/accounts/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountDeleteParams { ID = "id" };

        AccountDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
