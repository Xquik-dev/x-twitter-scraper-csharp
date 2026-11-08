// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(UnanalyzedTweetStatusConverter))]
public enum UnanalyzedTweetStatus
{
    Failed,
    Skipped,
}

sealed class UnanalyzedTweetStatusConverter : JsonConverter<UnanalyzedTweetStatus>
{
    public override UnanalyzedTweetStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "failed" => UnanalyzedTweetStatus.Failed,
            "skipped" => UnanalyzedTweetStatus.Skipped,
            _ => (UnanalyzedTweetStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnanalyzedTweetStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnanalyzedTweetStatus.Failed => "failed",
                UnanalyzedTweetStatus.Skipped => "skipped",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UnanalyzedTweet, UnanalyzedTweetFromRaw>))]
public sealed record class UnanalyzedTweet : JsonModel
{
    /// <summary>
    /// Post ID. Your own texts have the IDs text:1, text:2 &amp; so on.
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

    public required ApiEnum<string, UnanalyzedTweetStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UnanalyzedTweetStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// post_unavailable when X returns no such post. missing_text for a post without text. insufficient_credits when credits ran out. context_limit when the settings leave the post no room. The other reasons mean the analysis failed. Send the post again.
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
        _ = this.ID;
        this.Status.Validate();
        _ = this.Reason;
    }

    public UnanalyzedTweet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnanalyzedTweet(UnanalyzedTweet unanalyzedTweet)
        : base(unanalyzedTweet) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnanalyzedTweet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnanalyzedTweet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnanalyzedTweetFromRaw.FromRawUnchecked"/>
    public static UnanalyzedTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnanalyzedTweetFromRaw : IFromRawJson<UnanalyzedTweet>
{
    /// <inheritdoc/>
    public UnanalyzedTweet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnanalyzedTweet.FromRawUnchecked(rawData);
}
