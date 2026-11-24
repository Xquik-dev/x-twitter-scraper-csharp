// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models;

public class CommunityUnavailableTest
{
    const string Post =
        "\"id\":\"1\",\"text\":\"hello\",\"bookmarkCount\":0,\"likeCount\":0,\"quoteCount\":0,"
        + "\"replyCount\":0,\"retweetCount\":0,\"viewCount\":0";

    const string Unavailable = ",\"communityUnavailable\":{\"reason\":\"NonMember\"}";

    static readonly Dictionary<string, Func<string, CommunityUnavailable?>> Posts = new()
    {
        ["EmbeddedTweet"] = (json) => Read<EmbeddedTweet>(Post + json).CommunityUnavailable,
        ["SearchTweet"] = (json) => Read<SearchTweet>(Post + json).CommunityUnavailable,
        ["SearchTweet2"] = (json) => Read<SearchTweet2>(Post + json).CommunityUnavailable,
        ["TweetDetail"] = (json) => Read<TweetDetail>(Post + json).CommunityUnavailable,
    };

    static T Read<T>(string fields)
        where T : ModelBase
    {
        var model = JsonSerializer.Deserialize<T>("{" + fields + "}", ModelBase.SerializerOptions);
        Assert.NotNull(model);
        model.Validate();
        return model;
    }

    public static TheoryData<string> PostNames() => new(Posts.Keys);

    public static TheoryData<string> EmbeddedKeys() =>
        new("parentTweet", "quoted_tweet", "retweeted_tweet");

    [Fact]
    public void EveryPostModelIsListed()
    {
        Assert.Equal(4, Posts.Count);
    }

    [Theory]
    [MemberData(nameof(PostNames))]
    public void APostReadsXsReasonAsXWritesIt(string post)
    {
        var unavailable = Posts[post](Unavailable);

        Assert.NotNull(unavailable);
        Assert.Equal("NonMember", unavailable.Reason);
    }

    [Theory]
    [MemberData(nameof(PostNames))]
    public void APostWithoutAReasonReadsNull(string post)
    {
        Assert.Null(Posts[post](""));
    }

    [Theory]
    [MemberData(nameof(PostNames))]
    public void AnUnavailableCommunityWithoutAReasonFailsValidation(string post)
    {
        Assert.Throws<XTwitterScraperInvalidDataException>(() =>
            Posts[post](",\"communityUnavailable\":{}")
        );
    }

    [Theory]
    [MemberData(nameof(EmbeddedKeys))]
    public void AnEmbeddedPostReadsItsReason(string key)
    {
        var post = Read<SearchTweet>(Post + ",\"" + key + "\":{" + Post + Unavailable + "}");
        var embedded = key switch
        {
            "parentTweet" => post.ParentTweet,
            "quoted_tweet" => post.QuotedTweet,
            _ => post.RetweetedTweet,
        };

        Assert.NotNull(embedded);
        Assert.Equal("NonMember", embedded.CommunityUnavailable?.Reason);
        Assert.Null(post.CommunityUnavailable);
    }

    [Fact]
    public void CommunityUnavailableWritesItsWireValue()
    {
        var post = new EmbeddedTweet
        {
            ID = "1",
            Text = "hello",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            ViewCount = 0,
            CommunityUnavailable = new() { Reason = "NonMember" },
        };

        var json = JsonSerializer.SerializeToElement(post, ModelBase.SerializerOptions);

        Assert.Equal(
            "NonMember",
            json.GetProperty("communityUnavailable").GetProperty("reason").GetString()
        );
    }
}
