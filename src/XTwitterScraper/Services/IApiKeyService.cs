using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.ApiKeys;

namespace XTwitterScraper.Services;

/// <summary>
/// API key management (session auth only)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IApiKeyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IApiKeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create API key
    /// </summary>
    Task<ApiKeyCreateResponse> Create(
        ApiKeyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List API keys
    /// </summary>
    Task<ApiKeyListResponse> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke API key
    /// </summary>
    Task<ApiKeyRevokeResponse> Revoke(
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(ApiKeyRevokeParams, CancellationToken)"/>
    Task<ApiKeyRevokeResponse> Revoke(
        string id,
        ApiKeyRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IApiKeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IApiKeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api-keys</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.Create(ApiKeyCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKeyCreateResponse>> Create(
        ApiKeyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api-keys</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.List(ApiKeyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKeyListResponse>> List(
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api-keys/{id}</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.Revoke(ApiKeyRevokeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKeyRevokeResponse>> Revoke(
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(ApiKeyRevokeParams, CancellationToken)"/>
    Task<HttpResponse<ApiKeyRevokeResponse>> Revoke(
        string id,
        ApiKeyRevokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
