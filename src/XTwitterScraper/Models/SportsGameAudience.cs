// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(SportsGameAudienceLeagueConverter))]
public enum SportsGameAudienceLeague
{
    Nfl,
    Ncaafb,
}

sealed class SportsGameAudienceLeagueConverter : JsonConverter<SportsGameAudienceLeague>
{
    public override SportsGameAudienceLeague Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nfl" => SportsGameAudienceLeague.Nfl,
            "ncaafb" => SportsGameAudienceLeague.Ncaafb,
            _ => (SportsGameAudienceLeague)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SportsGameAudienceLeague value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SportsGameAudienceLeague.Nfl => "nfl",
                SportsGameAudienceLeague.Ncaafb => "ncaafb",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<SportsGameAudienceViewers, SportsGameAudienceViewersFromRaw>)
)]
public sealed record class SportsGameAudienceViewers : JsonModel
{
    /// <summary>
    /// How many people watched the game on X.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// When X counted them.
    /// </summary>
    public required DateTimeOffset AsOf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("asOf");
        }
        init { this._rawData.Set("asOf", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.AsOf;
    }

    public SportsGameAudienceViewers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceViewers(SportsGameAudienceViewers sportsGameAudienceViewers)
        : base(sportsGameAudienceViewers) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceViewers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGameAudienceViewers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGameAudienceViewersFromRaw.FromRawUnchecked"/>
    public static SportsGameAudienceViewers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGameAudienceViewersFromRaw : IFromRawJson<SportsGameAudienceViewers>
{
    /// <inheritdoc/>
    public SportsGameAudienceViewers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SportsGameAudienceViewers.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SportsGameAudienceTeamPicksTeams,
        SportsGameAudienceTeamPicksTeamsFromRaw
    >)
)]
public sealed record class SportsGameAudienceTeamPicksTeams : JsonModel
{
    /// <summary>
    /// The team ID, a key in teams.
    /// </summary>
    public required string TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("teamId");
        }
        init { this._rawData.Set("teamId", value); }
    }

    /// <summary>
    /// How many people picked this team.
    /// </summary>
    public required long? Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TeamID;
        _ = this.Count;
    }

    public SportsGameAudienceTeamPicksTeams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceTeamPicksTeams(
        SportsGameAudienceTeamPicksTeams sportsGameAudienceTeamPicksTeams
    )
        : base(sportsGameAudienceTeamPicksTeams) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceTeamPicksTeams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGameAudienceTeamPicksTeams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGameAudienceTeamPicksTeamsFromRaw.FromRawUnchecked"/>
    public static SportsGameAudienceTeamPicksTeams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGameAudienceTeamPicksTeamsFromRaw : IFromRawJson<SportsGameAudienceTeamPicksTeams>
{
    /// <inheritdoc/>
    public SportsGameAudienceTeamPicksTeams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SportsGameAudienceTeamPicksTeams.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SportsGameAudienceTeamPicks, SportsGameAudienceTeamPicksFromRaw>)
)]
public sealed record class SportsGameAudienceTeamPicks : JsonModel
{
    /// <summary>
    /// Picks for every team in the game.
    /// </summary>
    public required long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// Picks per team.
    /// </summary>
    public required IReadOnlyList<SportsGameAudienceTeamPicksTeams> Teams
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SportsGameAudienceTeamPicksTeams>>(
                "teams"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SportsGameAudienceTeamPicksTeams>>(
                "teams",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Total;
        foreach (var item in this.Teams)
        {
            item.Validate();
        }
    }

    public SportsGameAudienceTeamPicks() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceTeamPicks(SportsGameAudienceTeamPicks sportsGameAudienceTeamPicks)
        : base(sportsGameAudienceTeamPicks) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceTeamPicks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGameAudienceTeamPicks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGameAudienceTeamPicksFromRaw.FromRawUnchecked"/>
    public static SportsGameAudienceTeamPicks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGameAudienceTeamPicksFromRaw : IFromRawJson<SportsGameAudienceTeamPicks>
{
    /// <inheritdoc/>
    public SportsGameAudienceTeamPicks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SportsGameAudienceTeamPicks.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SportsGameAudienceChatOpensIn, SportsGameAudienceChatOpensInFromRaw>)
)]
public sealed record class SportsGameAudienceChatOpensIn : JsonModel
{
    /// <summary>
    /// Whole days left.
    /// </summary>
    public required long? Days
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("days");
        }
        init { this._rawData.Set("days", value); }
    }

    /// <summary>
    /// Hours left after the days.
    /// </summary>
    public required long? Hours
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("hours");
        }
        init { this._rawData.Set("hours", value); }
    }

    /// <summary>
    /// Minutes left after the hours.
    /// </summary>
    public required long? Minutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("minutes");
        }
        init { this._rawData.Set("minutes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Days;
        _ = this.Hours;
        _ = this.Minutes;
    }

    public SportsGameAudienceChatOpensIn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceChatOpensIn(
        SportsGameAudienceChatOpensIn sportsGameAudienceChatOpensIn
    )
        : base(sportsGameAudienceChatOpensIn) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceChatOpensIn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGameAudienceChatOpensIn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGameAudienceChatOpensInFromRaw.FromRawUnchecked"/>
    public static SportsGameAudienceChatOpensIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGameAudienceChatOpensInFromRaw : IFromRawJson<SportsGameAudienceChatOpensIn>
{
    /// <inheritdoc/>
    public SportsGameAudienceChatOpensIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SportsGameAudienceChatOpensIn.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SportsGameAudienceChat, SportsGameAudienceChatFromRaw>))]
public sealed record class SportsGameAudienceChat : JsonModel
{
    /// <summary>
    /// Whether the chat is open now.
    /// </summary>
    public required bool? Available
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("available");
        }
        init { this._rawData.Set("available", value); }
    }

    /// <summary>
    /// X's ID for the game's chat room.
    /// </summary>
    public required string? BroadcastID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("broadcastId");
        }
        init { this._rawData.Set("broadcastId", value); }
    }

    /// <summary>
    /// Time left until the chat opens. Null while it is open &amp; after the game.
    /// </summary>
    public required SportsGameAudienceChatOpensIn? OpensIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SportsGameAudienceChatOpensIn>("opensIn");
        }
        init { this._rawData.Set("opensIn", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Available;
        _ = this.BroadcastID;
        this.OpensIn?.Validate();
    }

    public SportsGameAudienceChat() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceChat(SportsGameAudienceChat sportsGameAudienceChat)
        : base(sportsGameAudienceChat) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudienceChat(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGameAudienceChat(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGameAudienceChatFromRaw.FromRawUnchecked"/>
    public static SportsGameAudienceChat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGameAudienceChatFromRaw : IFromRawJson<SportsGameAudienceChat>
{
    /// <inheritdoc/>
    public SportsGameAudienceChat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SportsGameAudienceChat.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SportsGameAudience, SportsGameAudienceFromRaw>))]
public sealed record class SportsGameAudience : JsonModel
{
    /// <summary>
    /// The ID of the game, from your request.
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
    /// The game's league, from your request.
    /// </summary>
    public required ApiEnum<string, SportsGameAudienceLeague> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SportsGameAudienceLeague>>(
                "league"
            );
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// People watching the game on X at X's last count. Null before X counts any, as before kickoff.
    /// </summary>
    public required SportsGameAudienceViewers? Viewers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SportsGameAudienceViewers>("viewers");
        }
        init { this._rawData.Set("viewers", value); }
    }

    /// <summary>
    /// How many people on X picked a team to root for.
    /// </summary>
    public required SportsGameAudienceTeamPicks TeamPicks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SportsGameAudienceTeamPicks>("teamPicks");
        }
        init { this._rawData.Set("teamPicks", value); }
    }

    /// <summary>
    /// The game's live chat on X.
    /// </summary>
    public required SportsGameAudienceChat Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SportsGameAudienceChat>("chat");
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// The game's teams, by team ID. Short name, alternate ID, X account &amp; record are null here.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Teams
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("teams");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "teams",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.League.Validate();
        this.Viewers?.Validate();
        this.TeamPicks.Validate();
        this.Chat.Validate();
        _ = this.Teams;
    }

    public SportsGameAudience() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudience(SportsGameAudience sportsGameAudience)
        : base(sportsGameAudience) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SportsGameAudience(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SportsGameAudience(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SportsGameAudienceFromRaw.FromRawUnchecked"/>
    public static SportsGameAudience FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SportsGameAudienceFromRaw : IFromRawJson<SportsGameAudience>
{
    /// <inheritdoc/>
    public SportsGameAudience FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SportsGameAudience.FromRawUnchecked(rawData);
}
