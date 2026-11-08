// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(AccountBasedInLevelConverter))]
public enum AccountBasedInLevel
{
    Country,
    Region,
}

sealed class AccountBasedInLevelConverter : JsonConverter<AccountBasedInLevel>
{
    public override AccountBasedInLevel Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "country" => AccountBasedInLevel.Country,
            "region" => AccountBasedInLevel.Region,
            _ => (AccountBasedInLevel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountBasedInLevel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountBasedInLevel.Country => "country",
                AccountBasedInLevel.Region => "region",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<AccountBasedIn, AccountBasedInFromRaw>))]
public sealed record class AccountBasedIn : JsonModel
{
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    public required ApiEnum<string, AccountBasedInLevel> Level
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountBasedInLevel>>("level");
        }
        init { this._rawData.Set("level", value); }
    }

    public required DateTimeOffset ObservedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("observedAt");
        }
        init { this._rawData.Set("observedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Value;
        this.Level.Validate();
        _ = this.ObservedAt;
    }

    public AccountBasedIn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountBasedIn(AccountBasedIn accountBasedIn)
        : base(accountBasedIn) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountBasedIn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountBasedIn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountBasedInFromRaw.FromRawUnchecked"/>
    public static AccountBasedIn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountBasedInFromRaw : IFromRawJson<AccountBasedIn>
{
    /// <inheritdoc/>
    public AccountBasedIn FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountBasedIn.FromRawUnchecked(rawData);
}
