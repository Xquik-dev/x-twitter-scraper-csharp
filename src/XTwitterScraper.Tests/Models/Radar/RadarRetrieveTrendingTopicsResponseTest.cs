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

        List<Item> expectedItems =
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

        List<Item> expectedItems =
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

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
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
        };

        string expectedCategory = "category";
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRegion = "region";
        double expectedScore = 0;
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedDescription = "description";
        string expectedImageUrl = "imageUrl";
        string expectedUrl = "url";

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedImageUrl, model.ImageUrl);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCategory = "category";
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRegion = "region";
        double expectedScore = 0;
        string expectedSource = "source";
        string expectedTitle = "title";
        string expectedDescription = "description";
        string expectedImageUrl = "imageUrl";
        string expectedUrl = "url";

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedImageUrl, deserialized.ImageUrl);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            Category = "category",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Region = "region",
            Score = 0,
            Source = "source",
            Title = "title",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ImageUrl);
        Assert.False(model.RawData.ContainsKey("imageUrl"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            Category = "category",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Region = "region",
            Score = 0,
            Source = "source",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
        {
            Category = "category",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Region = "region",
            Score = 0,
            Source = "source",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Description = null,
            ImageUrl = null,
            Url = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ImageUrl);
        Assert.False(model.RawData.ContainsKey("imageUrl"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            Category = "category",
            PublishedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Region = "region",
            Score = 0,
            Source = "source",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Description = null,
            ImageUrl = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
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
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}
