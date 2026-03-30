using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Radar;

namespace XTwitterScraper.Tests.Models.Radar;

public class RadarRetrieveTrendingTopicsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Region = "region",
                    Score = 0,
                    Source = "source",
                    Title = "title",
                    Description = "description",
                    ImageUrl = "imageUrl",
                    Url = "url",
                },
            ],
            Total = 0,
        };

        List<RadarItem> expectedItems =
        [
            new()
            {
                Category = "category",
                PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Region = "region",
                Score = 0,
                Source = "source",
                Title = "title",
                Description = "description",
                ImageUrl = "imageUrl",
                Url = "url",
            },
        ];
        long expectedTotal = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Region = "region",
                    Score = 0,
                    Source = "source",
                    Title = "title",
                    Description = "description",
                    ImageUrl = "imageUrl",
                    Url = "url",
                },
            ],
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RadarRetrieveTrendingTopicsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Region = "region",
                    Score = 0,
                    Source = "source",
                    Title = "title",
                    Description = "description",
                    ImageUrl = "imageUrl",
                    Url = "url",
                },
            ],
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RadarRetrieveTrendingTopicsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<RadarItem> expectedItems =
        [
            new()
            {
                Category = "category",
                PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Region = "region",
                Score = 0,
                Source = "source",
                Title = "title",
                Description = "description",
                ImageUrl = "imageUrl",
                Url = "url",
            },
        ];
        long expectedTotal = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Region = "region",
                    Score = 0,
                    Source = "source",
                    Title = "title",
                    Description = "description",
                    ImageUrl = "imageUrl",
                    Url = "url",
                },
            ],
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            Items =
            [
                new()
                {
                    Category = "category",
                    PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Region = "region",
                    Score = 0,
                    Source = "source",
                    Title = "title",
                    Description = "description",
                    ImageUrl = "imageUrl",
                    Url = "url",
                },
            ],
            Total = 0,
        };

        RadarRetrieveTrendingTopicsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
