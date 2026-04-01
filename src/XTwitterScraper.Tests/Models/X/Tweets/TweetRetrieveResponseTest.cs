using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
            },
        };

        Tweet expectedTweet = new()
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            CreatedAt = "createdAt",
        };
        TweetRetrieveResponseAuthor expectedAuthor = new()
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        Assert.Equal(expectedTweet, model.Tweet);
        Assert.Equal(expectedAuthor, model.Author);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Tweet expectedTweet = new()
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            CreatedAt = "createdAt",
        };
        TweetRetrieveResponseAuthor expectedAuthor = new()
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        Assert.Equal(expectedTweet, deserialized.Tweet);
        Assert.Equal(expectedAuthor, deserialized.Author);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },

            // Null should be interpreted as omitted for these properties
            Author = null,
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },

            // Null should be interpreted as omitted for these properties
            Author = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                CreatedAt = "createdAt",
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
            },
        };

        TweetRetrieveResponse copied = new(model);

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
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            CreatedAt = "createdAt",
        };

        string expectedID = "id";
        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        string expectedText = "text";
        long expectedViewCount = 0;
        string expectedCreatedAt = "createdAt";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBookmarkCount, model.BookmarkCount);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedViewCount, model.ViewCount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            CreatedAt = "createdAt",
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
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            CreatedAt = "createdAt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tweet>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        string expectedText = "text";
        long expectedViewCount = 0;
        string expectedCreatedAt = "createdAt";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBookmarkCount, deserialized.BookmarkCount);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            CreatedAt = "createdAt",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            CreatedAt = "createdAt",
        };

        Tweet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TweetRetrieveResponseAuthorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        string expectedID = "id";
        long expectedFollowers = 0;
        string expectedUsername = "username";
        bool expectedVerified = true;
        string expectedProfilePicture = "profilePicture";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedVerified, model.Verified);
        Assert.Equal(expectedProfilePicture, model.ProfilePicture);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetRetrieveResponseAuthor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetRetrieveResponseAuthor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedFollowers = 0;
        string expectedUsername = "username";
        bool expectedVerified = true;
        string expectedProfilePicture = "profilePicture";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedVerified, deserialized.Verified);
        Assert.Equal(expectedProfilePicture, deserialized.ProfilePicture);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
        };

        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,

            // Null should be interpreted as omitted for these properties
            ProfilePicture = null,
        };

        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,

            // Null should be interpreted as omitted for these properties
            ProfilePicture = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetRetrieveResponseAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        TweetRetrieveResponseAuthor copied = new(model);

        Assert.Equal(model, copied);
    }
}
