using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class XAccountDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            ProxyCountry = "US",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, XAccountDetailHealth> expectedHealth = XAccountDetailHealth.Healthy;
        string expectedStatus = "active";
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";
        DateTimeOffset expectedCookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");
        string expectedProxyCountry = "US";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedHealth, model.Health);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedXUserID, model.XUserID);
        Assert.Equal(expectedXUsername, model.XUsername);
        Assert.Equal(expectedCookiesObtainedAt, model.CookiesObtainedAt);
        Assert.Equal(expectedProxyCountry, model.ProxyCountry);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            ProxyCountry = "US",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccountDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            ProxyCountry = "US",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccountDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, XAccountDetailHealth> expectedHealth = XAccountDetailHealth.Healthy;
        string expectedStatus = "active";
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";
        DateTimeOffset expectedCookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");
        string expectedProxyCountry = "US";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedHealth, deserialized.Health);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedXUserID, deserialized.XUserID);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
        Assert.Equal(expectedCookiesObtainedAt, deserialized.CookiesObtainedAt);
        Assert.Equal(expectedProxyCountry, deserialized.ProxyCountry);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            ProxyCountry = "US",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        Assert.Null(model.CookiesObtainedAt);
        Assert.False(model.RawData.ContainsKey("cookiesObtainedAt"));
        Assert.Null(model.ProxyCountry);
        Assert.False(model.RawData.ContainsKey("proxyCountry"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",

            // Null should be interpreted as omitted for these properties
            CookiesObtainedAt = null,
            ProxyCountry = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CookiesObtainedAt);
        Assert.False(model.RawData.ContainsKey("cookiesObtainedAt"));
        Assert.Null(model.ProxyCountry);
        Assert.False(model.RawData.ContainsKey("proxyCountry"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",

            // Null should be interpreted as omitted for these properties
            CookiesObtainedAt = null,
            ProxyCountry = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new XAccountDetail
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = XAccountDetailHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            ProxyCountry = "US",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        XAccountDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class XAccountDetailHealthTest : TestBase
{
    [Theory]
    [InlineData(XAccountDetailHealth.Healthy)]
    [InlineData(XAccountDetailHealth.Locked)]
    [InlineData(XAccountDetailHealth.NeedsReauth)]
    [InlineData(XAccountDetailHealth.Recovering)]
    [InlineData(XAccountDetailHealth.Suspended)]
    [InlineData(XAccountDetailHealth.TemporaryIssue)]
    public void Validation_Works(XAccountDetailHealth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XAccountDetailHealth> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XAccountDetailHealth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(XAccountDetailHealth.Healthy)]
    [InlineData(XAccountDetailHealth.Locked)]
    [InlineData(XAccountDetailHealth.NeedsReauth)]
    [InlineData(XAccountDetailHealth.Recovering)]
    [InlineData(XAccountDetailHealth.Suspended)]
    [InlineData(XAccountDetailHealth.TemporaryIssue)]
    public void SerializationRoundtrip_Works(XAccountDetailHealth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, XAccountDetailHealth> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XAccountDetailHealth>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, XAccountDetailHealth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, XAccountDetailHealth>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
