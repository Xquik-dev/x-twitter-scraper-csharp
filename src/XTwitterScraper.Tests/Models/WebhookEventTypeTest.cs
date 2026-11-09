// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class WebhookEventTypeTest : TestBase
{
    static WebhookEventType Read(string raw) =>
        JsonSerializer.Deserialize<WebhookEventType>(
            JsonSerializer.Serialize(raw),
            ModelBase.SerializerOptions
        )!;

    [Fact]
    public void AccountEventReadsAsEventType()
    {
        var value = Read("tweet.new");

        value.Validate();
        Assert.True(value.TryPickEventType(out var picked));
        Assert.Equal(EventType.TweetNew, picked.Value());
        Assert.False(value.TryPickPostEventType(out _));
        Assert.Equal("event:tweet.new", Describe(value));
    }

    [Fact]
    public void PostEventReadsAsPostEventType()
    {
        var value = Read("post.deleted");

        value.Validate();
        Assert.True(value.TryPickPostEventType(out var picked));
        Assert.Equal(PostEventType.PostDeleted, picked.Value());
        Assert.False(value.TryPickEventType(out _));
        Assert.Equal("post:post.deleted", Describe(value));
    }

    [Fact]
    public void UnknownValueFailsValidation()
    {
        var value = Read("tweet.unknown");

        Assert.False(value.TryPickEventType(out _));
        Assert.False(value.TryPickPostEventType(out _));
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
        Assert.Throws<XTwitterScraperInvalidDataException>(() => Describe(value));
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Switch(_ => { }, _ => { }));
        Assert.Equal("tweet.unknown", value.Json.GetString());
    }

    [Theory]
    [InlineData("tweet.new")]
    [InlineData("post.reply.new")]
    [InlineData("tweet.unknown")]
    public void RawValueRoundTripsUnchanged(string raw)
    {
        var json = JsonSerializer.Serialize(raw);

        var again = JsonSerializer.Serialize(Read(raw), ModelBase.SerializerOptions);

        Assert.Equal(json, again);
    }

    [Fact]
    public void BuiltValuesSerializeToTheirRawString()
    {
        WebhookEventType account = EventType.FollowerAdded;
        WebhookEventType post = PostEventType.PostViewsChanged;

        Assert.Equal(
            "\"follower.added\"",
            JsonSerializer.Serialize(account, ModelBase.SerializerOptions)
        );
        Assert.Equal(
            "\"post.views.changed\"",
            JsonSerializer.Serialize(post, ModelBase.SerializerOptions)
        );
        Assert.Equal("\"follower.added\"", account.ToString());
    }

    [Fact]
    public void SwitchCallsTheMatchingBranch()
    {
        var seen = new List<string>();
        WebhookEventType account = EventType.TweetReply;
        WebhookEventType post = PostEventType.PostEdited;

        account.Switch(e => seen.Add("event:" + e.Raw()), p => seen.Add("post:" + p.Raw()));
        post.Switch(e => seen.Add("event:" + e.Raw()), p => seen.Add("post:" + p.Raw()));

        Assert.Equal(new List<string> { "event:tweet.reply", "post:post.edited" }, seen);
    }

    [Fact]
    public void EqualityComparesVariantAndValue()
    {
        WebhookEventType built = EventType.TweetNew;
        ApiEnum<string, EventType> rawEnum = "tweet.new";
        WebhookEventType fromApiEnum = rawEnum;
        WebhookEventType post = PostEventType.PostReplyNew;

        Assert.Equal(built, Read("tweet.new"));
        Assert.Equal(built, fromApiEnum);
        Assert.NotEqual(built, post);
        Assert.NotEqual(Read("tweet.unknown"), built);
        Assert.False(built.Equals(null));
    }

    [Fact]
    public void ApiEnumOfPostEventTypeConvertsImplicitly()
    {
        ApiEnum<string, PostEventType> raw = PostEventType.PostQuoteNew;
        WebhookEventType value = raw;

        Assert.True(value.TryPickPostEventType(out var picked));
        Assert.Equal(raw, picked);
    }

    static string Describe(WebhookEventType value) =>
        value.Match(e => "event:" + e.Raw(), p => "post:" + p.Raw());
}
