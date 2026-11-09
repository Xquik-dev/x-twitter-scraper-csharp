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

namespace XTwitterScraper.Models.X.CommunityNotes;

/// <summary>
/// Returns a contributor's notes, newest first, each with the post it is on. Includes notes X has not rated helpful. Each note costs 1 credit. Follow next_cursor for more.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public record class CommunityNoteListContributorNotesParams : ParamsBase
{
    public string? Alias { get; init; }

    /// <summary>
    /// Pagination cursor for collection results. Also read as next_cursor, next_token, pagination_token or continuation_token.
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
    /// Notes per page (1-10, default 10). A low credit balance can return fewer. Follow next_cursor for more pages. Also read as limit, count, max_results, maxItems, max_items &amp; per_page.
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

    public CommunityNoteListContributorNotesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNoteListContributorNotesParams(
        CommunityNoteListContributorNotesParams communityNoteListContributorNotesParams
    )
        : base(communityNoteListContributorNotesParams)
    {
        this.Alias = communityNoteListContributorNotesParams.Alias;
    }
#pragma warning restore CS8618

    public CommunityNoteListContributorNotesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNoteListContributorNotesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string alias
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Alias = alias;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CommunityNoteListContributorNotesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string alias
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            alias
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Alias"] = JsonSerializer.SerializeToElement(this.Alias),
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

    public virtual bool Equals(CommunityNoteListContributorNotesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Alias?.Equals(other.Alias) ?? other.Alias == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/x/community-notes/contributors/{0}/notes", this.Alias)
        )
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
