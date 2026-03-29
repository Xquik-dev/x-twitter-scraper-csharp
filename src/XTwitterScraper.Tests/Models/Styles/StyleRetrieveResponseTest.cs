using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleRetrieveResponse
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };

        DateTimeOffset expectedFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsOwnAccount = true;
        long expectedTweetCount = 0;
        List<StyleRetrieveResponseTweet> expectedTweets =
        [
            new()
            {
                ID = "id",
                Text = "text",
                AuthorUsername = "authorUsername",
                CreatedAt = "createdAt",
            },
        ];
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedFetchedAt, model.FetchedAt);
        Assert.Equal(expectedIsOwnAccount, model.IsOwnAccount);
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
        var model = new StyleRetrieveResponse
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleRetrieveResponse
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedFetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsOwnAccount = true;
        long expectedTweetCount = 0;
        List<StyleRetrieveResponseTweet> expectedTweets =
        [
            new()
            {
                ID = "id",
                Text = "text",
                AuthorUsername = "authorUsername",
                CreatedAt = "createdAt",
            },
        ];
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedFetchedAt, deserialized.FetchedAt);
        Assert.Equal(expectedIsOwnAccount, deserialized.IsOwnAccount);
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
        var model = new StyleRetrieveResponse
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StyleRetrieveResponse
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };

        StyleRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StyleRetrieveResponseTweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleRetrieveResponseTweet
        {
            ID = "id",
            Text = "text",
            AuthorUsername = "authorUsername",
            CreatedAt = "createdAt",
        };

        string expectedID = "id";
        string expectedText = "text";
        string expectedAuthorUsername = "authorUsername";
        string expectedCreatedAt = "createdAt";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedAuthorUsername, model.AuthorUsername);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StyleRetrieveResponseTweet
        {
            ID = "id",
            Text = "text",
            AuthorUsername = "authorUsername",
            CreatedAt = "createdAt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleRetrieveResponseTweet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleRetrieveResponseTweet
        {
            ID = "id",
            Text = "text",
            AuthorUsername = "authorUsername",
            CreatedAt = "createdAt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleRetrieveResponseTweet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedText = "text";
        string expectedAuthorUsername = "authorUsername";
        string expectedCreatedAt = "createdAt";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedAuthorUsername, deserialized.AuthorUsername);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StyleRetrieveResponseTweet
        {
            ID = "id",
            Text = "text",
            AuthorUsername = "authorUsername",
            CreatedAt = "createdAt",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StyleRetrieveResponseTweet { ID = "id", Text = "text" };

        Assert.Null(model.AuthorUsername);
        Assert.False(model.RawData.ContainsKey("authorUsername"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StyleRetrieveResponseTweet { ID = "id", Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StyleRetrieveResponseTweet
        {
            ID = "id",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AuthorUsername = null,
            CreatedAt = null,
        };

        Assert.Null(model.AuthorUsername);
        Assert.False(model.RawData.ContainsKey("authorUsername"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StyleRetrieveResponseTweet
        {
            ID = "id",
            Text = "text",

            // Null should be interpreted as omitted for these properties
            AuthorUsername = null,
            CreatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StyleRetrieveResponseTweet
        {
            ID = "id",
            Text = "text",
            AuthorUsername = "authorUsername",
            CreatedAt = "createdAt",
        };

        StyleRetrieveResponseTweet copied = new(model);

        Assert.Equal(model, copied);
    }
}
