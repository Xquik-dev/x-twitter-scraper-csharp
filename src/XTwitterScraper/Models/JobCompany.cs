// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<JobCompany, JobCompanyFromRaw>))]
public sealed record class JobCompany : JsonModel
{
    /// <summary>
    /// X company profile ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Company name.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Company logo URL.
    /// </summary>
    public string? LogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logoUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.LogoUrl;
    }

    public JobCompany() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobCompany(JobCompany jobCompany)
        : base(jobCompany) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobCompanyFromRaw.FromRawUnchecked"/>
    public static JobCompany FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobCompanyFromRaw : IFromRawJson<JobCompany>
{
    /// <inheritdoc/>
    public JobCompany FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobCompany.FromRawUnchecked(rawData);
}
