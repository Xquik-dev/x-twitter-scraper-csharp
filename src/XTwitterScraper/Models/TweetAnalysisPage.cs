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

[JsonConverter(typeof(JsonModelConverter<TweetAnalysisPage, TweetAnalysisPageFromRaw>))]
public sealed record class TweetAnalysisPage : JsonModel
{
    /// <summary>
    /// Each analyzed post with its answers.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.TweetAnalysisResult> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetAnalysisResult>
            >("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetAnalysisResult>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Each post without an analysis, by ID &amp; reason. These cost nothing.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.UnanalyzedTweet> Unanalyzed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.UnanalyzedTweet>
            >("unanalyzed");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.UnanalyzedTweet>>(
                "unanalyzed",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Totals of the answers across the analyzed posts.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetAnalysisSummary AnalysisSummary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetAnalysisSummary>(
                "analysisSummary"
            );
        }
        init { this._rawData.Set("analysisSummary", value); }
    }

    /// <summary>
    /// Whether the search has more posts. Send next_cursor as cursor.
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
    /// Cursor of the search's next page, else empty.
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

    /// <summary>
    /// What the topic filter asked &amp; how many posts it kept. Present when you send topic.
    /// </summary>
    public TopicFilterSummary? TopicFilter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TopicFilterSummary>("topicFilter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topicFilter", value);
        }
    }

    /// <summary>
    /// What the image filter asked &amp; how many posts it kept. Present when you send
    /// imageShows.
    /// </summary>
    public ImageFilterSummary? ImageFilter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageFilterSummary>("imageFilter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageFilter", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        foreach (var item in this.Unanalyzed)
        {
            item.Validate();
        }
        this.AnalysisSummary.Validate();
        _ = this.HasNextPage;
        _ = this.NextCursor;
        this.TopicFilter?.Validate();
        this.ImageFilter?.Validate();
    }

    public TweetAnalysisPage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisPage(TweetAnalysisPage tweetAnalysisPage)
        : base(tweetAnalysisPage) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisPageFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisPage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisPageFromRaw : IFromRawJson<TweetAnalysisPage>
{
    /// <inheritdoc/>
    public TweetAnalysisPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetAnalysisPage.FromRawUnchecked(rawData);
}
