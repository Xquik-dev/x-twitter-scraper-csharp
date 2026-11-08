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
    typeof(JsonModelConverter<SearchSuggestionUserBadges, SearchSuggestionUserBadgesFromRaw>)
)]
public sealed record class SearchSuggestionUserBadges : JsonModel
{
    /// <summary>
    /// Kind of badge.
    /// </summary>
    public string? BadgeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("badgeType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("badgeType", value);
        }
    }

    /// <summary>
    /// Badge image URL.
    /// </summary>
    public string? BadgeUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("badgeUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("badgeUrl", value);
        }
    }

    /// <summary>
    /// Name of the affiliated account.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BadgeType;
        _ = this.BadgeUrl;
        _ = this.Description;
    }

    public SearchSuggestionUserBadges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionUserBadges(SearchSuggestionUserBadges searchSuggestionUserBadges)
        : base(searchSuggestionUserBadges) { }
#pragma warning restore CS8618

    public SearchSuggestionUserBadges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchSuggestionUserBadges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchSuggestionUserBadgesFromRaw.FromRawUnchecked"/>
    public static SearchSuggestionUserBadges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchSuggestionUserBadgesFromRaw : IFromRawJson<SearchSuggestionUserBadges>
{
    /// <inheritdoc/>
    public SearchSuggestionUserBadges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchSuggestionUserBadges.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SearchSuggestionUser, SearchSuggestionUserFromRaw>))]
public sealed record class SearchSuggestionUser : JsonModel
{
    /// <summary>
    /// X user ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Handle without the @.
    /// </summary>
    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    /// <summary>
    /// Display name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Whether X shows any verification badge.
    /// </summary>
    public bool? Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("verified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verified", value);
        }
    }

    /// <summary>
    /// Whether X shows a blue verification badge.
    /// </summary>
    public bool? IsBlueVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isBlueVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isBlueVerified", value);
        }
    }

    /// <summary>
    /// Whether the account holds X's legacy verification.
    /// </summary>
    public bool? IsVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isVerified", value);
        }
    }

    /// <summary>
    /// Verification category, such as Government or Business. Omitted when X names none.
    /// </summary>
    public string? VerifiedType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verifiedType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verifiedType", value);
        }
    }

    /// <summary>
    /// Whether the account protects its posts.
    /// </summary>
    public bool? Protected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("protected");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protected", value);
        }
    }

    /// <summary>
    /// Public profile location text. Omitted when empty.
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// Avatar URL.
    /// </summary>
    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    /// <summary>
    /// The same avatar at full size.
    /// </summary>
    public string? ProfilePictureOriginal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePictureOriginal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePictureOriginal", value);
        }
    }

    /// <summary>
    /// Affiliation badges X shows beside the name.
    /// </summary>
    public IReadOnlyList<SearchSuggestionUserBadges>? Badges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchSuggestionUserBadges>>(
                "badges"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchSuggestionUserBadges>?>(
                "badges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X's flag for whether media can be generated from this account's persona.
    /// </summary>
    public bool? IsPersonaMediaGenable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPersonaMediaGenable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPersonaMediaGenable", value);
        }
    }

    /// <summary>
    /// X's rounded relevance score for the account.
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <summary>
    /// Normalized text tokens X matches the account by.
    /// </summary>
    public IReadOnlyList<string>? Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tokens",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X's inline flag for the account.
    /// </summary>
    public bool? Inline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inline", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
        _ = this.Name;
        _ = this.Verified;
        _ = this.IsBlueVerified;
        _ = this.IsVerified;
        _ = this.VerifiedType;
        _ = this.Protected;
        _ = this.Location;
        _ = this.ProfilePicture;
        _ = this.ProfilePictureOriginal;
        foreach (var item in this.Badges ?? [])
        {
            item.Validate();
        }
        _ = this.IsPersonaMediaGenable;
        _ = this.Score;
        _ = this.Tokens;
        _ = this.Inline;
    }

    public SearchSuggestionUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionUser(SearchSuggestionUser searchSuggestionUser)
        : base(searchSuggestionUser) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchSuggestionUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchSuggestionUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchSuggestionUserFromRaw.FromRawUnchecked"/>
    public static SearchSuggestionUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchSuggestionUserFromRaw : IFromRawJson<SearchSuggestionUser>
{
    /// <inheritdoc/>
    public SearchSuggestionUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchSuggestionUser.FromRawUnchecked(rawData);
}
