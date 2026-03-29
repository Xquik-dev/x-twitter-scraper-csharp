using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Services.Support;

/// <summary>
/// Support ticket management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITicketService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITicketServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITicketService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a support ticket
    /// </summary>
    Task<TicketCreateResponse> Create(
        TicketCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get ticket with all messages
    /// </summary>
    Task<TicketRetrieveResponse> Retrieve(
        TicketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TicketRetrieveParams, CancellationToken)"/>
    Task<TicketRetrieveResponse> Retrieve(
        string id,
        TicketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update ticket status
    /// </summary>
    Task<TicketUpdateResponse> Update(
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TicketUpdateParams, CancellationToken)"/>
    Task<TicketUpdateResponse> Update(
        string id,
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List user's support tickets
    /// </summary>
    Task<TicketListResponse> List(
        TicketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reply to a support ticket
    /// </summary>
    Task<TicketReplyResponse> Reply(
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reply(TicketReplyParams, CancellationToken)"/>
    Task<TicketReplyResponse> Reply(
        string id,
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITicketService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITicketServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITicketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /support/tickets</c>, but is otherwise the
    /// same as <see cref="ITicketService.Create(TicketCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TicketCreateResponse>> Create(
        TicketCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /support/tickets/{id}</c>, but is otherwise the
    /// same as <see cref="ITicketService.Retrieve(TicketRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TicketRetrieveResponse>> Retrieve(
        TicketRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TicketRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TicketRetrieveResponse>> Retrieve(
        string id,
        TicketRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /support/tickets/{id}</c>, but is otherwise the
    /// same as <see cref="ITicketService.Update(TicketUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TicketUpdateResponse>> Update(
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TicketUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TicketUpdateResponse>> Update(
        string id,
        TicketUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /support/tickets</c>, but is otherwise the
    /// same as <see cref="ITicketService.List(TicketListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TicketListResponse>> List(
        TicketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /support/tickets/{id}/messages</c>, but is otherwise the
    /// same as <see cref="ITicketService.Reply(TicketReplyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TicketReplyResponse>> Reply(
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reply(TicketReplyParams, CancellationToken)"/>
    Task<HttpResponse<TicketReplyResponse>> Reply(
        string id,
        TicketReplyParams parameters,
        CancellationToken cancellationToken = default
    );
}
