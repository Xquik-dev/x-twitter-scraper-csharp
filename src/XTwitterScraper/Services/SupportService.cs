// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using XTwitterScraper.Core;
using XTwitterScraper.Services.Support;
using Support = XTwitterScraper.Services.Support;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class SupportService : ISupportService
{
    readonly Lazy<ISupportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISupportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public ISupportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SupportService(this._client.WithOptions(modifier));
    }

    public SupportService(IXTwitterScraperClient client)
    {
        _client = client;

        _attachments = new(() => new Support::AttachmentService(client));
        _withRawResponse = new(() => new SupportServiceWithRawResponse(client.WithRawResponse));
        _tickets = new(() => new TicketService(client));
    }

    readonly Lazy<ITicketService> _tickets;
    public ITicketService Tickets
    {
        get { return _tickets.Value; }
    }

    readonly Lazy<Support::IAttachmentService> _attachments;
    public Support::IAttachmentService Attachments
    {
        get { return _attachments.Value; }
    }
}

/// <inheritdoc/>
public sealed class SupportServiceWithRawResponse : ISupportServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISupportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SupportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SupportServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;

        _attachments = new(() => new Support::AttachmentServiceWithRawResponse(client));
        _tickets = new(() => new TicketServiceWithRawResponse(client));
    }

    readonly Lazy<ITicketServiceWithRawResponse> _tickets;
    public ITicketServiceWithRawResponse Tickets
    {
        get { return _tickets.Value; }
    }

    readonly Lazy<Support::IAttachmentServiceWithRawResponse> _attachments;
    public Support::IAttachmentServiceWithRawResponse Attachments
    {
        get { return _attachments.Value; }
    }
}
