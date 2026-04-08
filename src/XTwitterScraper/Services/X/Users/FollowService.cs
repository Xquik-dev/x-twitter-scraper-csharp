using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Users.Follow;

namespace XTwitterScraper.Services.X.Users;

/// <inheritdoc/>
public sealed class FollowService : IFollowService
{
    readonly Lazy<IFollowServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFollowServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IFollowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowService(this._client.WithOptions(modifier));
    }

    public FollowService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FollowServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FollowCreateResponse> Create(
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FollowCreateResponse> Create(
        string id,
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FollowDeleteAllResponse> DeleteAll(
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeleteAll(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FollowDeleteAllResponse> DeleteAll(
        string id,
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FollowServiceWithRawResponse : IFollowServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFollowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FollowServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FollowCreateResponse>> Create(
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FollowCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var follow = await response
                    .Deserialize<FollowCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    follow.Validate();
                }
                return follow;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FollowCreateResponse>> Create(
        string id,
        FollowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FollowDeleteAllResponse>> DeleteAll(
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FollowDeleteAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FollowDeleteAllResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FollowDeleteAllResponse>> DeleteAll(
        string id,
        FollowDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with { ID = id }, cancellationToken);
    }
}
