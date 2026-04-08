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
    /// Get cached style profile
    /// </summary>
    Task<StyleProfile> Retrieve(
        StyleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(StyleRetrieveParams, CancellationToken)"/>
    Task<StyleProfile> Retrieve(
        string id,
        StyleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Save style profile with custom tweets
    /// </summary>
    Task<StyleProfile> Update(
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(StyleUpdateParams, CancellationToken)"/>
    Task<StyleProfile> Update(
        string id,
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List cached style profiles
    /// </summary>
    Task<StyleListResponse> List(
        StyleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a style profile
    /// </summary>
    Task Delete(StyleDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(StyleDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        StyleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Analyze writing style from recent tweets
    /// </summary>
    Task<StyleProfile> Analyze(
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

    /// <summary>
    /// Get engagement metrics for style tweets
    /// </summary>
    Task<StyleGetPerformanceResponse> GetPerformance(
        StyleGetPerformanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPerformance(StyleGetPerformanceParams, CancellationToken)"/>
    Task<StyleGetPerformanceResponse> GetPerformance(
        string id,
        StyleGetPerformanceParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /styles/{id}</c>, but is otherwise the
    /// same as <see cref="IStyleService.Retrieve(StyleRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleProfile>> Retrieve(
        StyleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(StyleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<StyleProfile>> Retrieve(
        string id,
        StyleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /styles/{id}</c>, but is otherwise the
    /// same as <see cref="IStyleService.Update(StyleUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleProfile>> Update(
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(StyleUpdateParams, CancellationToken)"/>
    Task<HttpResponse<StyleProfile>> Update(
        string id,
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /styles</c>, but is otherwise the
    /// same as <see cref="IStyleService.List(StyleListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleListResponse>> List(
        StyleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /styles/{id}</c>, but is otherwise the
    /// same as <see cref="IStyleService.Delete(StyleDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        StyleDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(StyleDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        StyleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /styles</c>, but is otherwise the
    /// same as <see cref="IStyleService.Analyze(StyleAnalyzeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleProfile>> Analyze(
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /styles/{id}/performance</c>, but is otherwise the
    /// same as <see cref="IStyleService.GetPerformance(StyleGetPerformanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<StyleGetPerformanceResponse>> GetPerformance(
        StyleGetPerformanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPerformance(StyleGetPerformanceParams, CancellationToken)"/>
    Task<HttpResponse<StyleGetPerformanceResponse>> GetPerformance(
        string id,
        StyleGetPerformanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
