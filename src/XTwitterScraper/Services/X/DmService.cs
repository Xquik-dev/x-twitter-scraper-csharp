using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Dm;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class DmService : IDmService
{
    readonly Lazy<IDmServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDmServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IDmService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DmService(this._client.WithOptions(modifier));
    }

    public DmService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DmServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DmUpdateResponse> Update(
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DmUpdateResponse> Update(
        string userID,
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DmRetrieveHistoryResponse> RetrieveHistory(
        DmRetrieveHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveHistory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DmRetrieveHistoryResponse> RetrieveHistory(
        string userID,
        DmRetrieveHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveHistory(parameters with { UserID = userID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DmServiceWithRawResponse : IDmServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDmServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DmServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DmServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DmUpdateResponse>> Update(
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<DmUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dm = await response.Deserialize<DmUpdateResponse>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dm.Validate();
                }
                return dm;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DmUpdateResponse>> Update(
        string userID,
        DmUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DmRetrieveHistoryResponse>> RetrieveHistory(
        DmRetrieveHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<DmRetrieveHistoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<DmRetrieveHistoryResponse>(token)
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
    public Task<HttpResponse<DmRetrieveHistoryResponse>> RetrieveHistory(
        string userID,
        DmRetrieveHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveHistory(parameters with { UserID = userID }, cancellationToken);
    }
}
