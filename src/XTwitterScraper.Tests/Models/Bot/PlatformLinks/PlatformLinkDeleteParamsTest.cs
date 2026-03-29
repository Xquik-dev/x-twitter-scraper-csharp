using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Tests.Models.Bot.PlatformLinks;

public class PlatformLinkDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlatformLinkDeleteParams
        {
            Platform = PlatformLinkDeleteParamsPlatform.Telegram,
            PlatformUserID = "platformUserId",
        };

        ApiEnum<string, PlatformLinkDeleteParamsPlatform> expectedPlatform =
            PlatformLinkDeleteParamsPlatform.Telegram;
        string expectedPlatformUserID = "platformUserId";

        Assert.Equal(expectedPlatform, parameters.Platform);
        Assert.Equal(expectedPlatformUserID, parameters.PlatformUserID);
    }

    [Fact]
    public void Url_Works()
    {
        PlatformLinkDeleteParams parameters = new()
        {
            Platform = PlatformLinkDeleteParamsPlatform.Telegram,
            PlatformUserID = "platformUserId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/bot/platform-links"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlatformLinkDeleteParams
        {
            Platform = PlatformLinkDeleteParamsPlatform.Telegram,
            PlatformUserID = "platformUserId",
        };

        PlatformLinkDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PlatformLinkDeleteParamsPlatformTest : TestBase
{
    [Theory]
    [InlineData(PlatformLinkDeleteParamsPlatform.Telegram)]
    public void Validation_Works(PlatformLinkDeleteParamsPlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlatformLinkDeleteParamsPlatform> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlatformLinkDeleteParamsPlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlatformLinkDeleteParamsPlatform.Telegram)]
    public void SerializationRoundtrip_Works(PlatformLinkDeleteParamsPlatform rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlatformLinkDeleteParamsPlatform> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlatformLinkDeleteParamsPlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlatformLinkDeleteParamsPlatform>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlatformLinkDeleteParamsPlatform>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
