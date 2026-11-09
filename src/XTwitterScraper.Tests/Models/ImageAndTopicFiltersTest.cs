// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Extractions;
using XTwitterScraper.Models.X.Media;
using XTwitterScraper.Models.X.Tweets;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models;

public class ImageAndTopicFiltersTest : TestBase
{
    const string TopicFilterJson =
        "{\"topic\":\"the Rust programming language\",\"question\":\"Is this post about the Rust programming language?\",\"cutoff\":0.5,\"checked\":3,\"kept\":1,\"unchecked\":[{\"id\":\"1234567891\",\"reason\":\"model_error\"}]}";

    const string ImageFilterJson =
        "{\"imageShows\":\"charts\",\"question\":\"Does a picture attached to this post show a chart?\",\"cutoff\":0.5,\"checked\":16,\"kept\":4,\"unchecked\":[{\"id\":\"1234567892\",\"reason\":\"no_safe_photos\"}]}";

    static string Page(string pageFields, string postFields) =>
        "{\"tweets\":[{\"id\":\"1234567890\",\"bookmarkCount\":0,\"likeCount\":3,\"quoteCount\":0,"
        + "\"replyCount\":1,\"retweetCount\":0,\"text\":\"Rust 1.92 is out\",\"viewCount\":40"
        + postFields
        + "}],\"has_next_page\":false,\"next_cursor\":\"\""
        + pageFields
        + "}";

    static Uri UrlOf(ParamsBase parameters) =>
        parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

    [Fact]
    public void SearchSendsTheFilters()
    {
        TweetSearchParams parameters = new()
        {
            Q = "rust",
            ImageShows = "charts",
            Topic = "the Rust programming language",
        };

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/tweets/search?q=rust&imageShows=charts&topic=the+Rust+programming+language"
                ),
                UrlOf(parameters)
            )
        );
    }

    static void AssertUserReadFilters(ParamsBase parameters, string path)
    {
        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    $"https://xquik.com/api/v1/x/users/44196397/{path}?imageShows=charts&topic=rockets"
                ),
                UrlOf(parameters)
            ),
            path
        );
    }

    [Fact]
    public void UserReadsSendTheFilters()
    {
        AssertUserReadFilters(
            new UserRetrieveTweetsParams
            {
                ID = "44196397",
                ImageShows = "charts",
                Topic = "rockets",
            },
            "tweets"
        );
        AssertUserReadFilters(
            new UserRetrieveRepliesParams
            {
                ID = "44196397",
                ImageShows = "charts",
                Topic = "rockets",
            },
            "replies"
        );
        AssertUserReadFilters(
            new UserRetrieveMediaParams
            {
                ID = "44196397",
                ImageShows = "charts",
                Topic = "rockets",
            },
            "media"
        );
    }

    static void AssertBodyFilters(IReadOnlyDictionary<string, JsonElement> body)
    {
        Assert.Equal("rockets", body["topic"].GetString());
        Assert.Equal("charts", body["imageShows"].GetString());
    }

    [Fact]
    public void ExtractionsSendTheFiltersInTheBody()
    {
        ExtractionRunParams run = new()
        {
            ToolType = ExtractionRunParamsToolType.TweetSearchExtractor,
            ImageShows = "charts",
            Topic = "rockets",
        };
        ExtractionEstimateCostParams estimate = new()
        {
            ToolType = ExtractionEstimateCostParamsToolType.TweetSearchExtractor,
            ImageShows = "charts",
            Topic = "rockets",
        };

        AssertBodyFilters(run.RawBodyData);
        AssertBodyFilters(estimate.RawBodyData);
    }

    [Fact]
    public void MediaDownloadSendsImageShowsInTheBody()
    {
        MediaDownloadParams parameters = new() { TweetInput = "1234567890", ImageShows = "charts" };

        Assert.Equal("charts", parameters.RawBodyData["imageShows"].GetString());
    }

    [Fact]
    public void ATopicPageReadsItsSummaryAndScores()
    {
        var page = JsonSerializer.Deserialize<PaginatedTweets>(
            Page(",\"topicFilter\":" + TopicFilterJson, ",\"topicScore\":0.92"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(page);
        page.Validate();
        Assert.NotNull(page.TopicFilter);
        Assert.Equal("the Rust programming language", page.TopicFilter.Topic);
        Assert.Equal(0.5, page.TopicFilter.Cutoff);
        Assert.Equal(3L, page.TopicFilter.Checked);
        Assert.Equal(1L, page.TopicFilter.Kept);
        Assert.Equal("model_error", page.TopicFilter.Unchecked[0].Reason);
        Assert.Equal(0.92, page.Tweets[0].TopicScore);
        Assert.Null(page.ImageFilter);
        Assert.Null(page.Tweets[0].ImageScore);
    }

    [Fact]
    public void AnImagePageReadsItsSummaryAndScores()
    {
        var page = JsonSerializer.Deserialize<PaginatedTweets>(
            Page(",\"imageFilter\":" + ImageFilterJson, ",\"imageScore\":0.81"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(page);
        page.Validate();
        Assert.NotNull(page.ImageFilter);
        Assert.Equal("charts", page.ImageFilter.ImageShows);
        Assert.Equal(16L, page.ImageFilter.Checked);
        Assert.Equal(4L, page.ImageFilter.Kept);
        Assert.Equal("no_safe_photos", page.ImageFilter.Unchecked[0].Reason);
        Assert.Equal(0.81, page.Tweets[0].ImageScore);
        Assert.Null(page.TopicFilter);
    }

    [Fact]
    public void APlainPageHasNoFilterSummaries()
    {
        var page = JsonSerializer.Deserialize<PaginatedTweets>(
            Page("", ""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(page);
        page.Validate();
        Assert.Null(page.TopicFilter);
        Assert.Null(page.ImageFilter);
        Assert.Null(page.Tweets[0].TopicScore);
        Assert.Null(page.Tweets[0].ImageScore);
    }

    [Fact]
    public void AnExtractionJobReadsBothSummaries()
    {
        var job = JsonSerializer.Deserialize<ExtractionJob>(
            "{\"id\":\"77\",\"createdAt\":\"2026-11-08T03:00:00Z\",\"status\":\"completed\","
                + "\"toolType\":\"tweet_search_extractor\",\"totalResults\":1,\"topicFilter\":"
                + TopicFilterJson
                + ",\"imageFilter\":"
                + ImageFilterJson
                + "}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(job);
        job.Validate();
        Assert.NotNull(job.TopicFilter);
        Assert.Equal(1L, job.TopicFilter.Kept);
        Assert.NotNull(job.ImageFilter);
        Assert.Equal(16L, job.ImageFilter.Checked);
    }

    [Fact]
    public void AMediaDownloadReadsTheImageSummary()
    {
        var result = JsonSerializer.Deserialize<MediaDownloadResponse>(
            "{\"tweetId\":\"1234567890\",\"imageFilter\":" + ImageFilterJson + "}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(result);
        result.Validate();
        Assert.NotNull(result.ImageFilter);
        Assert.Equal("charts", result.ImageFilter.ImageShows);
    }
}
