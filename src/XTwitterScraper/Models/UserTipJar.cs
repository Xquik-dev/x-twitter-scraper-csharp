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

[JsonConverter(typeof(JsonModelConverter<UserTipJar, UserTipJarFromRaw>))]
public sealed record class UserTipJar : JsonModel
{
    public string? BandcampHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bandcampHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bandcampHandle", value);
        }
    }

    public string? BitcoinHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bitcoinHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bitcoinHandle", value);
        }
    }

    public string? CashAppHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cashAppHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cashAppHandle", value);
        }
    }

    public string? EthereumHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ethereumHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ethereumHandle", value);
        }
    }

    public string? GofundmeHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gofundmeHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gofundmeHandle", value);
        }
    }

    public bool? IsEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isEnabled", value);
        }
    }

    public string? PatreonHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("patreonHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("patreonHandle", value);
        }
    }

    public string? PayPalHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payPalHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("payPalHandle", value);
        }
    }

    public string? VenmoHandle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("venmoHandle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("venmoHandle", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandcampHandle;
        _ = this.BitcoinHandle;
        _ = this.CashAppHandle;
        _ = this.EthereumHandle;
        _ = this.GofundmeHandle;
        _ = this.IsEnabled;
        _ = this.PatreonHandle;
        _ = this.PayPalHandle;
        _ = this.VenmoHandle;
    }

    public UserTipJar() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserTipJar(UserTipJar userTipJar)
        : base(userTipJar) { }
#pragma warning restore CS8618

    public UserTipJar(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserTipJar(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserTipJarFromRaw.FromRawUnchecked"/>
    public static UserTipJar FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserTipJarFromRaw : IFromRawJson<UserTipJar>
{
    /// <inheritdoc/>
    public UserTipJar FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserTipJar.FromRawUnchecked(rawData);
}
