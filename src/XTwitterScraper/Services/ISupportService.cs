using System;
using XTwitterScraper.Core;
using XTwitterScraper.Services.Support;

namespace XTwitterScraper.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISupportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISupportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISupportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITicketService Tickets { get; }
}

/// <summary>
/// A view of <see cref="ISupportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISupportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISupportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITicketServiceWithRawResponse Tickets { get; }
}
