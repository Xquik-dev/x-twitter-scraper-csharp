using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Monitors = XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class MonitorService : IMonitorService
{
    readonly Lazy<IMonitorServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMonitorServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IMonitorService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MonitorService(this._client.WithOptions(modifier));
    }

    public MonitorService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MonitorServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Monitors::MonitorCreateResponse> Create(
        Monitors::MonitorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Monitors::Monitor> Retrieve(
        Monitors::MonitorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Monitors::Monitor> Retrieve(
        string id,
        Monitors::MonitorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Monitors::Monitor> Update(
        Monitors::MonitorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Monitors::Monitor> Update(
        string id,
        Monitors::MonitorUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Monitors::MonitorListResponse> List(
        Monitors::MonitorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Monitors::MonitorDeactivateResponse> Deactivate(
        Monitors::MonitorDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deactivate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Monitors::MonitorDeactivateResponse> Deactivate(
        string id,
        Monitors::MonitorDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MonitorServiceWithRawResponse : IMonitorServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMonitorServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MonitorServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MonitorServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Monitors::MonitorCreateResponse>> Create(
        Monitors::MonitorCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Monitors::MonitorCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var monitor = await response
                    .Deserialize<Monitors::MonitorCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    monitor.Validate();
                }
                return monitor;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Monitors::Monitor>> Retrieve(
        Monitors::MonitorRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Monitors::MonitorRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var monitor = await response
                    .Deserialize<Monitors::Monitor>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    monitor.Validate();
                }
                return monitor;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Monitors::Monitor>> Retrieve(
        string id,
        Monitors::MonitorRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Monitors::Monitor>> Update(
        Monitors::MonitorUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Monitors::MonitorUpdateParams> request = new()
        {
            Method = XTwitterScraperClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var monitor = await response
                    .Deserialize<Monitors::Monitor>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    monitor.Validate();
                }
                return monitor;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Monitors::Monitor>> Update(
        string id,
        Monitors::MonitorUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Monitors::MonitorListResponse>> List(
        Monitors::MonitorListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Monitors::MonitorListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var monitors = await response
                    .Deserialize<Monitors::MonitorListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    monitors.Validate();
                }
                return monitors;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Monitors::MonitorDeactivateResponse>> Deactivate(
        Monitors::MonitorDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Monitors::MonitorDeactivateParams> request = new()
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
                    .Deserialize<Monitors::MonitorDeactivateResponse>(token)
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
    public Task<HttpResponse<Monitors::MonitorDeactivateResponse>> Deactivate(
        string id,
        Monitors::MonitorDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { ID = id }, cancellationToken);
    }
}
