using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Credits;

[JsonConverter(
    typeof(JsonModelConverter<CreditTopupBalanceResponse, CreditTopupBalanceResponseFromRaw>)
)]
public sealed record class CreditTopupBalanceResponse : JsonModel
{
    /// <summary>
    /// Stable first-party Xquik redirect URL for the active Stripe Checkout session.
    /// </summary>
    public required string RedirectUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("redirect_url");
        }
        init { this._rawData.Set("redirect_url", value); }
    }

    /// <summary>
    /// Same stable first-party Xquik redirect URL as redirect_url. The response
    /// never exposes a raw Stripe Checkout URL.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RedirectUrl;
        _ = this.Url;
    }

    public CreditTopupBalanceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditTopupBalanceResponse(CreditTopupBalanceResponse creditTopupBalanceResponse)
        : base(creditTopupBalanceResponse) { }
#pragma warning restore CS8618

    public CreditTopupBalanceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditTopupBalanceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditTopupBalanceResponseFromRaw.FromRawUnchecked"/>
    public static CreditTopupBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditTopupBalanceResponseFromRaw : IFromRawJson<CreditTopupBalanceResponse>
{
    /// <inheritdoc/>
    public CreditTopupBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditTopupBalanceResponse.FromRawUnchecked(rawData);
}
