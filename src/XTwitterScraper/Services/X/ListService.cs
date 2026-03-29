using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
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
    public Task RetrieveFollowers(
        ListRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveFollowers(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveFollowers(
        string id,
        ListRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveFollowers(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task RetrieveMembers(
        ListRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveMembers(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveMembers(
        string id,
        ListRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveMembers(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task RetrieveTweets(
        ListRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveTweets(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task RetrieveTweets(
        string id,
        ListRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RetrieveTweets(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
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
    public Task<HttpResponse> RetrieveFollowers(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveFollowers(
        string id,
        ListRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFollowers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveMembers(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveMembers(
        string id,
        ListRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMembers(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveTweets(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveTweets(
        string id,
        ListRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTweets(parameters with { ID = id }, cancellationToken);
    }
}
