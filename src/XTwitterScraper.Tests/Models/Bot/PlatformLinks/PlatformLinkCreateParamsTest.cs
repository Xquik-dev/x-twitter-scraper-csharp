using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Tests.Models.Bot.PlatformLinks;

public class PlatformLinkCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlatformLinkCreateParams
        {
            Platform = Platform.Telegram,
            PlatformUserID = "platformUserId",
        };

        ApiEnum<string, Platform> expectedPlatform = Platform.Telegram;
        string expectedPlatformUserID = "platformUserId";

        Assert.Equal(expectedPlatform, parameters.Platform);
        Assert.Equal(expectedPlatformUserID, parameters.PlatformUserID);
    }

    [Fact]
    public void Url_Works()
    {
        PlatformLinkCreateParams parameters = new()
        {
            Platform = Platform.Telegram,
            PlatformUserID = "platformUserId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/bot/platform-links"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlatformLinkCreateParams
        {
            Platform = Platform.Telegram,
            PlatformUserID = "platformUserId",
        };

        PlatformLinkCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PlatformTest : TestBase
{
    [Theory]
    [InlineData(Platform.Telegram)]
    public void Validation_Works(Platform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Platform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Platform.Telegram)]
    public void SerializationRoundtrip_Works(Platform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Platform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Platform>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
