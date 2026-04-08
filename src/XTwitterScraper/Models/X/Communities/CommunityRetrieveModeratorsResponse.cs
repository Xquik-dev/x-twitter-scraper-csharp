using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Communities;

/// <summary>
/// Paginated list of user profiles with cursor-based navigation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CommunityRetrieveModeratorsResponse,
        CommunityRetrieveModeratorsResponseFromRaw
    >)
)]
public sealed record class CommunityRetrieveModeratorsResponse : JsonModel
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

    public required IReadOnlyList<CommunityRetrieveModeratorsResponseUser> Users
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CommunityRetrieveModeratorsResponseUser>
            >("users");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CommunityRetrieveModeratorsResponseUser>>(
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

    public CommunityRetrieveModeratorsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityRetrieveModeratorsResponse(
        CommunityRetrieveModeratorsResponse communityRetrieveModeratorsResponse
    )
        : base(communityRetrieveModeratorsResponse) { }
#pragma warning restore CS8618

    public CommunityRetrieveModeratorsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityRetrieveModeratorsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityRetrieveModeratorsResponseFromRaw.FromRawUnchecked"/>
    public static CommunityRetrieveModeratorsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityRetrieveModeratorsResponseFromRaw : IFromRawJson<CommunityRetrieveModeratorsResponse>
{
    /// <inheritdoc/>
    public CommunityRetrieveModeratorsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityRetrieveModeratorsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// X user profile with bio, follower counts, and verification status.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CommunityRetrieveModeratorsResponseUser,
        CommunityRetrieveModeratorsResponseUserFromRaw
    >)
)]
public sealed record class CommunityRetrieveModeratorsResponseUser : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

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

    public long? Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("followers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("followers", value);
        }
    }

    public long? Following
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("following");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("following", value);
        }
    }

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

    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    public long? StatusesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("statusesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("statusesCount", value);
        }
    }

    public bool? Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("verified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verified", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Username;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Followers;
        _ = this.Following;
        _ = this.Location;
        _ = this.ProfilePicture;
        _ = this.StatusesCount;
        _ = this.Verified;
    }

    public CommunityRetrieveModeratorsResponseUser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityRetrieveModeratorsResponseUser(
        CommunityRetrieveModeratorsResponseUser communityRetrieveModeratorsResponseUser
    )
        : base(communityRetrieveModeratorsResponseUser) { }
#pragma warning restore CS8618

    public CommunityRetrieveModeratorsResponseUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityRetrieveModeratorsResponseUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityRetrieveModeratorsResponseUserFromRaw.FromRawUnchecked"/>
    public static CommunityRetrieveModeratorsResponseUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityRetrieveModeratorsResponseUserFromRaw
    : IFromRawJson<CommunityRetrieveModeratorsResponseUser>
{
    /// <inheritdoc/>
    public CommunityRetrieveModeratorsResponseUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityRetrieveModeratorsResponseUser.FromRawUnchecked(rawData);
}
