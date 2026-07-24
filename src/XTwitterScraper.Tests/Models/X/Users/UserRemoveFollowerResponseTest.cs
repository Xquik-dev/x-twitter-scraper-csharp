// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Users = XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRemoveFollowerResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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
        Users::UserRemoveFollowerResponseAccount expectedAccount = new()
        {
            ID = "42",
            Username = "example",
        };
        ApiEnum<string, Users::Action> expectedAction = Users::Action.Like;
        Users::Billing expectedBilling = new()
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Users::Status.Charged,
        };
        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        Users::NextAction expectedNextAction = new()
        {
            Type = Users::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };
        JsonElement expectedObject = JsonSerializer.SerializeToElement("x_write_action");
        Users::Request expectedRequest = new()
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };
        Users::Result expectedResult = new()
        {
            ID = "9876543210",
            State = "liked",
            Type = Users::ResultType.StateChange,
        };
        bool expectedRetryable = false;
        bool expectedSafeToRetry = false;
        bool expectedSendDispatched = true;
        ApiEnum<string, Users::UserRemoveFollowerResponseStatus> expectedStatus =
            Users::UserRemoveFollowerResponseStatus.Success;
        string expectedStatusUrl = "/api/v1/x/write-actions/12345";
        bool expectedSuccess = true;
        Users::Target expectedTarget = new() { ID = "9876543210", Type = Users::TargetType.Tweet };
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
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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
        var deserialized = JsonSerializer.Deserialize<Users::UserRemoveFollowerResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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
        var deserialized = JsonSerializer.Deserialize<Users::UserRemoveFollowerResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "12345";
        Users::UserRemoveFollowerResponseAccount expectedAccount = new()
        {
            ID = "42",
            Username = "example",
        };
        ApiEnum<string, Users::Action> expectedAction = Users::Action.Like;
        Users::Billing expectedBilling = new()
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Users::Status.Charged,
        };
        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        Users::NextAction expectedNextAction = new()
        {
            Type = Users::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };
        JsonElement expectedObject = JsonSerializer.SerializeToElement("x_write_action");
        Users::Request expectedRequest = new()
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };
        Users::Result expectedResult = new()
        {
            ID = "9876543210",
            State = "liked",
            Type = Users::ResultType.StateChange,
        };
        bool expectedRetryable = false;
        bool expectedSafeToRetry = false;
        bool expectedSendDispatched = true;
        ApiEnum<string, Users::UserRemoveFollowerResponseStatus> expectedStatus =
            Users::UserRemoveFollowerResponseStatus.Success;
        string expectedStatusUrl = "/api/v1/x/write-actions/12345";
        bool expectedSuccess = true;
        Users::Target expectedTarget = new() { ID = "9876543210", Type = Users::TargetType.Tweet };
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
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
            TargetID = "9876543210",
            Terminal = true,
            WriteActionID = "12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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
        var model = new Users::UserRemoveFollowerResponse
        {
            ID = "12345",
            Account = new() { ID = "42", Username = "example" },
            Action = Users::Action.Like,
            Billing = new()
            {
                Charged = true,
                ChargedCredits = "10",
                PlannedCredits = "10",
                Status = Users::Status.Charged,
            },
            Charged = true,
            ChargedCredits = "10",
            NextAction = new()
            {
                Type = Users::Type.Poll,
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
                Type = Users::ResultType.StateChange,
            },
            Retryable = false,
            SafeToRetry = false,
            SendDispatched = true,
            Status = Users::UserRemoveFollowerResponseStatus.Success,
            StatusUrl = "/api/v1/x/write-actions/12345",
            Success = true,
            Target = new() { ID = "9876543210", Type = Users::TargetType.Tweet },
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

        Users::UserRemoveFollowerResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserRemoveFollowerResponseAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Users::UserRemoveFollowerResponseAccount
        {
            ID = "42",
            Username = "example",
        };

        string expectedID = "42";
        string expectedUsername = "example";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Users::UserRemoveFollowerResponseAccount
        {
            ID = "42",
            Username = "example",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::UserRemoveFollowerResponseAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Users::UserRemoveFollowerResponseAccount
        {
            ID = "42",
            Username = "example",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::UserRemoveFollowerResponseAccount>(
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
        var model = new Users::UserRemoveFollowerResponseAccount
        {
            ID = "42",
            Username = "example",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Users::UserRemoveFollowerResponseAccount
        {
            ID = "42",
            Username = "example",
        };

        Users::UserRemoveFollowerResponseAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Users::Action.CreateTweet)]
    [InlineData(Users::Action.DeleteTweet)]
    [InlineData(Users::Action.Like)]
    [InlineData(Users::Action.Unlike)]
    [InlineData(Users::Action.Retweet)]
    [InlineData(Users::Action.Unretweet)]
    [InlineData(Users::Action.Follow)]
    [InlineData(Users::Action.Unfollow)]
    [InlineData(Users::Action.RemoveFollower)]
    [InlineData(Users::Action.SendDm)]
    [InlineData(Users::Action.UploadMedia)]
    [InlineData(Users::Action.UpdateProfile)]
    [InlineData(Users::Action.UpdateAvatar)]
    [InlineData(Users::Action.UpdateBanner)]
    [InlineData(Users::Action.CreateCommunity)]
    [InlineData(Users::Action.DeleteCommunity)]
    [InlineData(Users::Action.JoinCommunity)]
    [InlineData(Users::Action.LeaveCommunity)]
    public void Validation_Works(Users::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Users::Action.CreateTweet)]
    [InlineData(Users::Action.DeleteTweet)]
    [InlineData(Users::Action.Like)]
    [InlineData(Users::Action.Unlike)]
    [InlineData(Users::Action.Retweet)]
    [InlineData(Users::Action.Unretweet)]
    [InlineData(Users::Action.Follow)]
    [InlineData(Users::Action.Unfollow)]
    [InlineData(Users::Action.RemoveFollower)]
    [InlineData(Users::Action.SendDm)]
    [InlineData(Users::Action.UploadMedia)]
    [InlineData(Users::Action.UpdateProfile)]
    [InlineData(Users::Action.UpdateAvatar)]
    [InlineData(Users::Action.UpdateBanner)]
    [InlineData(Users::Action.CreateCommunity)]
    [InlineData(Users::Action.DeleteCommunity)]
    [InlineData(Users::Action.JoinCommunity)]
    [InlineData(Users::Action.LeaveCommunity)]
    public void SerializationRoundtrip_Works(Users::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::Action>>(
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
        var model = new Users::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Users::Status.Charged,
        };

        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        string expectedPlannedCredits = "10";
        ApiEnum<string, Users::Status> expectedStatus = Users::Status.Charged;

        Assert.Equal(expectedCharged, model.Charged);
        Assert.Equal(expectedChargedCredits, model.ChargedCredits);
        Assert.Equal(expectedPlannedCredits, model.PlannedCredits);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Users::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Users::Status.Charged,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Billing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Users::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Users::Status.Charged,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Billing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCharged = true;
        string expectedChargedCredits = "10";
        string expectedPlannedCredits = "10";
        ApiEnum<string, Users::Status> expectedStatus = Users::Status.Charged;

        Assert.Equal(expectedCharged, deserialized.Charged);
        Assert.Equal(expectedChargedCredits, deserialized.ChargedCredits);
        Assert.Equal(expectedPlannedCredits, deserialized.PlannedCredits);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Users::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Users::Status.Charged,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Users::Billing
        {
            Charged = true,
            ChargedCredits = "10",
            PlannedCredits = "10",
            Status = Users::Status.Charged,
        };

        Users::Billing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Users::Status.NotCharged)]
    [InlineData(Users::Status.Pending)]
    [InlineData(Users::Status.Charged)]
    [InlineData(Users::Status.ChargeFailed)]
    [InlineData(Users::Status.Refunded)]
    public void Validation_Works(Users::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Users::Status.NotCharged)]
    [InlineData(Users::Status.Pending)]
    [InlineData(Users::Status.Charged)]
    [InlineData(Users::Status.ChargeFailed)]
    [InlineData(Users::Status.Refunded)]
    public void SerializationRoundtrip_Works(Users::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::Status>>(
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
        var model = new Users::NextAction
        {
            Type = Users::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        ApiEnum<string, Users::Type> expectedType = Users::Type.Poll;
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
        var model = new Users::NextAction
        {
            Type = Users::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::NextAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Users::NextAction
        {
            Type = Users::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::NextAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Users::Type> expectedType = Users::Type.Poll;
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
        var model = new Users::NextAction
        {
            Type = Users::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Users::NextAction { Type = Users::Type.Poll };

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
        var model = new Users::NextAction { Type = Users::Type.Poll };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Users::NextAction
        {
            Type = Users::Type.Poll,

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
        var model = new Users::NextAction
        {
            Type = Users::Type.Poll,

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
        var model = new Users::NextAction
        {
            Type = Users::Type.Poll,
            AfterMs = 2000,
            RequiresNewIdempotencyKey = true,
            Url = "/api/v1/x/write-actions/12345",
        };

        Users::NextAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Users::Type.Poll)]
    [InlineData(Users::Type.Retry)]
    [InlineData(Users::Type.VerifyResult)]
    [InlineData(Users::Type.FixRequest)]
    public void Validation_Works(Users::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Users::Type.Poll)]
    [InlineData(Users::Type.Retry)]
    [InlineData(Users::Type.VerifyResult)]
    [InlineData(Users::Type.FixRequest)]
    public void SerializationRoundtrip_Works(Users::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::Type>>(
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
        var model = new Users::Request
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
        var model = new Users::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Request>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Users::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Request>(
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
        var model = new Users::Request
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
        var model = new Users::Request
        {
            Hash = "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef",
            Payload = new Dictionary<string, JsonElement>()
            {
                { "tweet_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Users::Request copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Users::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Users::ResultType.StateChange,
        };

        string expectedID = "9876543210";
        string expectedState = "liked";
        ApiEnum<string, Users::ResultType> expectedType = Users::ResultType.StateChange;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Users::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Users::ResultType.StateChange,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Result>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Users::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Users::ResultType.StateChange,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Result>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedState = "liked";
        ApiEnum<string, Users::ResultType> expectedType = Users::ResultType.StateChange;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Users::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Users::ResultType.StateChange,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Users::Result { };

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
        var model = new Users::Result { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Users::Result
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
        var model = new Users::Result
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
        var model = new Users::Result
        {
            ID = "9876543210",
            State = "liked",
            Type = Users::ResultType.StateChange,
        };

        Users::Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTypeTest : TestBase
{
    [Theory]
    [InlineData(Users::ResultType.Tweet)]
    [InlineData(Users::ResultType.DirectMessage)]
    [InlineData(Users::ResultType.Media)]
    [InlineData(Users::ResultType.Community)]
    [InlineData(Users::ResultType.StateChange)]
    public void Validation_Works(Users::ResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::ResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::ResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Users::ResultType.Tweet)]
    [InlineData(Users::ResultType.DirectMessage)]
    [InlineData(Users::ResultType.Media)]
    [InlineData(Users::ResultType.Community)]
    [InlineData(Users::ResultType.StateChange)]
    public void SerializationRoundtrip_Works(Users::ResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::ResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::ResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::ResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::ResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UserRemoveFollowerResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Accepted)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Dispatching)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.PendingConfirmation)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Success)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Failed)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Expired)]
    public void Validation_Works(Users::UserRemoveFollowerResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::UserRemoveFollowerResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Users::UserRemoveFollowerResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Accepted)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Dispatching)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.PendingConfirmation)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Success)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Failed)]
    [InlineData(Users::UserRemoveFollowerResponseStatus.Expired)]
    public void SerializationRoundtrip_Works(Users::UserRemoveFollowerResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::UserRemoveFollowerResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Users::UserRemoveFollowerResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Users::UserRemoveFollowerResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Users::UserRemoveFollowerResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TargetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Users::Target { ID = "9876543210", Type = Users::TargetType.Tweet };

        string expectedID = "9876543210";
        ApiEnum<string, Users::TargetType> expectedType = Users::TargetType.Tweet;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Users::Target { ID = "9876543210", Type = Users::TargetType.Tweet };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Target>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Users::Target { ID = "9876543210", Type = Users::TargetType.Tweet };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Users::Target>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        ApiEnum<string, Users::TargetType> expectedType = Users::TargetType.Tweet;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Users::Target { ID = "9876543210", Type = Users::TargetType.Tweet };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Users::Target { ID = "9876543210", Type = Users::TargetType.Tweet };

        Users::Target copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetTypeTest : TestBase
{
    [Theory]
    [InlineData(Users::TargetType.Tweet)]
    [InlineData(Users::TargetType.User)]
    [InlineData(Users::TargetType.Community)]
    public void Validation_Works(Users::TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::TargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Users::TargetType.Tweet)]
    [InlineData(Users::TargetType.User)]
    [InlineData(Users::TargetType.Community)]
    public void SerializationRoundtrip_Works(Users::TargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Users::TargetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Users::TargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Users::TargetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
