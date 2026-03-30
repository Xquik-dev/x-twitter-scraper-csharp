using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Followers;

[JsonConverter(typeof(JsonModelConverter<FollowerCheckResponse, FollowerCheckResponseFromRaw>))]
public sealed record class FollowerCheckResponse : JsonModel
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

    public FollowerCheckResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerCheckResponse(FollowerCheckResponse followerCheckResponse)
        : base(followerCheckResponse) { }
#pragma warning restore CS8618

    public FollowerCheckResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerCheckResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerCheckResponseFromRaw.FromRawUnchecked"/>
    public static FollowerCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerCheckResponseFromRaw : IFromRawJson<FollowerCheckResponse>
{
    /// <inheritdoc/>
    public FollowerCheckResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerCheckResponse.FromRawUnchecked(rawData);
}
