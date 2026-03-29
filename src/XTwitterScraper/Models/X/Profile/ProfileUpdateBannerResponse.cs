using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.X.Profile;

[JsonConverter(
    typeof(JsonModelConverter<ProfileUpdateBannerResponse, ProfileUpdateBannerResponseFromRaw>)
)]
public sealed record class ProfileUpdateBannerResponse : JsonModel
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

    public ProfileUpdateBannerResponse()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateBannerResponse(ProfileUpdateBannerResponse profileUpdateBannerResponse)
        : base(profileUpdateBannerResponse) { }
#pragma warning restore CS8618

    public ProfileUpdateBannerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateBannerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateBannerResponseFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateBannerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileUpdateBannerResponseFromRaw : IFromRawJson<ProfileUpdateBannerResponse>
{
    /// <inheritdoc/>
    public ProfileUpdateBannerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileUpdateBannerResponse.FromRawUnchecked(rawData);
}
