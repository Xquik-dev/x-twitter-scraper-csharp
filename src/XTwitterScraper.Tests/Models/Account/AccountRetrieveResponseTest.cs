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
            CreditInfo = new()
            {
                AutoTopupEnabled = false,
                Balance = 50000,
                LifetimePurchased = 140000,
                LifetimeUsed = 90000,
            },
        };

        long expectedMonitorsAllowed = 10;
        long expectedMonitorsUsed = 3;
        ApiEnum<string, Plan> expectedPlan = Plan.Active;
        CreditInfo expectedCreditInfo = new()
        {
            AutoTopupEnabled = false,
            Balance = 50000,
            LifetimePurchased = 140000,
            LifetimeUsed = 90000,
        };

        Assert.Equal(expectedMonitorsAllowed, model.MonitorsAllowed);
        Assert.Equal(expectedMonitorsUsed, model.MonitorsUsed);
        Assert.Equal(expectedPlan, model.Plan);
        Assert.Equal(expectedCreditInfo, model.CreditInfo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CreditInfo = new()
            {
                AutoTopupEnabled = false,
                Balance = 50000,
                LifetimePurchased = 140000,
                LifetimeUsed = 90000,
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
            CreditInfo = new()
            {
                AutoTopupEnabled = false,
                Balance = 50000,
                LifetimePurchased = 140000,
                LifetimeUsed = 90000,
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
        CreditInfo expectedCreditInfo = new()
        {
            AutoTopupEnabled = false,
            Balance = 50000,
            LifetimePurchased = 140000,
            LifetimeUsed = 90000,
        };

        Assert.Equal(expectedMonitorsAllowed, deserialized.MonitorsAllowed);
        Assert.Equal(expectedMonitorsUsed, deserialized.MonitorsUsed);
        Assert.Equal(expectedPlan, deserialized.Plan);
        Assert.Equal(expectedCreditInfo, deserialized.CreditInfo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            MonitorsAllowed = 10,
            MonitorsUsed = 3,
            Plan = Plan.Active,
            CreditInfo = new()
            {
                AutoTopupEnabled = false,
                Balance = 50000,
                LifetimePurchased = 140000,
                LifetimeUsed = 90000,
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

        Assert.Null(model.CreditInfo);
        Assert.False(model.RawData.ContainsKey("creditInfo"));
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
            CreditInfo = null,
        };

        Assert.Null(model.CreditInfo);
        Assert.False(model.RawData.ContainsKey("creditInfo"));
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
            CreditInfo = null,
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
            CreditInfo = new()
            {
                AutoTopupEnabled = false,
                Balance = 50000,
                LifetimePurchased = 140000,
                LifetimeUsed = 90000,
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

public class CreditInfoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupEnabled = false,
            Balance = 50000,
            LifetimePurchased = 140000,
            LifetimeUsed = 90000,
        };

        bool expectedAutoTopupEnabled = false;
        long expectedBalance = 50000;
        long expectedLifetimePurchased = 140000;
        long expectedLifetimeUsed = 90000;

        Assert.Equal(expectedAutoTopupEnabled, model.AutoTopupEnabled);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedLifetimePurchased, model.LifetimePurchased);
        Assert.Equal(expectedLifetimeUsed, model.LifetimeUsed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupEnabled = false,
            Balance = 50000,
            LifetimePurchased = 140000,
            LifetimeUsed = 90000,
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
            AutoTopupEnabled = false,
            Balance = 50000,
            LifetimePurchased = 140000,
            LifetimeUsed = 90000,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditInfo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAutoTopupEnabled = false;
        long expectedBalance = 50000;
        long expectedLifetimePurchased = 140000;
        long expectedLifetimeUsed = 90000;

        Assert.Equal(expectedAutoTopupEnabled, deserialized.AutoTopupEnabled);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedLifetimePurchased, deserialized.LifetimePurchased);
        Assert.Equal(expectedLifetimeUsed, deserialized.LifetimeUsed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupEnabled = false,
            Balance = 50000,
            LifetimePurchased = 140000,
            LifetimeUsed = 90000,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditInfo
        {
            AutoTopupEnabled = false,
            Balance = 50000,
            LifetimePurchased = 140000,
            LifetimeUsed = 90000,
        };

        CreditInfo copied = new(model);

        Assert.Equal(model, copied);
    }
}
