// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Attachments = XTwitterScraper.Models.Support.Attachments;

namespace XTwitterScraper.Services.Support;

/// <inheritdoc/>
public sealed class AttachmentService : IAttachmentService
{
    readonly Lazy<IAttachmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAttachmentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IAttachmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AttachmentService(this._client.WithOptions(modifier));
    }

    public AttachmentService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AttachmentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        Attachments::AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Download(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string id,
        Attachments::AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AttachmentServiceWithRawResponse : IAttachmentServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAttachmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AttachmentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AttachmentServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        Attachments::AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<Attachments::AttachmentDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string id,
        Attachments::AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with { ID = id }, cancellationToken);
    }
}
