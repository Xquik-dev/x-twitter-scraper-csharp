using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Compose;

[JsonConverter(typeof(JsonModelConverter<ComposeCreateResponse, ComposeCreateResponseFromRaw>))]
public sealed record class ComposeCreateResponse : JsonModel
{
    /// <summary>
    /// AI feedback on the draft
    /// </summary>
    public string? Feedback
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("feedback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("feedback", value);
        }
    }

    /// <summary>
    /// Engagement score (0-100)
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <summary>
    /// Improvement suggestions
    /// </summary>
    public IReadOnlyList<string>? Suggestions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("suggestions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "suggestions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Generated or refined tweet text
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Feedback;
        _ = this.Score;
        _ = this.Suggestions;
        _ = this.Text;
    }

    public ComposeCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposeCreateResponse(ComposeCreateResponse composeCreateResponse)
        : base(composeCreateResponse) { }
#pragma warning restore CS8618

    public ComposeCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposeCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComposeCreateResponseFromRaw.FromRawUnchecked"/>
    public static ComposeCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComposeCreateResponseFromRaw : IFromRawJson<ComposeCreateResponse>
{
    /// <inheritdoc/>
    public ComposeCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComposeCreateResponse.FromRawUnchecked(rawData);
}
