using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Media upload and download
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMediaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMediaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMediaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Download images and videos from tweets
    /// </summary>
    Task<MediaDownloadResponse> Download(
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload media
    /// </summary>
    Task<MediaUploadResponse> Upload(
        MediaUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMediaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMediaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMediaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/media/download</c>, but is otherwise the
    /// same as <see cref="IMediaService.Download(MediaDownloadParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MediaDownloadResponse>> Download(
        MediaDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/media</c>, but is otherwise the
    /// same as <see cref="IMediaService.Upload(MediaUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MediaUploadResponse>> Upload(
        MediaUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
