using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Services.Support;

/// <inheritdoc/>
public sealed class TicketService : ITicketService
{
    readonly Lazy<ITicketServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITicketServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ITicketService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TicketService(this._client.WithOptions(modifier));
    }

    public TicketService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TicketServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TicketCreateResponse> Create(
        TicketCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TicketRetrieveResponse> Retrieve(
        TicketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TicketRetrieveResponse> Retrieve(
        string id,
        TicketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TicketUpdateResponse> Update(
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TicketUpdateResponse> Update(
        string id,
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TicketListResponse> List(
        TicketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TicketReplyResponse> Reply(
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reply(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TicketReplyResponse> Reply(
        string id,
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reply(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TicketServiceWithRawResponse : ITicketServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITicketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TicketServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TicketServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketCreateResponse>> Create(
        TicketCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TicketCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ticket = await response
                    .Deserialize<TicketCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ticket.Validate();
                }
                return ticket;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketRetrieveResponse>> Retrieve(
        TicketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TicketRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ticket = await response
                    .Deserialize<TicketRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ticket.Validate();
                }
                return ticket;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TicketRetrieveResponse>> Retrieve(
        string id,
        TicketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketUpdateResponse>> Update(
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TicketUpdateParams> request = new()
        {
            Method = XTwitterScraperClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ticket = await response
                    .Deserialize<TicketUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ticket.Validate();
                }
                return ticket;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TicketUpdateResponse>> Update(
        string id,
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketListResponse>> List(
        TicketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TicketListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tickets = await response
                    .Deserialize<TicketListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tickets.Validate();
                }
                return tickets;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketReplyResponse>> Reply(
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TicketReplyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TicketReplyResponse>(token)
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
    public Task<HttpResponse<TicketReplyResponse>> Reply(
        string id,
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reply(parameters with { ID = id }, cancellationToken);
    }
}
