using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Lists;

namespace XTwitterScraper.Services.X;

/// <summary>
/// X List followers, members, and tweets
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IListService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IListServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List followers of an X List
    /// </summary>
    Task<PaginatedUsers> RetrieveFollowers(
        ListRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowers(ListRetrieveFollowersParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveFollowers(
        string id,
        ListRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List members of an X List
    /// </summary>
    Task<PaginatedUsers> RetrieveMembers(
        ListRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMembers(ListRetrieveMembersParams, CancellationToken)"/>
    Task<PaginatedUsers> RetrieveMembers(
        string id,
        ListRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List tweets from an X List
    /// </summary>
    Task<PaginatedTweets> RetrieveTweets(
        ListRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTweets(ListRetrieveTweetsParams, CancellationToken)"/>
    Task<PaginatedTweets> RetrieveTweets(
        string id,
        ListRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IListService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IListServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/lists/{id}/followers</c>, but is otherwise the
    /// same as <see cref="IListService.RetrieveFollowers(ListRetrieveFollowersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
        ListRetrieveFollowersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFollowers(ListRetrieveFollowersParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveFollowers(
        string id,
        ListRetrieveFollowersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/lists/{id}/members</c>, but is otherwise the
    /// same as <see cref="IListService.RetrieveMembers(ListRetrieveMembersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
        ListRetrieveMembersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveMembers(ListRetrieveMembersParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedUsers>> RetrieveMembers(
        string id,
        ListRetrieveMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/lists/{id}/tweets</c>, but is otherwise the
    /// same as <see cref="IListService.RetrieveTweets(ListRetrieveTweetsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
        ListRetrieveTweetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveTweets(ListRetrieveTweetsParams, CancellationToken)"/>
    Task<HttpResponse<PaginatedTweets>> RetrieveTweets(
        string id,
        ListRetrieveTweetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
