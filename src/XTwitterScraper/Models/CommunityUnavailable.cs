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

/// <summary>
/// Why X shows no Community for the post.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CommunityUnavailable, CommunityUnavailableFromRaw>))]
public sealed record class CommunityUnavailable : JsonModel
{
    /// <summary>
    /// X's reason, as X writes it.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public CommunityUnavailable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityUnavailable(CommunityUnavailable communityUnavailable)
        : base(communityUnavailable) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityUnavailableFromRaw.FromRawUnchecked"/>
    public static CommunityUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityUnavailableFromRaw : IFromRawJson<CommunityUnavailable>
{
    /// <inheritdoc/>
    public CommunityUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityUnavailable.FromRawUnchecked(rawData);
}
