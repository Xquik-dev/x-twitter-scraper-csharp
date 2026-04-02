using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Services;

/// <summary>
/// Tweet composition, drafts, writing styles &amp; radar
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IStyleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStyleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStyleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List cached style profiles
    /// </summary>
    Task<StyleListResponse> List(
        StyleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Analyze writing style from recent tweets
    /// </summary>
    Task<StyleAnalyzeResponse> Analyze(
        StyleAnalyzeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Compare two style profiles
    /// </summary>
    Task<StyleCompareResponse> Compare(
        StyleCompareParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IStyleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IStyleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStyleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /styles</c>, but is otherwise the
    /// same as <see cref="IStyleService.List(StyleListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleListResponse>> List(
        StyleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /styles</c>, but is otherwise the
    /// same as <see cref="IStyleService.Analyze(StyleAnalyzeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleAnalyzeResponse>> Analyze(
        StyleAnalyzeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /styles/compare</c>, but is otherwise the
    /// same as <see cref="IStyleService.Compare(StyleCompareParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleCompareResponse>> Compare(
        StyleCompareParams parameters,
        CancellationToken cancellationToken = default
    );
}
