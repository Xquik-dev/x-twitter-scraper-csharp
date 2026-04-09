using System;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountReauthParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountReauthParams
        {
            ID = "id",
            Password = "password_value",
            TotpSecret = "totp_secret_value",
        };

        string expectedID = "id";
        string expectedPassword = "password_value";
        string expectedTotpSecret = "totp_secret_value";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedTotpSecret, parameters.TotpSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountReauthParams { ID = "id", Password = "password_value" };

        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountReauthParams
        {
            ID = "id",
            Password = "password_value",

            // Null should be interpreted as omitted for these properties
            TotpSecret = null,
        };

        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountReauthParams parameters = new() { ID = "id", Password = "password_value" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/accounts/id/reauth"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountReauthParams
        {
            ID = "id",
            Password = "password_value",
            TotpSecret = "totp_secret_value",
        };

        AccountReauthParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
