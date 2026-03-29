using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Services.Bot;

/// <summary>
/// Telegram bot service endpoints
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPlatformLinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPlatformLinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlatformLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Link a platform user to an Xquik account
    /// </summary>
    Task<PlatformLinkCreateResponse> Create(
        PlatformLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unlink a platform user from an Xquik account
    /// </summary>
    Task<PlatformLinkDeleteResponse> Delete(
        PlatformLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Look up an Xquik user by platform identity
    /// </summary>
    Task<PlatformLinkLookupResponse> Lookup(
        PlatformLinkLookupParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPlatformLinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPlatformLinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlatformLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /bot/platform-links</c>, but is otherwise the
    /// same as <see cref="IPlatformLinkService.Create(PlatformLinkCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlatformLinkCreateResponse>> Create(
        PlatformLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /bot/platform-links</c>, but is otherwise the
    /// same as <see cref="IPlatformLinkService.Delete(PlatformLinkDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlatformLinkDeleteResponse>> Delete(
        PlatformLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /bot/platform-links/lookup</c>, but is otherwise the
    /// same as <see cref="IPlatformLinkService.Lookup(PlatformLinkLookupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlatformLinkLookupResponse>> Lookup(
        PlatformLinkLookupParams parameters,
        CancellationToken cancellationToken = default
    );
}
