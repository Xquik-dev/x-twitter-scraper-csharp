using System;
using XTwitterScraper.Core;
using XTwitterScraper.Services.Bot;

namespace XTwitterScraper.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBotService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBotServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPlatformLinkService PlatformLinks { get; }
}

/// <summary>
/// A view of <see cref="IBotService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBotServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBotServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPlatformLinkServiceWithRawResponse PlatformLinks { get; }
}
