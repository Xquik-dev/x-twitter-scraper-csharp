// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Models = XTwitterScraper.Models;
using Sports = XTwitterScraper.Models.X.Sports;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Sport operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface ISportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Lists NFL or college football games in a time window, with teams &amp; scores. Use it to find game IDs &amp; team IDs. Without from or to, X picks about 5 weeks around today. Each request costs 1 credit.
    /// </summary>
    Task<Models::FootballSchedule> ListGames(
        Sports::SportListGamesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListGames(Sports::SportListGamesParams, CancellationToken)"/>
    Task<Models::FootballSchedule> ListGames(
        string league,
        Sports::SportListGamesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns 1 game's scoreboard. It has the teams, the score by period, the status &amp; clock, down &amp; distance, the venue &amp; the latest play. Each request costs 1 credit.
    /// </summary>
    Task<Models::FootballScoreboard> RetrieveScoreboard(
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveScoreboard(Sports::SportRetrieveScoreboardParams, CancellationToken)"/>
    Task<Models::FootballScoreboard> RetrieveScoreboard(
        string id,
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns who follows 1 game on X. It has live viewers, fan picks per team &amp; the game chat's state. Each request costs 1 credit.
    /// </summary>
    Task<Models::SportsGameAudience> RetrieveAudience(
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveAudience(Sports::SportRetrieveAudienceParams, CancellationToken)"/>
    Task<Models::SportsGameAudience> RetrieveAudience(
        string id,
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns each team's totals &amp; each player's stats for 1 game. Stats cover passing, rushing, receiving, defense, kicking &amp; returns. A game that has not started has no stats yet. Each request costs 1 credit.
    /// </summary>
    Task<Models::FootballBoxScore> RetrieveBoxScore(
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveBoxScore(Sports::SportRetrieveBoxScoreParams, CancellationToken)"/>
    Task<Models::FootballBoxScore> RetrieveBoxScore(
        string id,
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns every drive &amp; play of 1 game, by quarter. Each play has its clock, down &amp; distance, details, penalties &amp; linked posts. Each request costs 1 credit.
    /// </summary>
    Task<Models::FootballPlays> RetrievePlays(
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrievePlays(Sports::SportRetrievePlaysParams, CancellationToken)"/>
    Task<Models::FootballPlays> RetrievePlays(
        string id,
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns both teams' players for 1 NFL game. Each player has a jersey, position, headshot &amp; X account. Each request costs 1 credit.
    /// </summary>
    Task<Models::FootballRoster> RetrieveRoster(
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveRoster(Sports::SportRetrieveRosterParams, CancellationToken)"/>
    Task<Models::FootballRoster> RetrieveRoster(
        string id,
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the player prop lines &amp; American odds X shows for 1 NFL game. X lists props before &amp; during a game. Other games return no categories. Each request costs 1 credit.
    /// </summary>
    Task<Models::FootballProps> RetrievePlayerProps(
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrievePlayerProps(Sports::SportRetrievePlayerPropsParams, CancellationToken)"/>
    Task<Models::FootballProps> RetrievePlayerProps(
        string id,
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a game's top or latest posts, plus an X search you can run for more. Works before, during &amp; after the game. Pages hold up to 20 posts, &amp; each post costs 1 credit.
    /// </summary>
    Task<Models::SportsGamePosts> ListPosts(
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPosts(Sports::SportListPostsParams, CancellationToken)"/>
    Task<Models::SportsGamePosts> ListPosts(
        string id,
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games</c>, but is otherwise the
    /// same as <see cref="ISportService.ListGames(Sports::SportListGamesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::FootballSchedule>> ListGames(
        Sports::SportListGamesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListGames(Sports::SportListGamesParams, CancellationToken)"/>
    Task<HttpResponse<Models::FootballSchedule>> ListGames(
        string league,
        Sports::SportListGamesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games/{id}</c>, but is otherwise the
    /// same as <see cref="ISportService.RetrieveScoreboard(Sports::SportRetrieveScoreboardParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::FootballScoreboard>> RetrieveScoreboard(
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveScoreboard(Sports::SportRetrieveScoreboardParams, CancellationToken)"/>
    Task<HttpResponse<Models::FootballScoreboard>> RetrieveScoreboard(
        string id,
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games/{id}/audience</c>, but is otherwise the
    /// same as <see cref="ISportService.RetrieveAudience(Sports::SportRetrieveAudienceParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::SportsGameAudience>> RetrieveAudience(
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveAudience(Sports::SportRetrieveAudienceParams, CancellationToken)"/>
    Task<HttpResponse<Models::SportsGameAudience>> RetrieveAudience(
        string id,
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games/{id}/box-score</c>, but is otherwise the
    /// same as <see cref="ISportService.RetrieveBoxScore(Sports::SportRetrieveBoxScoreParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::FootballBoxScore>> RetrieveBoxScore(
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveBoxScore(Sports::SportRetrieveBoxScoreParams, CancellationToken)"/>
    Task<HttpResponse<Models::FootballBoxScore>> RetrieveBoxScore(
        string id,
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games/{id}/plays</c>, but is otherwise the
    /// same as <see cref="ISportService.RetrievePlays(Sports::SportRetrievePlaysParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::FootballPlays>> RetrievePlays(
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrievePlays(Sports::SportRetrievePlaysParams, CancellationToken)"/>
    Task<HttpResponse<Models::FootballPlays>> RetrievePlays(
        string id,
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games/{id}/roster</c>, but is otherwise the
    /// same as <see cref="ISportService.RetrieveRoster(Sports::SportRetrieveRosterParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::FootballRoster>> RetrieveRoster(
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveRoster(Sports::SportRetrieveRosterParams, CancellationToken)"/>
    Task<HttpResponse<Models::FootballRoster>> RetrieveRoster(
        string id,
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games/{id}/player-props</c>, but is otherwise the
    /// same as <see cref="ISportService.RetrievePlayerProps(Sports::SportRetrievePlayerPropsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::FootballProps>> RetrievePlayerProps(
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrievePlayerProps(Sports::SportRetrievePlayerPropsParams, CancellationToken)"/>
    Task<HttpResponse<Models::FootballProps>> RetrievePlayerProps(
        string id,
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/sports/{league}/games/{id}/posts</c>, but is otherwise the
    /// same as <see cref="ISportService.ListPosts(Sports::SportListPostsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::SportsGamePosts>> ListPosts(
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPosts(Sports::SportListPostsParams, CancellationToken)"/>
    Task<HttpResponse<Models::SportsGamePosts>> ListPosts(
        string id,
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    );
}
