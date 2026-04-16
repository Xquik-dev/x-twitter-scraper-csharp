using System;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveBatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveBatchParams { Ids = "ids" };

        string expectedIds = "ids";

        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveBatchParams parameters = new() { Ids = "ids" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/users/batch?ids=ids"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveBatchParams { Ids = "ids" };

        UserRetrieveBatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
