using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleGetPerformanceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleGetPerformanceResponse
        {
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
                },
            ],
            XUsername = "xUsername",
        };

        long expectedTweetCount = 0;
        List<StyleGetPerformanceResponseTweet> expectedTweets =
        [
            new()
            {
                ID = "id",
                Text = "text",
                CreatedAt = "createdAt",
                LikeCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                ViewCount = 0,
            },
        ];
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedTweetCount, model.TweetCount);
        Assert.Equal(expectedTweets.Count, model.Tweets.Count);
        for (int i = 0; i < expectedTweets.Count; i++)
        {
            Assert.Equal(expectedTweets[i], model.Tweets[i]);
        }
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StyleGetPerformanceResponse
        {
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
                },
            ],
            XUsername = "xUsername",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleGetPerformanceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleGetPerformanceResponse
        {
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
                },
            ],
            XUsername = "xUsername",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleGetPerformanceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTweetCount = 0;
        List<StyleGetPerformanceResponseTweet> expectedTweets =
        [
            new()
            {
                ID = "id",
                Text = "text",
                CreatedAt = "createdAt",
                LikeCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                ViewCount = 0,
            },
        ];
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedTweetCount, deserialized.TweetCount);
        Assert.Equal(expectedTweets.Count, deserialized.Tweets.Count);
        for (int i = 0; i < expectedTweets.Count; i++)
        {
            Assert.Equal(expectedTweets[i], deserialized.Tweets[i]);
        }
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StyleGetPerformanceResponse
        {
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
                },
            ],
            XUsername = "xUsername",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StyleGetPerformanceResponse
        {
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    CreatedAt = "createdAt",
                    LikeCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    ViewCount = 0,
                },
            ],
            XUsername = "xUsername",
        };

        StyleGetPerformanceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StyleGetPerformanceResponseTweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleGetPerformanceResponseTweet
        {
            ID = "id",
            Text = "text",
            CreatedAt = "createdAt",
            LikeCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            ViewCount = 0,
        };

        string expectedID = "id";
        string expectedText = "text";
        string expectedCreatedAt = "createdAt";
        long expectedLikeCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        long expectedViewCount = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
        Assert.Equal(expectedViewCount, model.ViewCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StyleGetPerformanceResponseTweet
        {
            ID = "id",
            Text = "text",
            CreatedAt = "createdAt",
            LikeCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            ViewCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleGetPerformanceResponseTweet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleGetPerformanceResponseTweet
        {
            ID = "id",
            Text = "text",
            CreatedAt = "createdAt",
            LikeCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            ViewCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleGetPerformanceResponseTweet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedText = "text";
        string expectedCreatedAt = "createdAt";
        long expectedLikeCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        long expectedViewCount = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StyleGetPerformanceResponseTweet
        {
            ID = "id",
            Text = "text",
            CreatedAt = "createdAt",
            LikeCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            ViewCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StyleGetPerformanceResponseTweet { ID = "id", Text = "text" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
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
        var model = new StyleGetPerformanceResponseTweet { ID = "id", Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StyleGetPerformanceResponseTweet
        {
            ID = "id",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            LikeCount = null,
            ReplyCount = null,
            RetweetCount = null,
            ViewCount = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
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
        var model = new StyleGetPerformanceResponseTweet
        {
            ID = "id",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            LikeCount = null,
            ReplyCount = null,
            RetweetCount = null,
            ViewCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StyleGetPerformanceResponseTweet
        {
            ID = "id",
            Text = "text",
            CreatedAt = "createdAt",
            LikeCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            ViewCount = 0,
        };

        StyleGetPerformanceResponseTweet copied = new(model);

        Assert.Equal(model, copied);
    }
}
