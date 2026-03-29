using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Communities.Join;

namespace XTwitterScraper.Services.X.Communities;

/// <inheritdoc/>
public sealed class JoinService : IJoinService
{
    readonly Lazy<IJoinServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJoinServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IJoinService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JoinService(this._client.WithOptions(modifier));
    }

    public JoinService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new JoinServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<JoinCreateResponse> Create(
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JoinCreateResponse> Create(
        string id,
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JoinDeleteAllResponse> DeleteAll(
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeleteAll(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JoinDeleteAllResponse> DeleteAll(
        string id,
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class JoinServiceWithRawResponse : IJoinServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJoinServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JoinServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JoinServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JoinCreateResponse>> Create(
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<JoinCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var join = await response
                    .Deserialize<JoinCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    join.Validate();
                }
                return join;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JoinCreateResponse>> Create(
        string id,
        JoinCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JoinDeleteAllResponse>> DeleteAll(
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<JoinDeleteAllParams> request = new()
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
                    .Deserialize<JoinDeleteAllResponse>(token)
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
    public Task<HttpResponse<JoinDeleteAllResponse>> DeleteAll(
        string id,
        JoinDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with { ID = id }, cancellationToken);
    }
}
