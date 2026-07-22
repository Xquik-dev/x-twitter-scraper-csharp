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
            Email = "account@example.invalid",
            Password = "<ACCOUNT_PASSWORD>",
            Username = "your_x_username",
            TotpSecret = "<TOTP_SECRET>",
        };

        string expectedEmail = "account@example.invalid";
        string expectedPassword = "<ACCOUNT_PASSWORD>";
        string expectedUsername = "your_x_username";
        string expectedTotpSecret = "<TOTP_SECRET>";

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedUsername, parameters.Username);
        Assert.Equal(expectedTotpSecret, parameters.TotpSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "account@example.invalid",
            Password = "<ACCOUNT_PASSWORD>",
            Username = "your_x_username",
        };

        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "account@example.invalid",
            Password = "<ACCOUNT_PASSWORD>",
            Username = "your_x_username",

            // Null should be interpreted as omitted for these properties
            TotpSecret = null,
        };

        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountCreateParams parameters = new()
        {
            Email = "account@example.invalid",
            Password = "<ACCOUNT_PASSWORD>",
            Username = "your_x_username",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/accounts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "account@example.invalid",
            Password = "<ACCOUNT_PASSWORD>",
            Username = "your_x_username",
            TotpSecret = "<TOTP_SECRET>",
        };

        AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
