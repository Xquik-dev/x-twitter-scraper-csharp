// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<UserListCoverageDiagnostic, UserListCoverageDiagnosticFromRaw>)
)]
public sealed record class UserListCoverageDiagnostic : JsonModel
{
    /// <summary>
    /// True when the result covers the whole query &amp; range.
    /// </summary>
    public required bool Complete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("complete");
        }
        init { this._rawData.Set("complete", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long CursorFailureCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cursorFailureCount");
        }
        init { this._rawData.Set("cursorFailureCount", value); }
    }

    public required bool DeadlineReached
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("deadlineReached");
        }
        init { this._rawData.Set("deadlineReached", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long DuplicateCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("duplicateCount");
        }
        init { this._rawData.Set("duplicateCount", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long FailedStrategyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("failedStrategyCount");
        }
        init { this._rawData.Set("failedStrategyCount", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long MalformedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("malformedCount");
        }
        init { this._rawData.Set("malformedCount", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long PagesFetched
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pagesFetched");
        }
        init { this._rawData.Set("pagesFetched", value); }
    }

    /// <summary>
    /// True when credits or the requested limit reduce output.
    /// </summary>
    public required bool ResponseTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("responseTruncated");
        }
        init { this._rawData.Set("responseTruncated", value); }
    }

    public required bool ResultLimitReached
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("resultLimitReached");
        }
        init { this._rawData.Set("resultLimitReached", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long StalledStrategyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("stalledStrategyCount");
        }
        init { this._rawData.Set("stalledStrategyCount", value); }
    }

    public required long StrategyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("strategyCount");
        }
        init { this._rawData.Set("strategyCount", value); }
    }

    public required long ReturnedUsers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("returnedUsers");
        }
        init { this._rawData.Set("returnedUsers", value); }
    }

    public required IReadOnlyList<global::XTwitterScraper.Models.UserListCoverageStrategy> Strategies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.UserListCoverageStrategy>
            >("strategies");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<global::XTwitterScraper.Models.UserListCoverageStrategy>
            >("strategies", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required long UniqueUsers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("uniqueUsers");
        }
        init { this._rawData.Set("uniqueUsers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Complete;
        _ = this.CursorFailureCount;
        _ = this.DeadlineReached;
        _ = this.DuplicateCount;
        _ = this.FailedStrategyCount;
        _ = this.MalformedCount;
        _ = this.PagesFetched;
        _ = this.ResponseTruncated;
        _ = this.ResultLimitReached;
        _ = this.StalledStrategyCount;
        _ = this.StrategyCount;
        _ = this.ReturnedUsers;
        foreach (var item in this.Strategies)
        {
            item.Validate();
        }
        _ = this.UniqueUsers;
    }

    public UserListCoverageDiagnostic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListCoverageDiagnostic(UserListCoverageDiagnostic userListCoverageDiagnostic)
        : base(userListCoverageDiagnostic) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListCoverageDiagnostic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListCoverageDiagnostic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListCoverageDiagnosticFromRaw.FromRawUnchecked"/>
    public static UserListCoverageDiagnostic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListCoverageDiagnosticFromRaw : IFromRawJson<UserListCoverageDiagnostic>
{
    /// <inheritdoc/>
    public UserListCoverageDiagnostic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserListCoverageDiagnostic.FromRawUnchecked(rawData);
}
