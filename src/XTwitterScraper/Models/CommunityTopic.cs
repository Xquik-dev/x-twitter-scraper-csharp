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

[JsonConverter(typeof(JsonModelConverter<CommunityTopicSubtopics, CommunityTopicSubtopicsFromRaw>))]
public sealed record class CommunityTopicSubtopics : JsonModel
{
    /// <summary>
    /// Subtopic ID, which topicId also takes
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
    /// Subtopic name, which topic also takes
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public CommunityTopicSubtopics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityTopicSubtopics(CommunityTopicSubtopics communityTopicSubtopics)
        : base(communityTopicSubtopics) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityTopicSubtopics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityTopicSubtopics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityTopicSubtopicsFromRaw.FromRawUnchecked"/>
    public static CommunityTopicSubtopics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityTopicSubtopicsFromRaw : IFromRawJson<CommunityTopicSubtopics>
{
    /// <inheritdoc/>
    public CommunityTopicSubtopics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityTopicSubtopics.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommunityTopic, CommunityTopicFromRaw>))]
public sealed record class CommunityTopic : JsonModel
{
    /// <summary>
    /// Topic ID. Pass it as topicId to /x/communities/popular.
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
    /// Topic name, which topic on /x/communities/popular takes
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Narrower topics inside this topic
    /// </summary>
    public required IReadOnlyList<CommunityTopicSubtopics> Subtopics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CommunityTopicSubtopics>>(
                "subtopics"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CommunityTopicSubtopics>>(
                "subtopics",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        foreach (var item in this.Subtopics)
        {
            item.Validate();
        }
    }

    public CommunityTopic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityTopic(CommunityTopic communityTopic)
        : base(communityTopic) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityTopic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityTopic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityTopicFromRaw.FromRawUnchecked"/>
    public static CommunityTopic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityTopicFromRaw : IFromRawJson<CommunityTopic>
{
    /// <inheritdoc/>
    public CommunityTopic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CommunityTopic.FromRawUnchecked(rawData);
}
