// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(ShadowbanReportAccountConverter))]
public enum ShadowbanReportAccount
{
    Active,
    Protected,
    Suspended,
}

sealed class ShadowbanReportAccountConverter : JsonConverter<ShadowbanReportAccount>
{
    public override ShadowbanReportAccount Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => ShadowbanReportAccount.Active,
            "protected" => ShadowbanReportAccount.Protected,
            "suspended" => ShadowbanReportAccount.Suspended,
            _ => (ShadowbanReportAccount)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportAccount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportAccount.Active => "active",
                ShadowbanReportAccount.Protected => "protected",
                ShadowbanReportAccount.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ShadowbanReportOverallConverter))]
public enum ShadowbanReportOverall
{
    Clear,
    Limited,
    Unclear,
    Suspended,
}

sealed class ShadowbanReportOverallConverter : JsonConverter<ShadowbanReportOverall>
{
    public override ShadowbanReportOverall Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "clear" => ShadowbanReportOverall.Clear,
            "limited" => ShadowbanReportOverall.Limited,
            "unclear" => ShadowbanReportOverall.Unclear,
            "suspended" => ShadowbanReportOverall.Suspended,
            _ => (ShadowbanReportOverall)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportOverall value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportOverall.Clear => "clear",
                ShadowbanReportOverall.Limited => "limited",
                ShadowbanReportOverall.Unclear => "unclear",
                ShadowbanReportOverall.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ShadowbanReportChecksAccountReasonConverter))]
public enum ShadowbanReportChecksAccountReason
{
    Active,
    Protected,
    Suspended,
}

sealed class ShadowbanReportChecksAccountReasonConverter
    : JsonConverter<ShadowbanReportChecksAccountReason>
{
    public override ShadowbanReportChecksAccountReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => ShadowbanReportChecksAccountReason.Active,
            "protected" => ShadowbanReportChecksAccountReason.Protected,
            "suspended" => ShadowbanReportChecksAccountReason.Suspended,
            _ => (ShadowbanReportChecksAccountReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksAccountReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksAccountReason.Active => "active",
                ShadowbanReportChecksAccountReason.Protected => "protected",
                ShadowbanReportChecksAccountReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksAccountEvidence,
        ShadowbanReportChecksAccountEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksAccountEvidence : JsonModel
{
    /// <summary>
    /// Profile of the account on X.
    /// </summary>
    public required string ProfileUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("profileUrl");
        }
        init { this._rawData.Set("profileUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProfileUrl;
    }

    public ShadowbanReportChecksAccountEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksAccountEvidence(
        ShadowbanReportChecksAccountEvidence shadowbanReportChecksAccountEvidence
    )
        : base(shadowbanReportChecksAccountEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksAccountEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksAccountEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksAccountEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksAccountEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksAccountEvidenceFromRaw
    : IFromRawJson<ShadowbanReportChecksAccountEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksAccountEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksAccountEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ShadowbanReportChecksAccount, ShadowbanReportChecksAccountFromRaw>)
)]
public sealed record class ShadowbanReportChecksAccount : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// State of the account on X.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksAccountReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksAccountReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Where to see the account on X.
    /// </summary>
    public required ShadowbanReportChecksAccountEvidence Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksAccountEvidence>("evidence");
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence.Validate();
    }

    public ShadowbanReportChecksAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksAccount(ShadowbanReportChecksAccount shadowbanReportChecksAccount)
        : base(shadowbanReportChecksAccount) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksAccountFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksAccountFromRaw : IFromRawJson<ShadowbanReportChecksAccount>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksSearchReasonConverter))]
public enum ShadowbanReportChecksSearchReason
{
    Listed,
    Missing,
    NoRecentPosts,
    Unavailable,
    Protected,
    Suspended,
}

sealed class ShadowbanReportChecksSearchReasonConverter
    : JsonConverter<ShadowbanReportChecksSearchReason>
{
    public override ShadowbanReportChecksSearchReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "listed" => ShadowbanReportChecksSearchReason.Listed,
            "missing" => ShadowbanReportChecksSearchReason.Missing,
            "no_recent_posts" => ShadowbanReportChecksSearchReason.NoRecentPosts,
            "unavailable" => ShadowbanReportChecksSearchReason.Unavailable,
            "protected" => ShadowbanReportChecksSearchReason.Protected,
            "suspended" => ShadowbanReportChecksSearchReason.Suspended,
            _ => (ShadowbanReportChecksSearchReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksSearchReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksSearchReason.Listed => "listed",
                ShadowbanReportChecksSearchReason.Missing => "missing",
                ShadowbanReportChecksSearchReason.NoRecentPosts => "no_recent_posts",
                ShadowbanReportChecksSearchReason.Unavailable => "unavailable",
                ShadowbanReportChecksSearchReason.Protected => "protected",
                ShadowbanReportChecksSearchReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksSearchEvidence,
        ShadowbanReportChecksSearchEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksSearchEvidence : JsonModel
{
    /// <summary>
    /// The search it ran.
    /// </summary>
    public required string Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    /// <summary>
    /// The same search on X, sorted by Latest.
    /// </summary>
    public required string SearchUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("searchUrl");
        }
        init { this._rawData.Set("searchUrl", value); }
    }

    /// <summary>
    /// Up to 5 recent posts of the account.
    /// </summary>
    public required IReadOnlyList<string> RecentPostIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("recentPostIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "recentPostIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Up to 5 posts of the account that search showed.
    /// </summary>
    public required IReadOnlyList<string> FoundPostIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("foundPostIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "foundPostIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Query;
        _ = this.SearchUrl;
        _ = this.RecentPostIDs;
        _ = this.FoundPostIDs;
    }

    public ShadowbanReportChecksSearchEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSearchEvidence(
        ShadowbanReportChecksSearchEvidence shadowbanReportChecksSearchEvidence
    )
        : base(shadowbanReportChecksSearchEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSearchEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksSearchEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksSearchEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksSearchEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksSearchEvidenceFromRaw : IFromRawJson<ShadowbanReportChecksSearchEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksSearchEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksSearchEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ShadowbanReportChecksSearch, ShadowbanReportChecksSearchFromRaw>)
)]
public sealed record class ShadowbanReportChecksSearch : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `listed` means search shows its posts &amp; `missing` means it shows none. `no_recent_posts` means the account has no recent post to look for.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksSearchReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksSearchReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The search &amp; the posts it looked for.
    /// </summary>
    public required ShadowbanReportChecksSearchEvidence? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShadowbanReportChecksSearchEvidence>("evidence");
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence?.Validate();
    }

    public ShadowbanReportChecksSearch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSearch(ShadowbanReportChecksSearch shadowbanReportChecksSearch)
        : base(shadowbanReportChecksSearch) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSearch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksSearch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksSearchFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksSearch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksSearchFromRaw : IFromRawJson<ShadowbanReportChecksSearch>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksSearch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksSearch.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksSuggestionReasonConverter))]
public enum ShadowbanReportChecksSuggestionReason
{
    Suggested,
    NotSuggested,
    Unavailable,
    Suspended,
}

sealed class ShadowbanReportChecksSuggestionReasonConverter
    : JsonConverter<ShadowbanReportChecksSuggestionReason>
{
    public override ShadowbanReportChecksSuggestionReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "suggested" => ShadowbanReportChecksSuggestionReason.Suggested,
            "not_suggested" => ShadowbanReportChecksSuggestionReason.NotSuggested,
            "unavailable" => ShadowbanReportChecksSuggestionReason.Unavailable,
            "suspended" => ShadowbanReportChecksSuggestionReason.Suspended,
            _ => (ShadowbanReportChecksSuggestionReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksSuggestionReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksSuggestionReason.Suggested => "suggested",
                ShadowbanReportChecksSuggestionReason.NotSuggested => "not_suggested",
                ShadowbanReportChecksSuggestionReason.Unavailable => "unavailable",
                ShadowbanReportChecksSuggestionReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksSuggestionEvidence,
        ShadowbanReportChecksSuggestionEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksSuggestionEvidence : JsonModel
{
    /// <summary>
    /// The username it typed.
    /// </summary>
    public required string Query
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("query");
        }
        init { this._rawData.Set("query", value); }
    }

    /// <summary>
    /// Up to 10 accounts X suggested, in its order.
    /// </summary>
    public required IReadOnlyList<string> SuggestedUsernames
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("suggestedUsernames");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "suggestedUsernames",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Query;
        _ = this.SuggestedUsernames;
    }

    public ShadowbanReportChecksSuggestionEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSuggestionEvidence(
        ShadowbanReportChecksSuggestionEvidence shadowbanReportChecksSuggestionEvidence
    )
        : base(shadowbanReportChecksSuggestionEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSuggestionEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksSuggestionEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksSuggestionEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksSuggestionEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksSuggestionEvidenceFromRaw
    : IFromRawJson<ShadowbanReportChecksSuggestionEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksSuggestionEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksSuggestionEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksSuggestion,
        ShadowbanReportChecksSuggestionFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksSuggestion : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `suggested` means X suggests the account for its username.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksSuggestionReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksSuggestionReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The username searched &amp; the accounts X suggested.
    /// </summary>
    public required ShadowbanReportChecksSuggestionEvidence? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShadowbanReportChecksSuggestionEvidence>(
                "evidence"
            );
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence?.Validate();
    }

    public ShadowbanReportChecksSuggestion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSuggestion(
        ShadowbanReportChecksSuggestion shadowbanReportChecksSuggestion
    )
        : base(shadowbanReportChecksSuggestion) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSuggestion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksSuggestion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksSuggestionFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksSuggestion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksSuggestionFromRaw : IFromRawJson<ShadowbanReportChecksSuggestion>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksSuggestion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksSuggestion.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksRepliesReasonConverter))]
public enum ShadowbanReportChecksRepliesReason
{
    InThread,
    MoreReplies,
    NoRecentReplies,
    NotFound,
    Unavailable,
    Protected,
    Suspended,
}

sealed class ShadowbanReportChecksRepliesReasonConverter
    : JsonConverter<ShadowbanReportChecksRepliesReason>
{
    public override ShadowbanReportChecksRepliesReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_thread" => ShadowbanReportChecksRepliesReason.InThread,
            "more_replies" => ShadowbanReportChecksRepliesReason.MoreReplies,
            "no_recent_replies" => ShadowbanReportChecksRepliesReason.NoRecentReplies,
            "not_found" => ShadowbanReportChecksRepliesReason.NotFound,
            "unavailable" => ShadowbanReportChecksRepliesReason.Unavailable,
            "protected" => ShadowbanReportChecksRepliesReason.Protected,
            "suspended" => ShadowbanReportChecksRepliesReason.Suspended,
            _ => (ShadowbanReportChecksRepliesReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksRepliesReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksRepliesReason.InThread => "in_thread",
                ShadowbanReportChecksRepliesReason.MoreReplies => "more_replies",
                ShadowbanReportChecksRepliesReason.NoRecentReplies => "no_recent_replies",
                ShadowbanReportChecksRepliesReason.NotFound => "not_found",
                ShadowbanReportChecksRepliesReason.Unavailable => "unavailable",
                ShadowbanReportChecksRepliesReason.Protected => "protected",
                ShadowbanReportChecksRepliesReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ShadowbanReportChecksRepliesEvidenceRepliesPlacementConverter))]
public enum ShadowbanReportChecksRepliesEvidenceRepliesPlacement
{
    Thread,
    MoreReplies,
    NotFound,
}

sealed class ShadowbanReportChecksRepliesEvidenceRepliesPlacementConverter
    : JsonConverter<ShadowbanReportChecksRepliesEvidenceRepliesPlacement>
{
    public override ShadowbanReportChecksRepliesEvidenceRepliesPlacement Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "thread" => ShadowbanReportChecksRepliesEvidenceRepliesPlacement.Thread,
            "more_replies" => ShadowbanReportChecksRepliesEvidenceRepliesPlacement.MoreReplies,
            "not_found" => ShadowbanReportChecksRepliesEvidenceRepliesPlacement.NotFound,
            _ => (ShadowbanReportChecksRepliesEvidenceRepliesPlacement)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksRepliesEvidenceRepliesPlacement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksRepliesEvidenceRepliesPlacement.Thread => "thread",
                ShadowbanReportChecksRepliesEvidenceRepliesPlacement.MoreReplies => "more_replies",
                ShadowbanReportChecksRepliesEvidenceRepliesPlacement.NotFound => "not_found",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksRepliesEvidenceReplies,
        ShadowbanReportChecksRepliesEvidenceRepliesFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksRepliesEvidenceReplies : JsonModel
{
    /// <summary>
    /// ID of the reply.
    /// </summary>
    public required string ReplyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("replyId");
        }
        init { this._rawData.Set("replyId", value); }
    }

    /// <summary>
    /// The reply on X.
    /// </summary>
    public required string ReplyUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("replyUrl");
        }
        init { this._rawData.Set("replyUrl", value); }
    }

    /// <summary>
    /// ID of the post it replies to.
    /// </summary>
    public required string ParentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("parentId");
        }
        init { this._rawData.Set("parentId", value); }
    }

    /// <summary>
    /// The thread of that post on X.
    /// </summary>
    public required string ParentUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("parentUrl");
        }
        init { this._rawData.Set("parentUrl", value); }
    }

    /// <summary>
    /// `thread` means the reply shows in the thread. `more_replies` means it shows only behind X's hidden replies prompt.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksRepliesEvidenceRepliesPlacement> Placement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksRepliesEvidenceRepliesPlacement>
            >("placement");
        }
        init { this._rawData.Set("placement", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReplyID;
        _ = this.ReplyUrl;
        _ = this.ParentID;
        _ = this.ParentUrl;
        this.Placement.Validate();
    }

    public ShadowbanReportChecksRepliesEvidenceReplies() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksRepliesEvidenceReplies(
        ShadowbanReportChecksRepliesEvidenceReplies shadowbanReportChecksRepliesEvidenceReplies
    )
        : base(shadowbanReportChecksRepliesEvidenceReplies) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksRepliesEvidenceReplies(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksRepliesEvidenceReplies(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksRepliesEvidenceRepliesFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksRepliesEvidenceReplies FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksRepliesEvidenceRepliesFromRaw
    : IFromRawJson<ShadowbanReportChecksRepliesEvidenceReplies>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksRepliesEvidenceReplies FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksRepliesEvidenceReplies.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksRepliesEvidence,
        ShadowbanReportChecksRepliesEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksRepliesEvidence : JsonModel
{
    /// <summary>
    /// Up to 3 replies, newest first.
    /// </summary>
    public required IReadOnlyList<ShadowbanReportChecksRepliesEvidenceReplies> Replies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ShadowbanReportChecksRepliesEvidenceReplies>
            >("replies");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ShadowbanReportChecksRepliesEvidenceReplies>>(
                "replies",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Replies)
        {
            item.Validate();
        }
    }

    public ShadowbanReportChecksRepliesEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksRepliesEvidence(
        ShadowbanReportChecksRepliesEvidence shadowbanReportChecksRepliesEvidence
    )
        : base(shadowbanReportChecksRepliesEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksRepliesEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksRepliesEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksRepliesEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksRepliesEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksRepliesEvidenceFromRaw
    : IFromRawJson<ShadowbanReportChecksRepliesEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksRepliesEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksRepliesEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ShadowbanReportChecksReplies, ShadowbanReportChecksRepliesFromRaw>)
)]
public sealed record class ShadowbanReportChecksReplies : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `more_replies` means X put a reply behind its hidden replies prompt. `not_found` means no reply showed on the pages the check read.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksRepliesReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksRepliesReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Each reply it opened &amp; where it showed.
    /// </summary>
    public required ShadowbanReportChecksRepliesEvidence? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShadowbanReportChecksRepliesEvidence>("evidence");
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence?.Validate();
    }

    public ShadowbanReportChecksReplies() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksReplies(ShadowbanReportChecksReplies shadowbanReportChecksReplies)
        : base(shadowbanReportChecksReplies) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksReplies(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksReplies(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksRepliesFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksReplies FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksRepliesFromRaw : IFromRawJson<ShadowbanReportChecksReplies>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksReplies FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksReplies.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksReplyLockReasonConverter))]
public enum ShadowbanReportChecksReplyLockReason
{
    RepliesShow,
    RepliesMissing,
    NoRecentReplies,
    Unavailable,
    Protected,
    Suspended,
}

sealed class ShadowbanReportChecksReplyLockReasonConverter
    : JsonConverter<ShadowbanReportChecksReplyLockReason>
{
    public override ShadowbanReportChecksReplyLockReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "replies_show" => ShadowbanReportChecksReplyLockReason.RepliesShow,
            "replies_missing" => ShadowbanReportChecksReplyLockReason.RepliesMissing,
            "no_recent_replies" => ShadowbanReportChecksReplyLockReason.NoRecentReplies,
            "unavailable" => ShadowbanReportChecksReplyLockReason.Unavailable,
            "protected" => ShadowbanReportChecksReplyLockReason.Protected,
            "suspended" => ShadowbanReportChecksReplyLockReason.Suspended,
            _ => (ShadowbanReportChecksReplyLockReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksReplyLockReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksReplyLockReason.RepliesShow => "replies_show",
                ShadowbanReportChecksReplyLockReason.RepliesMissing => "replies_missing",
                ShadowbanReportChecksReplyLockReason.NoRecentReplies => "no_recent_replies",
                ShadowbanReportChecksReplyLockReason.Unavailable => "unavailable",
                ShadowbanReportChecksReplyLockReason.Protected => "protected",
                ShadowbanReportChecksReplyLockReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksReplyLockEvidence,
        ShadowbanReportChecksReplyLockEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksReplyLockEvidence : JsonModel
{
    /// <summary>
    /// Replies it looked for, up to 3.
    /// </summary>
    public required long CheckedReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("checkedReplies");
        }
        init { this._rawData.Set("checkedReplies", value); }
    }

    /// <summary>
    /// Replies that showed in their thread.
    /// </summary>
    public required long ShownReplies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("shownReplies");
        }
        init { this._rawData.Set("shownReplies", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CheckedReplies;
        _ = this.ShownReplies;
    }

    public ShadowbanReportChecksReplyLockEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksReplyLockEvidence(
        ShadowbanReportChecksReplyLockEvidence shadowbanReportChecksReplyLockEvidence
    )
        : base(shadowbanReportChecksReplyLockEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksReplyLockEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksReplyLockEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksReplyLockEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksReplyLockEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksReplyLockEvidenceFromRaw
    : IFromRawJson<ShadowbanReportChecksReplyLockEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksReplyLockEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksReplyLockEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksReplyLock,
        ShadowbanReportChecksReplyLockFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksReplyLock : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `replies_show` means X showed at least 1 checked reply. `replies_missing` means it showed none on the pages read.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksReplyLockReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksReplyLockReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// How many replies it opened &amp; how many showed.
    /// </summary>
    public required ShadowbanReportChecksReplyLockEvidence? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShadowbanReportChecksReplyLockEvidence>(
                "evidence"
            );
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence?.Validate();
    }

    public ShadowbanReportChecksReplyLock() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksReplyLock(
        ShadowbanReportChecksReplyLock shadowbanReportChecksReplyLock
    )
        : base(shadowbanReportChecksReplyLock) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksReplyLock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksReplyLock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksReplyLockFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksReplyLock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksReplyLockFromRaw : IFromRawJson<ShadowbanReportChecksReplyLock>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksReplyLock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksReplyLock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksTimelineReasonConverter))]
public enum ShadowbanReportChecksTimelineReason
{
    Visible,
    Hidden,
    NoPosts,
    Unavailable,
    Protected,
    Suspended,
}

sealed class ShadowbanReportChecksTimelineReasonConverter
    : JsonConverter<ShadowbanReportChecksTimelineReason>
{
    public override ShadowbanReportChecksTimelineReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "visible" => ShadowbanReportChecksTimelineReason.Visible,
            "hidden" => ShadowbanReportChecksTimelineReason.Hidden,
            "no_posts" => ShadowbanReportChecksTimelineReason.NoPosts,
            "unavailable" => ShadowbanReportChecksTimelineReason.Unavailable,
            "protected" => ShadowbanReportChecksTimelineReason.Protected,
            "suspended" => ShadowbanReportChecksTimelineReason.Suspended,
            _ => (ShadowbanReportChecksTimelineReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksTimelineReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksTimelineReason.Visible => "visible",
                ShadowbanReportChecksTimelineReason.Hidden => "hidden",
                ShadowbanReportChecksTimelineReason.NoPosts => "no_posts",
                ShadowbanReportChecksTimelineReason.Unavailable => "unavailable",
                ShadowbanReportChecksTimelineReason.Protected => "protected",
                ShadowbanReportChecksTimelineReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksTimelineEvidence,
        ShadowbanReportChecksTimelineEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksTimelineEvidence : JsonModel
{
    /// <summary>
    /// Posts X counts on the profile.
    /// </summary>
    public required long? PostCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("postCount");
        }
        init { this._rawData.Set("postCount", value); }
    }

    /// <summary>
    /// Posts the timeline read returned, up to 20.
    /// </summary>
    public required long TimelinePosts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("timelinePosts");
        }
        init { this._rawData.Set("timelinePosts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PostCount;
        _ = this.TimelinePosts;
    }

    public ShadowbanReportChecksTimelineEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksTimelineEvidence(
        ShadowbanReportChecksTimelineEvidence shadowbanReportChecksTimelineEvidence
    )
        : base(shadowbanReportChecksTimelineEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksTimelineEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksTimelineEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksTimelineEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksTimelineEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksTimelineEvidenceFromRaw
    : IFromRawJson<ShadowbanReportChecksTimelineEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksTimelineEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksTimelineEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ShadowbanReportChecksTimeline, ShadowbanReportChecksTimelineFromRaw>)
)]
public sealed record class ShadowbanReportChecksTimeline : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `visible` means the timeline shows posts. `hidden` means X counts posts but shows none. `no_posts` means the account has none to show.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksTimelineReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksTimelineReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The post count on the profile &amp; the posts read.
    /// </summary>
    public required ShadowbanReportChecksTimelineEvidence? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShadowbanReportChecksTimelineEvidence>(
                "evidence"
            );
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence?.Validate();
    }

    public ShadowbanReportChecksTimeline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksTimeline(
        ShadowbanReportChecksTimeline shadowbanReportChecksTimeline
    )
        : base(shadowbanReportChecksTimeline) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksTimeline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksTimeline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksTimelineFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksTimeline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksTimelineFromRaw : IFromRawJson<ShadowbanReportChecksTimeline>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksTimeline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksTimeline.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksEngagementReasonConverter))]
public enum ShadowbanReportChecksEngagementReason
{
    Typical,
    Low,
    TooFewPosts,
    Unavailable,
    Protected,
    Suspended,
}

sealed class ShadowbanReportChecksEngagementReasonConverter
    : JsonConverter<ShadowbanReportChecksEngagementReason>
{
    public override ShadowbanReportChecksEngagementReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "typical" => ShadowbanReportChecksEngagementReason.Typical,
            "low" => ShadowbanReportChecksEngagementReason.Low,
            "too_few_posts" => ShadowbanReportChecksEngagementReason.TooFewPosts,
            "unavailable" => ShadowbanReportChecksEngagementReason.Unavailable,
            "protected" => ShadowbanReportChecksEngagementReason.Protected,
            "suspended" => ShadowbanReportChecksEngagementReason.Suspended,
            _ => (ShadowbanReportChecksEngagementReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksEngagementReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksEngagementReason.Typical => "typical",
                ShadowbanReportChecksEngagementReason.Low => "low",
                ShadowbanReportChecksEngagementReason.TooFewPosts => "too_few_posts",
                ShadowbanReportChecksEngagementReason.Unavailable => "unavailable",
                ShadowbanReportChecksEngagementReason.Protected => "protected",
                ShadowbanReportChecksEngagementReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksEngagementEvidence,
        ShadowbanReportChecksEngagementEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksEngagementEvidence : JsonModel
{
    /// <summary>
    /// Median engagement of the newest posts.
    /// </summary>
    public required double NewestMedian
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("newestMedian");
        }
        init { this._rawData.Set("newestMedian", value); }
    }

    /// <summary>
    /// Posts in the newest group, up to 5.
    /// </summary>
    public required long NewestPosts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("newestPosts");
        }
        init { this._rawData.Set("newestPosts", value); }
    }

    /// <summary>
    /// Median engagement of the earlier posts.
    /// </summary>
    public required double EarlierMedian
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("earlierMedian");
        }
        init { this._rawData.Set("earlierMedian", value); }
    }

    /// <summary>
    /// Posts in the earlier group.
    /// </summary>
    public required long EarlierPosts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("earlierPosts");
        }
        init { this._rawData.Set("earlierPosts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NewestMedian;
        _ = this.NewestPosts;
        _ = this.EarlierMedian;
        _ = this.EarlierPosts;
    }

    public ShadowbanReportChecksEngagementEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksEngagementEvidence(
        ShadowbanReportChecksEngagementEvidence shadowbanReportChecksEngagementEvidence
    )
        : base(shadowbanReportChecksEngagementEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksEngagementEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksEngagementEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksEngagementEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksEngagementEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksEngagementEvidenceFromRaw
    : IFromRawJson<ShadowbanReportChecksEngagementEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksEngagementEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksEngagementEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksEngagement,
        ShadowbanReportChecksEngagementFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksEngagement : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `too_few_posts` means fewer than 8 posts to compare, or earlier posts with no engagement.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksEngagementReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksEngagementReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The 2 medians &amp; how many posts each one covers.
    /// </summary>
    public required ShadowbanReportChecksEngagementEvidence? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShadowbanReportChecksEngagementEvidence>(
                "evidence"
            );
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence?.Validate();
    }

    public ShadowbanReportChecksEngagement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksEngagement(
        ShadowbanReportChecksEngagement shadowbanReportChecksEngagement
    )
        : base(shadowbanReportChecksEngagement) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksEngagement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksEngagement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksEngagementFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksEngagement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksEngagementFromRaw : IFromRawJson<ShadowbanReportChecksEngagement>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksEngagement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksEngagement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksSensitiveReasonConverter))]
public enum ShadowbanReportChecksSensitiveReason
{
    NotFlagged,
    Flagged,
    Unknown,
    Suspended,
}

sealed class ShadowbanReportChecksSensitiveReasonConverter
    : JsonConverter<ShadowbanReportChecksSensitiveReason>
{
    public override ShadowbanReportChecksSensitiveReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_flagged" => ShadowbanReportChecksSensitiveReason.NotFlagged,
            "flagged" => ShadowbanReportChecksSensitiveReason.Flagged,
            "unknown" => ShadowbanReportChecksSensitiveReason.Unknown,
            "suspended" => ShadowbanReportChecksSensitiveReason.Suspended,
            _ => (ShadowbanReportChecksSensitiveReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksSensitiveReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksSensitiveReason.NotFlagged => "not_flagged",
                ShadowbanReportChecksSensitiveReason.Flagged => "flagged",
                ShadowbanReportChecksSensitiveReason.Unknown => "unknown",
                ShadowbanReportChecksSensitiveReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksSensitive,
        ShadowbanReportChecksSensitiveFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksSensitive : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `unknown` means X left the flag out of the profile.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksSensitiveReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksSensitiveReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Always null, since the reason holds the answer.
    /// </summary>
    public required JsonElement? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("evidence");
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        _ = this.Evidence;
    }

    public ShadowbanReportChecksSensitive() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSensitive(
        ShadowbanReportChecksSensitive shadowbanReportChecksSensitive
    )
        : base(shadowbanReportChecksSensitive) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksSensitive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksSensitive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksSensitiveFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksSensitive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksSensitiveFromRaw : IFromRawJson<ShadowbanReportChecksSensitive>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksSensitive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksSensitive.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ShadowbanReportChecksWithheldReasonConverter))]
public enum ShadowbanReportChecksWithheldReason
{
    None,
    Countries,
    Suspended,
}

sealed class ShadowbanReportChecksWithheldReasonConverter
    : JsonConverter<ShadowbanReportChecksWithheldReason>
{
    public override ShadowbanReportChecksWithheldReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => ShadowbanReportChecksWithheldReason.None,
            "countries" => ShadowbanReportChecksWithheldReason.Countries,
            "suspended" => ShadowbanReportChecksWithheldReason.Suspended,
            _ => (ShadowbanReportChecksWithheldReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowbanReportChecksWithheldReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShadowbanReportChecksWithheldReason.None => "none",
                ShadowbanReportChecksWithheldReason.Countries => "countries",
                ShadowbanReportChecksWithheldReason.Suspended => "suspended",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ShadowbanReportChecksWithheldEvidence,
        ShadowbanReportChecksWithheldEvidenceFromRaw
    >)
)]
public sealed record class ShadowbanReportChecksWithheldEvidence : JsonModel
{
    /// <summary>
    /// Country codes as X gives them.
    /// </summary>
    public required IReadOnlyList<string> Countries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("countries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "countries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Countries;
    }

    public ShadowbanReportChecksWithheldEvidence() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksWithheldEvidence(
        ShadowbanReportChecksWithheldEvidence shadowbanReportChecksWithheldEvidence
    )
        : base(shadowbanReportChecksWithheldEvidence) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksWithheldEvidence(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksWithheldEvidence(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksWithheldEvidenceFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksWithheldEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksWithheldEvidenceFromRaw
    : IFromRawJson<ShadowbanReportChecksWithheldEvidence>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksWithheldEvidence FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksWithheldEvidence.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<ShadowbanReportChecksWithheld, ShadowbanReportChecksWithheldFromRaw>)
)]
public sealed record class ShadowbanReportChecksWithheld : JsonModel
{
    /// <summary>
    /// Pass means X shows the account there, and fail means it doesn't. Unknown means the check had nothing to test or X didn't answer.
    /// </summary>
    public required ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::XTwitterScraper.Models.ShadowbanVerdict>
            >("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <summary>
    /// `countries` means X lists at least 1 country.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportChecksWithheldReason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ShadowbanReportChecksWithheldReason>
            >("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The countries X lists.
    /// </summary>
    public required ShadowbanReportChecksWithheldEvidence? Evidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShadowbanReportChecksWithheldEvidence>(
                "evidence"
            );
        }
        init { this._rawData.Set("evidence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Verdict.Validate();
        this.Reason.Validate();
        this.Evidence?.Validate();
    }

    public ShadowbanReportChecksWithheld() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksWithheld(
        ShadowbanReportChecksWithheld shadowbanReportChecksWithheld
    )
        : base(shadowbanReportChecksWithheld) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecksWithheld(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecksWithheld(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksWithheldFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecksWithheld FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksWithheldFromRaw : IFromRawJson<ShadowbanReportChecksWithheld>
{
    /// <inheritdoc/>
    public ShadowbanReportChecksWithheld FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecksWithheld.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ShadowbanReportChecks, ShadowbanReportChecksFromRaw>))]
public sealed record class ShadowbanReportChecks : JsonModel
{
    /// <summary>
    /// Passes an active or protected account &amp; fails a suspended one.
    /// </summary>
    public required ShadowbanReportChecksAccount Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksAccount>("account");
        }
        init { this._rawData.Set("account", value); }
    }

    /// <summary>
    /// Looks for the account's recent posts in X search, sorted by Latest. `listed` passes &amp; `missing` fails.
    /// </summary>
    public required ShadowbanReportChecksSearch Search
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksSearch>("search");
        }
        init { this._rawData.Set("search", value); }
    }

    /// <summary>
    /// Looks for the account among the accounts X suggests for its username. `suggested` passes &amp; `not_suggested` fails.
    /// </summary>
    public required ShadowbanReportChecksSuggestion Suggestion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksSuggestion>("suggestion");
        }
        init { this._rawData.Set("suggestion", value); }
    }

    /// <summary>
    /// Opens the threads of up to 3 recent replies to other accounts. `in_thread` passes. X ranks replies for each viewer, so `more_replies` can't tell.
    /// </summary>
    public required ShadowbanReportChecksReplies Replies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksReplies>("replies");
        }
        init { this._rawData.Set("replies", value); }
    }

    /// <summary>
    /// Reads the same reply threads as `replies`. `replies_show` passes when any checked reply shows. X ranks replies for each viewer, so `replies_missing` can't tell.
    /// </summary>
    public required ShadowbanReportChecksReplyLock ReplyLock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksReplyLock>("replyLock");
        }
        init { this._rawData.Set("replyLock", value); }
    }

    /// <summary>
    /// Looks for the account's posts on its profile timeline. `visible` passes &amp; `hidden` fails.
    /// </summary>
    public required ShadowbanReportChecksTimeline Timeline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksTimeline>("timeline");
        }
        init { this._rawData.Set("timeline", value); }
    }

    /// <summary>
    /// Compares the newest 5 of the account's own posts older than 24 hours with its earlier posts, by the median of likes, replies, reposts &amp; quotes. `typical` passes at 25% or more. A drop alone proves nothing, so `low` can't tell.
    /// </summary>
    public required ShadowbanReportChecksEngagement Engagement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksEngagement>("engagement");
        }
        init { this._rawData.Set("engagement", value); }
    }

    /// <summary>
    /// Reads X's sensitive flag on the profile. `not_flagged` passes &amp; `flagged` fails.
    /// </summary>
    public required ShadowbanReportChecksSensitive Sensitive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksSensitive>("sensitive");
        }
        init { this._rawData.Set("sensitive", value); }
    }

    /// <summary>
    /// Reads the countries where X withholds the account. `none` passes &amp; `countries` fails.
    /// </summary>
    public required ShadowbanReportChecksWithheld Withheld
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecksWithheld>("withheld");
        }
        init { this._rawData.Set("withheld", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Account.Validate();
        this.Search.Validate();
        this.Suggestion.Validate();
        this.Replies.Validate();
        this.ReplyLock.Validate();
        this.Timeline.Validate();
        this.Engagement.Validate();
        this.Sensitive.Validate();
        this.Withheld.Validate();
    }

    public ShadowbanReportChecks() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecks(ShadowbanReportChecks shadowbanReportChecks)
        : base(shadowbanReportChecks) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReportChecks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReportChecks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportChecksFromRaw.FromRawUnchecked"/>
    public static ShadowbanReportChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportChecksFromRaw : IFromRawJson<ShadowbanReportChecks>
{
    /// <inheritdoc/>
    public ShadowbanReportChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShadowbanReportChecks.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ShadowbanReport, ShadowbanReportFromRaw>))]
public sealed record class ShadowbanReport : JsonModel
{
    /// <summary>
    /// Username of the account. Null for a suspended account asked for by ID.
    /// </summary>
    public required string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    /// <summary>
    /// ID of the account. Null for a suspended account asked for by username.
    /// </summary>
    public required string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userId");
        }
        init { this._rawData.Set("userId", value); }
    }

    /// <summary>
    /// Whether the account is active, protected or suspended.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportAccount> Account
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ShadowbanReportAccount>>(
                "account"
            );
        }
        init { this._rawData.Set("account", value); }
    }

    /// <summary>
    /// When the check ran.
    /// </summary>
    public required DateTimeOffset CheckedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("checkedAt");
        }
        init { this._rawData.Set("checkedAt", value); }
    }

    /// <summary>
    /// `suspended` means X suspended the account. `limited` means at least 1 check failed. `clear` means search &amp; suggestions passed with no fail. `unclear` means neither of those.
    /// </summary>
    public required ApiEnum<string, ShadowbanReportOverall> Overall
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ShadowbanReportOverall>>(
                "overall"
            );
        }
        init { this._rawData.Set("overall", value); }
    }

    /// <summary>
    /// The 9 checks, each with a verdict, a reason &amp; evidence.
    /// </summary>
    public required ShadowbanReportChecks Checks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ShadowbanReportChecks>("checks");
        }
        init { this._rawData.Set("checks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Username;
        _ = this.UserID;
        this.Account.Validate();
        _ = this.CheckedAt;
        this.Overall.Validate();
        this.Checks.Validate();
    }

    public ShadowbanReport() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReport(ShadowbanReport shadowbanReport)
        : base(shadowbanReport) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShadowbanReport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShadowbanReport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShadowbanReportFromRaw.FromRawUnchecked"/>
    public static ShadowbanReport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShadowbanReportFromRaw : IFromRawJson<ShadowbanReport>
{
    /// <inheritdoc/>
    public ShadowbanReport FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ShadowbanReport.FromRawUnchecked(rawData);
}
