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

[JsonConverter(
    typeof(JsonModelConverter<UserListCoverageStrategy, UserListCoverageStrategyFromRaw>)
)]
public sealed record class UserListCoverageStrategy : JsonModel
{
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
    /// Why the read stopped.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.CoverageStopReason> StopReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.CoverageStopReason>
            >("stopReason");
        }
        init { this._rawData.Set("stopReason", value); }
    }

    public required long Strategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("strategy");
        }
        init { this._rawData.Set("strategy", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long UniqueAdded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("uniqueAdded");
        }
        init { this._rawData.Set("uniqueAdded", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DuplicateCount;
        _ = this.PagesFetched;
        this.StopReason.Validate();
        _ = this.Strategy;
        _ = this.UniqueAdded;
    }

    public UserListCoverageStrategy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListCoverageStrategy(UserListCoverageStrategy userListCoverageStrategy)
        : base(userListCoverageStrategy) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListCoverageStrategy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListCoverageStrategy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListCoverageStrategyFromRaw.FromRawUnchecked"/>
    public static UserListCoverageStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListCoverageStrategyFromRaw : IFromRawJson<UserListCoverageStrategy>
{
    /// <inheritdoc/>
    public UserListCoverageStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserListCoverageStrategy.FromRawUnchecked(rawData);
}
