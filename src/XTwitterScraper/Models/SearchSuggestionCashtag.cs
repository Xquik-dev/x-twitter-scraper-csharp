// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<SearchSuggestionCashtag, SearchSuggestionCashtagFromRaw>))]
public sealed record class SearchSuggestionCashtag : JsonModel
{
    /// <summary>
    /// Ticker symbol without the $.
    /// </summary>
    public required string Ticker
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ticker");
        }
        init { this._rawData.Set("ticker", value); }
    }

    /// <summary>
    /// Company or token name.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// X's tag for the asset. $TICKER for a stock, chain:contract for a token.
    /// </summary>
    public string? SmartTag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("smartTag");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("smartTag", value);
        }
    }

    /// <summary>
    /// Currency of price &amp; marketCap.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Latest price as decimal text, which keeps every digit.
    /// </summary>
    public string? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("price");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price", value);
        }
    }

    /// <summary>
    /// Market capitalization as decimal text.
    /// </summary>
    public string? MarketCap
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("marketCap");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("marketCap", value);
        }
    }

    /// <summary>
    /// Price change over the last 24 hours, in percent.
    /// </summary>
    public double? DailyChangePercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("dailyChangePercent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dailyChangePercent", value);
        }
    }

    /// <summary>
    /// Logo image URL.
    /// </summary>
    public string? LogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logoUrl", value);
        }
    }

    /// <summary>
    /// Stock exchange. Stocks only.
    /// </summary>
    public string? ExchangeShortName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("exchangeShortName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exchangeShortName", value);
        }
    }

    /// <summary>
    /// Token contract address. Tokens only.
    /// </summary>
    public string? ContractAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contractAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contractAddress", value);
        }
    }

    /// <summary>
    /// Logo of the token's chain. Tokens only.
    /// </summary>
    public string? ChainLogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("chainLogoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chainLogoUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ticker;
        _ = this.Name;
        _ = this.SmartTag;
        _ = this.Currency;
        _ = this.Price;
        _ = this.MarketCap;
        _ = this.DailyChangePercent;
        _ = this.LogoUrl;
        _ = this.ExchangeShortName;
        _ = this.ContractAddress;
        _ = this.ChainLogoUrl;
    }

    public SearchSuggestionCashtag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionCashtag(SearchSuggestionCashtag searchSuggestionCashtag)
        : base(searchSuggestionCashtag) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionCashtag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchSuggestionCashtag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchSuggestionCashtagFromRaw.FromRawUnchecked"/>
    public static SearchSuggestionCashtag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchSuggestionCashtagFromRaw : IFromRawJson<SearchSuggestionCashtag>
{
    /// <inheritdoc/>
    public SearchSuggestionCashtag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchSuggestionCashtag.FromRawUnchecked(rawData);
}
