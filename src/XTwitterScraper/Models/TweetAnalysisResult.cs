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

[JsonConverter(typeof(TweetAnalysisResultAnalysisStatusConverter))]
public enum TweetAnalysisResultAnalysisStatus
{
    Succeeded,
}

sealed class TweetAnalysisResultAnalysisStatusConverter
    : JsonConverter<TweetAnalysisResultAnalysisStatus>
{
    public override TweetAnalysisResultAnalysisStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "succeeded" => TweetAnalysisResultAnalysisStatus.Succeeded,
            _ => (TweetAnalysisResultAnalysisStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultAnalysisStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultAnalysisStatus.Succeeded => "succeeded",
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
        TweetAnalysisResultAnalysisQuestions,
        TweetAnalysisResultAnalysisQuestionsFromRaw
    >)
)]
public sealed record class TweetAnalysisResultAnalysisQuestions : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Version;
    }

    public TweetAnalysisResultAnalysisQuestions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResultAnalysisQuestions(
        TweetAnalysisResultAnalysisQuestions tweetAnalysisResultAnalysisQuestions
    )
        : base(tweetAnalysisResultAnalysisQuestions) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResultAnalysisQuestions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisResultAnalysisQuestions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisResultAnalysisQuestionsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisResultAnalysisQuestions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisResultAnalysisQuestionsFromRaw
    : IFromRawJson<TweetAnalysisResultAnalysisQuestions>
{
    /// <inheritdoc/>
    public TweetAnalysisResultAnalysisQuestions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisResultAnalysisQuestions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetAnalysisResultAnalysisContextAvailabilityQuoteConverter))]
public enum TweetAnalysisResultAnalysisContextAvailabilityQuote
{
    Available,
    Missing,
    NotApplicable,
}

sealed class TweetAnalysisResultAnalysisContextAvailabilityQuoteConverter
    : JsonConverter<TweetAnalysisResultAnalysisContextAvailabilityQuote>
{
    public override TweetAnalysisResultAnalysisContextAvailabilityQuote Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available" => TweetAnalysisResultAnalysisContextAvailabilityQuote.Available,
            "missing" => TweetAnalysisResultAnalysisContextAvailabilityQuote.Missing,
            "not_applicable" => TweetAnalysisResultAnalysisContextAvailabilityQuote.NotApplicable,
            _ => (TweetAnalysisResultAnalysisContextAvailabilityQuote)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultAnalysisContextAvailabilityQuote value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultAnalysisContextAvailabilityQuote.Available => "available",
                TweetAnalysisResultAnalysisContextAvailabilityQuote.Missing => "missing",
                TweetAnalysisResultAnalysisContextAvailabilityQuote.NotApplicable =>
                    "not_applicable",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetAnalysisResultAnalysisContextAvailabilityReplyConverter))]
public enum TweetAnalysisResultAnalysisContextAvailabilityReply
{
    Available,
    Missing,
    NotApplicable,
}

sealed class TweetAnalysisResultAnalysisContextAvailabilityReplyConverter
    : JsonConverter<TweetAnalysisResultAnalysisContextAvailabilityReply>
{
    public override TweetAnalysisResultAnalysisContextAvailabilityReply Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available" => TweetAnalysisResultAnalysisContextAvailabilityReply.Available,
            "missing" => TweetAnalysisResultAnalysisContextAvailabilityReply.Missing,
            "not_applicable" => TweetAnalysisResultAnalysisContextAvailabilityReply.NotApplicable,
            _ => (TweetAnalysisResultAnalysisContextAvailabilityReply)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultAnalysisContextAvailabilityReply value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultAnalysisContextAvailabilityReply.Available => "available",
                TweetAnalysisResultAnalysisContextAvailabilityReply.Missing => "missing",
                TweetAnalysisResultAnalysisContextAvailabilityReply.NotApplicable =>
                    "not_applicable",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetAnalysisResultAnalysisContextAvailabilityAuthorConverter))]
public enum TweetAnalysisResultAnalysisContextAvailabilityAuthor
{
    Available,
    Missing,
}

sealed class TweetAnalysisResultAnalysisContextAvailabilityAuthorConverter
    : JsonConverter<TweetAnalysisResultAnalysisContextAvailabilityAuthor>
{
    public override TweetAnalysisResultAnalysisContextAvailabilityAuthor Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available" => TweetAnalysisResultAnalysisContextAvailabilityAuthor.Available,
            "missing" => TweetAnalysisResultAnalysisContextAvailabilityAuthor.Missing,
            _ => (TweetAnalysisResultAnalysisContextAvailabilityAuthor)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultAnalysisContextAvailabilityAuthor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultAnalysisContextAvailabilityAuthor.Available => "available",
                TweetAnalysisResultAnalysisContextAvailabilityAuthor.Missing => "missing",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetAnalysisResultAnalysisContextAvailabilityMediaConverter))]
public enum TweetAnalysisResultAnalysisContextAvailabilityMedia
{
    Images,
    TextDescriptionsOnly,
    NotSupplied,
}

sealed class TweetAnalysisResultAnalysisContextAvailabilityMediaConverter
    : JsonConverter<TweetAnalysisResultAnalysisContextAvailabilityMedia>
{
    public override TweetAnalysisResultAnalysisContextAvailabilityMedia Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "images" => TweetAnalysisResultAnalysisContextAvailabilityMedia.Images,
            "text_descriptions_only" =>
                TweetAnalysisResultAnalysisContextAvailabilityMedia.TextDescriptionsOnly,
            "not_supplied" => TweetAnalysisResultAnalysisContextAvailabilityMedia.NotSupplied,
            _ => (TweetAnalysisResultAnalysisContextAvailabilityMedia)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultAnalysisContextAvailabilityMedia value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultAnalysisContextAvailabilityMedia.Images => "images",
                TweetAnalysisResultAnalysisContextAvailabilityMedia.TextDescriptionsOnly =>
                    "text_descriptions_only",
                TweetAnalysisResultAnalysisContextAvailabilityMedia.NotSupplied => "not_supplied",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetAnalysisResultAnalysisContextAvailabilityArticleConverter))]
public enum TweetAnalysisResultAnalysisContextAvailabilityArticle
{
    TextBlocks,
    Summary,
    NotSupplied,
}

sealed class TweetAnalysisResultAnalysisContextAvailabilityArticleConverter
    : JsonConverter<TweetAnalysisResultAnalysisContextAvailabilityArticle>
{
    public override TweetAnalysisResultAnalysisContextAvailabilityArticle Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text_blocks" => TweetAnalysisResultAnalysisContextAvailabilityArticle.TextBlocks,
            "summary" => TweetAnalysisResultAnalysisContextAvailabilityArticle.Summary,
            "not_supplied" => TweetAnalysisResultAnalysisContextAvailabilityArticle.NotSupplied,
            _ => (TweetAnalysisResultAnalysisContextAvailabilityArticle)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultAnalysisContextAvailabilityArticle value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultAnalysisContextAvailabilityArticle.TextBlocks => "text_blocks",
                TweetAnalysisResultAnalysisContextAvailabilityArticle.Summary => "summary",
                TweetAnalysisResultAnalysisContextAvailabilityArticle.NotSupplied => "not_supplied",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TweetAnalysisResultAnalysisContextAvailabilityPostTextConverter))]
public enum TweetAnalysisResultAnalysisContextAvailabilityPostText
{
    Full,
    Truncated,
}

sealed class TweetAnalysisResultAnalysisContextAvailabilityPostTextConverter
    : JsonConverter<TweetAnalysisResultAnalysisContextAvailabilityPostText>
{
    public override TweetAnalysisResultAnalysisContextAvailabilityPostText Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full" => TweetAnalysisResultAnalysisContextAvailabilityPostText.Full,
            "truncated" => TweetAnalysisResultAnalysisContextAvailabilityPostText.Truncated,
            _ => (TweetAnalysisResultAnalysisContextAvailabilityPostText)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultAnalysisContextAvailabilityPostText value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultAnalysisContextAvailabilityPostText.Full => "full",
                TweetAnalysisResultAnalysisContextAvailabilityPostText.Truncated => "truncated",
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
        TweetAnalysisResultAnalysisContextAvailability,
        TweetAnalysisResultAnalysisContextAvailabilityFromRaw
    >)
)]
public sealed record class TweetAnalysisResultAnalysisContextAvailability : JsonModel
{
    public required ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityQuote> Quote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityQuote>
            >("quote");
        }
        init { this._rawData.Set("quote", value); }
    }

    public required ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityReply> Reply
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityReply>
            >("reply");
        }
        init { this._rawData.Set("reply", value); }
    }

    public required ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityAuthor> Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityAuthor>
            >("author");
        }
        init { this._rawData.Set("author", value); }
    }

    /// <summary>
    /// images when the AI read the post's images. text_descriptions_only when it read only their alt text.
    /// </summary>
    public required ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityMedia> Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityMedia>
            >("media");
        }
        init { this._rawData.Set("media", value); }
    }

    public required ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityArticle> Article
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityArticle>
            >("article");
        }
        init { this._rawData.Set("article", value); }
    }

    /// <summary>
    /// truncated when the post was cut to fit.
    /// </summary>
    public required ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityPostText> PostText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetAnalysisResultAnalysisContextAvailabilityPostText>
            >("postText");
        }
        init { this._rawData.Set("postText", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Quote.Validate();
        this.Reply.Validate();
        this.Author.Validate();
        this.Media.Validate();
        this.Article.Validate();
        this.PostText.Validate();
    }

    public TweetAnalysisResultAnalysisContextAvailability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResultAnalysisContextAvailability(
        TweetAnalysisResultAnalysisContextAvailability tweetAnalysisResultAnalysisContextAvailability
    )
        : base(tweetAnalysisResultAnalysisContextAvailability) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResultAnalysisContextAvailability(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisResultAnalysisContextAvailability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisResultAnalysisContextAvailabilityFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisResultAnalysisContextAvailability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisResultAnalysisContextAvailabilityFromRaw
    : IFromRawJson<TweetAnalysisResultAnalysisContextAvailability>
{
    /// <inheritdoc/>
    public TweetAnalysisResultAnalysisContextAvailability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisResultAnalysisContextAvailability.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAnalysisResultAnalysis, TweetAnalysisResultAnalysisFromRaw>)
)]
public sealed record class TweetAnalysisResultAnalysis : JsonModel
{
    public required ApiEnum<string, TweetAnalysisResultAnalysisStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TweetAnalysisResultAnalysisStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// 1 answer per question, in question order.
    /// </summary>
    public required IReadOnlyList<global::XTwitterScraper.Models.TweetAnalysisAnswer> Answers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetAnalysisAnswer>
            >("answers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetAnalysisAnswer>>(
                "answers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID &amp; version of each question asked.
    /// </summary>
    public required IReadOnlyList<TweetAnalysisResultAnalysisQuestions> Questions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<TweetAnalysisResultAnalysisQuestions>
            >("questions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TweetAnalysisResultAnalysisQuestions>>(
                "questions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Bytes of post &amp; settings the AI read.
    /// </summary>
    public required long ContextBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("contextBytes");
        }
        init { this._rawData.Set("contextBytes", value); }
    }

    /// <summary>
    /// What the AI read beside the post's text.
    /// </summary>
    public required TweetAnalysisResultAnalysisContextAvailability ContextAvailability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TweetAnalysisResultAnalysisContextAvailability>(
                "contextAvailability"
            );
        }
        init { this._rawData.Set("contextAvailability", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.Answers)
        {
            item.Validate();
        }
        foreach (var item in this.Questions)
        {
            item.Validate();
        }
        _ = this.ContextBytes;
        this.ContextAvailability.Validate();
    }

    public TweetAnalysisResultAnalysis() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResultAnalysis(TweetAnalysisResultAnalysis tweetAnalysisResultAnalysis)
        : base(tweetAnalysisResultAnalysis) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResultAnalysis(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisResultAnalysis(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisResultAnalysisFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisResultAnalysis FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisResultAnalysisFromRaw : IFromRawJson<TweetAnalysisResultAnalysis>
{
    /// <inheritdoc/>
    public TweetAnalysisResultAnalysis FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisResultAnalysis.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TweetAnalysisResultViralVerdictConverter))]
public enum TweetAnalysisResultViralVerdict
{
    SendIt,
    EditFirst,
    SleepOnIt,
}

sealed class TweetAnalysisResultViralVerdictConverter
    : JsonConverter<TweetAnalysisResultViralVerdict>
{
    public override TweetAnalysisResultViralVerdict Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send_it" => TweetAnalysisResultViralVerdict.SendIt,
            "edit_first" => TweetAnalysisResultViralVerdict.EditFirst,
            "sleep_on_it" => TweetAnalysisResultViralVerdict.SleepOnIt,
            _ => (TweetAnalysisResultViralVerdict)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisResultViralVerdict value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisResultViralVerdict.SendIt => "send_it",
                TweetAnalysisResultViralVerdict.EditFirst => "edit_first",
                TweetAnalysisResultViralVerdict.SleepOnIt => "sleep_on_it",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TweetAnalysisResult, TweetAnalysisResultFromRaw>))]
public sealed record class TweetAnalysisResult : JsonModel
{
    /// <summary>
    /// The post, as /x/tweets/search returns it. Your own texts have the IDs text:1, text:2 &amp; so on.
    /// </summary>
    public required global::XTwitterScraper.Models.SearchTweet2 Tweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.SearchTweet2>(
                "tweet"
            );
        }
        init { this._rawData.Set("tweet", value); }
    }

    /// <summary>
    /// The answers in full, with their probabilities.
    /// </summary>
    public required TweetAnalysisResultAnalysis Analysis
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TweetAnalysisResultAnalysis>("analysis");
        }
        init { this._rawData.Set("analysis", value); }
    }

    /// <summary>
    /// Each question's decision by question ID. A choice gives its category, a score its level from 0, which can have decimals, &amp; a probability its value from 0 to 1.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Answers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("answers");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "answers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Hostnames the post links to, without t.co.
    /// </summary>
    public required IReadOnlyList<string> SourceDomains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("sourceDomains");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "sourceDomains",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cashtags in the post's text, in upper case.
    /// </summary>
    public required IReadOnlyList<string> Cashtags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("cashtags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "cashtags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Only from /x/analysis/viral-score. How viral the wording reads, or null when a trait has no answer.
    /// </summary>
    public long? ViralScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("viralScore");
        }
        init { this._rawData.Set("viralScore", value); }
    }

    /// <summary>
    /// Only from /x/analysis/viral-score. send_it from 70, edit_first from 40, else sleep_on_it.
    /// </summary>
    public ApiEnum<string, TweetAnalysisResultViralVerdict>? ViralVerdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TweetAnalysisResultViralVerdict>>(
                "viralVerdict"
            );
        }
        init { this._rawData.Set("viralVerdict", value); }
    }

    /// <summary>
    /// Only from /x/analysis/viral-score. The post's public counts under X's published ranking weights, per 1,000 views or followers.
    /// </summary>
    public double? ViralAlgorithmScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("viralAlgorithmScore");
        }
        init { this._rawData.Set("viralAlgorithmScore", value); }
    }

    /// <summary>
    /// Only from /x/analysis/viral-score. log10 of 1 plus the weighted engagement per 1,000 followers. Null without a follower count.
    /// </summary>
    public double? ViralActualEngagementRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("viralActualEngagementRate");
        }
        init { this._rawData.Set("viralActualEngagementRate", value); }
    }

    /// <summary>
    /// Only from /x/analysis/viral-score. The score with its weights version, the caps that applied &amp; the engagement comparison.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Viral
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("viral");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "viral",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// How the post's answers compare with its row in baseline, as the AI Actors compare a run with an earlier dataset.
    /// </summary>
    public required global::XTwitterScraper.Models.TweetAnalysisComparison Monitor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.TweetAnalysisComparison>(
                "monitor"
            );
        }
        init { this._rawData.Set("monitor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Tweet.Validate();
        this.Analysis.Validate();
        _ = this.Answers;
        _ = this.SourceDomains;
        _ = this.Cashtags;
        _ = this.ViralScore;
        this.ViralVerdict?.Validate();
        _ = this.ViralAlgorithmScore;
        _ = this.ViralActualEngagementRate;
        _ = this.Viral;
        this.Monitor.Validate();
    }

    public TweetAnalysisResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResult(TweetAnalysisResult tweetAnalysisResult)
        : base(tweetAnalysisResult) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisResultFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisResultFromRaw : IFromRawJson<TweetAnalysisResult>
{
    /// <inheritdoc/>
    public TweetAnalysisResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetAnalysisResult.FromRawUnchecked(rawData);
}
