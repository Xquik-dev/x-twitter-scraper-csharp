using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using X = XTwitterScraper.Models.X;

namespace XTwitterScraper.Tests.Models.X;

public class XGetNotificationsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new X::XGetNotificationsParams { Cursor = "cursor", Type = X::Type.All };

        string expectedCursor = "cursor";
        ApiEnum<string, X::Type> expectedType = X::Type.All;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new X::XGetNotificationsParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new X::XGetNotificationsParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Type = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        X::XGetNotificationsParams parameters = new() { Cursor = "cursor", Type = X::Type.All };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://xquik.com/api/v1/x/notifications?cursor=cursor&type=All"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new X::XGetNotificationsParams { Cursor = "cursor", Type = X::Type.All };

        X::XGetNotificationsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(X::Type.All)]
    [InlineData(X::Type.Verified)]
    [InlineData(X::Type.Mentions)]
    public void Validation_Works(X::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, X::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, X::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(X::Type.All)]
    [InlineData(X::Type.Verified)]
    [InlineData(X::Type.Mentions)]
    public void SerializationRoundtrip_Works(X::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, X::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, X::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, X::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, X::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
