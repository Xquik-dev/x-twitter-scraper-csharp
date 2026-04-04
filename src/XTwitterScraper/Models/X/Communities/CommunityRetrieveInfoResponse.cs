using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Communities;

[JsonConverter(
    typeof(JsonModelConverter<CommunityRetrieveInfoResponse, CommunityRetrieveInfoResponseFromRaw>)
)]
public sealed record class CommunityRetrieveInfoResponse : JsonModel
{
    /// <summary>
    /// Community info object
    /// </summary>
    public required Community Community
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Community>("community");
        }
        init { this._rawData.Set("community", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Community.Validate();
    }

    public CommunityRetrieveInfoResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityRetrieveInfoResponse(
        CommunityRetrieveInfoResponse communityRetrieveInfoResponse
    )
        : base(communityRetrieveInfoResponse) { }
#pragma warning restore CS8618

    public CommunityRetrieveInfoResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityRetrieveInfoResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityRetrieveInfoResponseFromRaw.FromRawUnchecked"/>
    public static CommunityRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CommunityRetrieveInfoResponse(Community community)
        : this()
    {
        this.Community = community;
    }
}

class CommunityRetrieveInfoResponseFromRaw : IFromRawJson<CommunityRetrieveInfoResponse>
{
    /// <inheritdoc/>
    public CommunityRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityRetrieveInfoResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Community info object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Community, CommunityFromRaw>))]
public sealed record class Community : JsonModel
{
    /// <summary>
    /// Community ID
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
    /// Community banner image URL
    /// </summary>
    public string? BannerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("banner_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("banner_url", value);
        }
    }

    /// <summary>
    /// Community creation timestamp
    /// </summary>
    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Community description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Join policy (open or restricted)
    /// </summary>
    public string? JoinPolicy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("join_policy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("join_policy", value);
        }
    }

    /// <summary>
    /// Total member count
    /// </summary>
    public long? MemberCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("member_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("member_count", value);
        }
    }

    /// <summary>
    /// Total moderator count
    /// </summary>
    public long? ModeratorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("moderator_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("moderator_count", value);
        }
    }

    /// <summary>
    /// Community name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Primary topic
    /// </summary>
    public PrimaryTopic? PrimaryTopic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PrimaryTopic>("primary_topic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_topic", value);
        }
    }

    /// <summary>
    /// Community rules
    /// </summary>
    public IReadOnlyList<Rule>? Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Rule>>("rules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Rule>?>(
                "rules",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BannerUrl;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.JoinPolicy;
        _ = this.MemberCount;
        _ = this.ModeratorCount;
        _ = this.Name;
        this.PrimaryTopic?.Validate();
        foreach (var item in this.Rules ?? [])
        {
            item.Validate();
        }
    }

    public Community() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Community(Community community)
        : base(community) { }
#pragma warning restore CS8618

    public Community(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Community(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityFromRaw.FromRawUnchecked"/>
    public static Community FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Community(string id)
        : this()
    {
        this.ID = id;
    }
}

class CommunityFromRaw : IFromRawJson<Community>
{
    /// <inheritdoc/>
    public Community FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Community.FromRawUnchecked(rawData);
}

/// <summary>
/// Primary topic
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PrimaryTopic, PrimaryTopicFromRaw>))]
public sealed record class PrimaryTopic : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public PrimaryTopic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrimaryTopic(PrimaryTopic primaryTopic)
        : base(primaryTopic) { }
#pragma warning restore CS8618

    public PrimaryTopic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PrimaryTopic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrimaryTopicFromRaw.FromRawUnchecked"/>
    public static PrimaryTopic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrimaryTopicFromRaw : IFromRawJson<PrimaryTopic>
{
    /// <inheritdoc/>
    public PrimaryTopic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PrimaryTopic.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Rule, RuleFromRaw>))]
public sealed record class Rule : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Name;
    }

    public Rule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rule(Rule rule)
        : base(rule) { }
#pragma warning restore CS8618

    public Rule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleFromRaw.FromRawUnchecked"/>
    public static Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleFromRaw : IFromRawJson<Rule>
{
    /// <inheritdoc/>
    public Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rule.FromRawUnchecked(rawData);
}
