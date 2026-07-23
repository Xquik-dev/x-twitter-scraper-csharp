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
            Email = "user@example.com",
            Password = "test-password",
            Username = "test-user",
            TotpSecret = "test-totp-secret",
        };

        string expectedEmail = "user@example.com";
        string expectedPassword = "test-password";
        string expectedUsername = "test-user";
        string expectedTotpSecret = "test-totp-secret";

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
            Email = "user@example.com",
            Password = "test-password",
            Username = "test-user",
        };

        Assert.Null(parameters.TotpSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("totp_secret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "user@example.com",
            Password = "test-password",
            Username = "test-user",

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
            Email = "user@example.com",
            Password = "test-password",
            Username = "test-user",
        };

        var url = parameters.Url(
            new() { ApiKey = "test-api-key", BearerToken = "test-bearer-token" }
        );

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/accounts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountCreateParams
        {
            Email = "user@example.com",
            Password = "test-password",
            Username = "test-user",
            TotpSecret = "test-totp-secret",
        };

        AccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
