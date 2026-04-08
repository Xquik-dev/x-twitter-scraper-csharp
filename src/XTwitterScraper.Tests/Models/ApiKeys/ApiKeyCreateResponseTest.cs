using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.ApiKeys;

namespace XTwitterScraper.Tests.Models.ApiKeys;

public class ApiKeyCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            FullKey = "xq_live_abc123def456",
            Name = "My API Key",
            Prefix = "xq_live_abc1",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedFullKey = "xq_live_abc123def456";
        string expectedName = "My API Key";
        string expectedPrefix = "xq_live_abc1";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFullKey, model.FullKey);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            FullKey = "xq_live_abc123def456",
            Name = "My API Key",
            Prefix = "xq_live_abc1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            FullKey = "xq_live_abc123def456",
            Name = "My API Key",
            Prefix = "xq_live_abc1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedFullKey = "xq_live_abc123def456";
        string expectedName = "My API Key";
        string expectedPrefix = "xq_live_abc1";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFullKey, deserialized.FullKey);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            FullKey = "xq_live_abc123def456",
            Name = "My API Key",
            Prefix = "xq_live_abc1",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            FullKey = "xq_live_abc123def456",
            Name = "My API Key",
            Prefix = "xq_live_abc1",
        };

        ApiKeyCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
