using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class PaginatedTweetsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginatedTweets
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    Author = new()
                    {
                        ID = "9876543210",
                        Name = "Elon Musk",
                        Username = "elonmusk",
                        Verified = true,
                    },
                    BookmarkCount = 2,
                    CreatedAt = "2025-01-15T12:00:00Z",
                    IsNoteTweet = false,
                    LikeCount = 42,
                    QuoteCount = 1,
                    ReplyCount = 3,
                    RetweetCount = 5,
                    ViewCount = 1500,
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<SearchTweet> expectedTweets =
        [
            new()
            {
                ID = "1234567890",
                Text = "Just launched our new feature!",
                Author = new()
                {
                    ID = "9876543210",
                    Name = "Elon Musk",
                    Username = "elonmusk",
                    Verified = true,
                },
                BookmarkCount = 2,
                CreatedAt = "2025-01-15T12:00:00Z",
                IsNoteTweet = false,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                ViewCount = 1500,
            },
        ];

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedTweets.Count, model.Tweets.Count);
        for (int i = 0; i < expectedTweets.Count; i++)
        {
            Assert.Equal(expectedTweets[i], model.Tweets[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaginatedTweets
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    Author = new()
                    {
                        ID = "9876543210",
                        Name = "Elon Musk",
                        Username = "elonmusk",
                        Verified = true,
                    },
                    BookmarkCount = 2,
                    CreatedAt = "2025-01-15T12:00:00Z",
                    IsNoteTweet = false,
                    LikeCount = 42,
                    QuoteCount = 1,
                    ReplyCount = 3,
                    RetweetCount = 5,
                    ViewCount = 1500,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedTweets>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaginatedTweets
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    Author = new()
                    {
                        ID = "9876543210",
                        Name = "Elon Musk",
                        Username = "elonmusk",
                        Verified = true,
                    },
                    BookmarkCount = 2,
                    CreatedAt = "2025-01-15T12:00:00Z",
                    IsNoteTweet = false,
                    LikeCount = 42,
                    QuoteCount = 1,
                    ReplyCount = 3,
                    RetweetCount = 5,
                    ViewCount = 1500,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedTweets>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<SearchTweet> expectedTweets =
        [
            new()
            {
                ID = "1234567890",
                Text = "Just launched our new feature!",
                Author = new()
                {
                    ID = "9876543210",
                    Name = "Elon Musk",
                    Username = "elonmusk",
                    Verified = true,
                },
                BookmarkCount = 2,
                CreatedAt = "2025-01-15T12:00:00Z",
                IsNoteTweet = false,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                ViewCount = 1500,
            },
        ];

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedTweets.Count, deserialized.Tweets.Count);
        for (int i = 0; i < expectedTweets.Count; i++)
        {
            Assert.Equal(expectedTweets[i], deserialized.Tweets[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaginatedTweets
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    Author = new()
                    {
                        ID = "9876543210",
                        Name = "Elon Musk",
                        Username = "elonmusk",
                        Verified = true,
                    },
                    BookmarkCount = 2,
                    CreatedAt = "2025-01-15T12:00:00Z",
                    IsNoteTweet = false,
                    LikeCount = 42,
                    QuoteCount = 1,
                    ReplyCount = 3,
                    RetweetCount = 5,
                    ViewCount = 1500,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaginatedTweets
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    Author = new()
                    {
                        ID = "9876543210",
                        Name = "Elon Musk",
                        Username = "elonmusk",
                        Verified = true,
                    },
                    BookmarkCount = 2,
                    CreatedAt = "2025-01-15T12:00:00Z",
                    IsNoteTweet = false,
                    LikeCount = 42,
                    QuoteCount = 1,
                    ReplyCount = 3,
                    RetweetCount = 5,
                    ViewCount = 1500,
                },
            ],
        };

        PaginatedTweets copied = new(model);

        Assert.Equal(model, copied);
    }
}
