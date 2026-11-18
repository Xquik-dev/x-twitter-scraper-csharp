// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Services.X;

public class BatchUnavailableIdsTest
{
    const string UsersPage =
        "\"users\":[],\"has_next_page\":false,\"next_cursor\":\"\",\"requested_count\":2,"
        + "\"processed_count\":2,\"returned_count\":0,\"unavailable_ids\":[\"1\",\"2\"],"
        + "\"failed_ids\":[],\"unprocessed_ids\":[]";

    const string TweetsPage =
        "\"tweets\":[],\"has_next_page\":false,\"next_cursor\":\"\","
        + "\"unavailable_ids\":[\"1\",\"2\",\"3\"],\"unprocessed_ids\":[]";

    [Fact]
    public async Task RetrieveBatchReadsTheUnavailableIdsByXsAnswer()
    {
        using var client = Client(
            "{" + UsersPage + ",\"not_found_ids\":[\"1\"],\"suspended_ids\":[\"2\"]}"
        );

        var page = await client.X.Users.RetrieveBatch(
            new() { Ids = "1,2" },
            TestContext.Current.CancellationToken
        );

        Assert.Equal<string>(["1", "2"], page.UnavailableIds);
        Assert.Equal<string>(["1"], page.NotFoundIDs);
        Assert.Equal<string>(["2"], page.SuspendedIDs);
    }

    [Fact]
    public async Task RetrieveBatchTweetsReadsTheUnavailableUsersByXsAnswer()
    {
        using var client = Client(
            "{"
                + TweetsPage
                + ",\"not_found_ids\":[\"1\"],\"suspended_ids\":[\"2\"],\"protected_ids\":[\"3\"]}"
        );

        var page = await client.X.Users.RetrieveBatchTweets(
            new() { Usernames = "gone,banned,private" },
            TestContext.Current.CancellationToken
        );

        Assert.Equal<string>(["1", "2", "3"], page.UnavailableIDs);
        Assert.Equal<string>(["1"], page.NotFoundIDs);
        Assert.Equal<string>(["2"], page.SuspendedIDs);
        Assert.Equal<string>(["3"], page.ProtectedIDs);
    }

    [Fact]
    public void AnswersFromBeforeTheSplitReadNull()
    {
        var users = JsonSerializer.Deserialize<UserRetrieveBatchResponse>(
            "{" + UsersPage + "}",
            ModelBase.SerializerOptions
        );
        var tweets = JsonSerializer.Deserialize<BatchUserTweets>(
            "{" + TweetsPage + "}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(users);
        Assert.NotNull(tweets);
        users.Validate();
        tweets.Validate();
        Assert.Null(users.NotFoundIDs);
        Assert.Null(users.SuspendedIDs);
        Assert.Null(tweets.NotFoundIDs);
        Assert.Null(tweets.SuspendedIDs);
        Assert.Null(tweets.ProtectedIDs);
    }

    static XTwitterScraperClient Client(string json) =>
        new()
        {
            BaseUrl = "http://127.0.0.1",
            ApiKey = "My API Key",
            HttpClient = new HttpClient(new PageHandler(json)),
            ResponseValidation = true,
        };

    sealed class PageHandler(string json) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            if (
                request.RequestUri is not { Scheme: "http", Host: "127.0.0.1" }
                || !request.RequestUri.IsLoopback
            )
            {
                throw new InvalidOperationException(
                    "Tests may only request the literal loopback host."
                );
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                RequestMessage = request,
            };
            return Task.FromResult(response);
        }
    }
}
