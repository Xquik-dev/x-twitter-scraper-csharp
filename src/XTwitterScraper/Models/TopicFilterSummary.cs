using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

/// <summary>
/// What the topic filter asked &amp; how many posts it kept.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopicFilterSummary, TopicFilterSummaryFromRaw>))]
public record class TopicFilterSummary : JsonModel
{
    /// <summary>
    /// The topic you sent.
    /// </summary>
    public required string Topic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic");
        }
        init { this._rawData.Set("topic", value); }
    }

    /// <summary>
    /// The question asked of each post.
    /// </summary>
    public required string Question
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("question");
        }
        init { this._rawData.Set("question", value); }
    }

    /// <summary>
    /// The lowest topicScore a kept post has.
    /// </summary>
    public required double Cutoff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("cutoff");
        }
        init { this._rawData.Set("cutoff", value); }
    }

    /// <summary>
    /// Posts checked. Only kept posts are billed.
    /// </summary>
    public required long Checked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("checked");
        }
        init { this._rawData.Set("checked", value); }
    }

    /// <summary>
    /// Posts about the topic, all returned &amp; billed at 2 credits each.
    /// </summary>
    public required long Kept
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("kept");
        }
        init { this._rawData.Set("kept", value); }
    }

    /// <summary>
    /// Posts the check couldn't answer. They aren't billed or returned.
    /// </summary>
    public required IReadOnlyList<TopicFilterSummaryUnchecked> Unchecked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopicFilterSummaryUnchecked>>(
                "unchecked"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopicFilterSummaryUnchecked>>(
                "unchecked",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Topic;
        _ = this.Question;
        _ = this.Cutoff;
        _ = this.Checked;
        _ = this.Kept;
        foreach (var item in this.Unchecked)
        {
            item.Validate();
        }
    }

    public TopicFilterSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicFilterSummary(TopicFilterSummary topicFilterSummary)
        : base(topicFilterSummary) { }
#pragma warning restore CS8618

    public TopicFilterSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicFilterSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicFilterSummaryFromRaw.FromRawUnchecked"/>
    public static TopicFilterSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopicFilterSummaryFromRaw : IFromRawJson<TopicFilterSummary>
{
    /// <inheritdoc/>
    public TopicFilterSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicFilterSummary.FromRawUnchecked(rawData);
}

/// <summary>
/// A post the filter couldn't check, with the reason.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TopicFilterSummaryUnchecked, TopicFilterSummaryUncheckedFromRaw>)
)]
public sealed record class TopicFilterSummaryUnchecked : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

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
        _ = this.Reason;
    }

    public TopicFilterSummaryUnchecked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicFilterSummaryUnchecked(TopicFilterSummaryUnchecked topicFilterSummaryUnchecked)
        : base(topicFilterSummaryUnchecked) { }
#pragma warning restore CS8618

    public TopicFilterSummaryUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicFilterSummaryUnchecked(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicFilterSummaryUncheckedFromRaw.FromRawUnchecked"/>
    public static TopicFilterSummaryUnchecked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopicFilterSummaryUncheckedFromRaw : IFromRawJson<TopicFilterSummaryUnchecked>
{
    /// <inheritdoc/>
    public TopicFilterSummaryUnchecked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopicFilterSummaryUnchecked.FromRawUnchecked(rawData);
}
