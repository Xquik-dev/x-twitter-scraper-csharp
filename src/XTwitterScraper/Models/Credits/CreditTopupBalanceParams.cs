// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Credits;

/// <summary>
/// Create a Stripe Checkout session only after the user confirms. The request never
/// completes payment or adds credits by itself.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class CreditTopupBalanceParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Amount to top up in US dollars. Minimum 10.
    /// </summary>
    public required long Dollars
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("dollars");
        }
        init { this._rawBodyData.Set("dollars", value); }
    }

    /// <summary>
    /// Optional checkout locale. Defaults to en.
    /// </summary>
    public string? Locale
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("locale", value);
        }
    }

    /// <summary>
    /// Currency to pay in. Xquik converts the dollar amount at the latest daily ECB rate. If the newest rates are more than 3 ECB working days old, it charges USD instead, and Checkout shows that before payment. `chargedCurrency` shows the currency charged. Credits always match the dollar amount. Lowercase codes work too.
    /// </summary>
    public ApiEnum<string, global::XTwitterScraper.Models.Currency>? Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, global::XTwitterScraper.Models.Currency>
            >("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("currency", value);
        }
    }

    /// <summary>
    /// Optional Xquik tool page to return to after Checkout, such as /en/x-article-reader.
    /// </summary>
    public string? ReturnPath
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("returnPath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("returnPath", value);
        }
    }

    public CreditTopupBalanceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditTopupBalanceParams(CreditTopupBalanceParams creditTopupBalanceParams)
        : base(creditTopupBalanceParams)
    {
        this._rawBodyData = new(creditTopupBalanceParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CreditTopupBalanceParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditTopupBalanceParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CreditTopupBalanceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CreditTopupBalanceParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/credits/topup")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
