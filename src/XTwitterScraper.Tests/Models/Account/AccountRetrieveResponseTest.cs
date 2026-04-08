using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Tests.Models.Account;

public class AccountRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CurrentPeriod = new()
            {
                End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
                Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
                UsagePercent = 42.5,
            },
        };

        long expectedMonitorsAllowed = 10;
        long expectedMonitorsUsed = 3;
        ApiEnum<string, Plan> expectedPlan = Plan.Active;
        CurrentPeriod expectedCurrentPeriod = new()
        {
            End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
            Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
            UsagePercent = 42.5,
        };

        Assert.Equal(expectedMonitorsAllowed, model.MonitorsAllowed);
        Assert.Equal(expectedMonitorsUsed, model.MonitorsUsed);
        Assert.Equal(expectedPlan, model.Plan);
        Assert.Equal(expectedCurrentPeriod, model.CurrentPeriod);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CurrentPeriod = new()
            {
                End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
                Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
                UsagePercent = 42.5,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CurrentPeriod = new()
            {
                End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
                Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
                UsagePercent = 42.5,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMonitorsAllowed = 10;
        long expectedMonitorsUsed = 3;
        ApiEnum<string, Plan> expectedPlan = Plan.Active;
        CurrentPeriod expectedCurrentPeriod = new()
        {
            End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
            Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
            UsagePercent = 42.5,
        };

        Assert.Equal(expectedMonitorsAllowed, deserialized.MonitorsAllowed);
        Assert.Equal(expectedMonitorsUsed, deserialized.MonitorsUsed);
        Assert.Equal(expectedPlan, deserialized.Plan);
        Assert.Equal(expectedCurrentPeriod, deserialized.CurrentPeriod);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CurrentPeriod = new()
            {
                End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
                Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
                UsagePercent = 42.5,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
        };

        Assert.Null(model.CurrentPeriod);
        Assert.False(model.RawData.ContainsKey("currentPeriod"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,

            // Null should be interpreted as omitted for these properties
            CurrentPeriod = null,
        };

        Assert.Null(model.CurrentPeriod);
        Assert.False(model.RawData.ContainsKey("currentPeriod"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,

            // Null should be interpreted as omitted for these properties
            CurrentPeriod = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CurrentPeriod = new()
            {
                End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
                Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
                UsagePercent = 42.5,
            },
        };

        AccountRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanTest : TestBase
{
    [Theory]
    [InlineData(Plan.Active)]
    [InlineData(Plan.Inactive)]
    public void Validation_Works(Plan rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plan> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plan>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plan.Active)]
    [InlineData(Plan.Inactive)]
    public void SerializationRoundtrip_Works(Plan rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plan> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plan>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plan>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plan>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CurrentPeriodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrentPeriod
        {
            End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
            Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
            UsagePercent = 42.5,
        };

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2025-02-01T00:00:00Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2025-01-01T00:00:00Z");
        double expectedUsagePercent = 42.5;

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
        Assert.Equal(expectedUsagePercent, model.UsagePercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrentPeriod
        {
            End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
            Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
            UsagePercent = 42.5,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrentPeriod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrentPeriod
        {
            End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
            Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
            UsagePercent = 42.5,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrentPeriod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2025-02-01T00:00:00Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2025-01-01T00:00:00Z");
        double expectedUsagePercent = 42.5;

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
        Assert.Equal(expectedUsagePercent, deserialized.UsagePercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrentPeriod
        {
            End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
            Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
            UsagePercent = 42.5,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CurrentPeriod
        {
            End = DateTimeOffset.Parse("2025-02-01T00:00:00Z"),
            Start = DateTimeOffset.Parse("2025-01-01T00:00:00Z"),
            UsagePercent = 42.5,
        };

        CurrentPeriod copied = new(model);

        Assert.Equal(model, copied);
    }
}
