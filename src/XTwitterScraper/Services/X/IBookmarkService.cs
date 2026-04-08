using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Bookmarks;

namespace XTwitterScraper.Services.X;

/// <summary>
/// X data lookups (subscription required)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBookmarkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBookmarkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookmarkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get bookmarked tweets
    /// </summary>
    Task<BookmarkListPage> List(
        BookmarkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get bookmark folders
    /// </summary>
    Task<BookmarkRetrieveFoldersResponse> RetrieveFolders(
        BookmarkRetrieveFoldersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBookmarkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBookmarkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBookmarkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/bookmarks</c>, but is otherwise the
    /// same as <see cref="IBookmarkService.List(BookmarkListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookmarkListPage>> List(
        BookmarkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/bookmarks/folders</c>, but is otherwise the
    /// same as <see cref="IBookmarkService.RetrieveFolders(BookmarkRetrieveFoldersParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BookmarkRetrieveFoldersResponse>> RetrieveFolders(
        BookmarkRetrieveFoldersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
