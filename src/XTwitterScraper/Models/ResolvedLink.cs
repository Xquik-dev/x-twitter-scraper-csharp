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

[JsonConverter(typeof(JsonModelConverter<ResolvedLink, ResolvedLinkFromRaw>))]
public sealed record class ResolvedLink : JsonModel
{
    /// <summary>
    /// The t.co link, as `https://t.co/&lt;code&gt;`.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Target URL, as the link's author set it. Xquik does not check it. Absent for a link t.co does not have.
    /// </summary>
    public string? ResolvedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resolvedUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resolvedUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.ResolvedUrl;
    }

    public ResolvedLink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResolvedLink(ResolvedLink resolvedLink)
        : base(resolvedLink) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResolvedLink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResolvedLink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResolvedLinkFromRaw.FromRawUnchecked"/>
    public static ResolvedLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResolvedLinkFromRaw : IFromRawJson<ResolvedLink>
{
    /// <inheritdoc/>
    public ResolvedLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ResolvedLink.FromRawUnchecked(rawData);
}
