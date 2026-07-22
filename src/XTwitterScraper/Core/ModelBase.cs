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
using XTwitterScraper.Models.X.Communities.Tweets;
using AccountConnectionChallenges = XTwitterScraper.Models.X.AccountConnectionChallenges;
using Communities = XTwitterScraper.Models.X.Communities;
using Credits = XTwitterScraper.Models.Credits;
using Dm = XTwitterScraper.Models.X.Dm;
using Drafts = XTwitterScraper.Models.Drafts;
using Draws = XTwitterScraper.Models.Draws;
using Extractions = XTwitterScraper.Models.Extractions;
using Follow = XTwitterScraper.Models.X.Users.Follow;
using GuestWallets = XTwitterScraper.Models.GuestWallets;
using Join = XTwitterScraper.Models.X.Communities.Join;
using Like = XTwitterScraper.Models.X.Tweets.Like;
using Media = XTwitterScraper.Models.X.Media;
using Profile = XTwitterScraper.Models.X.Profile;
using Retweet = XTwitterScraper.Models.X.Tweets.Retweet;
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
            new ApiEnumConverter<string, Goal>(),
            new ApiEnumConverter<string, ComposeRefineRequestGoal>(),
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
            new ApiEnumConverter<string, WriteActions::Action>(),
            new ApiEnumConverter<string, WriteActions::Status>(),
            new ApiEnumConverter<string, WriteActions::Type>(),
            new ApiEnumConverter<string, WriteActions::ResultType>(),
            new ApiEnumConverter<string, WriteActions::WriteActionRetrieveResponseStatus>(),
            new ApiEnumConverter<string, WriteActions::TargetType>(),
            new ApiEnumConverter<string, Tweets::Action>(),
            new ApiEnumConverter<string, Tweets::Status>(),
            new ApiEnumConverter<string, Tweets::Type>(),
            new ApiEnumConverter<string, Tweets::ResultType>(),
            new ApiEnumConverter<string, Tweets::TweetCreateResponseStatus>(),
            new ApiEnumConverter<string, Tweets::TargetType>(),
            new ApiEnumConverter<string, Tweets::TweetDeleteResponseAction>(),
            new ApiEnumConverter<string, Tweets::TweetDeleteResponseBillingStatus>(),
            new ApiEnumConverter<string, Tweets::TweetDeleteResponseNextActionType>(),
            new ApiEnumConverter<string, Tweets::TweetDeleteResponseResultType>(),
            new ApiEnumConverter<string, Tweets::TweetDeleteResponseStatus>(),
            new ApiEnumConverter<string, Tweets::TweetDeleteResponseTargetType>(),
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
            new ApiEnumConverter<string, Like::Action>(),
            new ApiEnumConverter<string, Like::Status>(),
            new ApiEnumConverter<string, Like::Type>(),
            new ApiEnumConverter<string, Like::ResultType>(),
            new ApiEnumConverter<string, Like::LikeCreateResponseStatus>(),
            new ApiEnumConverter<string, Like::TargetType>(),
            new ApiEnumConverter<string, Like::LikeDeleteResponseAction>(),
            new ApiEnumConverter<string, Like::LikeDeleteResponseBillingStatus>(),
            new ApiEnumConverter<string, Like::LikeDeleteResponseNextActionType>(),
            new ApiEnumConverter<string, Like::LikeDeleteResponseResultType>(),
            new ApiEnumConverter<string, Like::LikeDeleteResponseStatus>(),
            new ApiEnumConverter<string, Like::LikeDeleteResponseTargetType>(),
            new ApiEnumConverter<string, Retweet::Action>(),
            new ApiEnumConverter<string, Retweet::Status>(),
            new ApiEnumConverter<string, Retweet::Type>(),
            new ApiEnumConverter<string, Retweet::ResultType>(),
            new ApiEnumConverter<string, Retweet::RetweetCreateResponseStatus>(),
            new ApiEnumConverter<string, Retweet::TargetType>(),
            new ApiEnumConverter<string, Retweet::RetweetDeleteResponseAction>(),
            new ApiEnumConverter<string, Retweet::RetweetDeleteResponseBillingStatus>(),
            new ApiEnumConverter<string, Retweet::RetweetDeleteResponseNextActionType>(),
            new ApiEnumConverter<string, Retweet::RetweetDeleteResponseResultType>(),
            new ApiEnumConverter<string, Retweet::RetweetDeleteResponseStatus>(),
            new ApiEnumConverter<string, Retweet::RetweetDeleteResponseTargetType>(),
            new ApiEnumConverter<string, Users::Action>(),
            new ApiEnumConverter<string, Users::Status>(),
            new ApiEnumConverter<string, Users::Type>(),
            new ApiEnumConverter<string, Users::ResultType>(),
            new ApiEnumConverter<string, Users::UserRemoveFollowerResponseStatus>(),
            new ApiEnumConverter<string, Users::TargetType>(),
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
            new ApiEnumConverter<string, Follow::Action>(),
            new ApiEnumConverter<string, Follow::Status>(),
            new ApiEnumConverter<string, Follow::Type>(),
            new ApiEnumConverter<string, Follow::ResultType>(),
            new ApiEnumConverter<string, Follow::FollowCreateResponseStatus>(),
            new ApiEnumConverter<string, Follow::TargetType>(),
            new ApiEnumConverter<string, Follow::FollowDeleteAllResponseAction>(),
            new ApiEnumConverter<string, Follow::FollowDeleteAllResponseBillingStatus>(),
            new ApiEnumConverter<string, Follow::FollowDeleteAllResponseNextActionType>(),
            new ApiEnumConverter<string, Follow::FollowDeleteAllResponseResultType>(),
            new ApiEnumConverter<string, Follow::FollowDeleteAllResponseStatus>(),
            new ApiEnumConverter<string, Follow::FollowDeleteAllResponseTargetType>(),
            new ApiEnumConverter<string, Dm::Action>(),
            new ApiEnumConverter<string, Dm::Status>(),
            new ApiEnumConverter<string, Dm::Type>(),
            new ApiEnumConverter<string, Dm::ResultType>(),
            new ApiEnumConverter<string, Dm::DmSendResponseStatus>(),
            new ApiEnumConverter<string, Dm::TargetType>(),
            new ApiEnumConverter<string, Media::Action>(),
            new ApiEnumConverter<string, Media::Status>(),
            new ApiEnumConverter<string, Media::Type>(),
            new ApiEnumConverter<string, Media::ResultType>(),
            new ApiEnumConverter<string, Media::MediaUploadResponseStatus>(),
            new ApiEnumConverter<string, Media::TargetType>(),
            new ApiEnumConverter<string, Profile::Action>(),
            new ApiEnumConverter<string, Profile::Status>(),
            new ApiEnumConverter<string, Profile::Type>(),
            new ApiEnumConverter<string, Profile::ResultType>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateResponseStatus>(),
            new ApiEnumConverter<string, Profile::TargetType>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateAvatarResponseAction>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateAvatarResponseBillingStatus>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateAvatarResponseNextActionType>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateAvatarResponseResultType>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateAvatarResponseStatus>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateAvatarResponseTargetType>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateBannerResponseAction>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateBannerResponseBillingStatus>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateBannerResponseNextActionType>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateBannerResponseResultType>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateBannerResponseStatus>(),
            new ApiEnumConverter<string, Profile::ProfileUpdateBannerResponseTargetType>(),
            new ApiEnumConverter<string, Communities::Action>(),
            new ApiEnumConverter<string, Communities::Status>(),
            new ApiEnumConverter<string, Communities::Type>(),
            new ApiEnumConverter<string, Communities::ResultType>(),
            new ApiEnumConverter<string, Communities::CommunityCreateResponseStatus>(),
            new ApiEnumConverter<string, Communities::TargetType>(),
            new ApiEnumConverter<string, Communities::CommunityDeleteResponseAction>(),
            new ApiEnumConverter<string, Communities::CommunityDeleteResponseBillingStatus>(),
            new ApiEnumConverter<string, Communities::CommunityDeleteResponseNextActionType>(),
            new ApiEnumConverter<string, Communities::CommunityDeleteResponseResultType>(),
            new ApiEnumConverter<string, Communities::CommunityDeleteResponseStatus>(),
            new ApiEnumConverter<string, Communities::CommunityDeleteResponseTargetType>(),
            new ApiEnumConverter<string, Communities::QueryType>(),
            new ApiEnumConverter<string, Join::Action>(),
            new ApiEnumConverter<string, Join::Status>(),
            new ApiEnumConverter<string, Join::Type>(),
            new ApiEnumConverter<string, Join::ResultType>(),
            new ApiEnumConverter<string, Join::JoinCreateResponseStatus>(),
            new ApiEnumConverter<string, Join::TargetType>(),
            new ApiEnumConverter<string, Join::JoinDeleteAllResponseAction>(),
            new ApiEnumConverter<string, Join::JoinDeleteAllResponseBillingStatus>(),
            new ApiEnumConverter<string, Join::JoinDeleteAllResponseNextActionType>(),
            new ApiEnumConverter<string, Join::JoinDeleteAllResponseResultType>(),
            new ApiEnumConverter<string, Join::JoinDeleteAllResponseStatus>(),
            new ApiEnumConverter<string, Join::JoinDeleteAllResponseTargetType>(),
            new ApiEnumConverter<string, QueryType>(),
            new ApiEnumConverter<string, Health>(),
            new ApiEnumConverter<string, XAccountDetailHealth>(),
            new ApiEnumConverter<string, AccountCreateResponseHealth>(),
            new ApiEnumConverter<string, AccountReauthResponseHealth>(),
            new ApiEnumConverter<string, AccountConnectionChallenges::Health>(),
            new ApiEnumConverter<string, Tickets::AttachmentStatus>(),
            new ApiEnumConverter<string, Tickets::ContentType>(),
            new ApiEnumConverter<string, Tickets::Kind>(),
            new ApiEnumConverter<string, Tickets::MessageAttachmentStatus>(),
            new ApiEnumConverter<string, Tickets::TicketReplyResponseAttachmentStatus>(),
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
