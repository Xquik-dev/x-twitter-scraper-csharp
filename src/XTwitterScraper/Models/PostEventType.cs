// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(PostEventTypeConverter))]
public enum PostEventType
{
    PostReplyNew,
    PostQuoteNew,
    PostLikesChanged,
    PostRetweetsChanged,
    PostRepliesChanged,
    PostQuotesChanged,
    PostBookmarksChanged,
    PostViewsChanged,
    PostEdited,
    PostDeleted,
}

sealed class PostEventTypeConverter : JsonConverter<PostEventType>
{
    public override PostEventType Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "post.reply.new" => PostEventType.PostReplyNew,
            "post.quote.new" => PostEventType.PostQuoteNew,
            "post.likes.changed" => PostEventType.PostLikesChanged,
            "post.retweets.changed" => PostEventType.PostRetweetsChanged,
            "post.replies.changed" => PostEventType.PostRepliesChanged,
            "post.quotes.changed" => PostEventType.PostQuotesChanged,
            "post.bookmarks.changed" => PostEventType.PostBookmarksChanged,
            "post.views.changed" => PostEventType.PostViewsChanged,
            "post.edited" => PostEventType.PostEdited,
            "post.deleted" => PostEventType.PostDeleted,
            _ => (PostEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PostEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PostEventType.PostReplyNew => "post.reply.new",
                PostEventType.PostQuoteNew => "post.quote.new",
                PostEventType.PostLikesChanged => "post.likes.changed",
                PostEventType.PostRetweetsChanged => "post.retweets.changed",
                PostEventType.PostRepliesChanged => "post.replies.changed",
                PostEventType.PostQuotesChanged => "post.quotes.changed",
                PostEventType.PostBookmarksChanged => "post.bookmarks.changed",
                PostEventType.PostViewsChanged => "post.views.changed",
                PostEventType.PostEdited => "post.edited",
                PostEventType.PostDeleted => "post.deleted",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
