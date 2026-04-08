using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.ApiKeys;

namespace XTwitterScraper.Tests.Models.ApiKeys;

public class ApiKeyListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyListResponse
        {
            Keys =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsActive = true,
                    Name = "name",
                    Prefix = "prefix",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<ApiKey> expectedKeys =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsActive = true,
                Name = "name",
                Prefix = "prefix",
                LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedKeys.Count, model.Keys.Count);
        for (int i = 0; i < expectedKeys.Count; i++)
        {
            Assert.Equal(expectedKeys[i], model.Keys[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyListResponse
        {
            Keys =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsActive = true,
                    Name = "name",
                    Prefix = "prefix",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyListResponse
        {
            Keys =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsActive = true,
                    Name = "name",
                    Prefix = "prefix",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiKey> expectedKeys =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsActive = true,
                Name = "name",
                Prefix = "prefix",
                LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedKeys.Count, deserialized.Keys.Count);
        for (int i = 0; i < expectedKeys.Count; i++)
        {
            Assert.Equal(expectedKeys[i], deserialized.Keys[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyListResponse
        {
            Keys =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsActive = true,
                    Name = "name",
                    Prefix = "prefix",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyListResponse
        {
            Keys =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    IsActive = true,
                    Name = "name",
                    Prefix = "prefix",
                    LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        ApiKeyListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
