using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleProfileSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleProfileSummary
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
        var model = new StyleProfileSummary
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleProfileSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleProfileSummary
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleProfileSummary>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new StyleProfileSummary
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
        var model = new StyleProfileSummary
        {
            FetchedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            IsOwnAccount = true,
            TweetCount = 50,
            XUsername = "elonmusk",
        };

        StyleProfileSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}
