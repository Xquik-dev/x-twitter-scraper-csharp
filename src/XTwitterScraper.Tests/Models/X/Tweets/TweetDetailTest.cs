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
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            ConversationID = "conversationId",
            CreatedAt = "createdAt",
            Entities = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = Type.Photo,
                    Url = "url",
                },
            ],
            QuotedTweet = JsonSerializer.Deserialize<JsonElement>("{}"),
            Source = "source",
        };

        string expectedID = "id";
        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        string expectedText = "text";
        long expectedViewCount = 0;
        string expectedConversationID = "conversationId";
        string expectedCreatedAt = "createdAt";
        JsonElement expectedEntities = JsonSerializer.Deserialize<JsonElement>("{}");
        bool expectedIsNoteTweet = true;
        bool expectedIsQuoteStatus = true;
        bool expectedIsReply = true;
        List<TweetDetailMedia> expectedMedia =
        [
            new()
            {
                MediaUrl = "mediaUrl",
                Type = Type.Photo,
                Url = "url",
            },
        ];
        JsonElement expectedQuotedTweet = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSource = "source";

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
        Assert.True(JsonElement.DeepEquals(expectedEntities, model.Entities.Value));
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
        Assert.True(JsonElement.DeepEquals(expectedQuotedTweet, model.QuotedTweet.Value));
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetDetail
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            ConversationID = "conversationId",
            CreatedAt = "createdAt",
            Entities = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = Type.Photo,
                    Url = "url",
                },
            ],
            QuotedTweet = JsonSerializer.Deserialize<JsonElement>("{}"),
            Source = "source",
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
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            ConversationID = "conversationId",
            CreatedAt = "createdAt",
            Entities = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = Type.Photo,
                    Url = "url",
                },
            ],
            QuotedTweet = JsonSerializer.Deserialize<JsonElement>("{}"),
            Source = "source",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        string expectedText = "text";
        long expectedViewCount = 0;
        string expectedConversationID = "conversationId";
        string expectedCreatedAt = "createdAt";
        JsonElement expectedEntities = JsonSerializer.Deserialize<JsonElement>("{}");
        bool expectedIsNoteTweet = true;
        bool expectedIsQuoteStatus = true;
        bool expectedIsReply = true;
        List<TweetDetailMedia> expectedMedia =
        [
            new()
            {
                MediaUrl = "mediaUrl",
                Type = Type.Photo,
                Url = "url",
            },
        ];
        JsonElement expectedQuotedTweet = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSource = "source";

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
        Assert.True(JsonElement.DeepEquals(expectedEntities, deserialized.Entities.Value));
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
        Assert.True(JsonElement.DeepEquals(expectedQuotedTweet, deserialized.QuotedTweet.Value));
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetDetail
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            ConversationID = "conversationId",
            CreatedAt = "createdAt",
            Entities = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = Type.Photo,
                    Url = "url",
                },
            ],
            QuotedTweet = JsonSerializer.Deserialize<JsonElement>("{}"),
            Source = "source",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetDetail
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
        var model = new TweetDetail
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
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,

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
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
            ConversationID = "conversationId",
            CreatedAt = "createdAt",
            Entities = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = Type.Photo,
                    Url = "url",
                },
            ],
            QuotedTweet = JsonSerializer.Deserialize<JsonElement>("{}"),
            Source = "source",
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
            MediaUrl = "mediaUrl",
            Type = Type.Photo,
            Url = "url",
        };

        string expectedMediaUrl = "mediaUrl";
        ApiEnum<string, Type> expectedType = Type.Photo;
        string expectedUrl = "url";

        Assert.Equal(expectedMediaUrl, model.MediaUrl);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetDetailMedia
        {
            MediaUrl = "mediaUrl",
            Type = Type.Photo,
            Url = "url",
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
            MediaUrl = "mediaUrl",
            Type = Type.Photo,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetailMedia>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaUrl = "mediaUrl";
        ApiEnum<string, Type> expectedType = Type.Photo;
        string expectedUrl = "url";

        Assert.Equal(expectedMediaUrl, deserialized.MediaUrl);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetDetailMedia
        {
            MediaUrl = "mediaUrl",
            Type = Type.Photo,
            Url = "url",
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
            MediaUrl = "mediaUrl",
            Type = Type.Photo,
            Url = "url",
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
