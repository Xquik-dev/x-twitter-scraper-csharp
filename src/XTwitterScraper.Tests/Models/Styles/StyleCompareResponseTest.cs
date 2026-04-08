using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleCompareResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
        };

        StyleProfile expectedStyle1 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    AuthorUsername = "elonmusk",
                    CreatedAt = "2025-01-15T12:00:00Z",
                },
            ],
            XUsername = "elonmusk",
        };
        StyleProfile expectedStyle2 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    AuthorUsername = "elonmusk",
                    CreatedAt = "2025-01-15T12:00:00Z",
                },
            ],
            XUsername = "elonmusk",
        };

        Assert.Equal(expectedStyle1, model.Style1);
        Assert.Equal(expectedStyle2, model.Style2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleCompareResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleCompareResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        StyleProfile expectedStyle1 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    AuthorUsername = "elonmusk",
                    CreatedAt = "2025-01-15T12:00:00Z",
                },
            ],
            XUsername = "elonmusk",
        };
        StyleProfile expectedStyle2 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            Tweets =
            [
                new()
                {
                    ID = "1234567890",
                    Text = "Just launched our new feature!",
                    AuthorUsername = "elonmusk",
                    CreatedAt = "2025-01-15T12:00:00Z",
                },
            ],
            XUsername = "elonmusk",
        };

        Assert.Equal(expectedStyle1, deserialized.Style1);
        Assert.Equal(expectedStyle2, deserialized.Style2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                Tweets =
                [
                    new()
                    {
                        ID = "1234567890",
                        Text = "Just launched our new feature!",
                        AuthorUsername = "elonmusk",
                        CreatedAt = "2025-01-15T12:00:00Z",
                    },
                ],
                XUsername = "elonmusk",
            },
        };

        StyleCompareResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
