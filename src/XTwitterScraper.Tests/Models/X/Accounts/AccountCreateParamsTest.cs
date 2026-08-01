// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

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
            TotpSecret = "<TOTP_SECRET>",
            Username = "your_x_username",
        };

        string expectedEmail = "account@example.invalid";
        string expectedPassword = "<ACCOUNT_PASSWORD>";
        string expectedTotpSecret = "<TOTP_SECRET>";
        string expectedUsername = "your_x_username";

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedTotpSecret, parameters.TotpSecret);
        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        AccountCreateParams parameters = new()
        {
            Email = "account@example.invalid",
            Password = "<ACCOUNT_PASSWORD>",
            TotpSecret = "<TOTP_SECRET>",
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
            TotpSecret = "<TOTP_SECRET>",
            Username = "your_x_username",
        };

        AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
