using System.Collections.Generic;
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
            },
            Author = new()
            {
                ID = "9876543210",
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            },
        };

        TweetDetail expectedTweet = new()
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            ConversationID = "1234567890",
            CreatedAt = "2025-01-15T12:00:00Z",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            Media =
            [
                new()
                {
                    MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                    Type = Type.Photo,
                    Url = "https://t.co/abc123",
                },
            ],
            QuotedTweet = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Source = "Twitter Web App",
        };
        TweetAuthor expectedAuthor = new()
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
            },
            Author = new()
            {
                ID = "9876543210",
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
            },
            Author = new()
            {
                ID = "9876543210",
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            ConversationID = "1234567890",
            CreatedAt = "2025-01-15T12:00:00Z",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            Media =
            [
                new()
                {
                    MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                    Type = Type.Photo,
                    Url = "https://t.co/abc123",
                },
            ],
            QuotedTweet = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Source = "Twitter Web App",
        };
        TweetAuthor expectedAuthor = new()
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
            },
            Author = new()
            {
                ID = "9876543210",
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
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
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Media =
                [
                    new()
                    {
                        MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                        Type = Type.Photo,
                        Url = "https://t.co/abc123",
                    },
                ],
                QuotedTweet = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Source = "Twitter Web App",
            },
            Author = new()
            {
                ID = "9876543210",
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            },
        };

        TweetRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
