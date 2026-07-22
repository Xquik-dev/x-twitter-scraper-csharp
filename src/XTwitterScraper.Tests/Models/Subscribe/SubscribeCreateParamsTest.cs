using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Subscribe;

namespace XTwitterScraper.Tests.Models.Subscribe;

public class SubscribeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscribeCreateParams { Tier = Tier.Pro };

        ApiEnum<string, Tier> expectedTier = Tier.Pro;

        Assert.Equal(expectedTier, parameters.Tier);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscribeCreateParams { };

        Assert.Null(parameters.Tier);
        Assert.False(parameters.RawBodyData.ContainsKey("tier"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscribeCreateParams
        {
            // Null should be interpreted as omitted for these properties
            Tier = null,
        };

        Assert.Null(parameters.Tier);
        Assert.False(parameters.RawBodyData.ContainsKey("tier"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscribeCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/subscribe"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscribeCreateParams { Tier = Tier.Pro };

        SubscribeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TierTest : TestBase
{
    [Theory]
    [InlineData(Tier.Starter)]
    [InlineData(Tier.Pro)]
    [InlineData(Tier.Business)]
    public void Validation_Works(Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Tier.Starter)]
    [InlineData(Tier.Pro)]
    [InlineData(Tier.Business)]
    public void SerializationRoundtrip_Works(Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
