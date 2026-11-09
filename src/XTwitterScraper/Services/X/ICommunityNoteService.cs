// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using CommunityNotes = XTwitterScraper.Models.X.CommunityNotes;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <summary>
/// CommunityNote operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface ICommunityNoteService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICommunityNoteServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommunityNoteService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns 1 Community Notes contributor by the alias X gives them. Includes note counts by rating, rating counts &amp; the deleted notes count. Each lookup costs 1 credit.
    /// </summary>
    Task<CommunityNotes::CommunityNoteRetrieveContributorResponse> RetrieveContributor(
        CommunityNotes::CommunityNoteRetrieveContributorParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContributor(CommunityNotes::CommunityNoteRetrieveContributorParams, CancellationToken)"/>
    Task<CommunityNotes::CommunityNoteRetrieveContributorResponse> RetrieveContributor(
        string alias,
        CommunityNotes::CommunityNoteRetrieveContributorParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a contributor's notes, newest first, each with the post it is on. Includes notes X has not rated helpful. Each note costs 1 credit. Follow next_cursor for more.
    /// </summary>
    Task<Models::PaginatedCommunityNotes> ListContributorNotes(
        CommunityNotes::CommunityNoteListContributorNotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListContributorNotes(CommunityNotes::CommunityNoteListContributorNotesParams, CancellationToken)"/>
    Task<Models::PaginatedCommunityNotes> ListContributorNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the notes a contributor deleted, newest first. X keeps each note's ID, times, rating &amp; tags. A notice replaces its text &amp; post. Each note costs 1 credit. A contributor who deleted none returns an empty list, free.
    /// </summary>
    Task<Models::PaginatedCommunityNotes> ListContributorDeletedNotes(
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListContributorDeletedNotes(CommunityNotes::CommunityNoteListContributorDeletedNotesParams, CancellationToken)"/>
    Task<Models::PaginatedCommunityNotes> ListContributorDeletedNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICommunityNoteService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICommunityNoteServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommunityNoteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/community-notes/contributors/{alias}</c>, but is otherwise the
    /// same as <see cref="ICommunityNoteService.RetrieveContributor(CommunityNotes::CommunityNoteRetrieveContributorParams, CancellationToken)"/>
    /// </summary>
    Task<
        HttpResponse<CommunityNotes::CommunityNoteRetrieveContributorResponse>
    > RetrieveContributor(
        CommunityNotes::CommunityNoteRetrieveContributorParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContributor(CommunityNotes::CommunityNoteRetrieveContributorParams, CancellationToken)"/>
    Task<
        HttpResponse<CommunityNotes::CommunityNoteRetrieveContributorResponse>
    > RetrieveContributor(
        string alias,
        CommunityNotes::CommunityNoteRetrieveContributorParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/community-notes/contributors/{alias}/notes</c>, but is otherwise the
    /// same as <see cref="ICommunityNoteService.ListContributorNotes(CommunityNotes::CommunityNoteListContributorNotesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorNotes(
        CommunityNotes::CommunityNoteListContributorNotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListContributorNotes(CommunityNotes::CommunityNoteListContributorNotesParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/community-notes/contributors/{alias}/deleted-notes</c>, but is otherwise the
    /// same as <see cref="ICommunityNoteService.ListContributorDeletedNotes(CommunityNotes::CommunityNoteListContributorDeletedNotesParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorDeletedNotes(
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListContributorDeletedNotes(CommunityNotes::CommunityNoteListContributorDeletedNotesParams, CancellationToken)"/>
    Task<HttpResponse<Models::PaginatedCommunityNotes>> ListContributorDeletedNotes(
        string alias,
        CommunityNotes::CommunityNoteListContributorDeletedNotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
