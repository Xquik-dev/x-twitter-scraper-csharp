using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Compose;

namespace XTwitterScraper.Services;

/// <summary>
/// Tweet composition, drafts, writing styles &amp; radar
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IComposeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IComposeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComposeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Compose, refine, or score a tweet
    /// </summary>
    Task<Dictionary<string, JsonElement>> Create(
        ComposeCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IComposeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IComposeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IComposeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /compose</c>, but is otherwise the
    /// same as <see cref="IComposeService.Create(ComposeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> Create(
        ComposeCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
