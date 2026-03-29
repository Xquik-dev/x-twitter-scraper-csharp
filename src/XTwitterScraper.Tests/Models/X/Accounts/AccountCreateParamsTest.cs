using System;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "email",
            Password = "password",
            Username = "username",
            ProxyCountry = "proxy_country",
            TotpSecret = "totp_secret",
        };

        string expectedEmail = "email";
        string expectedPassword = "password";
        string expectedUsername = "username";
        string expectedProxyCountry = "proxy_country";
        string expectedTotpSecret = "totp_secret";

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedUsername, parameters.Username);
        Assert.Equal(expectedProxyCountry, parameters.ProxyCountry);
        Assert.Equal(expectedTotpSecret, parameters.TotpSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "email",
            Password = "password",
            Username = "username",
        };

        Assert.Null(parameters.ProxyCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("proxy_country"));
        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "email",
            Password = "password",
            Username = "username",

            // Null should be interpreted as omitted for these properties
            ProxyCountry = null,
            TotpSecret = null,
        };

        Assert.Null(parameters.ProxyCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("proxy_country"));
        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountCreateParams parameters = new()
        {
            Email = "email",
            Password = "password",
            Username = "username",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/accounts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "email",
            Password = "password",
            Username = "username",
            ProxyCountry = "proxy_country",
            TotpSecret = "totp_secret",
        };

        AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
