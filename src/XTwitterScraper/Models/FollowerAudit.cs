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

[JsonConverter(typeof(JsonModelConverter<FollowerAuditCoverage, FollowerAuditCoverageFromRaw>))]
public sealed record class FollowerAuditCoverage : JsonModel
{
    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    public required long Read
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("read");
        }
        init { this._rawData.Set("read", value); }
    }

    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Percent;
        _ = this.Read;
        _ = this.Total;
    }

    public FollowerAuditCoverage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditCoverage(FollowerAuditCoverage followerAuditCoverage)
        : base(followerAuditCoverage) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditCoverage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAuditCoverage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditCoverageFromRaw.FromRawUnchecked"/>
    public static FollowerAuditCoverage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditCoverageFromRaw : IFromRawJson<FollowerAuditCoverage>
{
    /// <inheritdoc/>
    public FollowerAuditCoverage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerAuditCoverage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FollowerAuditQualityGradeConverter))]
public enum FollowerAuditQualityGrade
{
    A,
    B,
    C,
    D,
    F,
}

sealed class FollowerAuditQualityGradeConverter : JsonConverter<FollowerAuditQualityGrade>
{
    public override FollowerAuditQualityGrade Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "A" => FollowerAuditQualityGrade.A,
            "B" => FollowerAuditQualityGrade.B,
            "C" => FollowerAuditQualityGrade.C,
            "D" => FollowerAuditQualityGrade.D,
            "F" => FollowerAuditQualityGrade.F,
            _ => (FollowerAuditQualityGrade)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FollowerAuditQualityGrade value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FollowerAuditQualityGrade.A => "A",
                FollowerAuditQualityGrade.B => "B",
                FollowerAuditQualityGrade.C => "C",
                FollowerAuditQualityGrade.D => "D",
                FollowerAuditQualityGrade.F => "F",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<FollowerAuditQuality, FollowerAuditQualityFromRaw>))]
public sealed record class FollowerAuditQuality : JsonModel
{
    public required ApiEnum<string, FollowerAuditQualityGrade> Grade
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FollowerAuditQualityGrade>>(
                "grade"
            );
        }
        init { this._rawData.Set("grade", value); }
    }

    public required long Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Grade.Validate();
        _ = this.Score;
    }

    public FollowerAuditQuality() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditQuality(FollowerAuditQuality followerAuditQuality)
        : base(followerAuditQuality) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditQuality(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAuditQuality(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditQualityFromRaw.FromRawUnchecked"/>
    public static FollowerAuditQuality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditQualityFromRaw : IFromRawJson<FollowerAuditQuality>
{
    /// <inheritdoc/>
    public FollowerAuditQuality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerAuditQuality.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FollowerAuditClasses, FollowerAuditClassesFromRaw>))]
public sealed record class FollowerAuditClasses : JsonModel
{
    /// <summary>
    /// What 1 follower looks like from its public profile.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.FollowerClass> Class
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.FollowerClass>
            >("class");
        }
        init { this._rawData.Set("class", value); }
    }

    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Class.Validate();
        _ = this.Count;
        _ = this.Percent;
    }

    public FollowerAuditClasses() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditClasses(FollowerAuditClasses followerAuditClasses)
        : base(followerAuditClasses) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditClasses(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAuditClasses(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditClassesFromRaw.FromRawUnchecked"/>
    public static FollowerAuditClasses FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditClassesFromRaw : IFromRawJson<FollowerAuditClasses>
{
    /// <inheritdoc/>
    public FollowerAuditClasses FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerAuditClasses.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FollowerAuditSignals, FollowerAuditSignalsFromRaw>))]
public sealed record class FollowerAuditSignals : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    public required long Points
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("points");
        }
        init { this._rawData.Set("points", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.ID;
        _ = this.Percent;
        _ = this.Points;
    }

    public FollowerAuditSignals() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditSignals(FollowerAuditSignals followerAuditSignals)
        : base(followerAuditSignals) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditSignals(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAuditSignals(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditSignalsFromRaw.FromRawUnchecked"/>
    public static FollowerAuditSignals FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditSignalsFromRaw : IFromRawJson<FollowerAuditSignals>
{
    /// <inheritdoc/>
    public FollowerAuditSignals FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerAuditSignals.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<FollowerAuditArrivalBands, FollowerAuditArrivalBandsFromRaw>)
)]
public sealed record class FollowerAuditArrivalBands : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required long From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    public required long Read
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("read");
        }
        init { this._rawData.Set("read", value); }
    }

    public required long To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("to");
        }
        init { this._rawData.Set("to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.From;
        _ = this.Percent;
        _ = this.Read;
        _ = this.To;
    }

    public FollowerAuditArrivalBands() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditArrivalBands(FollowerAuditArrivalBands followerAuditArrivalBands)
        : base(followerAuditArrivalBands) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditArrivalBands(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAuditArrivalBands(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditArrivalBandsFromRaw.FromRawUnchecked"/>
    public static FollowerAuditArrivalBands FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditArrivalBandsFromRaw : IFromRawJson<FollowerAuditArrivalBands>
{
    /// <inheritdoc/>
    public FollowerAuditArrivalBands FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerAuditArrivalBands.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FollowerAuditCohorts, FollowerAuditCohortsFromRaw>))]
public sealed record class FollowerAuditCohorts : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required long LikelyFake
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("likelyFake");
        }
        init { this._rawData.Set("likelyFake", value); }
    }

    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    public required long WeekStartMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("weekStartMs");
        }
        init { this._rawData.Set("weekStartMs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.LikelyFake;
        _ = this.Percent;
        _ = this.WeekStartMs;
    }

    public FollowerAuditCohorts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditCohorts(FollowerAuditCohorts followerAuditCohorts)
        : base(followerAuditCohorts) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditCohorts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAuditCohorts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditCohortsFromRaw.FromRawUnchecked"/>
    public static FollowerAuditCohorts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditCohortsFromRaw : IFromRawJson<FollowerAuditCohorts>
{
    /// <inheritdoc/>
    public FollowerAuditCohorts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerAuditCohorts.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FollowerAuditVerified, FollowerAuditVerifiedFromRaw>))]
public sealed record class FollowerAuditVerified : JsonModel
{
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    public required double Percent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percent");
        }
        init { this._rawData.Set("percent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Percent;
    }

    public FollowerAuditVerified() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditVerified(FollowerAuditVerified followerAuditVerified)
        : base(followerAuditVerified) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAuditVerified(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAuditVerified(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditVerifiedFromRaw.FromRawUnchecked"/>
    public static FollowerAuditVerified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditVerifiedFromRaw : IFromRawJson<FollowerAuditVerified>
{
    /// <inheritdoc/>
    public FollowerAuditVerified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowerAuditVerified.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FollowerAudit, FollowerAuditFromRaw>))]
public sealed record class FollowerAudit : JsonModel
{
    /// <summary>
    /// Engagement insights of 1 profile. Engagements are likes, replies, reposts and quotes. A rate is null when nothing divides it, such as a profile without posts of its own.
    /// </summary>
    public required global::XTwitterScraper.Models.UserInsights Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.UserInsights>(
                "account"
            );
        }
        init { this._rawData.Set("account", value); }
    }

    public required FollowerAuditCoverage Coverage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FollowerAuditCoverage>("coverage");
        }
        init { this._rawData.Set("coverage", value); }
    }

    public required FollowerAuditQuality Quality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FollowerAuditQuality>("quality");
        }
        init { this._rawData.Set("quality", value); }
    }

    public required IReadOnlyList<FollowerAuditClasses> Classes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FollowerAuditClasses>>("classes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FollowerAuditClasses>>(
                "classes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<FollowerAuditSignals> Signals
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FollowerAuditSignals>>("signals");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FollowerAuditSignals>>(
                "signals",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Likely fake share by position in the newest-first list.
    /// </summary>
    public required IReadOnlyList<FollowerAuditArrivalBands> ArrivalBands
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FollowerAuditArrivalBands>>(
                "arrivalBands"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FollowerAuditArrivalBands>>(
                "arrivalBands",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Followers who joined X in the same UTC week.
    /// </summary>
    public required IReadOnlyList<FollowerAuditCohorts> Cohorts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FollowerAuditCohorts>>("cohorts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FollowerAuditCohorts>>(
                "cohorts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<global::XTwitterScraper.Models.FollowerValueCount> Languages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FollowerValueCount>
            >("languages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FollowerValueCount>>(
                "languages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<global::XTwitterScraper.Models.FollowerValueCount> Places
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.FollowerValueCount>
            >("places");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.FollowerValueCount>>(
                "places",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required FollowerAuditVerified Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FollowerAuditVerified>("verified");
        }
        init { this._rawData.Set("verified", value); }
    }

    public required IReadOnlyList<global::XTwitterScraper.Models.AuditedFollower> Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.AuditedFollower>
            >("followers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.AuditedFollower>>(
                "followers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<global::XTwitterScraper.Models.AuditedFollower> TopFollowers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.AuditedFollower>
            >("topFollowers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.AuditedFollower>>(
                "topFollowers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Account.Validate();
        this.Coverage.Validate();
        this.Quality.Validate();
        foreach (var item in this.Classes)
        {
            item.Validate();
        }
        foreach (var item in this.Signals)
        {
            item.Validate();
        }
        foreach (var item in this.ArrivalBands)
        {
            item.Validate();
        }
        foreach (var item in this.Cohorts)
        {
            item.Validate();
        }
        foreach (var item in this.Languages)
        {
            item.Validate();
        }
        foreach (var item in this.Places)
        {
            item.Validate();
        }
        this.Verified.Validate();
        foreach (var item in this.Followers)
        {
            item.Validate();
        }
        foreach (var item in this.TopFollowers)
        {
            item.Validate();
        }
    }

    public FollowerAudit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAudit(FollowerAudit followerAudit)
        : base(followerAudit) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FollowerAudit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerAudit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowerAuditFromRaw.FromRawUnchecked"/>
    public static FollowerAudit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowerAuditFromRaw : IFromRawJson<FollowerAudit>
{
    /// <inheritdoc/>
    public FollowerAudit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FollowerAudit.FromRawUnchecked(rawData);
}
