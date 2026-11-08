// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using CommunityNotes = XTwitterScraper.Models.X.CommunityNotes;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class CommunityNoteService : ICommunityNoteService
{
    readonly Lazy<ICommunityNoteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICommunityNoteServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ICommunityNoteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CommunityNoteService(this._client.WithOptions(modifier));
    }

    public CommunityNoteService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CommunityNoteServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CommunityNotes::CommunityNoteRetrieveContributorResponse> RetrieveContributor(
        CommunityNotes::CommunityNoteRetrieveContributorParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveContributor(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CommunityNotes::CommunityNoteRetrieveContributorResponse> RetrieveContributor(
        string alias,
        CommunityNotes::CommunityNoteRetrieveContributorParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContributor(parameters with { Alias = alias }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedCommunityNotes> ListContributorNotes(
        CommunityNotes::CommunityNoteListContributorNotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListContributorNotes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedCommunityNotes> ListContributorNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListContributorNotes(parameters with { Alias = alias }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Models::PaginatedCommunityNotes> ListContributorDeletedNotes(
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListContributorDeletedNotes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::PaginatedCommunityNotes> ListContributorDeletedNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListContributorDeletedNotes(
            parameters with
            {
                Alias = alias,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class CommunityNoteServiceWithRawResponse : ICommunityNoteServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICommunityNoteServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CommunityNoteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CommunityNoteServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<CommunityNotes::CommunityNoteRetrieveContributorResponse>
    > RetrieveContributor(
        CommunityNotes::CommunityNoteRetrieveContributorParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Alias == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.Alias' cannot be null");
        }

        HttpRequest<CommunityNotes::CommunityNoteRetrieveContributorParams> request = new()
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
                    .Deserialize<CommunityNotes::CommunityNoteRetrieveContributorResponse>(token)
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
    public Task<
        HttpResponse<CommunityNotes::CommunityNoteRetrieveContributorResponse>
    > RetrieveContributor(
        string alias,
        CommunityNotes::CommunityNoteRetrieveContributorParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContributor(parameters with { Alias = alias }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorNotes(
        CommunityNotes::CommunityNoteListContributorNotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Alias == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.Alias' cannot be null");
        }

        HttpRequest<CommunityNotes::CommunityNoteListContributorNotesParams> request = new()
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
                    .Deserialize<Models::PaginatedCommunityNotes>(token)
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
    public Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListContributorNotes(parameters with { Alias = alias }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorDeletedNotes(
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Alias == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.Alias' cannot be null");
        }

        HttpRequest<CommunityNotes::CommunityNoteListContributorDeletedNotesParams> request = new()
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
                    .Deserialize<Models::PaginatedCommunityNotes>(token)
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
    public Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorDeletedNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListContributorDeletedNotes(
            parameters with
            {
                Alias = alias,
            },
            cancellationToken
        );
    }
}
