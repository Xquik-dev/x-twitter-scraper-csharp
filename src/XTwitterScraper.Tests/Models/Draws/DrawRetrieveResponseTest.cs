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
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                TotalEntries = 0,
                TweetAuthorUsername = "tweetAuthorUsername",
                TweetID = "tweetId",
                TweetLikeCount = 0,
                TweetQuoteCount = 0,
                TweetReplyCount = 0,
                TweetRetweetCount = 0,
                TweetText = "tweetText",
                TweetUrl = "https://example.com",
                ValidEntries = 0,
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

        Draw expectedDraw = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
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
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                TotalEntries = 0,
                TweetAuthorUsername = "tweetAuthorUsername",
                TweetID = "tweetId",
                TweetLikeCount = 0,
                TweetQuoteCount = 0,
                TweetReplyCount = 0,
                TweetRetweetCount = 0,
                TweetText = "tweetText",
                TweetUrl = "https://example.com",
                ValidEntries = 0,
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
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                TotalEntries = 0,
                TweetAuthorUsername = "tweetAuthorUsername",
                TweetID = "tweetId",
                TweetLikeCount = 0,
                TweetQuoteCount = 0,
                TweetReplyCount = 0,
                TweetRetweetCount = 0,
                TweetText = "tweetText",
                TweetUrl = "https://example.com",
                ValidEntries = 0,
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

        Draw expectedDraw = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
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
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                TotalEntries = 0,
                TweetAuthorUsername = "tweetAuthorUsername",
                TweetID = "tweetId",
                TweetLikeCount = 0,
                TweetQuoteCount = 0,
                TweetReplyCount = 0,
                TweetRetweetCount = 0,
                TweetText = "tweetText",
                TweetUrl = "https://example.com",
                ValidEntries = 0,
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
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                TotalEntries = 0,
                TweetAuthorUsername = "tweetAuthorUsername",
                TweetID = "tweetId",
                TweetLikeCount = 0,
                TweetQuoteCount = 0,
                TweetReplyCount = 0,
                TweetRetweetCount = 0,
                TweetText = "tweetText",
                TweetUrl = "https://example.com",
                ValidEntries = 0,
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

public class DrawTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        long expectedTotalEntries = 0;
        string expectedTweetAuthorUsername = "tweetAuthorUsername";
        string expectedTweetID = "tweetId";
        long expectedTweetLikeCount = 0;
        long expectedTweetQuoteCount = 0;
        long expectedTweetReplyCount = 0;
        long expectedTweetRetweetCount = 0;
        string expectedTweetText = "tweetText";
        string expectedTweetUrl = "https://example.com";
        long expectedValidEntries = 0;
        DateTimeOffset expectedDrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotalEntries, model.TotalEntries);
        Assert.Equal(expectedTweetAuthorUsername, model.TweetAuthorUsername);
        Assert.Equal(expectedTweetID, model.TweetID);
        Assert.Equal(expectedTweetLikeCount, model.TweetLikeCount);
        Assert.Equal(expectedTweetQuoteCount, model.TweetQuoteCount);
        Assert.Equal(expectedTweetReplyCount, model.TweetReplyCount);
        Assert.Equal(expectedTweetRetweetCount, model.TweetRetweetCount);
        Assert.Equal(expectedTweetText, model.TweetText);
        Assert.Equal(expectedTweetUrl, model.TweetUrl);
        Assert.Equal(expectedValidEntries, model.ValidEntries);
        Assert.Equal(expectedDrawnAt, model.DrawnAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draw>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draw>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        long expectedTotalEntries = 0;
        string expectedTweetAuthorUsername = "tweetAuthorUsername";
        string expectedTweetID = "tweetId";
        long expectedTweetLikeCount = 0;
        long expectedTweetQuoteCount = 0;
        long expectedTweetReplyCount = 0;
        long expectedTweetRetweetCount = 0;
        string expectedTweetText = "tweetText";
        string expectedTweetUrl = "https://example.com";
        long expectedValidEntries = 0;
        DateTimeOffset expectedDrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotalEntries, deserialized.TotalEntries);
        Assert.Equal(expectedTweetAuthorUsername, deserialized.TweetAuthorUsername);
        Assert.Equal(expectedTweetID, deserialized.TweetID);
        Assert.Equal(expectedTweetLikeCount, deserialized.TweetLikeCount);
        Assert.Equal(expectedTweetQuoteCount, deserialized.TweetQuoteCount);
        Assert.Equal(expectedTweetReplyCount, deserialized.TweetReplyCount);
        Assert.Equal(expectedTweetRetweetCount, deserialized.TweetRetweetCount);
        Assert.Equal(expectedTweetText, deserialized.TweetText);
        Assert.Equal(expectedTweetUrl, deserialized.TweetUrl);
        Assert.Equal(expectedValidEntries, deserialized.ValidEntries);
        Assert.Equal(expectedDrawnAt, deserialized.DrawnAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
        };

        Assert.Null(model.DrawnAt);
        Assert.False(model.RawData.ContainsKey("drawnAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,

            // Null should be interpreted as omitted for these properties
            DrawnAt = null,
        };

        Assert.Null(model.DrawnAt);
        Assert.False(model.RawData.ContainsKey("drawnAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,

            // Null should be interpreted as omitted for these properties
            DrawnAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Draw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetAuthorUsername = "tweetAuthorUsername",
            TweetID = "tweetId",
            TweetLikeCount = 0,
            TweetQuoteCount = 0,
            TweetReplyCount = 0,
            TweetRetweetCount = 0,
            TweetText = "tweetText",
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Draw copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WinnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Winner
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
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Winner>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Winner>(element, ModelBase.SerializerOptions);
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
        var model = new Winner
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
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        Winner copied = new(model);

        Assert.Equal(model, copied);
    }
}
