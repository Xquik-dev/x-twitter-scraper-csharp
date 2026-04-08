using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetDetail
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

        string expectedID = "1234567890";
        long expectedBookmarkCount = 2;
        long expectedLikeCount = 42;
        long expectedQuoteCount = 1;
        long expectedReplyCount = 3;
        long expectedRetweetCount = 5;
        string expectedText = "Just launched our new feature!";
        long expectedViewCount = 1500;
        string expectedConversationID = "1234567890";
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedIsNoteTweet = false;
        bool expectedIsQuoteStatus = false;
        bool expectedIsReply = false;
        List<TweetDetailMedia> expectedMedia =
        [
            new()
            {
                MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                Type = Type.Photo,
                Url = "https://t.co/abc123",
            },
        ];
        Dictionary<string, JsonElement> expectedQuotedTweet = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedSource = "Twitter Web App";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBookmarkCount, model.BookmarkCount);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedViewCount, model.ViewCount);
        Assert.Equal(expectedConversationID, model.ConversationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Entities);
        Assert.Equal(expectedEntities.Count, model.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(model.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Entities[item.Key]));
        }
        Assert.Equal(expectedIsNoteTweet, model.IsNoteTweet);
        Assert.Equal(expectedIsQuoteStatus, model.IsQuoteStatus);
        Assert.Equal(expectedIsReply, model.IsReply);
        Assert.NotNull(model.Media);
        Assert.Equal(expectedMedia.Count, model.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], model.Media[i]);
        }
        Assert.NotNull(model.QuotedTweet);
        Assert.Equal(expectedQuotedTweet.Count, model.QuotedTweet.Count);
        foreach (var item in expectedQuotedTweet)
        {
            Assert.True(model.QuotedTweet.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.QuotedTweet[item.Key]));
        }
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetDetail
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetDetail
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "1234567890";
        long expectedBookmarkCount = 2;
        long expectedLikeCount = 42;
        long expectedQuoteCount = 1;
        long expectedReplyCount = 3;
        long expectedRetweetCount = 5;
        string expectedText = "Just launched our new feature!";
        long expectedViewCount = 1500;
        string expectedConversationID = "1234567890";
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedIsNoteTweet = false;
        bool expectedIsQuoteStatus = false;
        bool expectedIsReply = false;
        List<TweetDetailMedia> expectedMedia =
        [
            new()
            {
                MediaUrl = "https://pbs.twimg.com/media/example.jpg",
                Type = Type.Photo,
                Url = "https://t.co/abc123",
            },
        ];
        Dictionary<string, JsonElement> expectedQuotedTweet = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedSource = "Twitter Web App";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBookmarkCount, deserialized.BookmarkCount);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
        Assert.Equal(expectedConversationID, deserialized.ConversationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Entities);
        Assert.Equal(expectedEntities.Count, deserialized.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(deserialized.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Entities[item.Key]));
        }
        Assert.Equal(expectedIsNoteTweet, deserialized.IsNoteTweet);
        Assert.Equal(expectedIsQuoteStatus, deserialized.IsQuoteStatus);
        Assert.Equal(expectedIsReply, deserialized.IsReply);
        Assert.NotNull(deserialized.Media);
        Assert.Equal(expectedMedia.Count, deserialized.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], deserialized.Media[i]);
        }
        Assert.NotNull(deserialized.QuotedTweet);
        Assert.Equal(expectedQuotedTweet.Count, deserialized.QuotedTweet.Count);
        foreach (var item in expectedQuotedTweet)
        {
            Assert.True(deserialized.QuotedTweet.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.QuotedTweet[item.Key]));
        }
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetDetail
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
        };

        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.IsNoteTweet);
        Assert.False(model.RawData.ContainsKey("isNoteTweet"));
        Assert.Null(model.IsQuoteStatus);
        Assert.False(model.RawData.ContainsKey("isQuoteStatus"));
        Assert.Null(model.IsReply);
        Assert.False(model.RawData.ContainsKey("isReply"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.QuotedTweet);
        Assert.False(model.RawData.ContainsKey("quoted_tweet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,

            // Null should be interpreted as omitted for these properties
            ConversationID = null,
            CreatedAt = null,
            Entities = null,
            IsNoteTweet = null,
            IsQuoteStatus = null,
            IsReply = null,
            Media = null,
            QuotedTweet = null,
            Source = null,
        };

        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.IsNoteTweet);
        Assert.False(model.RawData.ContainsKey("isNoteTweet"));
        Assert.Null(model.IsQuoteStatus);
        Assert.False(model.RawData.ContainsKey("isQuoteStatus"));
        Assert.Null(model.IsReply);
        Assert.False(model.RawData.ContainsKey("isReply"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.QuotedTweet);
        Assert.False(model.RawData.ContainsKey("quoted_tweet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,

            // Null should be interpreted as omitted for these properties
            ConversationID = null,
            CreatedAt = null,
            Entities = null,
            IsNoteTweet = null,
            IsQuoteStatus = null,
            IsReply = null,
            Media = null,
            QuotedTweet = null,
            Source = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetDetail
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

        TweetDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TweetDetailMediaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetDetailMedia
        {
            MediaUrl = "https://pbs.twimg.com/media/example.jpg",
            Type = Type.Photo,
            Url = "https://t.co/abc123",
        };

        string expectedMediaUrl = "https://pbs.twimg.com/media/example.jpg";
        ApiEnum<string, Type> expectedType = Type.Photo;
        string expectedUrl = "https://t.co/abc123";

        Assert.Equal(expectedMediaUrl, model.MediaUrl);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetDetailMedia
        {
            MediaUrl = "https://pbs.twimg.com/media/example.jpg",
            Type = Type.Photo,
            Url = "https://t.co/abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetailMedia>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetDetailMedia
        {
            MediaUrl = "https://pbs.twimg.com/media/example.jpg",
            Type = Type.Photo,
            Url = "https://t.co/abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetailMedia>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaUrl = "https://pbs.twimg.com/media/example.jpg";
        ApiEnum<string, Type> expectedType = Type.Photo;
        string expectedUrl = "https://t.co/abc123";

        Assert.Equal(expectedMediaUrl, deserialized.MediaUrl);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetDetailMedia
        {
            MediaUrl = "https://pbs.twimg.com/media/example.jpg",
            Type = Type.Photo,
            Url = "https://t.co/abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetDetailMedia { };

        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetDetailMedia { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetDetailMedia
        {
            // Null should be interpreted as omitted for these properties
            MediaUrl = null,
            Type = null,
            Url = null,
        };

        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetDetailMedia
        {
            // Null should be interpreted as omitted for these properties
            MediaUrl = null,
            Type = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetDetailMedia
        {
            MediaUrl = "https://pbs.twimg.com/media/example.jpg",
            Type = Type.Photo,
            Url = "https://t.co/abc123",
        };

        TweetDetailMedia copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Photo)]
    [InlineData(Type.Video)]
    [InlineData(Type.AnimatedGif)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Photo)]
    [InlineData(Type.Video)]
    [InlineData(Type.AnimatedGif)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
