using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveMediaResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserRetrieveMediaResponse
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
        List<UserRetrieveMediaResponseTweet> expectedTweets =
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
        var model = new UserRetrieveMediaResponse
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
        var deserialized = JsonSerializer.Deserialize<UserRetrieveMediaResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserRetrieveMediaResponse
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
        var deserialized = JsonSerializer.Deserialize<UserRetrieveMediaResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<UserRetrieveMediaResponseTweet> expectedTweets =
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
        var model = new UserRetrieveMediaResponse
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
        var model = new UserRetrieveMediaResponse
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

        UserRetrieveMediaResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserRetrieveMediaResponseTweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserRetrieveMediaResponseTweet
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
        };

        string expectedID = "1234567890";
        string expectedText = "Just launched our new feature!";
        UserRetrieveMediaResponseTweetAuthor expectedAuthor = new()
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            Verified = true,
        };
        long expectedBookmarkCount = 2;
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        bool expectedIsNoteTweet = false;
        long expectedLikeCount = 42;
        long expectedQuoteCount = 1;
        long expectedReplyCount = 3;
        long expectedRetweetCount = 5;
        long expectedViewCount = 1500;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedAuthor, model.Author);
        Assert.Equal(expectedBookmarkCount, model.BookmarkCount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsNoteTweet, model.IsNoteTweet);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
        Assert.Equal(expectedViewCount, model.ViewCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserRetrieveMediaResponseTweet
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRetrieveMediaResponseTweet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserRetrieveMediaResponseTweet
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRetrieveMediaResponseTweet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "1234567890";
        string expectedText = "Just launched our new feature!";
        UserRetrieveMediaResponseTweetAuthor expectedAuthor = new()
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            Verified = true,
        };
        long expectedBookmarkCount = 2;
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        bool expectedIsNoteTweet = false;
        long expectedLikeCount = 42;
        long expectedQuoteCount = 1;
        long expectedReplyCount = 3;
        long expectedRetweetCount = 5;
        long expectedViewCount = 1500;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedAuthor, deserialized.Author);
        Assert.Equal(expectedBookmarkCount, deserialized.BookmarkCount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsNoteTweet, deserialized.IsNoteTweet);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserRetrieveMediaResponseTweet
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserRetrieveMediaResponseTweet
        {
            ID = "1234567890",
            Text = "Just launched our new feature!",
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.BookmarkCount);
        Assert.False(model.RawData.ContainsKey("bookmarkCount"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IsNoteTweet);
        Assert.False(model.RawData.ContainsKey("isNoteTweet"));
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
        var model = new UserRetrieveMediaResponseTweet
        {
            ID = "1234567890",
            Text = "Just launched our new feature!",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserRetrieveMediaResponseTweet
        {
            ID = "1234567890",
            Text = "Just launched our new feature!",

            // Null should be interpreted as omitted for these properties
            Author = null,
            BookmarkCount = null,
            CreatedAt = null,
            IsNoteTweet = null,
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
        Assert.Null(model.IsNoteTweet);
        Assert.False(model.RawData.ContainsKey("isNoteTweet"));
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
        var model = new UserRetrieveMediaResponseTweet
        {
            ID = "1234567890",
            Text = "Just launched our new feature!",

            // Null should be interpreted as omitted for these properties
            Author = null,
            BookmarkCount = null,
            CreatedAt = null,
            IsNoteTweet = null,
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
        var model = new UserRetrieveMediaResponseTweet
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
        };

        UserRetrieveMediaResponseTweet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserRetrieveMediaResponseTweetAuthorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            Verified = true,
        };

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        bool expectedVerified = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedVerified, model.Verified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            Verified = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRetrieveMediaResponseTweetAuthor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            Verified = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRetrieveMediaResponseTweetAuthor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        bool expectedVerified = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedVerified, deserialized.Verified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
        };

        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            Verified = null,
        };

        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            Verified = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserRetrieveMediaResponseTweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            Verified = true,
        };

        UserRetrieveMediaResponseTweetAuthor copied = new(model);

        Assert.Equal(model, copied);
    }
}
