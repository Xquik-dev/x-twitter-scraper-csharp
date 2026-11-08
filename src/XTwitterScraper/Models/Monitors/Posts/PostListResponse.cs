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

namespace XTwitterScraper.Models.Monitors.Posts;

[JsonConverter(typeof(JsonModelConverter<PostListResponse, PostListResponseFromRaw>))]
public sealed record class PostListResponse : JsonModel
{
    public required IReadOnlyList<global::XTwitterScraper.Models.PostMonitor> Monitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.PostMonitor>
            >("monitors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.PostMonitor>>(
                "monitors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Post monitors on this page.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasMore");
        }
        init { this._rawData.Set("hasMore", value); }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextCursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Monitors)
        {
            item.Validate();
        }
        _ = this.Total;
        _ = this.HasMore;
        _ = this.NextCursor;
    }

    public PostListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostListResponse(PostListResponse postListResponse)
        : base(postListResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostListResponseFromRaw.FromRawUnchecked"/>
    public static PostListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostListResponseFromRaw : IFromRawJson<PostListResponse>
{
    /// <inheritdoc/>
    public PostListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostListResponse.FromRawUnchecked(rawData);
}
