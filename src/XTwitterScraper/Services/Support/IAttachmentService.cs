// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Attachments = XTwitterScraper.Models.Support.Attachments;

namespace XTwitterScraper.Services.Support;

/// <summary>
/// Attachment operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IAttachmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAttachmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttachmentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Streams an authenticated user's support image or video. Video requests support 1 standard byte range for seeking and resumable playback.
    /// </summary>
    Task<HttpResponse> Download(
        Attachments::AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(Attachments::AttachmentDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        Attachments::AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAttachmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAttachmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttachmentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /support/attachments/{id}</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Download(Attachments::AttachmentDownloadParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse> Download(
        Attachments::AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(Attachments::AttachmentDownloadParams, CancellationToken)"/>
    Task<HttpResponse> Download(
        string id,
        Attachments::AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
