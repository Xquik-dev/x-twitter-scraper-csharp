using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.GuestWallets;

/// <summary>
/// Confirmed USD amount for a guest wallet purchase.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GuestWalletAmount, GuestWalletAmountFromRaw>))]
public sealed record class GuestWalletAmount : JsonModel
{
    /// <summary>
    /// USD amount in cents. Accepted range is $10-$250.
    /// </summary>
    public required long AmountMinor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("amount_minor");
        }
        init { this._rawData.Set("amount_minor", value); }
    }

    public JsonElement Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountMinor;
        if (!JsonElement.DeepEquals(this.Currency, JsonSerializer.SerializeToElement("usd")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public GuestWalletAmount()
    {
        this.Currency = JsonSerializer.SerializeToElement("usd");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GuestWalletAmount(GuestWalletAmount guestWalletAmount)
        : base(guestWalletAmount) { }
#pragma warning restore CS8618

    public GuestWalletAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Currency = JsonSerializer.SerializeToElement("usd");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GuestWalletAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GuestWalletAmountFromRaw.FromRawUnchecked"/>
    public static GuestWalletAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GuestWalletAmount(long amountMinor)
        : this()
    {
        this.AmountMinor = amountMinor;
    }
}

class GuestWalletAmountFromRaw : IFromRawJson<GuestWalletAmount>
{
    /// <inheritdoc/>
    public GuestWalletAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GuestWalletAmount.FromRawUnchecked(rawData);
}
