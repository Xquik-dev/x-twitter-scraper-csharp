// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Jobs;

[JsonConverter(typeof(JsonModelConverter<JobRetrieveResponse, JobRetrieveResponseFromRaw>))]
public sealed record class JobRetrieveResponse : JsonModel
{
    /// <summary>
    /// Public X job listing. A search returns the fields down to the salary, plus company &amp; account. A lookup adds work type, seniority, function, team &amp; descriptions. A field X leaves empty is left out.
    /// </summary>
    public required global::XTwitterScraper.Models.Job Job
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.Job>("job");
        }
        init { this._rawData.Set("job", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Job.Validate();
    }

    public JobRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobRetrieveResponse(JobRetrieveResponse jobRetrieveResponse)
        : base(jobRetrieveResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static JobRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobRetrieveResponseFromRaw : IFromRawJson<JobRetrieveResponse>
{
    /// <inheritdoc/>
    public JobRetrieveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobRetrieveResponse.FromRawUnchecked(rawData);
}
