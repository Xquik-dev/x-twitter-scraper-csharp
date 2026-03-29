using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Trends;

namespace XTwitterScraper.Tests.Models.Trends;

public class TrendListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrendListResponse
        {
            Total = 0,
            Trends =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Query = "query",
                    Rank = 0,
                },
            ],
            Woeid = 0,
        };

        long expectedTotal = 0;
        List<Trend> expectedTrends =
        [
            new()
            {
                Name = "name",
                Description = "description",
                Query = "query",
                Rank = 0,
            },
        ];
        long expectedWoeid = 0;

        Assert.Equal(expectedTotal, model.Total);
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
        var model = new TrendListResponse
        {
            Total = 0,
            Trends =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Query = "query",
                    Rank = 0,
                },
            ],
            Woeid = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrendListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrendListResponse
        {
            Total = 0,
            Trends =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Query = "query",
                    Rank = 0,
                },
            ],
            Woeid = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrendListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTotal = 0;
        List<Trend> expectedTrends =
        [
            new()
            {
                Name = "name",
                Description = "description",
                Query = "query",
                Rank = 0,
            },
        ];
        long expectedWoeid = 0;

        Assert.Equal(expectedTotal, deserialized.Total);
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
        var model = new TrendListResponse
        {
            Total = 0,
            Trends =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Query = "query",
                    Rank = 0,
                },
            ],
            Woeid = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TrendListResponse
        {
            Total = 0,
            Trends =
            [
                new()
                {
                    Name = "name",
                    Description = "description",
                    Query = "query",
                    Rank = 0,
                },
            ],
            Woeid = 0,
        };

        TrendListResponse copied = new(model);

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
            Name = "name",
            Description = "description",
            Query = "query",
            Rank = 0,
        };

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedQuery = "query";
        long expectedRank = 0;

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
            Name = "name",
            Description = "description",
            Query = "query",
            Rank = 0,
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
            Name = "name",
            Description = "description",
            Query = "query",
            Rank = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Trend>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedDescription = "description";
        string expectedQuery = "query";
        long expectedRank = 0;

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
            Name = "name",
            Description = "description",
            Query = "query",
            Rank = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Trend { Name = "name" };

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
        var model = new Trend { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Trend
        {
            Name = "name",

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
            Name = "name",

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
            Name = "name",
            Description = "description",
            Query = "query",
            Rank = 0,
        };

        Trend copied = new(model);

        Assert.Equal(model, copied);
    }
}
