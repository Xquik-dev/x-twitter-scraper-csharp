// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Net.Http;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
            CommunityID = "1500000000000000000",
            IsNoteTweet = false,
            Media = ["https://example.com/video.mp4"],
            ReplyToTweetID = "1234567890",
            Text = "Just launched our new feature!",
        };

        string expectedAccount = "@elonmusk";
        string expectedIdempotencyKey = "Idempotency-Key";
        string expectedCommunityID = "1500000000000000000";
        bool expectedIsNoteTweet = false;
        List<string> expectedMedia = ["https://example.com/video.mp4"];
        string expectedReplyToTweetID = "1234567890";
        string expectedText = "Just launched our new feature!";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedCommunityID, parameters.CommunityID);
        Assert.Equal(expectedIsNoteTweet, parameters.IsNoteTweet);
        Assert.NotNull(parameters.Media);
        Assert.Equal(expectedMedia.Count, parameters.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], parameters.Media[i]);
        }
        Assert.Equal(expectedReplyToTweetID, parameters.ReplyToTweetID);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        Assert.Null(parameters.CommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("community_id"));
        Assert.Null(parameters.IsNoteTweet);
        Assert.False(parameters.RawBodyData.ContainsKey("is_note_tweet"));
        Assert.Null(parameters.Media);
        Assert.False(parameters.RawBodyData.ContainsKey("media"));
        Assert.Null(parameters.ReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_tweet_id"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",

            // Null should be interpreted as omitted for these properties
            CommunityID = null,
            IsNoteTweet = null,
            Media = null,
            ReplyToTweetID = null,
            Text = null,
        };

        Assert.Null(parameters.CommunityID);
        Assert.False(parameters.RawBodyData.ContainsKey("community_id"));
        Assert.Null(parameters.IsNoteTweet);
        Assert.False(parameters.RawBodyData.ContainsKey("is_note_tweet"));
        Assert.Null(parameters.Media);
        Assert.False(parameters.RawBodyData.ContainsKey("media"));
        Assert.Null(parameters.ReplyToTweetID);
        Assert.False(parameters.RawBodyData.ContainsKey("reply_to_tweet_id"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void Url_Works()
    {
        TweetCreateParams parameters = new()
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/tweets"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TweetCreateParams parameters = new()
        {
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
        var parameters = new TweetCreateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
            CommunityID = "1500000000000000000",
            IsNoteTweet = false,
            Media = ["https://example.com/video.mp4"],
            ReplyToTweetID = "1234567890",
            Text = "Just launched our new feature!",
        };

        TweetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
