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

[JsonConverter(typeof(JsonModelConverter<CommunityPage, CommunityPageFromRaw>))]
public sealed record class CommunityPage : JsonModel
{
    /// <summary>
    /// Communities in X's order
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.X.Communities.Community> Communities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.X.Communities.Community>
            >("communities");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::XTwitterScraper.Models.X.Communities.Community>
            >("communities", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Whether another page of communities follows
    /// </summary>
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    /// <summary>
    /// Cursor for the next page of communities. Empty at the end.
    /// </summary>
    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Communities)
        {
            item.Validate();
        }
        _ = this.HasNextPage;
        _ = this.NextCursor;
    }

    public CommunityPage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityPage(CommunityPage communityPage)
        : base(communityPage) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityPageFromRaw.FromRawUnchecked"/>
    public static CommunityPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityPageFromRaw : IFromRawJson<CommunityPage>
{
    /// <inheritdoc/>
    public CommunityPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CommunityPage.FromRawUnchecked(rawData);
}
