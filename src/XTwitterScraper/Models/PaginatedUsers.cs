using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

/// <summary>
/// Paginated list of user profiles with cursor-based navigation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaginatedUsers, PaginatedUsersFromRaw>))]
public sealed record class PaginatedUsers : JsonModel
{
    public required bool HasNextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_next_page");
        }
        init { this._rawData.Set("has_next_page", value); }
    }

    public required string NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("next_cursor");
        }
        init { this._rawData.Set("next_cursor", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        _ = this.NextCursor;
        foreach (var item in this.Users)
        {
            item.Validate();
        }
    }

    public PaginatedUsers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedUsers(PaginatedUsers paginatedUsers)
        : base(paginatedUsers) { }
#pragma warning restore CS8618

    public PaginatedUsers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedUsers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedUsersFromRaw.FromRawUnchecked"/>
    public static PaginatedUsers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginatedUsersFromRaw : IFromRawJson<PaginatedUsers>
{
    /// <inheritdoc/>
    public PaginatedUsers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaginatedUsers.FromRawUnchecked(rawData);
}
