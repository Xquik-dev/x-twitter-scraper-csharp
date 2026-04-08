using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        List<ExtractionJob> expectedExtractions =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = ExtractionJobStatus.Running,
                ToolType = ExtractionJobToolType.FollowerExplorer,
                TotalResults = 0,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedExtractions.Count, model.Extractions.Count);
        for (int i = 0; i < expectedExtractions.Count; i++)
        {
            Assert.Equal(expectedExtractions[i], model.Extractions[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ExtractionJob> expectedExtractions =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = ExtractionJobStatus.Running,
                ToolType = ExtractionJobToolType.FollowerExplorer,
                TotalResults = 0,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedExtractions.Count, deserialized.Extractions.Count);
        for (int i = 0; i < expectedExtractions.Count; i++)
        {
            Assert.Equal(expectedExtractions[i], deserialized.Extractions[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionJobStatus.Running,
                    ToolType = ExtractionJobToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        ExtractionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
