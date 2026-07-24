// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

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
            Password = "<ACCOUNT_PASSWORD>",
            Email = "account@example.invalid",
            TotpSecret = "<TOTP_SECRET>",
        };

        string expectedID = "id";
        string expectedPassword = "<ACCOUNT_PASSWORD>";
        string expectedEmail = "account@example.invalid";
        string expectedTotpSecret = "<TOTP_SECRET>";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPassword, parameters.Password);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedTotpSecret, parameters.TotpSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountReauthParams { ID = "id", Password = "<ACCOUNT_PASSWORD>" };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountReauthParams
        {
            ID = "id",
            Password = "<ACCOUNT_PASSWORD>",

            // Null should be interpreted as omitted for these properties
            Email = null,
            TotpSecret = null,
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountReauthParams parameters = new() { ID = "id", Password = "<ACCOUNT_PASSWORD>" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

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
            Password = "<ACCOUNT_PASSWORD>",
            Email = "account@example.invalid",
            TotpSecret = "<TOTP_SECRET>",
        };

        AccountReauthParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
