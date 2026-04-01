using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookUpdateResponseEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookUpdateResponseEventType>> expectedEventTypes =
        [
            WebhookUpdateResponseEventType.TweetNew,
        ];
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookUpdateResponseEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookUpdateResponseEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookUpdateResponseEventType>> expectedEventTypes =
        [
            WebhookUpdateResponseEventType.TweetNew,
        ];
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookUpdateResponseEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookUpdateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookUpdateResponseEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        WebhookUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookUpdateResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookUpdateResponseEventType.TweetNew)]
    [InlineData(WebhookUpdateResponseEventType.TweetReply)]
    [InlineData(WebhookUpdateResponseEventType.TweetRetweet)]
    [InlineData(WebhookUpdateResponseEventType.TweetQuote)]
    [InlineData(WebhookUpdateResponseEventType.FollowerGained)]
    [InlineData(WebhookUpdateResponseEventType.FollowerLost)]
    public void Validation_Works(WebhookUpdateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookUpdateResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookUpdateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookUpdateResponseEventType.TweetNew)]
    [InlineData(WebhookUpdateResponseEventType.TweetReply)]
    [InlineData(WebhookUpdateResponseEventType.TweetRetweet)]
    [InlineData(WebhookUpdateResponseEventType.TweetQuote)]
    [InlineData(WebhookUpdateResponseEventType.FollowerGained)]
    [InlineData(WebhookUpdateResponseEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(WebhookUpdateResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookUpdateResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookUpdateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookUpdateResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookUpdateResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
