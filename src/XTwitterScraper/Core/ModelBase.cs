using System.Text.Json;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Account;
using XTwitterScraper.Models.Compose;
using XTwitterScraper.Models.Events;
using XTwitterScraper.Models.Radar;
using XTwitterScraper.Models.Subscribe;
using XTwitterScraper.Models.Webhooks;
using XTwitterScraper.Models.X.Accounts;
using XTwitterScraper.Models.X.Communities;
using AccountConnectionChallenges = XTwitterScraper.Models.X.AccountConnectionChallenges;
using CommunitiesTweets = XTwitterScraper.Models.X.Communities.Tweets;
using Credits = XTwitterScraper.Models.Credits;
using Drafts = XTwitterScraper.Models.Drafts;
using Draws = XTwitterScraper.Models.Draws;
using Extractions = XTwitterScraper.Models.Extractions;
using GuestWallets = XTwitterScraper.Models.GuestWallets;
using Tickets = XTwitterScraper.Models.Support.Tickets;
using Tweets = XTwitterScraper.Models.X.Tweets;
using Users = XTwitterScraper.Models.X.Users;
using WriteActions = XTwitterScraper.Models.X.WriteActions;
using X = XTwitterScraper.Models.X;

namespace XTwitterScraper.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, LegacyErrorCode>(),
            new ApiEnumConverter<string, Code>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, EventType>(),
            new ApiEnumConverter<string, TweetMediaType>(),
            new ApiEnumConverter<string, Plan>(),
            new ApiEnumConverter<string, Locale>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Tier>(),
            new ApiEnumConverter<string, Step>(),
            new ApiEnumConverter<string, Goal>(),
            new ApiEnumConverter<string, MediaType>(),
            new ApiEnumConverter<string, Drafts::Goal>(),
            new ApiEnumConverter<string, RadarItemCategory>(),
            new ApiEnumConverter<string, RadarItemSource>(),
            new ApiEnumConverter<string, Category>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, MonitorType>(),
            new ApiEnumConverter<string, EventDetailMonitorType>(),
            new ApiEnumConverter<string, Extractions::ExtractionJobStatus>(),
            new ApiEnumConverter<string, Extractions::ExtractionJobToolType>(),
            new ApiEnumConverter<string, Extractions::Source>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunResponseToolType>(),
            new ApiEnumConverter<string, Extractions::Status>(),
            new ApiEnumConverter<string, Extractions::ToolType>(),
            new ApiEnumConverter<string, Extractions::ExtractionEstimateCostParamsToolType>(),
            new ApiEnumConverter<string, Extractions::MediaType>(),
            new ApiEnumConverter<string, Extractions::Quotes>(),
            new ApiEnumConverter<string, Extractions::Replies>(),
            new ApiEnumConverter<string, Extractions::Retweets>(),
            new ApiEnumConverter<string, Extractions::Format>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunParamsToolType>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunParamsMediaType>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunParamsQuotes>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunParamsReplies>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunParamsRetweets>(),
            new ApiEnumConverter<string, Draws::Format>(),
            new ApiEnumConverter<string, Draws::Type>(),
            new ApiEnumConverter<string, DeliveryStatus>(),
            new ApiEnumConverter<string, X::Type>(),
            new ApiEnumConverter<string, WriteActions::Kind>(),
            new ApiEnumConverter<string, WriteActions::Status>(),
            new ApiEnumConverter<string, Tweets::MediaType>(),
            new ApiEnumConverter<string, Tweets::Quotes>(),
            new ApiEnumConverter<string, Tweets::Replies>(),
            new ApiEnumConverter<string, Tweets::Retweets>(),
            new ApiEnumConverter<string, Tweets::TweetGetRepliesParamsMediaType>(),
            new ApiEnumConverter<string, Tweets::TweetGetRepliesParamsQuotes>(),
            new ApiEnumConverter<string, Tweets::TweetGetRepliesParamsReplies>(),
            new ApiEnumConverter<string, Tweets::TweetGetRepliesParamsRetweets>(),
            new ApiEnumConverter<string, Tweets::TweetSearchParamsMediaType>(),
            new ApiEnumConverter<string, Tweets::QueryType>(),
            new ApiEnumConverter<string, Tweets::TweetSearchParamsQuotes>(),
            new ApiEnumConverter<string, Tweets::TweetSearchParamsReplies>(),
            new ApiEnumConverter<string, Tweets::TweetSearchParamsRetweets>(),
            new ApiEnumConverter<string, Users::MediaType>(),
            new ApiEnumConverter<string, Users::Quotes>(),
            new ApiEnumConverter<string, Users::Replies>(),
            new ApiEnumConverter<string, Users::Retweets>(),
            new ApiEnumConverter<string, Users::UserRetrieveMediaParamsMediaType>(),
            new ApiEnumConverter<string, Users::UserRetrieveMediaParamsQuotes>(),
            new ApiEnumConverter<string, Users::UserRetrieveMediaParamsReplies>(),
            new ApiEnumConverter<string, Users::UserRetrieveMediaParamsRetweets>(),
            new ApiEnumConverter<string, Users::UserRetrieveMentionsParamsMediaType>(),
            new ApiEnumConverter<string, Users::UserRetrieveMentionsParamsQuotes>(),
            new ApiEnumConverter<string, Users::UserRetrieveMentionsParamsReplies>(),
            new ApiEnumConverter<string, Users::UserRetrieveMentionsParamsRetweets>(),
            new ApiEnumConverter<string, Users::UserRetrieveRepliesParamsMediaType>(),
            new ApiEnumConverter<string, Users::UserRetrieveRepliesParamsQuotes>(),
            new ApiEnumConverter<string, Users::UserRetrieveRepliesParamsReplies>(),
            new ApiEnumConverter<string, Users::UserRetrieveRepliesParamsRetweets>(),
            new ApiEnumConverter<string, Users::UserRetrieveTweetsParamsMediaType>(),
            new ApiEnumConverter<string, Users::UserRetrieveTweetsParamsQuotes>(),
            new ApiEnumConverter<string, Users::UserRetrieveTweetsParamsReplies>(),
            new ApiEnumConverter<string, Users::UserRetrieveTweetsParamsRetweets>(),
            new ApiEnumConverter<string, QueryType>(),
            new ApiEnumConverter<string, CommunitiesTweets::QueryType>(),
            new ApiEnumConverter<string, Health>(),
            new ApiEnumConverter<string, XAccountDetailHealth>(),
            new ApiEnumConverter<string, AccountCreateResponseHealth>(),
            new ApiEnumConverter<string, AccountReauthResponseHealth>(),
            new ApiEnumConverter<string, AccountConnectionChallenges::Health>(),
            new ApiEnumConverter<string, Tickets::Status>(),
            new ApiEnumConverter<string, Credits::Status>(),
            new ApiEnumConverter<string, GuestWallets::Header>(),
            new ApiEnumConverter<string, GuestWallets::Scheme>(),
            new ApiEnumConverter<string, GuestWallets::Status>(),
            new ApiEnumConverter<string, GuestWallets::LatestPurchaseStatus>(),
            new ApiEnumConverter<long, GuestWallets::PollAfterSeconds>(),
            new ApiEnumConverter<string, GuestWallets::GuestWalletRetrieveStatusResponseStatus>(),
            new ApiEnumConverter<string, GuestWallets::GuestWalletTopupResponseStatus>(),
            new ApiEnumConverter<
                string,
                GuestWallets::GuestWalletTopupResponseAuthorizationHeader
            >(),
            new ApiEnumConverter<
                string,
                GuestWallets::GuestWalletTopupResponseAuthorizationScheme
            >(),
            new ApiEnumConverter<string, GuestWallets::CredentialNotice>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
