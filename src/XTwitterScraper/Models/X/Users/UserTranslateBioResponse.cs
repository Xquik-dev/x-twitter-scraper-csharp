// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Users;

[JsonConverter(
    typeof(JsonModelConverter<UserTranslateBioResponse, UserTranslateBioResponseFromRaw>)
)]
public sealed record class UserTranslateBioResponse : JsonModel
{
    /// <summary>
    /// Null when the profile has no bio.
    /// </summary>
    public required global::XTwitterScraper.Models.ProfileTranslation? Translation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.ProfileTranslation>(
                "translation"
            );
        }
        init { this._rawData.Set("translation", value); }
    }

    /// <summary>
    /// Says why translation is null.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Translation?.Validate();
        _ = this.Message;
    }

    public UserTranslateBioResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserTranslateBioResponse(UserTranslateBioResponse userTranslateBioResponse)
        : base(userTranslateBioResponse) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserTranslateBioResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserTranslateBioResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserTranslateBioResponseFromRaw.FromRawUnchecked"/>
    public static UserTranslateBioResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserTranslateBioResponseFromRaw : IFromRawJson<UserTranslateBioResponse>
{
    /// <inheritdoc/>
    public UserTranslateBioResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserTranslateBioResponse.FromRawUnchecked(rawData);
}
