using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Profile;

[JsonConverter(typeof(JsonModelConverter<ProfilePatchAllResponse, ProfilePatchAllResponseFromRaw>))]
public sealed record class ProfilePatchAllResponse : JsonModel
{
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public ProfilePatchAllResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfilePatchAllResponse(ProfilePatchAllResponse profilePatchAllResponse)
        : base(profilePatchAllResponse) { }
#pragma warning restore CS8618

    public ProfilePatchAllResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfilePatchAllResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfilePatchAllResponseFromRaw.FromRawUnchecked"/>
    public static ProfilePatchAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfilePatchAllResponseFromRaw : IFromRawJson<ProfilePatchAllResponse>
{
    /// <inheritdoc/>
    public ProfilePatchAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfilePatchAllResponse.FromRawUnchecked(rawData);
}
