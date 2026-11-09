// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Models = XTwitterScraper.Models;
using Sports = XTwitterScraper.Models.X.Sports;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class SportService : ISportService
{
    readonly Lazy<ISportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ISportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SportService(this._client.WithOptions(modifier));
    }

    public SportService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SportServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Models::FootballSchedule> ListGames(
        Sports::SportListGamesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListGames(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::FootballSchedule> ListGames(
        string league,
        Sports::SportListGamesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListGames(parameters with { League = league }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::FootballScoreboard> RetrieveScoreboard(
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveScoreboard(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::FootballScoreboard> RetrieveScoreboard(
        string id,
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveScoreboard(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::SportsGameAudience> RetrieveAudience(
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveAudience(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::SportsGameAudience> RetrieveAudience(
        string id,
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveAudience(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::FootballBoxScore> RetrieveBoxScore(
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveBoxScore(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::FootballBoxScore> RetrieveBoxScore(
        string id,
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveBoxScore(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::FootballPlays> RetrievePlays(
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrievePlays(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::FootballPlays> RetrievePlays(
        string id,
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrievePlays(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::FootballRoster> RetrieveRoster(
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveRoster(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::FootballRoster> RetrieveRoster(
        string id,
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRoster(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::FootballProps> RetrievePlayerProps(
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrievePlayerProps(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::FootballProps> RetrievePlayerProps(
        string id,
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrievePlayerProps(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::SportsGamePosts> ListPosts(
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPosts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::SportsGamePosts> ListPosts(
        string id,
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListPosts(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SportServiceWithRawResponse : ISportServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SportServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::FootballSchedule>> ListGames(
        Sports::SportListGamesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.League == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.League' cannot be null");
        }

        HttpRequest<Sports::SportListGamesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::FootballSchedule>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::FootballSchedule>> ListGames(
        string league,
        Sports::SportListGamesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListGames(parameters with { League = league }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::FootballScoreboard>> RetrieveScoreboard(
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Sports::SportRetrieveScoreboardParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::FootballScoreboard>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::FootballScoreboard>> RetrieveScoreboard(
        string id,
        Sports::SportRetrieveScoreboardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveScoreboard(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::SportsGameAudience>> RetrieveAudience(
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Sports::SportRetrieveAudienceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::SportsGameAudience>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::SportsGameAudience>> RetrieveAudience(
        string id,
        Sports::SportRetrieveAudienceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveAudience(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::FootballBoxScore>> RetrieveBoxScore(
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Sports::SportRetrieveBoxScoreParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::FootballBoxScore>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::FootballBoxScore>> RetrieveBoxScore(
        string id,
        Sports::SportRetrieveBoxScoreParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveBoxScore(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::FootballPlays>> RetrievePlays(
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Sports::SportRetrievePlaysParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::FootballPlays>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::FootballPlays>> RetrievePlays(
        string id,
        Sports::SportRetrievePlaysParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrievePlays(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::FootballRoster>> RetrieveRoster(
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Sports::SportRetrieveRosterParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::FootballRoster>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::FootballRoster>> RetrieveRoster(
        string id,
        Sports::SportRetrieveRosterParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRoster(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::FootballProps>> RetrievePlayerProps(
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Sports::SportRetrievePlayerPropsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::FootballProps>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::FootballProps>> RetrievePlayerProps(
        string id,
        Sports::SportRetrievePlayerPropsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrievePlayerProps(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::SportsGamePosts>> ListPosts(
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Sports::SportListPostsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::SportsGamePosts>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::SportsGamePosts>> ListPosts(
        string id,
        Sports::SportListPostsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListPosts(parameters with { ID = id }, cancellationToken);
    }
}
