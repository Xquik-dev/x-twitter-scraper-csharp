// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Users;

/// <summary>
/// Search users by name or username
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class UserRetrieveSearchParams : ParamsBase
{
    /// <summary>
    /// User search query
    /// </summary>
    public required string Q
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("q");
        }
        init { this._rawQueryData.Set("q", value); }
    }

    /// <summary>
    /// Pagination cursor for user search
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Items per page (1-100, default 20). Source, filters or credits can return fewer. Follow next_cursor for more pages. Its aliases are limit, count, max_results, maxItems, max_items &amp; per_page.
    /// </summary>
    public long? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("pageSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("pageSize", value);
        }
    }

    /// <summary>
    /// Minimum follower count. Profiles the filter drops cost nothing.
    /// </summary>
    public long? MinFollowers
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minFollowers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minFollowers", value);
        }
    }

    /// <summary>
    /// Maximum follower count. A profile without a count passes.
    /// </summary>
    public long? MaxFollowers
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxFollowers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxFollowers", value);
        }
    }

    /// <summary>
    /// Profiles must follow at least this many accounts.
    /// </summary>
    public long? MinFollowing
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minFollowing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minFollowing", value);
        }
    }

    /// <summary>
    /// Profiles may follow at most this many accounts.
    /// </summary>
    public long? MaxFollowing
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxFollowing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxFollowing", value);
        }
    }

    /// <summary>
    /// Minimum post count. minPosts is also accepted.
    /// </summary>
    public long? MinStatuses
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minStatuses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minStatuses", value);
        }
    }

    /// <summary>
    /// Maximum post count. maxPosts is also accepted.
    /// </summary>
    public long? MaxStatuses
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("maxStatuses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("maxStatuses", value);
        }
    }

    /// <summary>
    /// Minimum account age in whole days.
    /// </summary>
    public long? MinAccountAgeDays
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("minAccountAgeDays");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minAccountAgeDays", value);
        }
    }

    /// <summary>
    /// Only return verified profiles.
    /// </summary>
    public bool? VerifiedOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("verifiedOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("verifiedOnly", value);
        }
    }

    /// <summary>
    /// Only return profiles X marks as blue verified. X marks many business &amp; government accounts blue too. Use verifiedType for 1 badge type.
    /// </summary>
    public bool? BlueVerifiedOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("blueVerifiedOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("blueVerifiedOnly", value);
        }
    }

    /// <summary>
    /// Match the verification type exactly, ignoring case.
    /// </summary>
    public string? VerifiedType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("verifiedType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("verifiedType", value);
        }
    }

    /// <summary>
    /// Only return profiles with a website.
    /// </summary>
    public bool? HasWebsite
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasWebsite");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasWebsite", value);
        }
    }

    /// <summary>
    /// Only return profiles with a location.
    /// </summary>
    public bool? HasLocation
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasLocation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasLocation", value);
        }
    }

    /// <summary>
    /// Only return profiles that publish an email.
    /// </summary>
    public bool? HasEmail
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("hasEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hasEmail", value);
        }
    }

    /// <summary>
    /// Only return profiles that publish an email outside free webmail, such as Gmail.
    /// </summary>
    public bool? BusinessEmailOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("businessEmailOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("businessEmailOnly", value);
        }
    }

    /// <summary>
    /// Only return profiles with an email at one of these domains. Separate domains with commas. Subdomains match.
    /// </summary>
    public string? EmailDomains
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("emailDomains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("emailDomains", value);
        }
    }

    /// <summary>
    /// Match any comma-separated or line-separated bio term, ignoring case.
    /// </summary>
    public string? BioContains
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("bioContains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("bioContains", value);
        }
    }

    /// <summary>
    /// Match a location substring, ignoring case.
    /// </summary>
    public string? LocationContains
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("locationContains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("locationContains", value);
        }
    }

    /// <summary>
    /// Match a username substring, ignoring case.
    /// </summary>
    public string? UsernameContains
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("usernameContains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("usernameContains", value);
        }
    }

    /// <summary>
    /// Add each row's full profile, as GET /x/users/{id} returns it. Pages take several seconds longer.
    /// </summary>
    public bool? EnrichProfiles
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("enrichProfiles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("enrichProfiles", value);
        }
    }

    /// <summary>
    /// Fields to keep in each row, comma-separated. Use dots for nested fields, such as author.username. A list keeps the field in each item. Case &amp; underscores do not matter. A row that lacks a field leaves it out. Cursors, counts &amp; diagnostics always stay. An unknown name answers 400 unknown_field with the valid names, before any read. The price stays the same. SDK row types then hold only the named fields. A longer URL fails at the edge before Xquik reads it. Pick only the fields you need with `fields` &amp; `omit`.
    /// </summary>
    public string? Fields
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("fields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fields", value);
        }
    }

    /// <summary>
    /// Fields to drop from each row, comma-separated. It takes the same names as fields. With fields, it drops from the kept fields. A longer URL fails at the edge before Xquik reads it.
    /// </summary>
    public string? Omit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("omit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("omit", value);
        }
    }

    public UserRetrieveSearchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveSearchParams(UserRetrieveSearchParams userRetrieveSearchParams)
        : base(userRetrieveSearchParams) { }
#pragma warning restore CS8618

    public UserRetrieveSearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveSearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserRetrieveSearchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UserRetrieveSearchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/x/users/search")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
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
