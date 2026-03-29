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
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullKey = "fullKey",
            Name = "name",
            Prefix = "prefix",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFullKey = "fullKey";
        string expectedName = "name";
        string expectedPrefix = "prefix";

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
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullKey = "fullKey",
            Name = "name",
            Prefix = "prefix",
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
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullKey = "fullKey",
            Name = "name",
            Prefix = "prefix",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFullKey = "fullKey";
        string expectedName = "name";
        string expectedPrefix = "prefix";

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
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullKey = "fullKey",
            Name = "name",
            Prefix = "prefix",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FullKey = "fullKey",
            Name = "name",
            Prefix = "prefix",
        };

        ApiKeyCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
