// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class EndReasonTest
{
    const string TweetPage = "\"tweets\":[],\"has_next_page\":false,\"next_cursor\":\"\"";
    const string UserPage = "\"users\":[],\"has_next_page\":false,\"next_cursor\":\"\"";
    const string SportsPage = TweetPage + ",\"query\":null";

    static readonly Dictionary<
        string,
        Func<string, ApiEnum<string, CoverageEndReason>?>
    > Pages = new()
    {
        ["PaginatedTweets"] = (json) => Read<PaginatedTweets>(TweetPage + json).EndReason,
        ["PaginatedTweets2"] = (json) => Read<PaginatedTweets2>(TweetPage + json).EndReason,
        ["PaginatedUsers"] = (json) => Read<PaginatedUsers>(UserPage + json).EndReason,
        ["SportsGamePosts"] = (json) => Read<SportsGamePosts>(SportsPage + json).EndReason,
    };

    static T Read<T>(string fields)
        where T : ModelBase
    {
        var model = JsonSerializer.Deserialize<T>("{" + fields + "}", ModelBase.SerializerOptions);
        Assert.NotNull(model);
        model.Validate();
        return model;
    }

    public static TheoryData<string> PageNames() => new(Pages.Keys);

    [Fact]
    public void EveryPageModelIsListed()
    {
        Assert.Equal(4, Pages.Count);
    }

    [Theory]
    [MemberData(nameof(PageNames))]
    public void APageXCutShortReadsStalled(string page)
    {
        var reason = Pages[page](",\"endReason\":\"stalled\"");

        Assert.NotNull(reason);
        Assert.Equal(CoverageEndReason.Stalled, reason.Value());
        Assert.Equal("stalled", reason.Raw());
    }

    [Theory]
    [MemberData(nameof(PageNames))]
    public void AFullPageHasNoEndReason(string page)
    {
        Assert.Null(Pages[page](""));
    }

    [Theory]
    [MemberData(nameof(PageNames))]
    public void AnUnknownEndReasonFailsValidation(string page)
    {
        Assert.Throws<XTwitterScraperInvalidDataException>(() =>
            Pages[page](",\"endReason\":\"something_new\"")
        );
    }

    [Fact]
    public void EndReasonWritesItsWireValue()
    {
        var page = new PaginatedUsers
        {
            Users = [],
            HasNextPage = false,
            NextCursor = "",
            EndReason = CoverageEndReason.Stalled,
        };

        var json = JsonSerializer.SerializeToElement(page, ModelBase.SerializerOptions);

        Assert.Equal("stalled", json.GetProperty("endReason").GetString());
    }
}
