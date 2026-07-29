using System;
using XTwitterScraper.Models.X.AccountConnectionAttempts;

namespace XTwitterScraper.Tests.Models.X.AccountConnectionAttempts;

public class AccountConnectionAttemptRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountConnectionAttemptRetrieveParams
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        string expectedID = "xatt_0123456789abcdef0123456789abcdef";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountConnectionAttemptRetrieveParams parameters = new()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/account-connection-attempts/xatt_0123456789abcdef0123456789abcdef"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountConnectionAttemptRetrieveParams
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        AccountConnectionAttemptRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
