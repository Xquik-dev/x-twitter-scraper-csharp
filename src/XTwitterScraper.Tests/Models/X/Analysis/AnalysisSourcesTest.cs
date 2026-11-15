// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using XTwitterScraper.Models.X.Analysis;

namespace XTwitterScraper.Tests.Models.X.Analysis;

public class AnalysisSourcesTest
{
    const string Post = "2102882545427714266";
    const string Account = "@NASA";
    static readonly string[] Queries = ["from:nasa", "from:esa"];
    static readonly string[] Usernames = ["@NASA", "@ESA"];
    static readonly string[] ListIDs = ["4143408", "1970899750481260878"];

    sealed record Sources(
        IReadOnlyDictionary<string, JsonElement> Search,
        IReadOnlyDictionary<string, JsonElement> Page,
        IReadOnlyList<string?> ReadBack
    );

    static readonly Dictionary<string, Func<Sources>> Kinds = new()
    {
        ["Brand"] = () =>
        {
            AnalysisBrandParams search = new()
            {
                Queries = Queries,
                Usernames = Usernames,
                ListIDs = ListIDs,
            };
            AnalysisBrandParams page = new()
            {
                ThreadOf = Post,
                RepliesBy = Account,
                MediaBy = Account,
                LikedBy = Account,
            };
            return new Sources(
                search.RawBodyData,
                page.RawBodyData,
                [
                    .. search.Queries ?? [],
                    .. search.Usernames ?? [],
                    .. search.ListIDs ?? [],
                    page.ThreadOf,
                    page.RepliesBy,
                    page.MediaBy,
                    page.LikedBy,
                ]
            );
        },
        ["Classify"] = () =>
        {
            AnalysisClassifyParams search = new()
            {
                Queries = Queries,
                Usernames = Usernames,
                ListIDs = ListIDs,
            };
            AnalysisClassifyParams page = new()
            {
                ThreadOf = Post,
                RepliesBy = Account,
                MediaBy = Account,
                LikedBy = Account,
            };
            return new Sources(
                search.RawBodyData,
                page.RawBodyData,
                [
                    .. search.Queries ?? [],
                    .. search.Usernames ?? [],
                    .. search.ListIDs ?? [],
                    page.ThreadOf,
                    page.RepliesBy,
                    page.MediaBy,
                    page.LikedBy,
                ]
            );
        },
        ["MarketSignals"] = () =>
        {
            AnalysisMarketSignalsParams search = new()
            {
                Queries = Queries,
                Usernames = Usernames,
                ListIDs = ListIDs,
            };
            AnalysisMarketSignalsParams page = new()
            {
                ThreadOf = Post,
                RepliesBy = Account,
                MediaBy = Account,
                LikedBy = Account,
            };
            return new Sources(
                search.RawBodyData,
                page.RawBodyData,
                [
                    .. search.Queries ?? [],
                    .. search.Usernames ?? [],
                    .. search.ListIDs ?? [],
                    page.ThreadOf,
                    page.RepliesBy,
                    page.MediaBy,
                    page.LikedBy,
                ]
            );
        },
        ["News"] = () =>
        {
            AnalysisNewsParams search = new()
            {
                Queries = Queries,
                Usernames = Usernames,
                ListIDs = ListIDs,
            };
            AnalysisNewsParams page = new()
            {
                ThreadOf = Post,
                RepliesBy = Account,
                MediaBy = Account,
                LikedBy = Account,
            };
            return new Sources(
                search.RawBodyData,
                page.RawBodyData,
                [
                    .. search.Queries ?? [],
                    .. search.Usernames ?? [],
                    .. search.ListIDs ?? [],
                    page.ThreadOf,
                    page.RepliesBy,
                    page.MediaBy,
                    page.LikedBy,
                ]
            );
        },
        ["Sentiment"] = () =>
        {
            AnalysisSentimentParams search = new()
            {
                Queries = Queries,
                Usernames = Usernames,
                ListIDs = ListIDs,
            };
            AnalysisSentimentParams page = new()
            {
                ThreadOf = Post,
                RepliesBy = Account,
                MediaBy = Account,
                LikedBy = Account,
            };
            return new Sources(
                search.RawBodyData,
                page.RawBodyData,
                [
                    .. search.Queries ?? [],
                    .. search.Usernames ?? [],
                    .. search.ListIDs ?? [],
                    page.ThreadOf,
                    page.RepliesBy,
                    page.MediaBy,
                    page.LikedBy,
                ]
            );
        },
        ["ViralScore"] = () =>
        {
            AnalysisViralScoreParams search = new()
            {
                Queries = Queries,
                Usernames = Usernames,
                ListIDs = ListIDs,
            };
            AnalysisViralScoreParams page = new()
            {
                ThreadOf = Post,
                RepliesBy = Account,
                MediaBy = Account,
                LikedBy = Account,
            };
            return new Sources(
                search.RawBodyData,
                page.RawBodyData,
                [
                    .. search.Queries ?? [],
                    .. search.Usernames ?? [],
                    .. search.ListIDs ?? [],
                    page.ThreadOf,
                    page.RepliesBy,
                    page.MediaBy,
                    page.LikedBy,
                ]
            );
        },
    };

    public static TheoryData<string> KindNames() => new(Kinds.Keys);

    [Fact]
    public void EveryAnalysisParamsTypeIsListed()
    {
        Assert.Equal(6, Kinds.Count);
    }

    [Theory]
    [MemberData(nameof(KindNames))]
    public void EachSearchAndPageSourceReachesTheBody(string kind)
    {
        var sources = Kinds[kind]();

        Assert.Equal<string>(
            ["listIds", "queries", "usernames"],
            sources.Search.Keys.OrderBy(key => key, StringComparer.Ordinal)
        );
        Assert.Equal<string?>(
            Queries,
            sources.Search["queries"].EnumerateArray().Select(item => item.GetString())
        );
        Assert.Equal<string>(
            ["likedBy", "mediaBy", "repliesBy", "threadOf"],
            sources.Page.Keys.OrderBy(key => key, StringComparer.Ordinal)
        );
        Assert.Equal(Post, sources.Page["threadOf"].GetString());
        Assert.Equal<string?>(
            [.. Queries, .. Usernames, .. ListIDs, Post, Account, Account, Account],
            sources.ReadBack
        );
    }
}
