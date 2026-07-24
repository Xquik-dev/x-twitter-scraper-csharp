// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Profile = XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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
        Profile::ProfileUpdateResponseAccount expectedAccount = new()
        {
            ID = "42",
            Username = "example",
        };
        ApiEnum<string, Profile::Action> expectedAction = Profile::Action.Like;
        Profile::Billing expectedBilling = new()
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Profile::Status.Charged,
        };
        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        Profile::NextAction expectedNextAction = new()
        {
            Type = Profile::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };
        JsonElement expectedObject = JsonSerializer.SerializeToElement("x_write_action");
        Profile::Request expectedRequest = new()
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };
        Profile::Result expectedResult = new()
        {
            ID = "9876543210",
            State = "liked",
            Type = Profile::ResultType.StateChange,
        };
        bool expectedRetryable = false;
        bool expectedSafeToRetry = false;
        bool expectedSendDispatched = true;
        ApiEnum<string, Profile::ProfileUpdateResponseStatus> expectedStatus =
            Profile::ProfileUpdateResponseStatus.Success;
        string expectedStatusUrl = "/api/v1/x/write-actions/12345";
        bool expectedSuccess = true;
        Profile::Target expectedTarget = new()
        {
            ID = "9876543210",
            Type = Profile::TargetType.Tweet,
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
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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
        var deserialized = JsonSerializer.Deserialize<Profile::ProfileUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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
        var deserialized = JsonSerializer.Deserialize<Profile::ProfileUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "12345";
        Profile::ProfileUpdateResponseAccount expectedAccount = new()
        {
            ID = "42",
            Username = "example",
        };
        ApiEnum<string, Profile::Action> expectedAction = Profile::Action.Like;
        Profile::Billing expectedBilling = new()
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Profile::Status.Charged,
        };
        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        Profile::NextAction expectedNextAction = new()
        {
            Type = Profile::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };
        JsonElement expectedObject = JsonSerializer.SerializeToElement("x_write_action");
        Profile::Request expectedRequest = new()
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };
        Profile::Result expectedResult = new()
        {
            ID = "9876543210",
            State = "liked",
            Type = Profile::ResultType.StateChange,
        };
        bool expectedRetryable = false;
        bool expectedSafeToRetry = false;
        bool expectedSendDispatched = true;
        ApiEnum<string, Profile::ProfileUpdateResponseStatus> expectedStatus =
            Profile::ProfileUpdateResponseStatus.Success;
        string expectedStatusUrl = "/api/v1/x/write-actions/12345";
        bool expectedSuccess = true;
        Profile::Target expectedTarget = new()
        {
            ID = "9876543210",
            Type = Profile::TargetType.Tweet,
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
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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
        var model = new Profile::ProfileUpdateResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Profile::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Profile::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Profile::Type.Poll,
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
                Type = Profile::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Profile::ProfileUpdateResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Profile::TargetType.Tweet },
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

        Profile::ProfileUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProfileUpdateResponseAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Profile::ProfileUpdateResponseAccount { ID = "42", Username = "example" };

        string expectedID = "42";
        string expectedUsername = "example";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Profile::ProfileUpdateResponseAccount { ID = "42", Username = "example" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::ProfileUpdateResponseAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile::ProfileUpdateResponseAccount { ID = "42", Username = "example" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::ProfileUpdateResponseAccount>(
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
        var model = new Profile::ProfileUpdateResponseAccount { ID = "42", Username = "example" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Profile::ProfileUpdateResponseAccount { ID = "42", Username = "example" };

        Profile::ProfileUpdateResponseAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Profile::Action.CreateTweet)]
    [InlineData(Profile::Action.DeleteTweet)]
    [InlineData(Profile::Action.Like)]
    [InlineData(Profile::Action.Unlike)]
    [InlineData(Profile::Action.Retweet)]
    [InlineData(Profile::Action.Unretweet)]
    [InlineData(Profile::Action.Follow)]
    [InlineData(Profile::Action.Unfollow)]
    [InlineData(Profile::Action.RemoveFollower)]
    [InlineData(Profile::Action.SendDm)]
    [InlineData(Profile::Action.UploadMedia)]
    [InlineData(Profile::Action.UpdateProfile)]
    [InlineData(Profile::Action.UpdateAvatar)]
    [InlineData(Profile::Action.UpdateBanner)]
    [InlineData(Profile::Action.CreateCommunity)]
    [InlineData(Profile::Action.DeleteCommunity)]
    [InlineData(Profile::Action.JoinCommunity)]
    [InlineData(Profile::Action.LeaveCommunity)]
    public void Validation_Works(Profile::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Profile::Action.CreateTweet)]
    [InlineData(Profile::Action.DeleteTweet)]
    [InlineData(Profile::Action.Like)]
    [InlineData(Profile::Action.Unlike)]
    [InlineData(Profile::Action.Retweet)]
    [InlineData(Profile::Action.Unretweet)]
    [InlineData(Profile::Action.Follow)]
    [InlineData(Profile::Action.Unfollow)]
    [InlineData(Profile::Action.RemoveFollower)]
    [InlineData(Profile::Action.SendDm)]
    [InlineData(Profile::Action.UploadMedia)]
    [InlineData(Profile::Action.UpdateProfile)]
    [InlineData(Profile::Action.UpdateAvatar)]
    [InlineData(Profile::Action.UpdateBanner)]
    [InlineData(Profile::Action.CreateCommunity)]
    [InlineData(Profile::Action.DeleteCommunity)]
    [InlineData(Profile::Action.JoinCommunity)]
    [InlineData(Profile::Action.LeaveCommunity)]
    public void SerializationRoundtrip_Works(Profile::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::Action>>(
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
        var model = new Profile::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Profile::Status.Charged,
        };

        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        string expectedPlannedCredits = "10";
        ApiEnum<string, Profile::Status> expectedStatus = Profile::Status.Charged;

        Assert.Equal(expectedCharged, model.Charged);
        Assert.Equal(expectedChargedCredits, model.ChargedCredits);
        Assert.Equal(expectedPlannedCredits, model.PlannedCredits);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Profile::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Profile::Status.Charged,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Billing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Profile::Status.Charged,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Billing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        string expectedPlannedCredits = "10";
        ApiEnum<string, Profile::Status> expectedStatus = Profile::Status.Charged;

        Assert.Equal(expectedCharged, deserialized.Charged);
        Assert.Equal(expectedChargedCredits, deserialized.ChargedCredits);
        Assert.Equal(expectedPlannedCredits, deserialized.PlannedCredits);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Profile::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Profile::Status.Charged,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Profile::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Profile::Status.Charged,
        };

        Profile::Billing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Profile::Status.NotCharged)]
    [InlineData(Profile::Status.Pending)]
    [InlineData(Profile::Status.Charged)]
    [InlineData(Profile::Status.ChargeFailed)]
    [InlineData(Profile::Status.Refunded)]
    public void Validation_Works(Profile::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Profile::Status.NotCharged)]
    [InlineData(Profile::Status.Pending)]
    [InlineData(Profile::Status.Charged)]
    [InlineData(Profile::Status.ChargeFailed)]
    [InlineData(Profile::Status.Refunded)]
    public void SerializationRoundtrip_Works(Profile::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::Status>>(
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
        var model = new Profile::NextAction
        {
            Type = Profile::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        ApiEnum<string, Profile::Type> expectedType = Profile::Type.Poll;
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
        var model = new Profile::NextAction
        {
            Type = Profile::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::NextAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile::NextAction
        {
            Type = Profile::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::NextAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Profile::Type> expectedType = Profile::Type.Poll;
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
        var model = new Profile::NextAction
        {
            Type = Profile::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Profile::NextAction { Type = Profile::Type.Poll };

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
        var model = new Profile::NextAction { Type = Profile::Type.Poll };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Profile::NextAction
        {
            Type = Profile::Type.Poll,

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
        var model = new Profile::NextAction
        {
            Type = Profile::Type.Poll,

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
        var model = new Profile::NextAction
        {
            Type = Profile::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        Profile::NextAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Profile::Type.Poll)]
    [InlineData(Profile::Type.Retry)]
    [InlineData(Profile::Type.VerifyResult)]
    [InlineData(Profile::Type.FixRequest)]
    public void Validation_Works(Profile::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Profile::Type.Poll)]
    [InlineData(Profile::Type.Retry)]
    [InlineData(Profile::Type.VerifyResult)]
    [InlineData(Profile::Type.FixRequest)]
    public void SerializationRoundtrip_Works(Profile::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::Type>>(
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
        var model = new Profile::Request
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
        var model = new Profile::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Request>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Request>(
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
        var model = new Profile::Request
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
        var model = new Profile::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Profile::Request copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Profile::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Profile::ResultType.StateChange,
        };

        string expectedID = "9876543210";
        string expectedState = "liked";
        ApiEnum<string, Profile::ResultType> expectedType = Profile::ResultType.StateChange;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Profile::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Profile::ResultType.StateChange,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Result>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Profile::ResultType.StateChange,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Result>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedState = "liked";
        ApiEnum<string, Profile::ResultType> expectedType = Profile::ResultType.StateChange;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Profile::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Profile::ResultType.StateChange,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Profile::Result { };

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
        var model = new Profile::Result { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Profile::Result
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
        var model = new Profile::Result
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
        var model = new Profile::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Profile::ResultType.StateChange,
        };

        Profile::Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTypeTest : TestBase
{
    [Theory]
    [InlineData(Profile::ResultType.Tweet)]
    [InlineData(Profile::ResultType.DirectMessage)]
    [InlineData(Profile::ResultType.Media)]
    [InlineData(Profile::ResultType.Community)]
    [InlineData(Profile::ResultType.StateChange)]
    public void Validation_Works(Profile::ResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::ResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::ResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Profile::ResultType.Tweet)]
    [InlineData(Profile::ResultType.DirectMessage)]
    [InlineData(Profile::ResultType.Media)]
    [InlineData(Profile::ResultType.Community)]
    [InlineData(Profile::ResultType.StateChange)]
    public void SerializationRoundtrip_Works(Profile::ResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::ResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::ResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::ResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::ResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProfileUpdateResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(Profile::ProfileUpdateResponseStatus.Accepted)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Dispatching)]
    [InlineData(Profile::ProfileUpdateResponseStatus.PendingConfirmation)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Success)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Failed)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Expired)]
    public void Validation_Works(Profile::ProfileUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::ProfileUpdateResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Profile::ProfileUpdateResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Profile::ProfileUpdateResponseStatus.Accepted)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Dispatching)]
    [InlineData(Profile::ProfileUpdateResponseStatus.PendingConfirmation)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Success)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Failed)]
    [InlineData(Profile::ProfileUpdateResponseStatus.Expired)]
    public void SerializationRoundtrip_Works(Profile::ProfileUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::ProfileUpdateResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Profile::ProfileUpdateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Profile::ProfileUpdateResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Profile::ProfileUpdateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Profile::Target { ID = "9876543210", Type = Profile::TargetType.Tweet };

        string expectedID = "9876543210";
        ApiEnum<string, Profile::TargetType> expectedType = Profile::TargetType.Tweet;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Profile::Target { ID = "9876543210", Type = Profile::TargetType.Tweet };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Target>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Profile::Target { ID = "9876543210", Type = Profile::TargetType.Tweet };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Profile::Target>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        ApiEnum<string, Profile::TargetType> expectedType = Profile::TargetType.Tweet;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Profile::Target { ID = "9876543210", Type = Profile::TargetType.Tweet };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Profile::Target { ID = "9876543210", Type = Profile::TargetType.Tweet };

        Profile::Target copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetTypeTest : TestBase
{
    [Theory]
    [InlineData(Profile::TargetType.Tweet)]
    [InlineData(Profile::TargetType.User)]
    [InlineData(Profile::TargetType.Community)]
    public void Validation_Works(Profile::TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::TargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Profile::TargetType.Tweet)]
    [InlineData(Profile::TargetType.User)]
    [InlineData(Profile::TargetType.Community)]
    public void SerializationRoundtrip_Works(Profile::TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Profile::TargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Profile::TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Profile::TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
