using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            NextCursor = "nextCursor",
        };

        bool expectedHasMore = true;
        Dictionary<string, JsonElement> expectedJob = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<Dictionary<string, JsonElement>> expectedResults =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedJob.Count, model.Job.Count);
        foreach (var item in expectedJob)
        {
            Assert.True(model.Job.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Job[item.Key]));
        }
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i].Count, model.Results[i].Count);
            foreach (var item in expectedResults[i])
            {
                Assert.True(model.Results[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Results[i][item.Key]));
            }
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        Dictionary<string, JsonElement> expectedJob = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<Dictionary<string, JsonElement>> expectedResults =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedJob.Count, deserialized.Job.Count);
        foreach (var item in expectedJob)
        {
            Assert.True(deserialized.Job.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Job[item.Key]));
        }
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i].Count, deserialized.Results[i].Count);
            foreach (var item in expectedResults[i])
            {
                Assert.True(deserialized.Results[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.Results[i][item.Key]));
            }
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractionRetrieveResponse
        {
            HasMore = true,
            Job = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            NextCursor = "nextCursor",
        };

        ExtractionRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
