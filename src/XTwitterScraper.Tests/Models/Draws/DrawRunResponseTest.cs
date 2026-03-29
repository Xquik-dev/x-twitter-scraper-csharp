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
            ID = "id",
            TotalEntries = 0,
            TweetID = "tweetId",
            ValidEntries = 0,
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

        string expectedID = "id";
        long expectedTotalEntries = 0;
        string expectedTweetID = "tweetId";
        long expectedValidEntries = 0;
        List<DrawRunResponseWinner> expectedWinners =
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
            ID = "id",
            TotalEntries = 0,
            TweetID = "tweetId",
            ValidEntries = 0,
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
            ID = "id",
            TotalEntries = 0,
            TweetID = "tweetId",
            ValidEntries = 0,
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

        string expectedID = "id";
        long expectedTotalEntries = 0;
        string expectedTweetID = "tweetId";
        long expectedValidEntries = 0;
        List<DrawRunResponseWinner> expectedWinners =
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
            ID = "id",
            TotalEntries = 0,
            TweetID = "tweetId",
            ValidEntries = 0,
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
            ID = "id",
            TotalEntries = 0,
            TweetID = "tweetId",
            ValidEntries = 0,
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

public class DrawRunResponseWinnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DrawRunResponseWinner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string expectedAuthorUsername = "authorUsername";
        bool expectedIsBackup = true;
        long expectedPosition = 0;
        string expectedTweetID = "tweetId";

        Assert.Equal(expectedAuthorUsername, model.AuthorUsername);
        Assert.Equal(expectedIsBackup, model.IsBackup);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTweetID, model.TweetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DrawRunResponseWinner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawRunResponseWinner>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DrawRunResponseWinner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawRunResponseWinner>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAuthorUsername = "authorUsername";
        bool expectedIsBackup = true;
        long expectedPosition = 0;
        string expectedTweetID = "tweetId";

        Assert.Equal(expectedAuthorUsername, deserialized.AuthorUsername);
        Assert.Equal(expectedIsBackup, deserialized.IsBackup);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTweetID, deserialized.TweetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DrawRunResponseWinner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DrawRunResponseWinner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        DrawRunResponseWinner copied = new(model);

        Assert.Equal(model, copied);
    }
}
