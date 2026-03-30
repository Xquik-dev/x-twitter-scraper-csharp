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

        TweetDetail expectedTweet = new()
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
        TweetAuthor expectedAuthor = new()
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

        TweetDetail expectedTweet = new()
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
        TweetAuthor expectedAuthor = new()
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
