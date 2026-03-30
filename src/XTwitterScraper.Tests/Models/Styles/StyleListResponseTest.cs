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
                    FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsOwnAccount = true,
                    TweetCount = 0,
                    XUsername = "xUsername",
                },
            ],
        };

        List<StyleProfileSummary> expectedStyles =
        [
            new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                XUsername = "xUsername",
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
                    FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsOwnAccount = true,
                    TweetCount = 0,
                    XUsername = "xUsername",
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
                    FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsOwnAccount = true,
                    TweetCount = 0,
                    XUsername = "xUsername",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<StyleProfileSummary> expectedStyles =
        [
            new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                XUsername = "xUsername",
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
                    FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsOwnAccount = true,
                    TweetCount = 0,
                    XUsername = "xUsername",
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
                    FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsOwnAccount = true,
                    TweetCount = 0,
                    XUsername = "xUsername",
                },
            ],
        };

        StyleListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
