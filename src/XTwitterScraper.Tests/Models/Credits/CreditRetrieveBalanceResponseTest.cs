using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Tests.Models.Credits;

public class CreditRetrieveBalanceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditRetrieveBalanceResponse
        {
            AutoTopupEnabled = true,
            Balance = 0,
            LifetimePurchased = 0,
            LifetimeUsed = 0,
        };

        bool expectedAutoTopupEnabled = true;
        long expectedBalance = 0;
        long expectedLifetimePurchased = 0;
        long expectedLifetimeUsed = 0;

        Assert.Equal(expectedAutoTopupEnabled, model.AutoTopupEnabled);
        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedLifetimePurchased, model.LifetimePurchased);
        Assert.Equal(expectedLifetimeUsed, model.LifetimeUsed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditRetrieveBalanceResponse
        {
            AutoTopupEnabled = true,
            Balance = 0,
            LifetimePurchased = 0,
            LifetimeUsed = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRetrieveBalanceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditRetrieveBalanceResponse
        {
            AutoTopupEnabled = true,
            Balance = 0,
            LifetimePurchased = 0,
            LifetimeUsed = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRetrieveBalanceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAutoTopupEnabled = true;
        long expectedBalance = 0;
        long expectedLifetimePurchased = 0;
        long expectedLifetimeUsed = 0;

        Assert.Equal(expectedAutoTopupEnabled, deserialized.AutoTopupEnabled);
        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedLifetimePurchased, deserialized.LifetimePurchased);
        Assert.Equal(expectedLifetimeUsed, deserialized.LifetimeUsed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditRetrieveBalanceResponse
        {
            AutoTopupEnabled = true,
            Balance = 0,
            LifetimePurchased = 0,
            LifetimeUsed = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditRetrieveBalanceResponse
        {
            AutoTopupEnabled = true,
            Balance = 0,
            LifetimePurchased = 0,
            LifetimeUsed = 0,
        };

        CreditRetrieveBalanceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
