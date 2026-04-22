using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Communities;
using Communities = XTwitterScraper.Services.X.Communities;

namespace XTwitterScraper.Services.X;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICommunityService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICommunityServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommunityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Communities::IJoinService Join { get; }

    Communities::ITweetService Tweets { get; }

    /// <summary>
    /// Create community
    /// </summary>
    Task<CommunityCreateResponse> Create(
        CommunityCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete community
    /// </summary>
    Task<CommunityDeleteResponse> Delete(
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CommunityDeleteParams, CancellationToken)"/>
    Task<CommunityDeleteResponse> Delete(
        string id,
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get community name, description and member count
    /// </summary>
    Task<CommunityRetrieveInfoResponse> RetrieveInfo(
        CommunityRetrieveInfoParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveInfo(CommunityRetrieveInfoParams, CancellationToken)"/>
    Task<CommunityRetrieveInfoResponse> RetrieveInfo(
        string id,
        CommunityRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List members of a community
    /// </summary>
    Task<PaginatedUsers> RetrieveMembers(
        CommunityRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMembers(CommunityRetrieveMembersParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveMembers(
        string id,
        CommunityRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List moderators of a community
    /// </summary>
    Task<PaginatedUsers> RetrieveModerators(
        CommunityRetrieveModeratorsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveModerators(CommunityRetrieveModeratorsParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveModerators(
        string id,
        CommunityRetrieveModeratorsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search for communities by keyword
    /// </summary>
    Task<PaginatedTweets> RetrieveSearch(
        CommunityRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICommunityService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICommunityServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommunityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Communities::IJoinServiceWithRawResponse Join { get; }

    Communities::ITweetServiceWithRawResponse Tweets { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/communities</c>, but is otherwise the
    /// same as <see cref="ICommunityService.Create(CommunityCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CommunityCreateResponse>> Create(
        CommunityCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /x/communities/{id}</c>, but is otherwise the
    /// same as <see cref="ICommunityService.Delete(CommunityDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CommunityDeleteResponse>> Delete(
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CommunityDeleteParams, CancellationToken)"/>
    Task<HttpResponse<CommunityDeleteResponse>> Delete(
        string id,
        CommunityDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/communities/{id}/info</c>, but is otherwise the
    /// same as <see cref="ICommunityService.RetrieveInfo(CommunityRetrieveInfoParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CommunityRetrieveInfoResponse>> RetrieveInfo(
        CommunityRetrieveInfoParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveInfo(CommunityRetrieveInfoParams, CancellationToken)"/>
    Task<HttpResponse<CommunityRetrieveInfoResponse>> RetrieveInfo(
        string id,
        CommunityRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/communities/{id}/members</c>, but is otherwise the
    /// same as <see cref="ICommunityService.RetrieveMembers(CommunityRetrieveMembersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
        CommunityRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMembers(CommunityRetrieveMembersParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
        string id,
        CommunityRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/communities/{id}/moderators</c>, but is otherwise the
    /// same as <see cref="ICommunityService.RetrieveModerators(CommunityRetrieveModeratorsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveModerators(
        CommunityRetrieveModeratorsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveModerators(CommunityRetrieveModeratorsParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveModerators(
        string id,
        CommunityRetrieveModeratorsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/communities/search</c>, but is otherwise the
    /// same as <see cref="ICommunityService.RetrieveSearch(CommunityRetrieveSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> RetrieveSearch(
        CommunityRetrieveSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}
