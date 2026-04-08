using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DrawRunResponse
        {
            ID = "42",
            TotalEntries = 250,
            TweetID = "1234567890",
            ValidEntries = 200,
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

        string expectedID = "42";
        long expectedTotalEntries = 250;
        string expectedTweetID = "1234567890";
        long expectedValidEntries = 200;
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

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedTotalEntries, model.TotalEntries);
        Assert.Equal(expectedTweetID, model.TweetID);
        Assert.Equal(expectedValidEntries, model.ValidEntries);
        Assert.Equal(expectedWinners.Count, model.Winners.Count);
        for (int i = 0; i < expectedWinners.Count; i++)
        {
            Assert.Equal(expectedWinners[i], model.Winners[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DrawRunResponse
        {
            ID = "42",
            TotalEntries = 250,
            TweetID = "1234567890",
            ValidEntries = 200,
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
        var deserialized = JsonSerializer.Deserialize<DrawRunResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DrawRunResponse
        {
            ID = "42",
            TotalEntries = 250,
            TweetID = "1234567890",
            ValidEntries = 200,
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
        var deserialized = JsonSerializer.Deserialize<DrawRunResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        long expectedTotalEntries = 250;
        string expectedTweetID = "1234567890";
        long expectedValidEntries = 200;
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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedTotalEntries, deserialized.TotalEntries);
        Assert.Equal(expectedTweetID, deserialized.TweetID);
        Assert.Equal(expectedValidEntries, deserialized.ValidEntries);
        Assert.Equal(expectedWinners.Count, deserialized.Winners.Count);
        for (int i = 0; i < expectedWinners.Count; i++)
        {
            Assert.Equal(expectedWinners[i], deserialized.Winners[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DrawRunResponse
        {
            ID = "42",
            TotalEntries = 250,
            TweetID = "1234567890",
            ValidEntries = 200,
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
        var model = new DrawRunResponse
        {
            ID = "42",
            TotalEntries = 250,
            TweetID = "1234567890",
            ValidEntries = 200,
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

        DrawRunResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
