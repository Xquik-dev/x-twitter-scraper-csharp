using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountReauthResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = AccountReauthResponseHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, AccountReauthResponseHealth> expectedHealth =
            AccountReauthResponseHealth.Healthy;
        string expectedStatus = "active";
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedHealth, model.Health);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedXUserID, model.XUserID);
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = AccountReauthResponseHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountReauthResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = AccountReauthResponseHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountReauthResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, AccountReauthResponseHealth> expectedHealth =
            AccountReauthResponseHealth.Healthy;
        string expectedStatus = "active";
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedHealth, deserialized.Health);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedXUserID, deserialized.XUserID);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = AccountReauthResponseHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = AccountReauthResponseHealth.Healthy,
            Status = "active",
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        AccountReauthResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountReauthResponseHealthTest : TestBase
{
    [Theory]
    [InlineData(AccountReauthResponseHealth.Healthy)]
    [InlineData(AccountReauthResponseHealth.Locked)]
    [InlineData(AccountReauthResponseHealth.NeedsReauth)]
    [InlineData(AccountReauthResponseHealth.Recovering)]
    [InlineData(AccountReauthResponseHealth.Suspended)]
    [InlineData(AccountReauthResponseHealth.TemporaryIssue)]
    public void Validation_Works(AccountReauthResponseHealth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountReauthResponseHealth> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountReauthResponseHealth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountReauthResponseHealth.Healthy)]
    [InlineData(AccountReauthResponseHealth.Locked)]
    [InlineData(AccountReauthResponseHealth.NeedsReauth)]
    [InlineData(AccountReauthResponseHealth.Recovering)]
    [InlineData(AccountReauthResponseHealth.Suspended)]
    [InlineData(AccountReauthResponseHealth.TemporaryIssue)]
    public void SerializationRoundtrip_Works(AccountReauthResponseHealth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountReauthResponseHealth> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountReauthResponseHealth>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountReauthResponseHealth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountReauthResponseHealth>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
