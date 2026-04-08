using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleListResponse
        {
            Styles =
            [
                new()
                {
                    FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    IsOwnAccount = true,
                    TweetCount = 50,
                    XUsername = "elonmusk",
                },
            ],
        };

        List<Style> expectedStyles =
        [
            new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                XUsername = "elonmusk",
            },
        ];

        Assert.Equal(expectedStyles.Count, model.Styles.Count);
        for (int i = 0; i < expectedStyles.Count; i++)
        {
            Assert.Equal(expectedStyles[i], model.Styles[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StyleListResponse
        {
            Styles =
            [
                new()
                {
                    FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    IsOwnAccount = true,
                    TweetCount = 50,
                    XUsername = "elonmusk",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleListResponse
        {
            Styles =
            [
                new()
                {
                    FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    IsOwnAccount = true,
                    TweetCount = 50,
                    XUsername = "elonmusk",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Style> expectedStyles =
        [
            new()
            {
                FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                IsOwnAccount = true,
                TweetCount = 50,
                XUsername = "elonmusk",
            },
        ];

        Assert.Equal(expectedStyles.Count, deserialized.Styles.Count);
        for (int i = 0; i < expectedStyles.Count; i++)
        {
            Assert.Equal(expectedStyles[i], deserialized.Styles[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StyleListResponse
        {
            Styles =
            [
                new()
                {
                    FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    IsOwnAccount = true,
                    TweetCount = 50,
                    XUsername = "elonmusk",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StyleListResponse
        {
            Styles =
            [
                new()
                {
                    FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    IsOwnAccount = true,
                    TweetCount = 50,
                    XUsername = "elonmusk",
                },
            ],
        };

        StyleListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StyleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Style
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        DateTimeOffset expectedFetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        bool expectedIsOwnAccount = true;
        long expectedTweetCount = 50;
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedFetchedAt, model.FetchedAt);
        Assert.Equal(expectedIsOwnAccount, model.IsOwnAccount);
        Assert.Equal(expectedTweetCount, model.TweetCount);
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Style
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Style>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Style
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Style>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedFetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        bool expectedIsOwnAccount = true;
        long expectedTweetCount = 50;
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedFetchedAt, deserialized.FetchedAt);
        Assert.Equal(expectedIsOwnAccount, deserialized.IsOwnAccount);
        Assert.Equal(expectedTweetCount, deserialized.TweetCount);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Style
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Style
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        Style copied = new(model);

        Assert.Equal(model, copied);
    }
}
