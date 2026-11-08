// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(ExtractionRelationTargetRelationConverter))]
public enum ExtractionRelationTargetRelation
{
    CommunityMembers,
    Followers,
    Following,
    ListFollowers,
    ListMembers,
    VerifiedFollowers,
}

sealed class ExtractionRelationTargetRelationConverter
    : JsonConverter<ExtractionRelationTargetRelation>
{
    public override ExtractionRelationTargetRelation Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "community_members" => ExtractionRelationTargetRelation.CommunityMembers,
            "followers" => ExtractionRelationTargetRelation.Followers,
            "following" => ExtractionRelationTargetRelation.Following,
            "list_followers" => ExtractionRelationTargetRelation.ListFollowers,
            "list_members" => ExtractionRelationTargetRelation.ListMembers,
            "verified_followers" => ExtractionRelationTargetRelation.VerifiedFollowers,
            _ => (ExtractionRelationTargetRelation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionRelationTargetRelation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionRelationTargetRelation.CommunityMembers => "community_members",
                ExtractionRelationTargetRelation.Followers => "followers",
                ExtractionRelationTargetRelation.Following => "following",
                ExtractionRelationTargetRelation.ListFollowers => "list_followers",
                ExtractionRelationTargetRelation.ListMembers => "list_members",
                ExtractionRelationTargetRelation.VerifiedFollowers => "verified_followers",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ExtractionRelationTarget, ExtractionRelationTargetFromRaw>)
)]
public sealed record class ExtractionRelationTarget : JsonModel
{
    public required ApiEnum<string, ExtractionRelationTargetRelation> Relation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ExtractionRelationTargetRelation>>(
                "relation"
            );
        }
        init { this._rawData.Set("relation", value); }
    }

    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Relation.Validate();
        _ = this.Value;
    }

    public ExtractionRelationTarget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionRelationTarget(ExtractionRelationTarget extractionRelationTarget)
        : base(extractionRelationTarget) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractionRelationTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractionRelationTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractionRelationTargetFromRaw.FromRawUnchecked"/>
    public static ExtractionRelationTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractionRelationTargetFromRaw : IFromRawJson<ExtractionRelationTarget>
{
    /// <inheritdoc/>
    public ExtractionRelationTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractionRelationTarget.FromRawUnchecked(rawData);
}
