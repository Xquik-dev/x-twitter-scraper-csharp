using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Tests.Models.Bot.PlatformLinks;

public class PlatformLinkCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlatformLinkCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPlatform = "platform";
        string expectedPlatformUserID = "platformUserId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPlatform, model.Platform);
        Assert.Equal(expectedPlatformUserID, model.PlatformUserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlatformLinkCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlatformLinkCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlatformLinkCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlatformLinkCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPlatform = "platform";
        string expectedPlatformUserID = "platformUserId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPlatform, deserialized.Platform);
        Assert.Equal(expectedPlatformUserID, deserialized.PlatformUserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlatformLinkCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlatformLinkCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Platform = "platform",
            PlatformUserID = "platformUserId",
        };

        PlatformLinkCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
