using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookCreateResponseEventType.TweetNew],
            Secret = "secret",
            Url = "https://example.com",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookCreateResponseEventType>> expectedEventTypes =
        [
            WebhookCreateResponseEventType.TweetNew,
        ];
        string expectedSecret = "secret";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedSecret, model.Secret);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookCreateResponseEventType.TweetNew],
            Secret = "secret",
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookCreateResponseEventType.TweetNew],
            Secret = "secret",
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookCreateResponseEventType>> expectedEventTypes =
        [
            WebhookCreateResponseEventType.TweetNew,
        ];
        string expectedSecret = "secret";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedSecret, deserialized.Secret);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookCreateResponseEventType.TweetNew],
            Secret = "secret",
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookCreateResponseEventType.TweetNew],
            Secret = "secret",
            Url = "https://example.com",
        };

        WebhookCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookCreateResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookCreateResponseEventType.TweetNew)]
    [InlineData(WebhookCreateResponseEventType.TweetReply)]
    [InlineData(WebhookCreateResponseEventType.TweetRetweet)]
    [InlineData(WebhookCreateResponseEventType.TweetQuote)]
    [InlineData(WebhookCreateResponseEventType.FollowerGained)]
    [InlineData(WebhookCreateResponseEventType.FollowerLost)]
    public void Validation_Works(WebhookCreateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookCreateResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookCreateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookCreateResponseEventType.TweetNew)]
    [InlineData(WebhookCreateResponseEventType.TweetReply)]
    [InlineData(WebhookCreateResponseEventType.TweetRetweet)]
    [InlineData(WebhookCreateResponseEventType.TweetQuote)]
    [InlineData(WebhookCreateResponseEventType.FollowerGained)]
    [InlineData(WebhookCreateResponseEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(WebhookCreateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookCreateResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookCreateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookCreateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookCreateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
