// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<TweetCardUserReferenceErrors, TweetCardUserReferenceErrorsFromRaw>)
)]
public sealed record class TweetCardUserReferenceErrors : JsonModel
{
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Reason;
    }

    public TweetCardUserReferenceErrors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCardUserReferenceErrors(TweetCardUserReferenceErrors tweetCardUserReferenceErrors)
        : base(tweetCardUserReferenceErrors) { }
#pragma warning restore CS8618

    public TweetCardUserReferenceErrors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetCardUserReferenceErrors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetCardUserReferenceErrorsFromRaw.FromRawUnchecked"/>
    public static TweetCardUserReferenceErrors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetCardUserReferenceErrorsFromRaw : IFromRawJson<TweetCardUserReferenceErrors>
{
    /// <inheritdoc/>
    public TweetCardUserReferenceErrors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetCardUserReferenceErrors.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetCard, TweetCardFromRaw>))]
public sealed record class TweetCard : JsonModel
{
    /// <summary>
    /// X's ID for the card, such as its t.co link.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

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

    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? BindingValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "bindingValues"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "bindingValues",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Platform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "platform"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "platform",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Unresolved card user references.
    /// </summary>
    public IReadOnlyList<TweetCardUserReferenceErrors>? UserReferenceErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetCardUserReferenceErrors>>(
                "userReferenceErrors"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetCardUserReferenceErrors>?>(
                "userReferenceErrors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<global::XTwitterScraper.Models.UserProfile>? UserReferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.UserProfile>
            >("userReferences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.UserProfile>?>(
                "userReferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.UrlValue;
        _ = this.BindingValues;
        _ = this.Platform;
        foreach (var item in this.UserReferenceErrors ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UserReferences ?? [])
        {
            item.Validate();
        }
    }

    public TweetCard() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCard(TweetCard tweetCard)
        : base(tweetCard) { }
#pragma warning restore CS8618

    public TweetCard(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetCard(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetCardFromRaw.FromRawUnchecked"/>
    public static TweetCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetCardFromRaw : IFromRawJson<TweetCard>
{
    /// <inheritdoc/>
    public TweetCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetCard.FromRawUnchecked(rawData);
}
