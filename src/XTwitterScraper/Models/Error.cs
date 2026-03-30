using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    public required ApiEnum<string, ErrorError> ErrorValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ErrorError>>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorValue.Validate();
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Error(ApiEnum<string, ErrorError> errorValue)
        : this()
    {
        this.ErrorValue = errorValue;
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ErrorErrorConverter))]
public enum ErrorError
{
    InternalError,
    InvalidFormat,
    InvalidID,
    InvalidInput,
    InvalidParams,
    InvalidToolType,
    InvalidTweetID,
    InvalidTweetUrl,
    InvalidUsername,
    MissingParams,
    MissingQuery,
    MonitorAlreadyExists,
    MonitorLimitReached,
    NoSubscription,
    NotFound,
    StreamRegistrationFailed,
    SubscriptionInactive,
    TweetNotFound,
    Unauthenticated,
    UsageLimitReached,
    UserNotFound,
    WebhookInactive,
    XApiRateLimited,
    XApiUnavailable,
    XApiUnauthorized,
}

sealed class ErrorErrorConverter : JsonConverter<ErrorError>
{
    public override ErrorError Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal_error" => ErrorError.InternalError,
            "invalid_format" => ErrorError.InvalidFormat,
            "invalid_id" => ErrorError.InvalidID,
            "invalid_input" => ErrorError.InvalidInput,
            "invalid_params" => ErrorError.InvalidParams,
            "invalid_tool_type" => ErrorError.InvalidToolType,
            "invalid_tweet_id" => ErrorError.InvalidTweetID,
            "invalid_tweet_url" => ErrorError.InvalidTweetUrl,
            "invalid_username" => ErrorError.InvalidUsername,
            "missing_params" => ErrorError.MissingParams,
            "missing_query" => ErrorError.MissingQuery,
            "monitor_already_exists" => ErrorError.MonitorAlreadyExists,
            "monitor_limit_reached" => ErrorError.MonitorLimitReached,
            "no_subscription" => ErrorError.NoSubscription,
            "not_found" => ErrorError.NotFound,
            "stream_registration_failed" => ErrorError.StreamRegistrationFailed,
            "subscription_inactive" => ErrorError.SubscriptionInactive,
            "tweet_not_found" => ErrorError.TweetNotFound,
            "unauthenticated" => ErrorError.Unauthenticated,
            "usage_limit_reached" => ErrorError.UsageLimitReached,
            "user_not_found" => ErrorError.UserNotFound,
            "webhook_inactive" => ErrorError.WebhookInactive,
            "x_api_rate_limited" => ErrorError.XApiRateLimited,
            "x_api_unavailable" => ErrorError.XApiUnavailable,
            "x_api_unauthorized" => ErrorError.XApiUnauthorized,
            _ => (ErrorError)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorError value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorError.InternalError => "internal_error",
                ErrorError.InvalidFormat => "invalid_format",
                ErrorError.InvalidID => "invalid_id",
                ErrorError.InvalidInput => "invalid_input",
                ErrorError.InvalidParams => "invalid_params",
                ErrorError.InvalidToolType => "invalid_tool_type",
                ErrorError.InvalidTweetID => "invalid_tweet_id",
                ErrorError.InvalidTweetUrl => "invalid_tweet_url",
                ErrorError.InvalidUsername => "invalid_username",
                ErrorError.MissingParams => "missing_params",
                ErrorError.MissingQuery => "missing_query",
                ErrorError.MonitorAlreadyExists => "monitor_already_exists",
                ErrorError.MonitorLimitReached => "monitor_limit_reached",
                ErrorError.NoSubscription => "no_subscription",
                ErrorError.NotFound => "not_found",
                ErrorError.StreamRegistrationFailed => "stream_registration_failed",
                ErrorError.SubscriptionInactive => "subscription_inactive",
                ErrorError.TweetNotFound => "tweet_not_found",
                ErrorError.Unauthenticated => "unauthenticated",
                ErrorError.UsageLimitReached => "usage_limit_reached",
                ErrorError.UserNotFound => "user_not_found",
                ErrorError.WebhookInactive => "webhook_inactive",
                ErrorError.XApiRateLimited => "x_api_rate_limited",
                ErrorError.XApiUnavailable => "x_api_unavailable",
                ErrorError.XApiUnauthorized => "x_api_unauthorized",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
