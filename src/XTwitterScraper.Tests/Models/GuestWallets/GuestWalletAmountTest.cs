using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.GuestWallets;

namespace XTwitterScraper.Tests.Models.GuestWallets;

public class GuestWalletAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GuestWalletAmount { AmountMinor = 1000 };

        long expectedAmountMinor = 1000;
        JsonElement expectedCurrency = JsonSerializer.SerializeToElement("usd");

        Assert.Equal(expectedAmountMinor, model.AmountMinor);
        Assert.True(JsonElement.DeepEquals(expectedCurrency, model.Currency));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GuestWalletAmount { AmountMinor = 1000 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GuestWalletAmount { AmountMinor = 1000 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmountMinor = 1000;
        JsonElement expectedCurrency = JsonSerializer.SerializeToElement("usd");

        Assert.Equal(expectedAmountMinor, deserialized.AmountMinor);
        Assert.True(JsonElement.DeepEquals(expectedCurrency, deserialized.Currency));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GuestWalletAmount { AmountMinor = 1000 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GuestWalletAmount { AmountMinor = 1000 };

        GuestWalletAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}
