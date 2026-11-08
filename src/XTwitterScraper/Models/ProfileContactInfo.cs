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

namespace XTwitterScraper.Models;

[JsonConverter(typeof(ProfileContactInfoEmailsSourceConverter))]
public enum ProfileContactInfoEmailsSource
{
    Bio,
    Name,
    Location,
}

sealed class ProfileContactInfoEmailsSourceConverter : JsonConverter<ProfileContactInfoEmailsSource>
{
    public override ProfileContactInfoEmailsSource Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bio" => ProfileContactInfoEmailsSource.Bio,
            "name" => ProfileContactInfoEmailsSource.Name,
            "location" => ProfileContactInfoEmailsSource.Location,
            _ => (ProfileContactInfoEmailsSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileContactInfoEmailsSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileContactInfoEmailsSource.Bio => "bio",
                ProfileContactInfoEmailsSource.Name => "name",
                ProfileContactInfoEmailsSource.Location => "location",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ProfileContactInfoEmails, ProfileContactInfoEmailsFromRaw>)
)]
public sealed record class ProfileContactInfoEmails : JsonModel
{
    /// <summary>
    /// The email address.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// The part after the @ sign.
    /// </summary>
    public required string Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    /// <summary>
    /// Profile field that holds the email.
    /// </summary>
    public required ApiEnum<string, ProfileContactInfoEmailsSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ProfileContactInfoEmailsSource>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The account's own spelling, sent when it spelled the email out.
    /// </summary>
    public string? WrittenAs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("writtenAs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("writtenAs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Value;
        _ = this.Domain;
        this.Source.Validate();
        _ = this.WrittenAs;
    }

    public ProfileContactInfoEmails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileContactInfoEmails(ProfileContactInfoEmails profileContactInfoEmails)
        : base(profileContactInfoEmails) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileContactInfoEmails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileContactInfoEmails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileContactInfoEmailsFromRaw.FromRawUnchecked"/>
    public static ProfileContactInfoEmails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileContactInfoEmailsFromRaw : IFromRawJson<ProfileContactInfoEmails>
{
    /// <inheritdoc/>
    public ProfileContactInfoEmails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileContactInfoEmails.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileContactInfoPhonesSourceConverter))]
public enum ProfileContactInfoPhonesSource
{
    Bio,
    Name,
    Location,
    Url,
}

sealed class ProfileContactInfoPhonesSourceConverter : JsonConverter<ProfileContactInfoPhonesSource>
{
    public override ProfileContactInfoPhonesSource Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bio" => ProfileContactInfoPhonesSource.Bio,
            "name" => ProfileContactInfoPhonesSource.Name,
            "location" => ProfileContactInfoPhonesSource.Location,
            "url" => ProfileContactInfoPhonesSource.Url,
            _ => (ProfileContactInfoPhonesSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileContactInfoPhonesSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileContactInfoPhonesSource.Bio => "bio",
                ProfileContactInfoPhonesSource.Name => "name",
                ProfileContactInfoPhonesSource.Location => "location",
                ProfileContactInfoPhonesSource.Url => "url",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ProfileContactInfoPhones, ProfileContactInfoPhonesFromRaw>)
)]
public sealed record class ProfileContactInfoPhones : JsonModel
{
    /// <summary>
    /// The digits, with a leading + when the account wrote a country code.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Profile field that holds the number.
    /// </summary>
    public required ApiEnum<string, ProfileContactInfoPhonesSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ProfileContactInfoPhonesSource>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The account's own spelling of the number.
    /// </summary>
    public string? WrittenAs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("writtenAs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("writtenAs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Value;
        this.Source.Validate();
        _ = this.WrittenAs;
    }

    public ProfileContactInfoPhones() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileContactInfoPhones(ProfileContactInfoPhones profileContactInfoPhones)
        : base(profileContactInfoPhones) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileContactInfoPhones(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileContactInfoPhones(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileContactInfoPhonesFromRaw.FromRawUnchecked"/>
    public static ProfileContactInfoPhones FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileContactInfoPhonesFromRaw : IFromRawJson<ProfileContactInfoPhones>
{
    /// <inheritdoc/>
    public ProfileContactInfoPhones FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileContactInfoPhones.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ProfileContactInfoLinksSourceConverter))]
public enum ProfileContactInfoLinksSource
{
    Url,
    Bio,
}

sealed class ProfileContactInfoLinksSourceConverter : JsonConverter<ProfileContactInfoLinksSource>
{
    public override ProfileContactInfoLinksSource Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "url" => ProfileContactInfoLinksSource.Url,
            "bio" => ProfileContactInfoLinksSource.Bio,
            _ => (ProfileContactInfoLinksSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProfileContactInfoLinksSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProfileContactInfoLinksSource.Url => "url",
                ProfileContactInfoLinksSource.Bio => "bio",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ProfileContactInfoLinks, ProfileContactInfoLinksFromRaw>))]
public sealed record class ProfileContactInfoLinks : JsonModel
{
    /// <summary>
    /// The link, as X expands it.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Site the link belongs to, such as `linkedin`, `github` or `telegram`. Any other site is `website`.
    /// </summary>
    public required string Network
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("network");
        }
        init { this._rawData.Set("network", value); }
    }

    /// <summary>
    /// `url` for the website field, `bio` for a bio link.
    /// </summary>
    public required ApiEnum<string, ProfileContactInfoLinksSource> Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ProfileContactInfoLinksSource>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.Network;
        this.Source.Validate();
    }

    public ProfileContactInfoLinks() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileContactInfoLinks(ProfileContactInfoLinks profileContactInfoLinks)
        : base(profileContactInfoLinks) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileContactInfoLinks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileContactInfoLinks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileContactInfoLinksFromRaw.FromRawUnchecked"/>
    public static ProfileContactInfoLinks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileContactInfoLinksFromRaw : IFromRawJson<ProfileContactInfoLinks>
{
    /// <inheritdoc/>
    public ProfileContactInfoLinks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileContactInfoLinks.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProfileContactInfo, ProfileContactInfoFromRaw>))]
public sealed record class ProfileContactInfo : JsonModel
{
    /// <summary>
    /// Emails in the bio, name or location, lowercased.
    /// </summary>
    public IReadOnlyList<ProfileContactInfoEmails>? Emails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProfileContactInfoEmails>>(
                "emails"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileContactInfoEmails>?>(
                "emails",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Phone numbers on the profile. Only a spelling that can be nothing else counts.
    /// </summary>
    public IReadOnlyList<ProfileContactInfoPhones>? Phones
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProfileContactInfoPhones>>(
                "phones"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileContactInfoPhones>?>(
                "phones",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The profile's website &amp; the links in its bio.
    /// </summary>
    public IReadOnlyList<ProfileContactInfoLinks>? Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ProfileContactInfoLinks>>(
                "links"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ProfileContactInfoLinks>?>(
                "links",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Emails ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Phones ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Links ?? [])
        {
            item.Validate();
        }
    }

    public ProfileContactInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileContactInfo(ProfileContactInfo profileContactInfo)
        : base(profileContactInfo) { }
#pragma warning restore CS8618

    public ProfileContactInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileContactInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileContactInfoFromRaw.FromRawUnchecked"/>
    public static ProfileContactInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileContactInfoFromRaw : IFromRawJson<ProfileContactInfo>
{
    /// <inheritdoc/>
    public ProfileContactInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProfileContactInfo.FromRawUnchecked(rawData);
}
