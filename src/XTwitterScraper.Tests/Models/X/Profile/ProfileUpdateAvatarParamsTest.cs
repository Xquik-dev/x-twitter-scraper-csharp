// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateAvatarParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateAvatarParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/avatar.png",
            IdempotencyKey = "Idempotency-Key",
        };

        string expectedAccount = "@elonmusk";
        string expectedUrlValue = "https://example.com/avatar.png";
        string expectedIdempotencyKey = "Idempotency-Key";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateAvatarParams parameters = new()
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/avatar.png",
            IdempotencyKey = "Idempotency-Key",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/profile/avatar"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProfileUpdateAvatarParams parameters = new()
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/avatar.png",
            IdempotencyKey = "Idempotency-Key",
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" }
        );

        Assert.Equal(["Idempotency-Key"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileUpdateAvatarParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/avatar.png",
            IdempotencyKey = "Idempotency-Key",
        };

        ProfileUpdateAvatarParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
