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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        WebhookListResponseWebhookEventType.TweetNew,
                        WebhookListResponseWebhookEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        List<WebhookListResponseWebhook> expectedWebhooks =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes =
                [
                    WebhookListResponseWebhookEventType.TweetNew,
                    WebhookListResponseWebhookEventType.FollowerGained,
                ],
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        WebhookListResponseWebhookEventType.TweetNew,
                        WebhookListResponseWebhookEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        WebhookListResponseWebhookEventType.TweetNew,
                        WebhookListResponseWebhookEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WebhookListResponseWebhook> expectedWebhooks =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                EventTypes =
                [
                    WebhookListResponseWebhookEventType.TweetNew,
                    WebhookListResponseWebhookEventType.FollowerGained,
                ],
                IsActive = true,
                Url = "https://example.com/webhooks/xquik",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        WebhookListResponseWebhookEventType.TweetNew,
                        WebhookListResponseWebhookEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
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
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    EventTypes =
                    [
                        WebhookListResponseWebhookEventType.TweetNew,
                        WebhookListResponseWebhookEventType.FollowerGained,
                    ],
                    IsActive = true,
                    Url = "https://example.com/webhooks/xquik",
                },
            ],
        };

        WebhookListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListResponseWebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookListResponseWebhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                WebhookListResponseWebhookEventType.TweetNew,
                WebhookListResponseWebhookEventType.FollowerGained,
            ],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, WebhookListResponseWebhookEventType>> expectedEventTypes =
        [
            WebhookListResponseWebhookEventType.TweetNew,
            WebhookListResponseWebhookEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com/webhooks/xquik";

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
        var model = new WebhookListResponseWebhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                WebhookListResponseWebhookEventType.TweetNew,
                WebhookListResponseWebhookEventType.FollowerGained,
            ],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListResponseWebhook>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookListResponseWebhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                WebhookListResponseWebhookEventType.TweetNew,
                WebhookListResponseWebhookEventType.FollowerGained,
            ],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookListResponseWebhook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        List<ApiEnum<string, WebhookListResponseWebhookEventType>> expectedEventTypes =
        [
            WebhookListResponseWebhookEventType.TweetNew,
            WebhookListResponseWebhookEventType.FollowerGained,
        ];
        bool expectedIsActive = true;
        string expectedUrl = "https://example.com/webhooks/xquik";

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
        var model = new WebhookListResponseWebhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                WebhookListResponseWebhookEventType.TweetNew,
                WebhookListResponseWebhookEventType.FollowerGained,
            ],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookListResponseWebhook
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            EventTypes =
            [
                WebhookListResponseWebhookEventType.TweetNew,
                WebhookListResponseWebhookEventType.FollowerGained,
            ],
            IsActive = true,
            Url = "https://example.com/webhooks/xquik",
        };

        WebhookListResponseWebhook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookListResponseWebhookEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookListResponseWebhookEventType.TweetNew)]
    [InlineData(WebhookListResponseWebhookEventType.TweetReply)]
    [InlineData(WebhookListResponseWebhookEventType.TweetRetweet)]
    [InlineData(WebhookListResponseWebhookEventType.TweetQuote)]
    [InlineData(WebhookListResponseWebhookEventType.FollowerGained)]
    [InlineData(WebhookListResponseWebhookEventType.FollowerLost)]
    public void Validation_Works(WebhookListResponseWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookListResponseWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookListResponseWebhookEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookListResponseWebhookEventType.TweetNew)]
    [InlineData(WebhookListResponseWebhookEventType.TweetReply)]
    [InlineData(WebhookListResponseWebhookEventType.TweetRetweet)]
    [InlineData(WebhookListResponseWebhookEventType.TweetQuote)]
    [InlineData(WebhookListResponseWebhookEventType.FollowerGained)]
    [InlineData(WebhookListResponseWebhookEventType.FollowerLost)]
    public void SerializationRoundtrip_Works(WebhookListResponseWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookListResponseWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookListResponseWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookListResponseWebhookEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookListResponseWebhookEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
