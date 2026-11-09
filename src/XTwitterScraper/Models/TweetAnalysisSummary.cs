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
    typeof(JsonModelConverter<TweetAnalysisSummaryRows, TweetAnalysisSummaryRowsFromRaw>)
)]
public sealed record class TweetAnalysisSummaryRows : JsonModel
{
    public required long Analyzed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("analyzed");
        }
        init { this._rawData.Set("analyzed", value); }
    }

    public required long Failed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("failed");
        }
        init { this._rawData.Set("failed", value); }
    }

    public required long Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skipped");
        }
        init { this._rawData.Set("skipped", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Analyzed;
        _ = this.Failed;
        _ = this.Skipped;
    }

    public TweetAnalysisSummaryRows() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryRows(TweetAnalysisSummaryRows tweetAnalysisSummaryRows)
        : base(tweetAnalysisSummaryRows) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryRows(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummaryRows(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryRowsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummaryRows FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryRowsFromRaw : IFromRawJson<TweetAnalysisSummaryRows>
{
    /// <inheritdoc/>
    public TweetAnalysisSummaryRows FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummaryRows.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAnalysisSummaryTargets, TweetAnalysisSummaryTargetsFromRaw>)
)]
public sealed record class TweetAnalysisSummaryTargets : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required long Mentions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("mentions");
        }
        init { this._rawData.Set("mentions", value); }
    }

    public required double Share
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("share");
        }
        init { this._rawData.Set("share", value); }
    }

    public required long Engagement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("engagement");
        }
        init { this._rawData.Set("engagement", value); }
    }

    /// <summary>
    /// Category counts by question ID.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Choices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("choices");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "choices",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The most engaged posts per question ID &amp; category.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Top
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("top");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "top",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Mentions;
        _ = this.Share;
        _ = this.Engagement;
        _ = this.Choices;
        _ = this.Top;
    }

    public TweetAnalysisSummaryTargets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryTargets(TweetAnalysisSummaryTargets tweetAnalysisSummaryTargets)
        : base(tweetAnalysisSummaryTargets) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryTargets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummaryTargets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryTargetsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummaryTargets FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryTargetsFromRaw : IFromRawJson<TweetAnalysisSummaryTargets>
{
    /// <inheritdoc/>
    public TweetAnalysisSummaryTargets FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummaryTargets.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetAnalysisSummaryCashtagsSignal,
        TweetAnalysisSummaryCashtagsSignalFromRaw
    >)
)]
public sealed record class TweetAnalysisSummaryCashtagsSignal : JsonModel
{
    public required long Bullish
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bullish");
        }
        init { this._rawData.Set("bullish", value); }
    }

    public required long Bearish
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bearish");
        }
        init { this._rawData.Set("bearish", value); }
    }

    /// <summary>
    /// Bullish minus bearish posts, over all posts.
    /// </summary>
    public required double Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bullish;
        _ = this.Bearish;
        _ = this.Score;
    }

    public TweetAnalysisSummaryCashtagsSignal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryCashtagsSignal(
        TweetAnalysisSummaryCashtagsSignal tweetAnalysisSummaryCashtagsSignal
    )
        : base(tweetAnalysisSummaryCashtagsSignal) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryCashtagsSignal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummaryCashtagsSignal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryCashtagsSignalFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummaryCashtagsSignal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryCashtagsSignalFromRaw : IFromRawJson<TweetAnalysisSummaryCashtagsSignal>
{
    /// <inheritdoc/>
    public TweetAnalysisSummaryCashtagsSignal FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummaryCashtagsSignal.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAnalysisSummaryCashtags, TweetAnalysisSummaryCashtagsFromRaw>)
)]
public sealed record class TweetAnalysisSummaryCashtags : JsonModel
{
    public required string Cashtag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cashtag");
        }
        init { this._rawData.Set("cashtag", value); }
    }

    public required long Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("rows");
        }
        init { this._rawData.Set("rows", value); }
    }

    /// <summary>
    /// Category counts of the cashtag's posts by question ID.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Choices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("choices");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "choices",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public TweetAnalysisSummaryCashtagsSignal? Signal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAnalysisSummaryCashtagsSignal>("signal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signal", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cashtag;
        _ = this.Rows;
        _ = this.Choices;
        this.Signal?.Validate();
    }

    public TweetAnalysisSummaryCashtags() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryCashtags(TweetAnalysisSummaryCashtags tweetAnalysisSummaryCashtags)
        : base(tweetAnalysisSummaryCashtags) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryCashtags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummaryCashtags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryCashtagsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummaryCashtags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryCashtagsFromRaw : IFromRawJson<TweetAnalysisSummaryCashtags>
{
    /// <inheritdoc/>
    public TweetAnalysisSummaryCashtags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummaryCashtags.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetAnalysisSummarySourceDomains,
        TweetAnalysisSummarySourceDomainsFromRaw
    >)
)]
public sealed record class TweetAnalysisSummarySourceDomains : JsonModel
{
    public required string Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    public required long Posts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("posts");
        }
        init { this._rawData.Set("posts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Domain;
        _ = this.Posts;
    }

    public TweetAnalysisSummarySourceDomains() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummarySourceDomains(
        TweetAnalysisSummarySourceDomains tweetAnalysisSummarySourceDomains
    )
        : base(tweetAnalysisSummarySourceDomains) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummarySourceDomains(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummarySourceDomains(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummarySourceDomainsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummarySourceDomains FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummarySourceDomainsFromRaw : IFromRawJson<TweetAnalysisSummarySourceDomains>
{
    /// <inheritdoc/>
    public TweetAnalysisSummarySourceDomains FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummarySourceDomains.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetAnalysisSummaryMonitorChangedRowsChanges,
        TweetAnalysisSummaryMonitorChangedRowsChangesFromRaw
    >)
)]
public sealed record class TweetAnalysisSummaryMonitorChangedRowsChanges : JsonModel
{
    public required string QuestionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("questionId");
        }
        init { this._rawData.Set("questionId", value); }
    }

    public required string Previous
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("previous");
        }
        init { this._rawData.Set("previous", value); }
    }

    public required string Current
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("current");
        }
        init { this._rawData.Set("current", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.QuestionID;
        _ = this.Previous;
        _ = this.Current;
    }

    public TweetAnalysisSummaryMonitorChangedRowsChanges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryMonitorChangedRowsChanges(
        TweetAnalysisSummaryMonitorChangedRowsChanges tweetAnalysisSummaryMonitorChangedRowsChanges
    )
        : base(tweetAnalysisSummaryMonitorChangedRowsChanges) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryMonitorChangedRowsChanges(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummaryMonitorChangedRowsChanges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryMonitorChangedRowsChangesFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummaryMonitorChangedRowsChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryMonitorChangedRowsChangesFromRaw
    : IFromRawJson<TweetAnalysisSummaryMonitorChangedRowsChanges>
{
    /// <inheritdoc/>
    public TweetAnalysisSummaryMonitorChangedRowsChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummaryMonitorChangedRowsChanges.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetAnalysisSummaryMonitorChangedRows,
        TweetAnalysisSummaryMonitorChangedRowsFromRaw
    >)
)]
public sealed record class TweetAnalysisSummaryMonitorChangedRows : JsonModel
{
    public required string TweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tweetId");
        }
        init { this._rawData.Set("tweetId", value); }
    }

    public required IReadOnlyList<TweetAnalysisSummaryMonitorChangedRowsChanges> Changes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<TweetAnalysisSummaryMonitorChangedRowsChanges>
            >("changes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetAnalysisSummaryMonitorChangedRowsChanges>>(
                "changes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TweetID;
        foreach (var item in this.Changes)
        {
            item.Validate();
        }
    }

    public TweetAnalysisSummaryMonitorChangedRows() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryMonitorChangedRows(
        TweetAnalysisSummaryMonitorChangedRows tweetAnalysisSummaryMonitorChangedRows
    )
        : base(tweetAnalysisSummaryMonitorChangedRows) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryMonitorChangedRows(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummaryMonitorChangedRows(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryMonitorChangedRowsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummaryMonitorChangedRows FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryMonitorChangedRowsFromRaw
    : IFromRawJson<TweetAnalysisSummaryMonitorChangedRows>
{
    /// <inheritdoc/>
    public TweetAnalysisSummaryMonitorChangedRows FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummaryMonitorChangedRows.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAnalysisSummaryMonitor, TweetAnalysisSummaryMonitorFromRaw>)
)]
public sealed record class TweetAnalysisSummaryMonitor : JsonModel
{
    /// <summary>
    /// Posts per monitor status.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Statuses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("statuses");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "statuses",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyList<TweetAnalysisSummaryMonitorChangedRows> ChangedRows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<TweetAnalysisSummaryMonitorChangedRows>
            >("changedRows");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetAnalysisSummaryMonitorChangedRows>>(
                "changedRows",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Statuses;
        foreach (var item in this.ChangedRows)
        {
            item.Validate();
        }
    }

    public TweetAnalysisSummaryMonitor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryMonitor(TweetAnalysisSummaryMonitor tweetAnalysisSummaryMonitor)
        : base(tweetAnalysisSummaryMonitor) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummaryMonitor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummaryMonitor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryMonitorFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummaryMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryMonitorFromRaw : IFromRawJson<TweetAnalysisSummaryMonitor>
{
    /// <inheritdoc/>
    public TweetAnalysisSummaryMonitor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummaryMonitor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetAnalysisSummary, TweetAnalysisSummaryFromRaw>))]
public sealed record class TweetAnalysisSummary : JsonModel
{
    public required long SchemaVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("schemaVersion");
        }
        init { this._rawData.Set("schemaVersion", value); }
    }

    /// <summary>
    /// Posts by analysis outcome.
    /// </summary>
    public required TweetAnalysisSummaryRows Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TweetAnalysisSummaryRows>("rows");
        }
        init { this._rawData.Set("rows", value); }
    }

    /// <summary>
    /// Likes, reposts, replies &amp; quotes of the analyzed posts.
    /// </summary>
    public required long Engagement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("engagement");
        }
        init { this._rawData.Set("engagement", value); }
    }

    /// <summary>
    /// Totals by question ID. A choice has counts, shares, engagementShares &amp; top posts per category. A score has mean, engagementWeightedMean &amp; levels. A probability has mean, yes &amp; no.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Questions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "questions"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "questions",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Mentions &amp; answers per target in analysis.targets.
    /// </summary>
    public required IReadOnlyList<TweetAnalysisSummaryTargets> Targets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TweetAnalysisSummaryTargets>>(
                "targets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetAnalysisSummaryTargets>>(
                "targets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Posts &amp; answers per cashtag, most posts first, up to 20. signal is present for the market questions.
    /// </summary>
    public required IReadOnlyList<TweetAnalysisSummaryCashtags> Cashtags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TweetAnalysisSummaryCashtags>>(
                "cashtags"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetAnalysisSummaryCashtags>>(
                "cashtags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Posts per linked hostname, most posts first, up to 20.
    /// </summary>
    public required IReadOnlyList<TweetAnalysisSummarySourceDomains> SourceDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<TweetAnalysisSummarySourceDomains>
            >("sourceDomains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetAnalysisSummarySourceDomains>>(
                "sourceDomains",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Only from /x/analysis/viral-score. Scored posts, the average score, verdict counts, the scores against actual engagement, a report per author &amp; the leaderboards.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Viral
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("viral");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "viral",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Posts per comparison status, &amp; up to 50 changed posts with their changes. Null when the answer holds no post.
    /// </summary>
    public required TweetAnalysisSummaryMonitor? Monitor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAnalysisSummaryMonitor>("monitor");
        }
        init { this._rawData.Set("monitor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SchemaVersion;
        this.Rows.Validate();
        _ = this.Engagement;
        _ = this.Questions;
        foreach (var item in this.Targets)
        {
            item.Validate();
        }
        foreach (var item in this.Cashtags)
        {
            item.Validate();
        }
        foreach (var item in this.SourceDomains)
        {
            item.Validate();
        }
        _ = this.Viral;
        this.Monitor?.Validate();
    }

    public TweetAnalysisSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummary(TweetAnalysisSummary tweetAnalysisSummary)
        : base(tweetAnalysisSummary) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSummaryFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSummaryFromRaw : IFromRawJson<TweetAnalysisSummary>
{
    /// <inheritdoc/>
    public TweetAnalysisSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSummary.FromRawUnchecked(rawData);
}
