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

[JsonConverter(typeof(JsonModelConverter<ProfileTranslation, ProfileTranslationFromRaw>))]
public sealed record class ProfileTranslation : JsonModel
{
    /// <summary>
    /// ID of the account whose bio X translated.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <summary>
    /// Username of that account.
    /// </summary>
    public required string UserName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("userName");
        }
        init { this._rawData.Set("userName", value); }
    }

    /// <summary>
    /// Language code of the translated bio, in lower case.
    /// </summary>
    public required string Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// Language code X detects in the bio, when it names one.
    /// </summary>
    public string? SourceLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sourceLanguage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sourceLanguage", value);
        }
    }

    /// <summary>
    /// Translated bio.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Lists hashtags, symbols, links, and mentions from tweet text.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetEntities Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetEntities>(
                "entities"
            );
        }
        init { this._rawData.Set("entities", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserID;
        _ = this.UserName;
        _ = this.Language;
        _ = this.SourceLanguage;
        _ = this.Text;
        this.Entities.Validate();
    }

    public ProfileTranslation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileTranslation(ProfileTranslation profileTranslation)
        : base(profileTranslation) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileTranslation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileTranslation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileTranslationFromRaw.FromRawUnchecked"/>
    public static ProfileTranslation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileTranslationFromRaw : IFromRawJson<ProfileTranslation>
{
    /// <inheritdoc/>
    public ProfileTranslation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileTranslation.FromRawUnchecked(rawData);
}
