using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

/// <summary>
/// What the image filter asked &amp; how many posts it kept.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImageFilterSummary, ImageFilterSummaryFromRaw>))]
public record class ImageFilterSummary : JsonModel
{
    /// <summary>
    /// What you asked the photos to show.
    /// </summary>
    public required string ImageShows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("imageShows");
        }
        init { this._rawData.Set("imageShows", value); }
    }

    /// <summary>
    /// The question asked of each post's photos.
    /// </summary>
    public required string Question
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("question");
        }
        init { this._rawData.Set("question", value); }
    }

    /// <summary>
    /// The lowest imageScore a kept post has.
    /// </summary>
    public required double Cutoff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("cutoff");
        }
        init { this._rawData.Set("cutoff", value); }
    }

    /// <summary>
    /// Posts whose photos were checked. Only kept posts are billed.
    /// </summary>
    public required long Checked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("checked");
        }
        init { this._rawData.Set("checked", value); }
    }

    /// <summary>
    /// Posts whose photos show it, all returned &amp; billed at 2 credits each.
    /// </summary>
    public required long Kept
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("kept");
        }
        init { this._rawData.Set("kept", value); }
    }

    /// <summary>
    /// Posts without a safe photo &amp; posts the check couldn't answer. They aren't billed or
    /// returned.
    /// </summary>
    public required IReadOnlyList<ImageFilterSummaryUnchecked> Unchecked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ImageFilterSummaryUnchecked>>(
                "unchecked"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImageFilterSummaryUnchecked>>(
                "unchecked",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ImageShows;
        _ = this.Question;
        _ = this.Cutoff;
        _ = this.Checked;
        _ = this.Kept;
        foreach (var item in this.Unchecked)
        {
            item.Validate();
        }
    }

    public ImageFilterSummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageFilterSummary(ImageFilterSummary imageFilterSummary)
        : base(imageFilterSummary) { }
#pragma warning restore CS8618

    public ImageFilterSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageFilterSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageFilterSummaryFromRaw.FromRawUnchecked"/>
    public static ImageFilterSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageFilterSummaryFromRaw : IFromRawJson<ImageFilterSummary>
{
    /// <inheritdoc/>
    public ImageFilterSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageFilterSummary.FromRawUnchecked(rawData);
}

/// <summary>
/// A post the filter couldn't check, with the reason.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ImageFilterSummaryUnchecked, ImageFilterSummaryUncheckedFromRaw>)
)]
public sealed record class ImageFilterSummaryUnchecked : JsonModel
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

    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Reason;
    }

    public ImageFilterSummaryUnchecked() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageFilterSummaryUnchecked(ImageFilterSummaryUnchecked imageFilterSummaryUnchecked)
        : base(imageFilterSummaryUnchecked) { }
#pragma warning restore CS8618

    public ImageFilterSummaryUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageFilterSummaryUnchecked(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageFilterSummaryUncheckedFromRaw.FromRawUnchecked"/>
    public static ImageFilterSummaryUnchecked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageFilterSummaryUncheckedFromRaw : IFromRawJson<ImageFilterSummaryUnchecked>
{
    /// <inheritdoc/>
    public ImageFilterSummaryUnchecked FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImageFilterSummaryUnchecked.FromRawUnchecked(rawData);
}
