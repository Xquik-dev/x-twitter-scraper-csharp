// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X;

namespace XTwitterScraper.Tests.Models.X;

public class XGetTrendsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new XGetTrendsResponse
        {
            Count = 30,
            Trends =
            [
                new()
                {
                    Name = "#AI",
                    Description = "Artificial intelligence discussions",
                    PromotedContent = null,
                    Query = "%23AI",
                    Rank = 1,
                    TweetVolume = 250000,
                    Url = "https://x.com/search?q=%23AI",
                },
            ],
            Woeid = 1,
        };

        long expectedCount = 30;
        List<Trend> expectedTrends =
        [
            new()
            {
                Name = "#AI",
                Description = "Artificial intelligence discussions",
                PromotedContent = null,
                Query = "%23AI",
                Rank = 1,
                TweetVolume = 250000,
                Url = "https://x.com/search?q=%23AI",
            },
        ];
        long expectedWoeid = 1;

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedTrends.Count, model.Trends.Count);
        for (int i = 0; i < expectedTrends.Count; i++)
        {
            Assert.Equal(expectedTrends[i], model.Trends[i]);
        }
        Assert.Equal(expectedWoeid, model.Woeid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new XGetTrendsResponse
        {
            Count = 30,
            Trends =
            [
                new()
                {
                    Name = "#AI",
                    Description = "Artificial intelligence discussions",
                    PromotedContent = null,
                    Query = "%23AI",
                    Rank = 1,
                    TweetVolume = 250000,
                    Url = "https://x.com/search?q=%23AI",
                },
            ],
            Woeid = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XGetTrendsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new XGetTrendsResponse
        {
            Count = 30,
            Trends =
            [
                new()
                {
                    Name = "#AI",
                    Description = "Artificial intelligence discussions",
                    PromotedContent = null,
                    Query = "%23AI",
                    Rank = 1,
                    TweetVolume = 250000,
                    Url = "https://x.com/search?q=%23AI",
                },
            ],
            Woeid = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XGetTrendsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 30;
        List<Trend> expectedTrends =
        [
            new()
            {
                Name = "#AI",
                Description = "Artificial intelligence discussions",
                PromotedContent = null,
                Query = "%23AI",
                Rank = 1,
                TweetVolume = 250000,
                Url = "https://x.com/search?q=%23AI",
            },
        ];
        long expectedWoeid = 1;

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedTrends.Count, deserialized.Trends.Count);
        for (int i = 0; i < expectedTrends.Count; i++)
        {
            Assert.Equal(expectedTrends[i], deserialized.Trends[i]);
        }
        Assert.Equal(expectedWoeid, deserialized.Woeid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new XGetTrendsResponse
        {
            Count = 30,
            Trends =
            [
                new()
                {
                    Name = "#AI",
                    Description = "Artificial intelligence discussions",
                    PromotedContent = null,
                    Query = "%23AI",
                    Rank = 1,
                    TweetVolume = 250000,
                    Url = "https://x.com/search?q=%23AI",
                },
            ],
            Woeid = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new XGetTrendsResponse
        {
            Count = 30,
            Trends =
            [
                new()
                {
                    Name = "#AI",
                    Description = "Artificial intelligence discussions",
                    PromotedContent = null,
                    Query = "%23AI",
                    Rank = 1,
                    TweetVolume = 250000,
                    Url = "https://x.com/search?q=%23AI",
                },
            ],
            Woeid = 1,
        };

        XGetTrendsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrendTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            PromotedContent = "promotedContent",
            Query = "%23AI",
            Rank = 1,
            TweetVolume = 250000,
            Url = "https://example.com",
        };

        string expectedName = "#AI";
        string expectedDescription = "Artificial intelligence discussions";
        string expectedPromotedContent = "promotedContent";
        string expectedQuery = "%23AI";
        long expectedRank = 1;
        long expectedTweetVolume = 250000;
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedPromotedContent, model.PromotedContent);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedRank, model.Rank);
        Assert.Equal(expectedTweetVolume, model.TweetVolume);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            PromotedContent = "promotedContent",
            Query = "%23AI",
            Rank = 1,
            TweetVolume = 250000,
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trend>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            PromotedContent = "promotedContent",
            Query = "%23AI",
            Rank = 1,
            TweetVolume = 250000,
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trend>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "#AI";
        string expectedDescription = "Artificial intelligence discussions";
        string expectedPromotedContent = "promotedContent";
        string expectedQuery = "%23AI";
        long expectedRank = 1;
        long expectedTweetVolume = 250000;
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedPromotedContent, deserialized.PromotedContent);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedRank, deserialized.Rank);
        Assert.Equal(expectedTweetVolume, deserialized.TweetVolume);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            PromotedContent = "promotedContent",
            Query = "%23AI",
            Rank = 1,
            TweetVolume = 250000,
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            PromotedContent = "promotedContent",
            TweetVolume = 250000,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Rank);
        Assert.False(model.RawData.ContainsKey("rank"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            PromotedContent = "promotedContent",
            TweetVolume = 250000,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            PromotedContent = "promotedContent",
            TweetVolume = 250000,

            // Null should be interpreted as omitted for these properties
            Description = null,
            Query = null,
            Rank = null,
            Url = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Rank);
        Assert.False(model.RawData.ContainsKey("rank"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            PromotedContent = "promotedContent",
            TweetVolume = 250000,

            // Null should be interpreted as omitted for these properties
            Description = null,
            Query = null,
            Rank = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            Query = "%23AI",
            Rank = 1,
            Url = "https://example.com",
        };

        Assert.Null(model.PromotedContent);
        Assert.False(model.RawData.ContainsKey("promotedContent"));
        Assert.Null(model.TweetVolume);
        Assert.False(model.RawData.ContainsKey("tweetVolume"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            Query = "%23AI",
            Rank = 1,
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            Query = "%23AI",
            Rank = 1,
            Url = "https://example.com",

            PromotedContent = null,
            TweetVolume = null,
        };

        Assert.Null(model.PromotedContent);
        Assert.True(model.RawData.ContainsKey("promotedContent"));
        Assert.Null(model.TweetVolume);
        Assert.True(model.RawData.ContainsKey("tweetVolume"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            Query = "%23AI",
            Rank = 1,
            Url = "https://example.com",

            PromotedContent = null,
            TweetVolume = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            PromotedContent = "promotedContent",
            Query = "%23AI",
            Rank = 1,
            TweetVolume = 250000,
            Url = "https://example.com",
        };

        Trend copied = new(model);

        Assert.Equal(model, copied);
    }
}
