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
                    Query = "%23AI",
                    Rank = 1,
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
                Query = "%23AI",
                Rank = 1,
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
                    Query = "%23AI",
                    Rank = 1,
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
                    Query = "%23AI",
                    Rank = 1,
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
                Query = "%23AI",
                Rank = 1,
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
                    Query = "%23AI",
                    Rank = 1,
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
                    Query = "%23AI",
                    Rank = 1,
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
            Query = "%23AI",
            Rank = 1,
        };

        string expectedName = "#AI";
        string expectedDescription = "Artificial intelligence discussions";
        string expectedQuery = "%23AI";
        long expectedRank = 1;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedRank, model.Rank);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            Query = "%23AI",
            Rank = 1,
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
            Query = "%23AI",
            Rank = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trend>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "#AI";
        string expectedDescription = "Artificial intelligence discussions";
        string expectedQuery = "%23AI";
        long expectedRank = 1;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedRank, deserialized.Rank);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Trend
        {
            Name = "#AI",
            Description = "Artificial intelligence discussions",
            Query = "%23AI",
            Rank = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Trend { Name = "#AI" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Rank);
        Assert.False(model.RawData.ContainsKey("rank"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Trend { Name = "#AI" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Trend
        {
            Name = "#AI",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Query = null,
            Rank = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Query);
        Assert.False(model.RawData.ContainsKey("query"));
        Assert.Null(model.Rank);
        Assert.False(model.RawData.ContainsKey("rank"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Trend
        {
            Name = "#AI",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Query = null,
            Rank = null,
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
            Query = "%23AI",
            Rank = 1,
        };

        Trend copied = new(model);

        Assert.Equal(model, copied);
    }
}
