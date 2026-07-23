using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Follow = XTwitterScraper.Models.X.Users.Follow;

namespace XTwitterScraper.Tests.Models.X.Users.Follow;

public class FollowCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
            CommunityID = "3456789012",
            CommunityName = "Builders",
            CompletedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmationAttempts = 1,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            CreatedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            Details = new Dictionary<string, JsonElement>()
            {
                { "suggestion", JsonSerializer.SerializeToElement("bar") },
            },
            Error = "x_write_ambiguous",
            ExpiresAt = DateTimeOffset.Parse("2026-07-22T05:00:00Z"),
            Idempotent = false,
            Media = new Dictionary<string, JsonElement>()
            {
                { "count", JsonSerializer.SerializeToElement("bar") },
                { "kind", JsonSerializer.SerializeToElement("bar") },
            },
            MediaID = "2345678901",
            MediaUrl = "https://media.xquik.com/example.jpg",
            Message = "Invalid input. Check request fields.",
            MessageID = "1234567890",
            RequestHash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            RequestID = "01JZ8R7QSC9QKT0V7JX4M2A6B8",
            ResultID = "9876543210",
            SendDispatchedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            TweetID = "9876543210",
            UpdatedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
        };

        string expectedID = "12345";
        Follow::FollowCreateResponseAccount expectedAccount = new()
        {
            ID = "42",
            Username = "example",
        };
        ApiEnum<string, Follow::Action> expectedAction = Follow::Action.Like;
        Follow::Billing expectedBilling = new()
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Follow::Status.Charged,
        };
        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        Follow::NextAction expectedNextAction = new()
        {
            Type = Follow::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };
        JsonElement expectedObject = JsonSerializer.SerializeToElement("x_write_action");
        Follow::Request expectedRequest = new()
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };
        Follow::Result expectedResult = new()
        {
            ID = "9876543210",
            State = "liked",
            Type = Follow::ResultType.StateChange,
        };
        bool expectedRetryable = false;
        bool expectedSafeToRetry = false;
        bool expectedSendDispatched = true;
        ApiEnum<string, Follow::FollowCreateResponseStatus> expectedStatus =
            Follow::FollowCreateResponseStatus.Success;
        string expectedStatusUrl = "/api/v1/x/write-actions/12345";
        bool expectedSuccess = true;
        Follow::Target expectedTarget = new()
        {
            ID = "9876543210",
            Type = Follow::TargetType.Tweet,
        };
        string expectedTargetID = "9876543210";
        bool expectedTerminal = true;
        string expectedWriteActionID = "12345";
        string expectedCommunityID = "3456789012";
        string expectedCommunityName = "Builders";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");
        long expectedConfirmationAttempts = 1;
        DateTimeOffset expectedConfirmationCheckedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");
        DateTimeOffset expectedConfirmedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z");
        Dictionary<string, JsonElement> expectedDetails = new()
        {
            { "suggestion", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedError = "x_write_ambiguous";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-22T05:00:00Z");
        bool expectedIdempotent = false;
        Dictionary<string, JsonElement> expectedMedia = new()
        {
            { "count", JsonSerializer.SerializeToElement("bar") },
            { "kind", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMediaID = "2345678901";
        string expectedMediaUrl = "https://media.xquik.com/example.jpg";
        string expectedMessage = "Invalid input. Check request fields.";
        string expectedMessageID = "1234567890";
        string expectedRequestHash =
            "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";
        string expectedRequestID = "01JZ8R7QSC9QKT0V7JX4M2A6B8";
        string expectedResultID = "9876543210";
        DateTimeOffset expectedSendDispatchedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z");
        string expectedTweetID = "9876543210";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccount, model.Account);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedBilling, model.Billing);
        Assert.Equal(expectedCharged, model.Charged);
        Assert.Equal(expectedChargedCredits, model.ChargedCredits);
        Assert.Equal(expectedNextAction, model.NextAction);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
        Assert.Null(model.PollAfterMs);
        Assert.Equal(expectedRequest, model.Request);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedRetryable, model.Retryable);
        Assert.Equal(expectedSafeToRetry, model.SafeToRetry);
        Assert.Equal(expectedSendDispatched, model.SendDispatched);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStatusUrl, model.StatusUrl);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedTargetID, model.TargetID);
        Assert.Equal(expectedTerminal, model.Terminal);
        Assert.Equal(expectedWriteActionID, model.WriteActionID);
        Assert.Equal(expectedCommunityID, model.CommunityID);
        Assert.Equal(expectedCommunityName, model.CommunityName);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedConfirmationAttempts, model.ConfirmationAttempts);
        Assert.Equal(expectedConfirmationCheckedAt, model.ConfirmationCheckedAt);
        Assert.Equal(expectedConfirmedAt, model.ConfirmedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Details);
        Assert.Equal(expectedDetails.Count, model.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(model.Details.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Details[item.Key]));
        }
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedIdempotent, model.Idempotent);
        Assert.NotNull(model.Media);
        Assert.Equal(expectedMedia.Count, model.Media.Count);
        foreach (var item in expectedMedia)
        {
            Assert.True(model.Media.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Media[item.Key]));
        }
        Assert.Equal(expectedMediaID, model.MediaID);
        Assert.Equal(expectedMediaUrl, model.MediaUrl);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedRequestHash, model.RequestHash);
        Assert.Equal(expectedRequestID, model.RequestID);
        Assert.Equal(expectedResultID, model.ResultID);
        Assert.Equal(expectedSendDispatchedAt, model.SendDispatchedAt);
        Assert.Equal(expectedTweetID, model.TweetID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
            CommunityID = "3456789012",
            CommunityName = "Builders",
            CompletedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmationAttempts = 1,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            CreatedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            Details = new Dictionary<string, JsonElement>()
            {
                { "suggestion", JsonSerializer.SerializeToElement("bar") },
            },
            Error = "x_write_ambiguous",
            ExpiresAt = DateTimeOffset.Parse("2026-07-22T05:00:00Z"),
            Idempotent = false,
            Media = new Dictionary<string, JsonElement>()
            {
                { "count", JsonSerializer.SerializeToElement("bar") },
                { "kind", JsonSerializer.SerializeToElement("bar") },
            },
            MediaID = "2345678901",
            MediaUrl = "https://media.xquik.com/example.jpg",
            Message = "Invalid input. Check request fields.",
            MessageID = "1234567890",
            RequestHash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            RequestID = "01JZ8R7QSC9QKT0V7JX4M2A6B8",
            ResultID = "9876543210",
            SendDispatchedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            TweetID = "9876543210",
            UpdatedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::FollowCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
            CommunityID = "3456789012",
            CommunityName = "Builders",
            CompletedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmationAttempts = 1,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            CreatedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            Details = new Dictionary<string, JsonElement>()
            {
                { "suggestion", JsonSerializer.SerializeToElement("bar") },
            },
            Error = "x_write_ambiguous",
            ExpiresAt = DateTimeOffset.Parse("2026-07-22T05:00:00Z"),
            Idempotent = false,
            Media = new Dictionary<string, JsonElement>()
            {
                { "count", JsonSerializer.SerializeToElement("bar") },
                { "kind", JsonSerializer.SerializeToElement("bar") },
            },
            MediaID = "2345678901",
            MediaUrl = "https://media.xquik.com/example.jpg",
            Message = "Invalid input. Check request fields.",
            MessageID = "1234567890",
            RequestHash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            RequestID = "01JZ8R7QSC9QKT0V7JX4M2A6B8",
            ResultID = "9876543210",
            SendDispatchedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            TweetID = "9876543210",
            UpdatedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::FollowCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "12345";
        Follow::FollowCreateResponseAccount expectedAccount = new()
        {
            ID = "42",
            Username = "example",
        };
        ApiEnum<string, Follow::Action> expectedAction = Follow::Action.Like;
        Follow::Billing expectedBilling = new()
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Follow::Status.Charged,
        };
        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        Follow::NextAction expectedNextAction = new()
        {
            Type = Follow::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };
        JsonElement expectedObject = JsonSerializer.SerializeToElement("x_write_action");
        Follow::Request expectedRequest = new()
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };
        Follow::Result expectedResult = new()
        {
            ID = "9876543210",
            State = "liked",
            Type = Follow::ResultType.StateChange,
        };
        bool expectedRetryable = false;
        bool expectedSafeToRetry = false;
        bool expectedSendDispatched = true;
        ApiEnum<string, Follow::FollowCreateResponseStatus> expectedStatus =
            Follow::FollowCreateResponseStatus.Success;
        string expectedStatusUrl = "/api/v1/x/write-actions/12345";
        bool expectedSuccess = true;
        Follow::Target expectedTarget = new()
        {
            ID = "9876543210",
            Type = Follow::TargetType.Tweet,
        };
        string expectedTargetID = "9876543210";
        bool expectedTerminal = true;
        string expectedWriteActionID = "12345";
        string expectedCommunityID = "3456789012";
        string expectedCommunityName = "Builders";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");
        long expectedConfirmationAttempts = 1;
        DateTimeOffset expectedConfirmationCheckedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");
        DateTimeOffset expectedConfirmedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z");
        Dictionary<string, JsonElement> expectedDetails = new()
        {
            { "suggestion", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedError = "x_write_ambiguous";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-22T05:00:00Z");
        bool expectedIdempotent = false;
        Dictionary<string, JsonElement> expectedMedia = new()
        {
            { "count", JsonSerializer.SerializeToElement("bar") },
            { "kind", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMediaID = "2345678901";
        string expectedMediaUrl = "https://media.xquik.com/example.jpg";
        string expectedMessage = "Invalid input. Check request fields.";
        string expectedMessageID = "1234567890";
        string expectedRequestHash =
            "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";
        string expectedRequestID = "01JZ8R7QSC9QKT0V7JX4M2A6B8";
        string expectedResultID = "9876543210";
        DateTimeOffset expectedSendDispatchedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z");
        string expectedTweetID = "9876543210";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccount, deserialized.Account);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedBilling, deserialized.Billing);
        Assert.Equal(expectedCharged, deserialized.Charged);
        Assert.Equal(expectedChargedCredits, deserialized.ChargedCredits);
        Assert.Equal(expectedNextAction, deserialized.NextAction);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
        Assert.Null(deserialized.PollAfterMs);
        Assert.Equal(expectedRequest, deserialized.Request);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedRetryable, deserialized.Retryable);
        Assert.Equal(expectedSafeToRetry, deserialized.SafeToRetry);
        Assert.Equal(expectedSendDispatched, deserialized.SendDispatched);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStatusUrl, deserialized.StatusUrl);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedTargetID, deserialized.TargetID);
        Assert.Equal(expectedTerminal, deserialized.Terminal);
        Assert.Equal(expectedWriteActionID, deserialized.WriteActionID);
        Assert.Equal(expectedCommunityID, deserialized.CommunityID);
        Assert.Equal(expectedCommunityName, deserialized.CommunityName);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedConfirmationAttempts, deserialized.ConfirmationAttempts);
        Assert.Equal(expectedConfirmationCheckedAt, deserialized.ConfirmationCheckedAt);
        Assert.Equal(expectedConfirmedAt, deserialized.ConfirmedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Details);
        Assert.Equal(expectedDetails.Count, deserialized.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(deserialized.Details.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Details[item.Key]));
        }
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedIdempotent, deserialized.Idempotent);
        Assert.NotNull(deserialized.Media);
        Assert.Equal(expectedMedia.Count, deserialized.Media.Count);
        foreach (var item in expectedMedia)
        {
            Assert.True(deserialized.Media.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Media[item.Key]));
        }
        Assert.Equal(expectedMediaID, deserialized.MediaID);
        Assert.Equal(expectedMediaUrl, deserialized.MediaUrl);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedRequestHash, deserialized.RequestHash);
        Assert.Equal(expectedRequestID, deserialized.RequestID);
        Assert.Equal(expectedResultID, deserialized.ResultID);
        Assert.Equal(expectedSendDispatchedAt, deserialized.SendDispatchedAt);
        Assert.Equal(expectedTweetID, deserialized.TweetID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
            CommunityID = "3456789012",
            CommunityName = "Builders",
            CompletedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmationAttempts = 1,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            CreatedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            Details = new Dictionary<string, JsonElement>()
            {
                { "suggestion", JsonSerializer.SerializeToElement("bar") },
            },
            Error = "x_write_ambiguous",
            ExpiresAt = DateTimeOffset.Parse("2026-07-22T05:00:00Z"),
            Idempotent = false,
            Media = new Dictionary<string, JsonElement>()
            {
                { "count", JsonSerializer.SerializeToElement("bar") },
                { "kind", JsonSerializer.SerializeToElement("bar") },
            },
            MediaID = "2345678901",
            MediaUrl = "https://media.xquik.com/example.jpg",
            Message = "Invalid input. Check request fields.",
            MessageID = "1234567890",
            RequestHash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            RequestID = "01JZ8R7QSC9QKT0V7JX4M2A6B8",
            ResultID = "9876543210",
            SendDispatchedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            TweetID = "9876543210",
            UpdatedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
        };

        Assert.Null(model.CommunityID);
        Assert.False(model.RawData.ContainsKey("communityId"));
        Assert.Null(model.CommunityName);
        Assert.False(model.RawData.ContainsKey("communityName"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.ConfirmationAttempts);
        Assert.False(model.RawData.ContainsKey("confirmationAttempts"));
        Assert.Null(model.ConfirmationCheckedAt);
        Assert.False(model.RawData.ContainsKey("confirmationCheckedAt"));
        Assert.Null(model.ConfirmedAt);
        Assert.False(model.RawData.ContainsKey("confirmedAt"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expiresAt"));
        Assert.Null(model.Idempotent);
        Assert.False(model.RawData.ContainsKey("idempotent"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.MediaID);
        Assert.False(model.RawData.ContainsKey("mediaId"));
        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
        Assert.Null(model.RequestHash);
        Assert.False(model.RawData.ContainsKey("requestHash"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("requestId"));
        Assert.Null(model.ResultID);
        Assert.False(model.RawData.ContainsKey("resultId"));
        Assert.Null(model.SendDispatchedAt);
        Assert.False(model.RawData.ContainsKey("sendDispatchedAt"));
        Assert.Null(model.TweetID);
        Assert.False(model.RawData.ContainsKey("tweetId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",

            // Null should be interpreted as omitted for these properties
            CommunityID = null,
            CommunityName = null,
            CompletedAt = null,
            ConfirmationAttempts = null,
            ConfirmationCheckedAt = null,
            ConfirmedAt = null,
            CreatedAt = null,
            Details = null,
            Error = null,
            ExpiresAt = null,
            Idempotent = null,
            Media = null,
            MediaID = null,
            MediaUrl = null,
            Message = null,
            MessageID = null,
            RequestHash = null,
            RequestID = null,
            ResultID = null,
            SendDispatchedAt = null,
            TweetID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CommunityID);
        Assert.False(model.RawData.ContainsKey("communityId"));
        Assert.Null(model.CommunityName);
        Assert.False(model.RawData.ContainsKey("communityName"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.ConfirmationAttempts);
        Assert.False(model.RawData.ContainsKey("confirmationAttempts"));
        Assert.Null(model.ConfirmationCheckedAt);
        Assert.False(model.RawData.ContainsKey("confirmationCheckedAt"));
        Assert.Null(model.ConfirmedAt);
        Assert.False(model.RawData.ContainsKey("confirmedAt"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expiresAt"));
        Assert.Null(model.Idempotent);
        Assert.False(model.RawData.ContainsKey("idempotent"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.MediaID);
        Assert.False(model.RawData.ContainsKey("mediaId"));
        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
        Assert.Null(model.RequestHash);
        Assert.False(model.RawData.ContainsKey("requestHash"));
        Assert.Null(model.RequestID);
        Assert.False(model.RawData.ContainsKey("requestId"));
        Assert.Null(model.ResultID);
        Assert.False(model.RawData.ContainsKey("resultId"));
        Assert.Null(model.SendDispatchedAt);
        Assert.False(model.RawData.ContainsKey("sendDispatchedAt"));
        Assert.Null(model.TweetID);
        Assert.False(model.RawData.ContainsKey("tweetId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",

            // Null should be interpreted as omitted for these properties
            CommunityID = null,
            CommunityName = null,
            CompletedAt = null,
            ConfirmationAttempts = null,
            ConfirmationCheckedAt = null,
            ConfirmedAt = null,
            CreatedAt = null,
            Details = null,
            Error = null,
            ExpiresAt = null,
            Idempotent = null,
            Media = null,
            MediaID = null,
            MediaUrl = null,
            Message = null,
            MessageID = null,
            RequestHash = null,
            RequestID = null,
            ResultID = null,
            SendDispatchedAt = null,
            TweetID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Follow::FollowCreateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Follow::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Follow::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Follow::Type.Poll,
                AfterMs = 2000,
                RequiresNewIdempotencyKey = true,
                Url = "/api/v1/x/write-actions/12345",
            },
            PollAfterMs = null,
            Request = new()
            {
                Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
                Payload = new Dictionary<string, JsonElement>()
                {
                    { "tweet_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Result = new()
            {
                ID = "9876543210",
                State = "liked",
                Type = Follow::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Follow::FollowCreateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Follow::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
            CommunityID = "3456789012",
            CommunityName = "Builders",
            CompletedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmationAttempts = 1,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
            CreatedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            Details = new Dictionary<string, JsonElement>()
            {
                { "suggestion", JsonSerializer.SerializeToElement("bar") },
            },
            Error = "x_write_ambiguous",
            ExpiresAt = DateTimeOffset.Parse("2026-07-22T05:00:00Z"),
            Idempotent = false,
            Media = new Dictionary<string, JsonElement>()
            {
                { "count", JsonSerializer.SerializeToElement("bar") },
                { "kind", JsonSerializer.SerializeToElement("bar") },
            },
            MediaID = "2345678901",
            MediaUrl = "https://media.xquik.com/example.jpg",
            Message = "Invalid input. Check request fields.",
            MessageID = "1234567890",
            RequestHash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            RequestID = "01JZ8R7QSC9QKT0V7JX4M2A6B8",
            ResultID = "9876543210",
            SendDispatchedAt = DateTimeOffset.Parse("2026-07-21T05:00:00Z"),
            TweetID = "9876543210",
            UpdatedAt = DateTimeOffset.Parse("2026-07-21T05:00:02Z"),
        };

        Follow::FollowCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FollowCreateResponseAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Follow::FollowCreateResponseAccount { ID = "42", Username = "example" };

        string expectedID = "42";
        string expectedUsername = "example";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Follow::FollowCreateResponseAccount { ID = "42", Username = "example" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::FollowCreateResponseAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Follow::FollowCreateResponseAccount { ID = "42", Username = "example" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::FollowCreateResponseAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        string expectedUsername = "example";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Follow::FollowCreateResponseAccount { ID = "42", Username = "example" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Follow::FollowCreateResponseAccount { ID = "42", Username = "example" };

        Follow::FollowCreateResponseAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Follow::Action.CreateTweet)]
    [InlineData(Follow::Action.DeleteTweet)]
    [InlineData(Follow::Action.Like)]
    [InlineData(Follow::Action.Unlike)]
    [InlineData(Follow::Action.Retweet)]
    [InlineData(Follow::Action.Unretweet)]
    [InlineData(Follow::Action.Follow)]
    [InlineData(Follow::Action.Unfollow)]
    [InlineData(Follow::Action.RemoveFollower)]
    [InlineData(Follow::Action.SendDm)]
    [InlineData(Follow::Action.UploadMedia)]
    [InlineData(Follow::Action.UpdateProfile)]
    [InlineData(Follow::Action.UpdateAvatar)]
    [InlineData(Follow::Action.UpdateBanner)]
    [InlineData(Follow::Action.CreateCommunity)]
    [InlineData(Follow::Action.DeleteCommunity)]
    [InlineData(Follow::Action.JoinCommunity)]
    [InlineData(Follow::Action.LeaveCommunity)]
    public void Validation_Works(Follow::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Follow::Action.CreateTweet)]
    [InlineData(Follow::Action.DeleteTweet)]
    [InlineData(Follow::Action.Like)]
    [InlineData(Follow::Action.Unlike)]
    [InlineData(Follow::Action.Retweet)]
    [InlineData(Follow::Action.Unretweet)]
    [InlineData(Follow::Action.Follow)]
    [InlineData(Follow::Action.Unfollow)]
    [InlineData(Follow::Action.RemoveFollower)]
    [InlineData(Follow::Action.SendDm)]
    [InlineData(Follow::Action.UploadMedia)]
    [InlineData(Follow::Action.UpdateProfile)]
    [InlineData(Follow::Action.UpdateAvatar)]
    [InlineData(Follow::Action.UpdateBanner)]
    [InlineData(Follow::Action.CreateCommunity)]
    [InlineData(Follow::Action.DeleteCommunity)]
    [InlineData(Follow::Action.JoinCommunity)]
    [InlineData(Follow::Action.LeaveCommunity)]
    public void SerializationRoundtrip_Works(Follow::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BillingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Follow::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Follow::Status.Charged,
        };

        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        string expectedPlannedCredits = "10";
        ApiEnum<string, Follow::Status> expectedStatus = Follow::Status.Charged;

        Assert.Equal(expectedCharged, model.Charged);
        Assert.Equal(expectedChargedCredits, model.ChargedCredits);
        Assert.Equal(expectedPlannedCredits, model.PlannedCredits);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Follow::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Follow::Status.Charged,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Billing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Follow::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Follow::Status.Charged,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Billing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        string expectedPlannedCredits = "10";
        ApiEnum<string, Follow::Status> expectedStatus = Follow::Status.Charged;

        Assert.Equal(expectedCharged, deserialized.Charged);
        Assert.Equal(expectedChargedCredits, deserialized.ChargedCredits);
        Assert.Equal(expectedPlannedCredits, deserialized.PlannedCredits);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Follow::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Follow::Status.Charged,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Follow::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Follow::Status.Charged,
        };

        Follow::Billing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Follow::Status.NotCharged)]
    [InlineData(Follow::Status.Pending)]
    [InlineData(Follow::Status.Charged)]
    [InlineData(Follow::Status.ChargeFailed)]
    [InlineData(Follow::Status.Refunded)]
    public void Validation_Works(Follow::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Follow::Status.NotCharged)]
    [InlineData(Follow::Status.Pending)]
    [InlineData(Follow::Status.Charged)]
    [InlineData(Follow::Status.ChargeFailed)]
    [InlineData(Follow::Status.Refunded)]
    public void SerializationRoundtrip_Works(Follow::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NextActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Follow::NextAction
        {
            Type = Follow::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        ApiEnum<string, Follow::Type> expectedType = Follow::Type.Poll;
        long expectedAfterMs = 2000;
        bool expectedRequiresNewIdempotencyKey = true;
        string expectedUrl = "/api/v1/x/write-actions/12345";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAfterMs, model.AfterMs);
        Assert.Equal(expectedRequiresNewIdempotencyKey, model.RequiresNewIdempotencyKey);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Follow::NextAction
        {
            Type = Follow::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::NextAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Follow::NextAction
        {
            Type = Follow::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::NextAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Follow::Type> expectedType = Follow::Type.Poll;
        long expectedAfterMs = 2000;
        bool expectedRequiresNewIdempotencyKey = true;
        string expectedUrl = "/api/v1/x/write-actions/12345";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAfterMs, deserialized.AfterMs);
        Assert.Equal(expectedRequiresNewIdempotencyKey, deserialized.RequiresNewIdempotencyKey);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Follow::NextAction
        {
            Type = Follow::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Follow::NextAction { Type = Follow::Type.Poll };

        Assert.Null(model.AfterMs);
        Assert.False(model.RawData.ContainsKey("afterMs"));
        Assert.Null(model.RequiresNewIdempotencyKey);
        Assert.False(model.RawData.ContainsKey("requiresNewIdempotencyKey"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Follow::NextAction { Type = Follow::Type.Poll };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Follow::NextAction
        {
            Type = Follow::Type.Poll,

            // Null should be interpreted as omitted for these properties
            AfterMs = null,
            RequiresNewIdempotencyKey = null,
            Url = null,
        };

        Assert.Null(model.AfterMs);
        Assert.False(model.RawData.ContainsKey("afterMs"));
        Assert.Null(model.RequiresNewIdempotencyKey);
        Assert.False(model.RawData.ContainsKey("requiresNewIdempotencyKey"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Follow::NextAction
        {
            Type = Follow::Type.Poll,

            // Null should be interpreted as omitted for these properties
            AfterMs = null,
            RequiresNewIdempotencyKey = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Follow::NextAction
        {
            Type = Follow::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        Follow::NextAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Follow::Type.Poll)]
    [InlineData(Follow::Type.Retry)]
    [InlineData(Follow::Type.VerifyResult)]
    [InlineData(Follow::Type.FixRequest)]
    public void Validation_Works(Follow::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Follow::Type.Poll)]
    [InlineData(Follow::Type.Retry)]
    [InlineData(Follow::Type.VerifyResult)]
    [InlineData(Follow::Type.FixRequest)]
    public void SerializationRoundtrip_Works(Follow::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Follow::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedHash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";
        Dictionary<string, JsonElement> expectedPayload = new()
        {
            { "tweet_id", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedHash, model.Hash);
        Assert.NotNull(model.Payload);
        Assert.Equal(expectedPayload.Count, model.Payload.Count);
        foreach (var item in expectedPayload)
        {
            Assert.True(model.Payload.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Payload[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Follow::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Request>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Follow::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Request>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedHash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef";
        Dictionary<string, JsonElement> expectedPayload = new()
        {
            { "tweet_id", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedHash, deserialized.Hash);
        Assert.NotNull(deserialized.Payload);
        Assert.Equal(expectedPayload.Count, deserialized.Payload.Count);
        foreach (var item in expectedPayload)
        {
            Assert.True(deserialized.Payload.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Payload[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Follow::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Follow::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Follow::Request copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Follow::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Follow::ResultType.StateChange,
        };

        string expectedID = "9876543210";
        string expectedState = "liked";
        ApiEnum<string, Follow::ResultType> expectedType = Follow::ResultType.StateChange;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Follow::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Follow::ResultType.StateChange,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Result>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Follow::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Follow::ResultType.StateChange,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Result>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedState = "liked";
        ApiEnum<string, Follow::ResultType> expectedType = Follow::ResultType.StateChange;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Follow::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Follow::ResultType.StateChange,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Follow::Result { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Follow::Result { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Follow::Result
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            State = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Follow::Result
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            State = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Follow::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Follow::ResultType.StateChange,
        };

        Follow::Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTypeTest : TestBase
{
    [Theory]
    [InlineData(Follow::ResultType.Tweet)]
    [InlineData(Follow::ResultType.DirectMessage)]
    [InlineData(Follow::ResultType.Media)]
    [InlineData(Follow::ResultType.Community)]
    [InlineData(Follow::ResultType.StateChange)]
    public void Validation_Works(Follow::ResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::ResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::ResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Follow::ResultType.Tweet)]
    [InlineData(Follow::ResultType.DirectMessage)]
    [InlineData(Follow::ResultType.Media)]
    [InlineData(Follow::ResultType.Community)]
    [InlineData(Follow::ResultType.StateChange)]
    public void SerializationRoundtrip_Works(Follow::ResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::ResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::ResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::ResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::ResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FollowCreateResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(Follow::FollowCreateResponseStatus.Accepted)]
    [InlineData(Follow::FollowCreateResponseStatus.Dispatching)]
    [InlineData(Follow::FollowCreateResponseStatus.PendingConfirmation)]
    [InlineData(Follow::FollowCreateResponseStatus.Success)]
    [InlineData(Follow::FollowCreateResponseStatus.Failed)]
    [InlineData(Follow::FollowCreateResponseStatus.Expired)]
    public void Validation_Works(Follow::FollowCreateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::FollowCreateResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::FollowCreateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Follow::FollowCreateResponseStatus.Accepted)]
    [InlineData(Follow::FollowCreateResponseStatus.Dispatching)]
    [InlineData(Follow::FollowCreateResponseStatus.PendingConfirmation)]
    [InlineData(Follow::FollowCreateResponseStatus.Success)]
    [InlineData(Follow::FollowCreateResponseStatus.Failed)]
    [InlineData(Follow::FollowCreateResponseStatus.Expired)]
    public void SerializationRoundtrip_Works(Follow::FollowCreateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::FollowCreateResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Follow::FollowCreateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::FollowCreateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Follow::FollowCreateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Follow::Target { ID = "9876543210", Type = Follow::TargetType.Tweet };

        string expectedID = "9876543210";
        ApiEnum<string, Follow::TargetType> expectedType = Follow::TargetType.Tweet;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Follow::Target { ID = "9876543210", Type = Follow::TargetType.Tweet };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Target>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Follow::Target { ID = "9876543210", Type = Follow::TargetType.Tweet };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Follow::Target>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        ApiEnum<string, Follow::TargetType> expectedType = Follow::TargetType.Tweet;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Follow::Target { ID = "9876543210", Type = Follow::TargetType.Tweet };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Follow::Target { ID = "9876543210", Type = Follow::TargetType.Tweet };

        Follow::Target copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetTypeTest : TestBase
{
    [Theory]
    [InlineData(Follow::TargetType.Tweet)]
    [InlineData(Follow::TargetType.User)]
    [InlineData(Follow::TargetType.Community)]
    public void Validation_Works(Follow::TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::TargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Follow::TargetType.Tweet)]
    [InlineData(Follow::TargetType.User)]
    [InlineData(Follow::TargetType.Community)]
    public void SerializationRoundtrip_Works(Follow::TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Follow::TargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Follow::TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Follow::TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
