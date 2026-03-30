using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.ApiKeys;

namespace XTwitterScraper.Tests.Models.ApiKeys;

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsActive = true;
        string expectedName = "name";
        string expectedPrefix = "prefix";
        DateTimeOffset expectedLastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.Equal(expectedLastUsedAt, model.LastUsedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsActive = true;
        string expectedName = "name";
        string expectedPrefix = "prefix";
        DateTimeOffset expectedLastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.Equal(expectedLastUsedAt, deserialized.LastUsedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",
        };

        Assert.Null(model.LastUsedAt);
        Assert.False(model.RawData.ContainsKey("lastUsedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",

            // Null should be interpreted as omitted for these properties
            LastUsedAt = null,
        };

        Assert.Null(model.LastUsedAt);
        Assert.False(model.RawData.ContainsKey("lastUsedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",

            // Null should be interpreted as omitted for these properties
            LastUsedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Name = "name",
            Prefix = "prefix",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}
