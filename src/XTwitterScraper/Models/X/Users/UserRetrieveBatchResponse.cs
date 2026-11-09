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
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Users;

/// <summary>
/// Batch user lookup results. Duplicate requested IDs are ignored while preserving
/// first-seen order. unavailable_ids identifies processed IDs with no returned profile.
/// unprocessed_ids identifies IDs skipped when available credits limit processing.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UserRetrieveBatchResponse, UserRetrieveBatchResponseFromRaw>)
)]
public sealed record class UserRetrieveBatchResponse : JsonModel
{
    /// <summary>
    /// Batch lookups never paginate.
    /// </summary>
    public JsonElement HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    /// <summary>
    /// Empty because batch lookups never paginate.
    /// </summary>
    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <summary>
    /// Number of requested IDs included in the lookup.
    /// </summary>
    public required long ProcessedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("processed_count");
        }
        init { this._rawData.Set("processed_count", value); }
    }

    /// <summary>
    /// Number of unique IDs requested.
    /// </summary>
    public required long RequestedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("requested_count");
        }
        init { this._rawData.Set("requested_count", value); }
    }

    /// <summary>
    /// Number of user profiles returned and charged.
    /// </summary>
    public required long ReturnedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("returned_count");
        }
        init { this._rawData.Set("returned_count", value); }
    }

    /// <summary>
    /// Processed IDs with no returned profile, in first-seen request order.
    /// </summary>
    public required IReadOnlyList<string> UnavailableIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("unavailable_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "unavailable_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Requested IDs skipped because available credits limited processing. Retry
    /// these IDs after adding credits.
    /// </summary>
    public required IReadOnlyList<string> UnprocessedIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("unprocessed_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "unprocessed_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<UserProfile> Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UserProfile>>("users");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UserProfile>>(
                "users",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Profiles rejected by the requested filters.
    /// </summary>
    public long? FilteredCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("filtered_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filtered_count", value);
        }
    }

    /// <summary>
    /// Processed IDs that failed to load, in first-seen request order. They cost nothing. Retry them.
    /// </summary>
    public IReadOnlyList<string>? FailedIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("failed_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "failed_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.HasNextPage, JsonSerializer.SerializeToElement(false)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.NextCursor;
        _ = this.ProcessedCount;
        _ = this.RequestedCount;
        _ = this.ReturnedCount;
        _ = this.UnavailableIds;
        _ = this.UnprocessedIds;
        foreach (var item in this.Users)
        {
            item.Validate();
        }
        _ = this.FilteredCount;
        _ = this.FailedIDs;
    }

    public UserRetrieveBatchResponse()
    {
        this.HasNextPage = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveBatchResponse(UserRetrieveBatchResponse userRetrieveBatchResponse)
        : base(userRetrieveBatchResponse) { }
#pragma warning restore CS8618

    public UserRetrieveBatchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.HasNextPage = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveBatchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveBatchResponseFromRaw.FromRawUnchecked"/>
    public static UserRetrieveBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveBatchResponseFromRaw : IFromRawJson<UserRetrieveBatchResponse>
{
    /// <inheritdoc/>
    public UserRetrieveBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveBatchResponse.FromRawUnchecked(rawData);
}
