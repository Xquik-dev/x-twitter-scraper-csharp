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

[JsonConverter(typeof(JsonModelConverter<FootballPlayScore, FootballPlayScoreFromRaw>))]
public sealed record class FootballPlayScore : JsonModel
{
    /// <summary>
    /// The home team's score once this scoring play counted.
    /// </summary>
    public required long? HomePoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("homePoints");
        }
        init { this._rawData.Set("homePoints", value); }
    }

    /// <summary>
    /// The away team's score once this scoring play counted.
    /// </summary>
    public required long? AwayPoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("awayPoints");
        }
        init { this._rawData.Set("awayPoints", value); }
    }

    /// <summary>
    /// The points the play scored.
    /// </summary>
    public required long? Points
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("points");
        }
        init { this._rawData.Set("points", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HomePoints;
        _ = this.AwayPoints;
        _ = this.Points;
    }

    public FootballPlayScore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayScore(FootballPlayScore footballPlayScore)
        : base(footballPlayScore) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayScore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayScore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayScoreFromRaw.FromRawUnchecked"/>
    public static FootballPlayScore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayScoreFromRaw : IFromRawJson<FootballPlayScore>
{
    /// <inheritdoc/>
    public FootballPlayScore FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlayScore.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballPlayStart, FootballPlayStartFromRaw>))]
public sealed record class FootballPlayStart : JsonModel
{
    /// <summary>
    /// The down, from 1 to 4.
    /// </summary>
    public required long? Down
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("down");
        }
        init { this._rawData.Set("down", value); }
    }

    /// <summary>
    /// The yards needed for a first down.
    /// </summary>
    public required long? YardsToGo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("yardsToGo");
        }
        init { this._rawData.Set("yardsToGo", value); }
    }

    /// <summary>
    /// The yard line of the ball.
    /// </summary>
    public required long? Yardline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("yardline");
        }
        init { this._rawData.Set("yardline", value); }
    }

    /// <summary>
    /// Whose half the ball was in. Home or Away in NFL games, the team's alternateId in college games.
    /// </summary>
    public required string? YardlineSide
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("yardlineSide");
        }
        init { this._rawData.Set("yardlineSide", value); }
    }

    /// <summary>
    /// The team with the ball. Home or Away in NFL games, the team's alternateId in college games.
    /// </summary>
    public required string? Possession
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("possession");
        }
        init { this._rawData.Set("possession", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Down;
        _ = this.YardsToGo;
        _ = this.Yardline;
        _ = this.YardlineSide;
        _ = this.Possession;
    }

    public FootballPlayStart() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayStart(FootballPlayStart footballPlayStart)
        : base(footballPlayStart) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayStart(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayStart(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayStartFromRaw.FromRawUnchecked"/>
    public static FootballPlayStart FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayStartFromRaw : IFromRawJson<FootballPlayStart>
{
    /// <inheritdoc/>
    public FootballPlayStart FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlayStart.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballPlayOnField, FootballPlayOnFieldFromRaw>))]
public sealed record class FootballPlayOnField : JsonModel
{
    /// <summary>
    /// Whether a penalty called the play back.
    /// </summary>
    public required bool? CalledBack
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("calledBack");
        }
        init { this._rawData.Set("calledBack", value); }
    }

    /// <summary>
    /// Whether a flag was thrown.
    /// </summary>
    public required bool? PenaltyOnField
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("penaltyOnField");
        }
        init { this._rawData.Set("penaltyOnField", value); }
    }

    /// <summary>
    /// Whether a timeout followed the play.
    /// </summary>
    public required bool? Timeout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("timeout");
        }
        init { this._rawData.Set("timeout", value); }
    }

    /// <summary>
    /// Whether officials were reviewing the play.
    /// </summary>
    public required bool? UnderReview
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("underReview");
        }
        init { this._rawData.Set("underReview", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CalledBack;
        _ = this.PenaltyOnField;
        _ = this.Timeout;
        _ = this.UnderReview;
    }

    public FootballPlayOnField() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayOnField(FootballPlayOnField footballPlayOnField)
        : base(footballPlayOnField) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayOnField(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayOnField(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayOnFieldFromRaw.FromRawUnchecked"/>
    public static FootballPlayOnField FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayOnFieldFromRaw : IFromRawJson<FootballPlayOnField>
{
    /// <inheritdoc/>
    public FootballPlayOnField FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlayOnField.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballPlayPost, FootballPlayPostFromRaw>))]
public sealed record class FootballPlayPost : JsonModel
{
    /// <summary>
    /// The post's ID.
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
    /// The username of the post's author, when X sends it.
    /// </summary>
    public required string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
    }

    public FootballPlayPost() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayPost(FootballPlayPost footballPlayPost)
        : base(footballPlayPost) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlayPost(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlayPost(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayPostFromRaw.FromRawUnchecked"/>
    public static FootballPlayPost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayPostFromRaw : IFromRawJson<FootballPlayPost>
{
    /// <inheritdoc/>
    public FootballPlayPost FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlayPost.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FootballPlay, FootballPlayFromRaw>))]
public sealed record class FootballPlay : JsonModel
{
    /// <summary>
    /// X's ID for the play within the game.
    /// </summary>
    public required string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The play's place in its drive, or null when X sends no digits.
    /// </summary>
    public required long? Sequence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sequence");
        }
        init { this._rawData.Set("sequence", value); }
    }

    /// <summary>
    /// The game clock when the play started, as HH:MM:SS.
    /// </summary>
    public required string? Clock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clock");
        }
        init { this._rawData.Set("clock", value); }
    }

    /// <summary>
    /// X's kind of play, such as Pass, Rush, Punt or Conversion.
    /// </summary>
    public required string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Where the play went, such as Left or Middle.
    /// </summary>
    public required string? Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// The play as the official play-by-play writes it.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Whether the play scored points.
    /// </summary>
    public required bool? Scoring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("scoring");
        }
        init { this._rawData.Set("scoring", value); }
    }

    /// <summary>
    /// The home team's points after the play.
    /// </summary>
    public required long? HomePoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("homePoints");
        }
        init { this._rawData.Set("homePoints", value); }
    }

    /// <summary>
    /// The away team's points after the play.
    /// </summary>
    public required long? AwayPoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("awayPoints");
        }
        init { this._rawData.Set("awayPoints", value); }
    }

    /// <summary>
    /// The points a scoring play added, or null.
    /// </summary>
    public required FootballPlayScore? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayScore>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// Down &amp; distance when the play started, or null.
    /// </summary>
    public required FootballPlayStart? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayStart>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <summary>
    /// Flags X shows on the field for the play, or null.
    /// </summary>
    public required FootballPlayOnField? OnField
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayOnField>("onField");
        }
        init { this._rawData.Set("onField", value); }
    }

    /// <summary>
    /// The play's steps, in order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.FootballPlayDetail> Details
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FootballPlayDetail>
            >("details");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FootballPlayDetail>>(
                "details",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The post X links to the play, or null.
    /// </summary>
    public required FootballPlayPost? Post
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FootballPlayPost>("post");
        }
        init { this._rawData.Set("post", value); }
    }

    /// <summary>
    /// The ID of a post with the play's video.
    /// </summary>
    public required string? VideoPostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("videoPostId");
        }
        init { this._rawData.Set("videoPostId", value); }
    }

    /// <summary>
    /// The ID of a reply with the play's video.
    /// </summary>
    public required string? VideoReplyPostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("videoReplyPostId");
        }
        init { this._rawData.Set("videoReplyPostId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Sequence;
        _ = this.Clock;
        _ = this.Type;
        _ = this.Direction;
        _ = this.Description;
        _ = this.Scoring;
        _ = this.HomePoints;
        _ = this.AwayPoints;
        this.Score?.Validate();
        this.Start?.Validate();
        this.OnField?.Validate();
        foreach (var item in this.Details)
        {
            item.Validate();
        }
        this.Post?.Validate();
        _ = this.VideoPostID;
        _ = this.VideoReplyPostID;
    }

    public FootballPlay() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlay(FootballPlay footballPlay)
        : base(footballPlay) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FootballPlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FootballPlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FootballPlayFromRaw.FromRawUnchecked"/>
    public static FootballPlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FootballPlayFromRaw : IFromRawJson<FootballPlay>
{
    /// <inheritdoc/>
    public FootballPlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FootballPlay.FromRawUnchecked(rawData);
}
