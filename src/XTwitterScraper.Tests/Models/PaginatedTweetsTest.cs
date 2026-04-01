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
        List<Tweet> expectedTweets =
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
        List<Tweet> expectedTweets =
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

public class TweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tweet
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
        };

        string expectedID = "id";
        string expectedText = "text";
        Author expectedAuthor = new()
        {
            ID = "id",
            Name = "name",
            Username = "username",
            Verified = true,
        };
        long expectedBookmarkCount = 0;
        string expectedCreatedAt = "createdAt";
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        long expectedViewCount = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedAuthor, model.Author);
        Assert.Equal(expectedBookmarkCount, model.BookmarkCount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
        Assert.Equal(expectedViewCount, model.ViewCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tweet
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tweet>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tweet
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tweet>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedText = "text";
        Author expectedAuthor = new()
        {
            ID = "id",
            Name = "name",
            Username = "username",
            Verified = true,
        };
        long expectedBookmarkCount = 0;
        string expectedCreatedAt = "createdAt";
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        long expectedViewCount = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedAuthor, deserialized.Author);
        Assert.Equal(expectedBookmarkCount, deserialized.BookmarkCount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tweet
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tweet { ID = "id", Text = "text" };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.BookmarkCount);
        Assert.False(model.RawData.ContainsKey("bookmarkCount"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
        Assert.Null(model.QuoteCount);
        Assert.False(model.RawData.ContainsKey("quoteCount"));
        Assert.Null(model.ReplyCount);
        Assert.False(model.RawData.ContainsKey("replyCount"));
        Assert.Null(model.RetweetCount);
        Assert.False(model.RawData.ContainsKey("retweetCount"));
        Assert.Null(model.ViewCount);
        Assert.False(model.RawData.ContainsKey("viewCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tweet { ID = "id", Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Author = null,
            BookmarkCount = null,
            CreatedAt = null,
            LikeCount = null,
            QuoteCount = null,
            ReplyCount = null,
            RetweetCount = null,
            ViewCount = null,
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.BookmarkCount);
        Assert.False(model.RawData.ContainsKey("bookmarkCount"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
        Assert.Null(model.QuoteCount);
        Assert.False(model.RawData.ContainsKey("quoteCount"));
        Assert.Null(model.ReplyCount);
        Assert.False(model.RawData.ContainsKey("replyCount"));
        Assert.Null(model.RetweetCount);
        Assert.False(model.RawData.ContainsKey("retweetCount"));
        Assert.Null(model.ViewCount);
        Assert.False(model.RawData.ContainsKey("viewCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Author = null,
            BookmarkCount = null,
            CreatedAt = null,
            LikeCount = null,
            QuoteCount = null,
            ReplyCount = null,
            RetweetCount = null,
            ViewCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tweet
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
        };

        Tweet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AuthorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",
            Verified = true,
        };

        string expectedID = "id";
        string expectedName = "name";
        string expectedUsername = "username";
        bool expectedVerified = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedVerified, model.Verified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",
            Verified = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Author>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",
            Verified = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Author>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        string expectedUsername = "username";
        bool expectedVerified = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedVerified, deserialized.Verified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",
        };

        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",

            // Null should be interpreted as omitted for these properties
            Verified = null,
        };

        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",

            // Null should be interpreted as omitted for these properties
            Verified = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Author
        {
            ID = "id",
            Name = "name",
            Username = "username",
            Verified = true,
        };

        Author copied = new(model);

        Assert.Equal(model, copied);
    }
}
