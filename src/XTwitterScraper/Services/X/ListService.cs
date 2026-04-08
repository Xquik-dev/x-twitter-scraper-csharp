using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Lists;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class ListService : IListService
{
    readonly Lazy<IListServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    public ListService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ListServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveFollowers(
        ListRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFollowers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedUsers> RetrieveFollowers(
        string id,
        ListRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedUsers> RetrieveMembers(
        ListRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveMembers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedUsers> RetrieveMembers(
        string id,
        ListRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PaginatedTweets> RetrieveTweets(
        ListRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveTweets(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PaginatedTweets> RetrieveTweets(
        string id,
        ListRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTweets(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ListServiceWithRawResponse : IListServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ListServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
        ListRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ListRetrieveFollowersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var paginatedUsers = await response
                    .Deserialize<PaginatedUsers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedUsers.Validate();
                }
                return paginatedUsers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
        string id,
        ListRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
        ListRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ListRetrieveMembersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var paginatedUsers = await response
                    .Deserialize<PaginatedUsers>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedUsers.Validate();
                }
                return paginatedUsers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
        string id,
        ListRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
        ListRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ListRetrieveTweetsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var paginatedTweets = await response
                    .Deserialize<PaginatedTweets>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    paginatedTweets.Validate();
                }
                return paginatedTweets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
        string id,
        ListRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTweets(parameters with { ID = id }, cancellationToken);
    }
}
