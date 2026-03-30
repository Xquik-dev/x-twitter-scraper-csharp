using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models;

public class PaginatedTweetsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginatedTweets
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    Author = new()
                    {
                        ID = "id",
                        Name = "name",
                        Username = "username",
                        Verified = true,
                    },
                    BookmarkCount = 0,
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";
        List<SearchTweet> expectedTweets =
        [
            new()
            {
                ID = "id",
                Text = "text",
                Author = new()
                {
                    ID = "id",
                    Name = "name",
                    Username = "username",
                    Verified = true,
                },
                BookmarkCount = 0,
                CreatedAt = "createdAt",
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                ViewCount = 0,
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
            NextCursor = "next_cursor",
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    Author = new()
                    {
                        ID = "id",
                        Name = "name",
                        Username = "username",
                        Verified = true,
                    },
                    BookmarkCount = 0,
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
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
            NextCursor = "next_cursor",
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    Author = new()
                    {
                        ID = "id",
                        Name = "name",
                        Username = "username",
                        Verified = true,
                    },
                    BookmarkCount = 0,
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
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
        string expectedNextCursor = "next_cursor";
        List<SearchTweet> expectedTweets =
        [
            new()
            {
                ID = "id",
                Text = "text",
                Author = new()
                {
                    ID = "id",
                    Name = "name",
                    Username = "username",
                    Verified = true,
                },
                BookmarkCount = 0,
                CreatedAt = "createdAt",
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                ViewCount = 0,
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
            NextCursor = "next_cursor",
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    Author = new()
                    {
                        ID = "id",
                        Name = "name",
                        Username = "username",
                        Verified = true,
                    },
                    BookmarkCount = 0,
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
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
            NextCursor = "next_cursor",
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    Author = new()
                    {
                        ID = "id",
                        Name = "name",
                        Username = "username",
                        Verified = true,
                    },
                    BookmarkCount = 0,
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
                },
            ],
        };

        PaginatedTweets copied = new(model);

        Assert.Equal(model, copied);
    }
}
