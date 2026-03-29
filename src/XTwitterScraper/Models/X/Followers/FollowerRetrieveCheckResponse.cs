using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Followers;

[JsonConverter(
    typeof(JsonModelConverter<FollowerRetrieveCheckResponse, FollowerRetrieveCheckResponseFromRaw>)
)]
public sealed record class FollowerRetrieveCheckResponse : JsonModel
{
    public required bool IsFollowedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isFollowedBy");
        }
        init { this._rawData.Set("isFollowedBy", value); }
    }

    public required bool IsFollowing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isFollowing");
        }
        init { this._rawData.Set("isFollowing", value); }
    }

    public required string SourceUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sourceUsername");
        }
        init { this._rawData.Set("sourceUsername", value); }
    }

    public required string TargetUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("targetUsername");
        }
        init { this._rawData.Set("targetUsername", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsFollowedBy;
        _ = this.IsFollowing;
        _ = this.SourceUsername;
        _ = this.TargetUsername;
    }

    public FollowerRetrieveCheckResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerRetrieveCheckResponse(
        FollowerRetrieveCheckResponse followerRetrieveCheckResponse
    )
        : base(followerRetrieveCheckResponse) { }
#pragma warning restore CS8618

    public FollowerRetrieveCheckResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerRetrieveCheckResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerRetrieveCheckResponseFromRaw.FromRawUnchecked"/>
    public static FollowerRetrieveCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerRetrieveCheckResponseFromRaw : IFromRawJson<FollowerRetrieveCheckResponse>
{
    /// <inheritdoc/>
    public FollowerRetrieveCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerRetrieveCheckResponse.FromRawUnchecked(rawData);
}
