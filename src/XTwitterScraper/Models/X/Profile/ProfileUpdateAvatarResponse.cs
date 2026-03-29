using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Profile;

[JsonConverter(
    typeof(JsonModelConverter<ProfileUpdateAvatarResponse, ProfileUpdateAvatarResponseFromRaw>)
)]
public sealed record class ProfileUpdateAvatarResponse : JsonModel
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

    public ProfileUpdateAvatarResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateAvatarResponse(ProfileUpdateAvatarResponse profileUpdateAvatarResponse)
        : base(profileUpdateAvatarResponse) { }
#pragma warning restore CS8618

    public ProfileUpdateAvatarResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateAvatarResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateAvatarResponseFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateAvatarResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateAvatarResponseFromRaw : IFromRawJson<ProfileUpdateAvatarResponse>
{
    /// <inheritdoc/>
    public ProfileUpdateAvatarResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateAvatarResponse.FromRawUnchecked(rawData);
}
