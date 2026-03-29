using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [WebhookEventType.TweetNew],
                    IsActive = true,
                    Url = "https://example.com",
                },
            ],
        };

        List<Webhook> expectedWebhooks =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [WebhookEventType.TweetNew],
                IsActive = true,
                Url = "https://example.com",
            },
        ];

        Assert.Equal(expectedWebhooks.Count, model.Webhooks.Count);
        for (int i = 0; i < expectedWebhooks.Count; i++)
        {
            Assert.Equal(expectedWebhooks[i], model.Webhooks[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [WebhookEventType.TweetNew],
                    IsActive = true,
                    Url = "https://example.com",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [WebhookEventType.TweetNew],
                    IsActive = true,
                    Url = "https://example.com",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Webhook> expectedWebhooks =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [WebhookEventType.TweetNew],
                IsActive = true,
                Url = "https://example.com",
            },
        ];

        Assert.Equal(expectedWebhooks.Count, deserialized.Webhooks.Count);
        for (int i = 0; i < expectedWebhooks.Count; i++)
        {
            Assert.Equal(expectedWebhooks[i], deserialized.Webhooks[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [WebhookEventType.TweetNew],
                    IsActive = true,
                    Url = "https://example.com",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListResponse
        {
            Webhooks =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventTypes = [WebhookEventType.TweetNew],
                    IsActive = true,
                    Url = "https://example.com",
                },
            ],
        };

        WebhookListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhook
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookEventType>> expectedEventTypes = [WebhookEventType.TweetNew];
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
        var model = new Webhook
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhook
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookEventType>> expectedEventTypes = [WebhookEventType.TweetNew];
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
        var model = new Webhook
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhook
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [WebhookEventType.TweetNew],
            IsActive = true,
            Url = "https://example.com",
        };

        Webhook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookEventType.TweetNew)]
    [InlineData(WebhookEventType.TweetReply)]
    [InlineData(WebhookEventType.TweetRetweet)]
    [InlineData(WebhookEventType.TweetQuote)]
    [InlineData(WebhookEventType.FollowerGained)]
    [InlineData(WebhookEventType.FollowerLost)]
    public void Validation_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookEventType.TweetNew)]
    [InlineData(WebhookEventType.TweetReply)]
    [InlineData(WebhookEventType.TweetRetweet)]
    [InlineData(WebhookEventType.TweetQuote)]
    [InlineData(WebhookEventType.FollowerGained)]
    [InlineData(WebhookEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(WebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
