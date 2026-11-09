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

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<NewsVersion, NewsVersionFromRaw>))]
public sealed record class NewsVersion : JsonModel
{
    /// <summary>
    /// The version's ID.
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
    /// When X wrote the version, in UTC, from its ID.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The story's headline in this version.
    /// </summary>
    public required string Headline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("headline");
        }
        init { this._rawData.Set("headline", value); }
    }

    /// <summary>
    /// The story's text in this version, without its time line.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Headline;
        _ = this.Text;
    }

    public NewsVersion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewsVersion(NewsVersion newsVersion)
        : base(newsVersion) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewsVersion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewsVersion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewsVersionFromRaw.FromRawUnchecked"/>
    public static NewsVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewsVersionFromRaw : IFromRawJson<NewsVersion>
{
    /// <inheritdoc/>
    public NewsVersion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewsVersion.FromRawUnchecked(rawData);
}
