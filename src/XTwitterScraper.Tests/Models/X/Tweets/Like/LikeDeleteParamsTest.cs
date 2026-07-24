// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using XTwitterScraper.Models.X.Tweets.Like;

namespace XTwitterScraper.Tests.Models.X.Tweets.Like;

public class LikeDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LikeDeleteParams
        {
            ID = "id",
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";
        string expectedIdempotencyKey = "Idempotency-Key";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
    }

    [Fact]
    public void Url_Works()
    {
        LikeDeleteParams parameters = new()
        {
            ID = "id",
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/tweets/id/like"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        LikeDeleteParams parameters = new()
        {
            ID = "id",
            Account = "@elonmusk",
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
        var parameters = new LikeDeleteParams
        {
            ID = "id",
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        LikeDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
