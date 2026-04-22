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
            Email = "user@example.com",
            ProxyCountry = "US",
            TotpSecret = "totp_secret_value",
        };

        string expectedID = "id";
        string expectedPassword = "password_value";
        string expectedEmail = "user@example.com";
        string expectedProxyCountry = "US";
        string expectedTotpSecret = "totp_secret_value";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedProxyCountry, parameters.ProxyCountry);
        Assert.Equal(expectedTotpSecret, parameters.TotpSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountReauthParams { ID = "id", Password = "password_value" };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.ProxyCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("proxy_country"));
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
            Email = null,
            ProxyCountry = null,
            TotpSecret = null,
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.ProxyCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("proxy_country"));
        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountReauthParams parameters = new() { ID = "id", Password = "password_value" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/accounts/id/reauth"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountReauthParams
        {
            ID = "id",
            Password = "password_value",
            Email = "user@example.com",
            ProxyCountry = "US",
            TotpSecret = "totp_secret_value",
        };

        AccountReauthParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
