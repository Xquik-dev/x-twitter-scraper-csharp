using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DrawRetrieveResponse
        {
            Draw = new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Status = "completed",
                TotalEntries = 250,
                TweetAuthorUsername = "elonmusk",
                TweetID = "1234567890",
                TweetLikeCount = 50000,
                TweetQuoteCount = 5000,
                TweetReplyCount = 10000,
                TweetRetweetCount = 25000,
                TweetText = "Giving away 3 Tesla Model 3s!",
                TweetUrl = "https://x.com/elonmusk/status/1234567890",
                ValidEntries = 200,
                DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Winners =
            [
                new()
                {
                    AuthorUsername = "authorUsername",
                    IsBackup = true,
                    Position = 0,
                    TweetID = "tweetId",
                },
            ],
        };

        DrawDetail expectedDraw = new()
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Status = "completed",
            TotalEntries = 250,
            TweetAuthorUsername = "elonmusk",
            TweetID = "1234567890",
            TweetLikeCount = 50000,
            TweetQuoteCount = 5000,
            TweetReplyCount = 10000,
            TweetRetweetCount = 25000,
            TweetText = "Giving away 3 Tesla Model 3s!",
            TweetUrl = "https://x.com/elonmusk/status/1234567890",
            ValidEntries = 200,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        List<Winner> expectedWinners =
        [
            new()
            {
                AuthorUsername = "authorUsername",
                IsBackup = true,
                Position = 0,
                TweetID = "tweetId",
            },
        ];

        Assert.Equal(expectedDraw, model.Draw);
        Assert.Equal(expectedWinners.Count, model.Winners.Count);
        for (int i = 0; i < expectedWinners.Count; i++)
        {
            Assert.Equal(expectedWinners[i], model.Winners[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DrawRetrieveResponse
        {
            Draw = new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Status = "completed",
                TotalEntries = 250,
                TweetAuthorUsername = "elonmusk",
                TweetID = "1234567890",
                TweetLikeCount = 50000,
                TweetQuoteCount = 5000,
                TweetReplyCount = 10000,
                TweetRetweetCount = 25000,
                TweetText = "Giving away 3 Tesla Model 3s!",
                TweetUrl = "https://x.com/elonmusk/status/1234567890",
                ValidEntries = 200,
                DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Winners =
            [
                new()
                {
                    AuthorUsername = "authorUsername",
                    IsBackup = true,
                    Position = 0,
                    TweetID = "tweetId",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DrawRetrieveResponse
        {
            Draw = new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Status = "completed",
                TotalEntries = 250,
                TweetAuthorUsername = "elonmusk",
                TweetID = "1234567890",
                TweetLikeCount = 50000,
                TweetQuoteCount = 5000,
                TweetReplyCount = 10000,
                TweetRetweetCount = 25000,
                TweetText = "Giving away 3 Tesla Model 3s!",
                TweetUrl = "https://x.com/elonmusk/status/1234567890",
                ValidEntries = 200,
                DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Winners =
            [
                new()
                {
                    AuthorUsername = "authorUsername",
                    IsBackup = true,
                    Position = 0,
                    TweetID = "tweetId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DrawDetail expectedDraw = new()
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Status = "completed",
            TotalEntries = 250,
            TweetAuthorUsername = "elonmusk",
            TweetID = "1234567890",
            TweetLikeCount = 50000,
            TweetQuoteCount = 5000,
            TweetReplyCount = 10000,
            TweetRetweetCount = 25000,
            TweetText = "Giving away 3 Tesla Model 3s!",
            TweetUrl = "https://x.com/elonmusk/status/1234567890",
            ValidEntries = 200,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        List<Winner> expectedWinners =
        [
            new()
            {
                AuthorUsername = "authorUsername",
                IsBackup = true,
                Position = 0,
                TweetID = "tweetId",
            },
        ];

        Assert.Equal(expectedDraw, deserialized.Draw);
        Assert.Equal(expectedWinners.Count, deserialized.Winners.Count);
        for (int i = 0; i < expectedWinners.Count; i++)
        {
            Assert.Equal(expectedWinners[i], deserialized.Winners[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DrawRetrieveResponse
        {
            Draw = new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Status = "completed",
                TotalEntries = 250,
                TweetAuthorUsername = "elonmusk",
                TweetID = "1234567890",
                TweetLikeCount = 50000,
                TweetQuoteCount = 5000,
                TweetReplyCount = 10000,
                TweetRetweetCount = 25000,
                TweetText = "Giving away 3 Tesla Model 3s!",
                TweetUrl = "https://x.com/elonmusk/status/1234567890",
                ValidEntries = 200,
                DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Winners =
            [
                new()
                {
                    AuthorUsername = "authorUsername",
                    IsBackup = true,
                    Position = 0,
                    TweetID = "tweetId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DrawRetrieveResponse
        {
            Draw = new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Status = "completed",
                TotalEntries = 250,
                TweetAuthorUsername = "elonmusk",
                TweetID = "1234567890",
                TweetLikeCount = 50000,
                TweetQuoteCount = 5000,
                TweetReplyCount = 10000,
                TweetRetweetCount = 25000,
                TweetText = "Giving away 3 Tesla Model 3s!",
                TweetUrl = "https://x.com/elonmusk/status/1234567890",
                ValidEntries = 200,
                DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Winners =
            [
                new()
                {
                    AuthorUsername = "authorUsername",
                    IsBackup = true,
                    Position = 0,
                    TweetID = "tweetId",
                },
            ],
        };

        DrawRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
