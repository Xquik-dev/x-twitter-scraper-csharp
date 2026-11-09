// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<Job, JobFromRaw>))]
public sealed record class Job : JsonModel
{
    /// <summary>
    /// Job ID.
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
    /// Job title.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <summary>
    /// The job page on X.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Where applicants apply, off X.
    /// </summary>
    public string? ApplyUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("applyUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("applyUrl", value);
        }
    }

    /// <summary>
    /// Location as the employer wrote it.
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// Where the work happens (onsite, remote or hybrid).
    /// </summary>
    public string? LocationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locationType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locationType", value);
        }
    }

    /// <summary>
    /// Contract type (full_time, full_time_contract, part_time or contract_to_hire).
    /// </summary>
    public string? EmploymentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("employmentType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("employmentType", value);
        }
    }

    /// <summary>
    /// Seniority (intern, entry_level, junior, mid_level, senior, lead, manager or executive).
    /// </summary>
    public string? SeniorityLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("seniorityLevel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("seniorityLevel", value);
        }
    }

    /// <summary>
    /// Job function, such as software_engineering.
    /// </summary>
    public string? JobFunction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("jobFunction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("jobFunction", value);
        }
    }

    /// <summary>
    /// Team inside the company.
    /// </summary>
    public string? Team
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("team");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("team", value);
        }
    }

    /// <summary>
    /// When the employer posted the job.
    /// </summary>
    public DateTimeOffset? PostedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("postedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postedAt", value);
        }
    }

    /// <summary>
    /// Salary as X shows it.
    /// </summary>
    public string? FormattedSalary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formattedSalary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("formattedSalary", value);
        }
    }

    /// <summary>
    /// Lowest salary, in salaryCurrencyCode per salaryInterval.
    /// </summary>
    public double? SalaryMin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("salaryMin");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("salaryMin", value);
        }
    }

    /// <summary>
    /// Highest salary, in salaryCurrencyCode per salaryInterval.
    /// </summary>
    public double? SalaryMax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("salaryMax");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("salaryMax", value);
        }
    }

    /// <summary>
    /// ISO 4217 currency code of the salary.
    /// </summary>
    public string? SalaryCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("salaryCurrencyCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("salaryCurrencyCode", value);
        }
    }

    /// <summary>
    /// Pay period of the salary (annually or hourly).
    /// </summary>
    public string? SalaryInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("salaryInterval");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("salaryInterval", value);
        }
    }

    /// <summary>
    /// Whether X features the job.
    /// </summary>
    public bool? Featured
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("featured");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("featured", value);
        }
    }

    /// <summary>
    /// Short summary of the job, as plain text.
    /// </summary>
    public string? ShortDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shortDescription");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shortDescription", value);
        }
    }

    /// <summary>
    /// Full description as plain text, 1 line per paragraph.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Full description as Markdown, with headings, lists, links, bold &amp; italics.
    /// </summary>
    public string? DescriptionMarkdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("descriptionMarkdown");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("descriptionMarkdown", value);
        }
    }

    /// <summary>
    /// The company profile of a job X imported from a job board.
    /// </summary>
    public global::XTwitterScraper.Models.JobCompany? Company
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.JobCompany>(
                "company"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company", value);
        }
    }

    /// <summary>
    /// The X account that posted a job. A job has none when X imported it from a job board or no longer shows the account.
    /// </summary>
    public global::XTwitterScraper.Models.JobAccount? Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.JobAccount>(
                "account"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Title;
        _ = this.UrlValue;
        _ = this.ApplyUrl;
        _ = this.Location;
        _ = this.LocationType;
        _ = this.EmploymentType;
        _ = this.SeniorityLevel;
        _ = this.JobFunction;
        _ = this.Team;
        _ = this.PostedAt;
        _ = this.FormattedSalary;
        _ = this.SalaryMin;
        _ = this.SalaryMax;
        _ = this.SalaryCurrencyCode;
        _ = this.SalaryInterval;
        _ = this.Featured;
        _ = this.ShortDescription;
        _ = this.Description;
        _ = this.DescriptionMarkdown;
        this.Company?.Validate();
        this.Account?.Validate();
    }

    public Job() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Job(Job job)
        : base(job) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Job(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Job(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobFromRaw.FromRawUnchecked"/>
    public static Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobFromRaw : IFromRawJson<Job>
{
    /// <inheritdoc/>
    public Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Job.FromRawUnchecked(rawData);
}
