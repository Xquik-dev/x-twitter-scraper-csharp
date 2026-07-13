using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.WriteActions;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class WriteActionService : IWriteActionService
{
    readonly Lazy<IWriteActionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWriteActionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IWriteActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WriteActionService(this._client.WithOptions(modifier));
    }

    public WriteActionService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WriteActionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<WriteActionRetrieveResponse> Retrieve(
        WriteActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WriteActionRetrieveResponse> Retrieve(
        string id,
        WriteActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WriteActionServiceWithRawResponse : IWriteActionServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWriteActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WriteActionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WriteActionServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WriteActionRetrieveResponse>> Retrieve(
        WriteActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WriteActionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var writeAction = await response
                    .Deserialize<WriteActionRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    writeAction.Validate();
                }
                return writeAction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WriteActionRetrieveResponse>> Retrieve(
        string id,
        WriteActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
