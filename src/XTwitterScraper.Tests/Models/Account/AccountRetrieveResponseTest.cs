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
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CreditInfo = new()
            {
                AutoTopupAmountDollars = 10,
                AutoTopupEnabled = false,
                AutoTopupThreshold = "50000",
                Balance = "50000",
                LifetimePurchased = "140000",
                LifetimeUsed = "90000",
            },
            XUsername = "elonmusk",
        };

        MonitorBilling expectedMonitorBilling = new()
        {
            ActiveDailyEstimate = "1500",
            ActiveHourlyBurn = "63",
            CreditsPerActiveMonitorDay = "500",
            CreditsPerActiveMonitorHour = "21",
            EventsIncluded = true,
            InstantCheckIntervalSeconds = 1,
            UnlimitedSlots = true,
        };
        long expectedMonitorsAllowed = 9007199254740991;
        long expectedMonitorsUsed = 3;
        ApiEnum<string, Plan> expectedPlan = Plan.Active;
        CreditInfo expectedCreditInfo = new()
        {
            AutoTopupAmountDollars = 10,
            AutoTopupEnabled = false,
            AutoTopupThreshold = "50000",
            Balance = "50000",
            LifetimePurchased = "140000",
            LifetimeUsed = "90000",
        };
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedMonitorBilling, model.MonitorBilling);
        Assert.Equal(expectedMonitorsAllowed, model.MonitorsAllowed);
        Assert.Equal(expectedMonitorsUsed, model.MonitorsUsed);
        Assert.Equal(expectedPlan, model.Plan);
        Assert.Equal(expectedCreditInfo, model.CreditInfo);
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CreditInfo = new()
            {
                AutoTopupAmountDollars = 10,
                AutoTopupEnabled = false,
                AutoTopupThreshold = "50000",
                Balance = "50000",
                LifetimePurchased = "140000",
                LifetimeUsed = "90000",
            },
            XUsername = "elonmusk",
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
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CreditInfo = new()
            {
                AutoTopupAmountDollars = 10,
                AutoTopupEnabled = false,
                AutoTopupThreshold = "50000",
                Balance = "50000",
                LifetimePurchased = "140000",
                LifetimeUsed = "90000",
            },
            XUsername = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MonitorBilling expectedMonitorBilling = new()
        {
            ActiveDailyEstimate = "1500",
            ActiveHourlyBurn = "63",
            CreditsPerActiveMonitorDay = "500",
            CreditsPerActiveMonitorHour = "21",
            EventsIncluded = true,
            InstantCheckIntervalSeconds = 1,
            UnlimitedSlots = true,
        };
        long expectedMonitorsAllowed = 9007199254740991;
        long expectedMonitorsUsed = 3;
        ApiEnum<string, Plan> expectedPlan = Plan.Active;
        CreditInfo expectedCreditInfo = new()
        {
            AutoTopupAmountDollars = 10,
            AutoTopupEnabled = false,
            AutoTopupThreshold = "50000",
            Balance = "50000",
            LifetimePurchased = "140000",
            LifetimeUsed = "90000",
        };
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedMonitorBilling, deserialized.MonitorBilling);
        Assert.Equal(expectedMonitorsAllowed, deserialized.MonitorsAllowed);
        Assert.Equal(expectedMonitorsUsed, deserialized.MonitorsUsed);
        Assert.Equal(expectedPlan, deserialized.Plan);
        Assert.Equal(expectedCreditInfo, deserialized.CreditInfo);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CreditInfo = new()
            {
                AutoTopupAmountDollars = 10,
                AutoTopupEnabled = false,
                AutoTopupThreshold = "50000",
                Balance = "50000",
                LifetimePurchased = "140000",
                LifetimeUsed = "90000",
            },
            XUsername = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,
        };

        Assert.Null(model.CreditInfo);
        Assert.False(model.RawData.ContainsKey("creditInfo"));
        Assert.Null(model.XUsername);
        Assert.False(model.RawData.ContainsKey("xUsername"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
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
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,

            // Null should be interpreted as omitted for these properties
            CreditInfo = null,
            XUsername = null,
        };

        Assert.Null(model.CreditInfo);
        Assert.False(model.RawData.ContainsKey("creditInfo"));
        Assert.Null(model.XUsername);
        Assert.False(model.RawData.ContainsKey("xUsername"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,

            // Null should be interpreted as omitted for these properties
            CreditInfo = null,
            XUsername = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorBilling = new()
            {
                ActiveDailyEstimate = "1500",
                ActiveHourlyBurn = "63",
                CreditsPerActiveMonitorDay = "500",
                CreditsPerActiveMonitorHour = "21",
                EventsIncluded = true,
                InstantCheckIntervalSeconds = 1,
                UnlimitedSlots = true,
            },
            MonitorsAllowed = 9007199254740991,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CreditInfo = new()
            {
                AutoTopupAmountDollars = 10,
                AutoTopupEnabled = false,
                AutoTopupThreshold = "50000",
                Balance = "50000",
                LifetimePurchased = "140000",
                LifetimeUsed = "90000",
            },
            XUsername = "elonmusk",
        };

        AccountRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonitorBillingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonitorBilling
        {
            ActiveDailyEstimate = "1500",
            ActiveHourlyBurn = "63",
            CreditsPerActiveMonitorDay = "500",
            CreditsPerActiveMonitorHour = "21",
            EventsIncluded = true,
            InstantCheckIntervalSeconds = 1,
            UnlimitedSlots = true,
        };

        string expectedActiveDailyEstimate = "1500";
        string expectedActiveHourlyBurn = "63";
        string expectedCreditsPerActiveMonitorDay = "500";
        string expectedCreditsPerActiveMonitorHour = "21";
        bool expectedEventsIncluded = true;
        long expectedInstantCheckIntervalSeconds = 1;
        bool expectedUnlimitedSlots = true;

        Assert.Equal(expectedActiveDailyEstimate, model.ActiveDailyEstimate);
        Assert.Equal(expectedActiveHourlyBurn, model.ActiveHourlyBurn);
        Assert.Equal(expectedCreditsPerActiveMonitorDay, model.CreditsPerActiveMonitorDay);
        Assert.Equal(expectedCreditsPerActiveMonitorHour, model.CreditsPerActiveMonitorHour);
        Assert.Equal(expectedEventsIncluded, model.EventsIncluded);
        Assert.Equal(expectedInstantCheckIntervalSeconds, model.InstantCheckIntervalSeconds);
        Assert.Equal(expectedUnlimitedSlots, model.UnlimitedSlots);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonitorBilling
        {
            ActiveDailyEstimate = "1500",
            ActiveHourlyBurn = "63",
            CreditsPerActiveMonitorDay = "500",
            CreditsPerActiveMonitorHour = "21",
            EventsIncluded = true,
            InstantCheckIntervalSeconds = 1,
            UnlimitedSlots = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorBilling>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonitorBilling
        {
            ActiveDailyEstimate = "1500",
            ActiveHourlyBurn = "63",
            CreditsPerActiveMonitorDay = "500",
            CreditsPerActiveMonitorHour = "21",
            EventsIncluded = true,
            InstantCheckIntervalSeconds = 1,
            UnlimitedSlots = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonitorBilling>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActiveDailyEstimate = "1500";
        string expectedActiveHourlyBurn = "63";
        string expectedCreditsPerActiveMonitorDay = "500";
        string expectedCreditsPerActiveMonitorHour = "21";
        bool expectedEventsIncluded = true;
        long expectedInstantCheckIntervalSeconds = 1;
        bool expectedUnlimitedSlots = true;

        Assert.Equal(expectedActiveDailyEstimate, deserialized.ActiveDailyEstimate);
        Assert.Equal(expectedActiveHourlyBurn, deserialized.ActiveHourlyBurn);
        Assert.Equal(expectedCreditsPerActiveMonitorDay, deserialized.CreditsPerActiveMonitorDay);
        Assert.Equal(expectedCreditsPerActiveMonitorHour, deserialized.CreditsPerActiveMonitorHour);
        Assert.Equal(expectedEventsIncluded, deserialized.EventsIncluded);
        Assert.Equal(expectedInstantCheckIntervalSeconds, deserialized.InstantCheckIntervalSeconds);
        Assert.Equal(expectedUnlimitedSlots, deserialized.UnlimitedSlots);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonitorBilling
        {
            ActiveDailyEstimate = "1500",
            ActiveHourlyBurn = "63",
            CreditsPerActiveMonitorDay = "500",
            CreditsPerActiveMonitorHour = "21",
            EventsIncluded = true,
            InstantCheckIntervalSeconds = 1,
            UnlimitedSlots = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonitorBilling
        {
            ActiveDailyEstimate = "1500",
            ActiveHourlyBurn = "63",
            CreditsPerActiveMonitorDay = "500",
            CreditsPerActiveMonitorHour = "21",
            EventsIncluded = true,
            InstantCheckIntervalSeconds = 1,
            UnlimitedSlots = true,
        };

        MonitorBilling copied = new(model);

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

public class CreditInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupAmountDollars = 10,
            AutoTopupEnabled = false,
            AutoTopupThreshold = "50000",
            Balance = "50000",
            LifetimePurchased = "140000",
            LifetimeUsed = "90000",
        };

        double expectedAutoTopupAmountDollars = 10;
        bool expectedAutoTopupEnabled = false;
        string expectedAutoTopupThreshold = "50000";
        string expectedBalance = "50000";
        string expectedLifetimePurchased = "140000";
        string expectedLifetimeUsed = "90000";

        Assert.Equal(expectedAutoTopupAmountDollars, model.AutoTopupAmountDollars);
        Assert.Equal(expectedAutoTopupEnabled, model.AutoTopupEnabled);
        Assert.Equal(expectedAutoTopupThreshold, model.AutoTopupThreshold);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedLifetimePurchased, model.LifetimePurchased);
        Assert.Equal(expectedLifetimeUsed, model.LifetimeUsed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupAmountDollars = 10,
            AutoTopupEnabled = false,
            AutoTopupThreshold = "50000",
            Balance = "50000",
            LifetimePurchased = "140000",
            LifetimeUsed = "90000",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditInfo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupAmountDollars = 10,
            AutoTopupEnabled = false,
            AutoTopupThreshold = "50000",
            Balance = "50000",
            LifetimePurchased = "140000",
            LifetimeUsed = "90000",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAutoTopupAmountDollars = 10;
        bool expectedAutoTopupEnabled = false;
        string expectedAutoTopupThreshold = "50000";
        string expectedBalance = "50000";
        string expectedLifetimePurchased = "140000";
        string expectedLifetimeUsed = "90000";

        Assert.Equal(expectedAutoTopupAmountDollars, deserialized.AutoTopupAmountDollars);
        Assert.Equal(expectedAutoTopupEnabled, deserialized.AutoTopupEnabled);
        Assert.Equal(expectedAutoTopupThreshold, deserialized.AutoTopupThreshold);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedLifetimePurchased, deserialized.LifetimePurchased);
        Assert.Equal(expectedLifetimeUsed, deserialized.LifetimeUsed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupAmountDollars = 10,
            AutoTopupEnabled = false,
            AutoTopupThreshold = "50000",
            Balance = "50000",
            LifetimePurchased = "140000",
            LifetimeUsed = "90000",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupAmountDollars = 10,
            AutoTopupEnabled = false,
            AutoTopupThreshold = "50000",
            Balance = "50000",
            LifetimePurchased = "140000",
            LifetimeUsed = "90000",
        };

        CreditInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
