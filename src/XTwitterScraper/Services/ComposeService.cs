using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Compose;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class ComposeService : IComposeService
{
    readonly Lazy<IComposeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IComposeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IComposeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComposeService(this._client.WithOptions(modifier));
    }

    public ComposeService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ComposeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ComposeCreateResponse> Create(
        ComposeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ComposeServiceWithRawResponse : IComposeServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IComposeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComposeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ComposeServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ComposeCreateResponse>> Create(
        ComposeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ComposeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var compose = await response
                    .Deserialize<ComposeCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    compose.Validate();
                }
                return compose;
            }
        );
    }
}
