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
            Email = "user@example.com",
            Password = "s3cur3Pa$$w0rd",
            Username = "elonmusk",
            ProxyCountry = "US",
            TotpSecret = "JBSWY3DPEHPK3PXP",
        };

        string expectedEmail = "user@example.com";
        string expectedPassword = "s3cur3Pa$$w0rd";
        string expectedUsername = "elonmusk";
        string expectedProxyCountry = "US";
        string expectedTotpSecret = "JBSWY3DPEHPK3PXP";

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
            Email = "user@example.com",
            Password = "s3cur3Pa$$w0rd",
            Username = "elonmusk",
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
            Email = "user@example.com",
            Password = "s3cur3Pa$$w0rd",
            Username = "elonmusk",

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
            Email = "user@example.com",
            Password = "s3cur3Pa$$w0rd",
            Username = "elonmusk",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/accounts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "user@example.com",
            Password = "s3cur3Pa$$w0rd",
            Username = "elonmusk",
            ProxyCountry = "US",
            TotpSecret = "JBSWY3DPEHPK3PXP",
        };

        AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
