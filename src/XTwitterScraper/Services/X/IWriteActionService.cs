using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.WriteActions;

namespace XTwitterScraper.Services.X;

/// <summary>
/// X write actions (tweets, likes, follows, DMs)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWriteActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWriteActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWriteActionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get write action status
    /// </summary>
    Task<WriteActionRetrieveResponse> Retrieve(
        WriteActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WriteActionRetrieveParams, CancellationToken)"/>
    Task<WriteActionRetrieveResponse> Retrieve(
        string id,
        WriteActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWriteActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWriteActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWriteActionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/write-actions/{id}</c>, but is otherwise the
    /// same as <see cref="IWriteActionService.Retrieve(WriteActionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WriteActionRetrieveResponse>> Retrieve(
        WriteActionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WriteActionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WriteActionRetrieveResponse>> Retrieve(
        string id,
        WriteActionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
