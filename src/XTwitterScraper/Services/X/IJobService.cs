// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Jobs = XTwitterScraper.Models.X.Jobs;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Job operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IJobService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJobServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns job listings with title, location, salary, company &amp; apply link. Add filters to narrow them. A closed job does not appear &amp; costs nothing. Follow next_cursor for more.
    /// </summary>
    Task<Models::PaginatedJobs> Search(
        Jobs::JobSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the places whose names match a query, each with the location ID that GET /x/jobs/search takes. No match returns an empty list, free.
    /// </summary>
    Task<Models::JobLocations> ListLocations(
        Jobs::JobListLocationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a public job listing with its description as text &amp; Markdown, work type, seniority, salary, company &amp; apply link. A job that closed returns job_not_found &amp; is free.
    /// </summary>
    Task<Jobs::JobRetrieveResponse> Retrieve(
        Jobs::JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Jobs::JobRetrieveParams, CancellationToken)"/>
    Task<Jobs::JobRetrieveResponse> Retrieve(
        string id,
        Jobs::JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJobService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJobServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/jobs/search</c>, but is otherwise the
    /// same as <see cref="IJobService.Search(Jobs::JobSearchParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::PaginatedJobs>> Search(
        Jobs::JobSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/jobs/locations</c>, but is otherwise the
    /// same as <see cref="IJobService.ListLocations(Jobs::JobListLocationsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::JobLocations>> ListLocations(
        Jobs::JobListLocationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /x/jobs/{id}</c>, but is otherwise the
    /// same as <see cref="IJobService.Retrieve(Jobs::JobRetrieveParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Jobs::JobRetrieveResponse>> Retrieve(
        Jobs::JobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(Jobs::JobRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Jobs::JobRetrieveResponse>> Retrieve(
        string id,
        Jobs::JobRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
