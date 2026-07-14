using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.WriteActions;

namespace XTwitterScraper.Tests.Models.X.WriteActions;

public class WriteActionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmationSource = "read_confirmation",
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TargetID = "1234567890",
            TweetID = "1234567890",
        };

        string expectedAction = "create_tweet";
        bool expectedCharged = false;
        string expectedChargedCredits = "32";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z");
        WriteActionRetrieveResponseMedia expectedMedia = new()
        {
            Count = 1,
            Credits = "2",
            Kind = Kind.Video,
            TotalBytes = "834921",
        };
        JsonElement expectedRetryable = JsonSerializer.SerializeToElement(false);
        bool expectedSendDispatched = true;
        ApiEnum<string, Status> expectedStatus = Status.PendingConfirmation;
        string expectedWriteActionID = "42";
        long expectedConfirmationAttempts = 2;
        DateTimeOffset expectedConfirmationCheckedAt = DateTimeOffset.Parse(
            "2026-05-08T20:00:05.000Z"
        );
        string expectedConfirmationSource = "read_confirmation";
        DateTimeOffset expectedConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z");
        string expectedMessage = "Confirmation is still pending.";
        string expectedMessageID = "1234567890";
        DateTimeOffset expectedSendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z");
        string expectedTargetID = "1234567890";
        string expectedTweetID = "1234567890";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedCharged, model.Charged);
        Assert.Equal(expectedChargedCredits, model.ChargedCredits);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMedia, model.Media);
        Assert.True(JsonElement.DeepEquals(expectedRetryable, model.Retryable));
        Assert.Equal(expectedSendDispatched, model.SendDispatched);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedWriteActionID, model.WriteActionID);
        Assert.Equal(expectedConfirmationAttempts, model.ConfirmationAttempts);
        Assert.Equal(expectedConfirmationCheckedAt, model.ConfirmationCheckedAt);
        Assert.Equal(expectedConfirmationSource, model.ConfirmationSource);
        Assert.Equal(expectedConfirmedAt, model.ConfirmedAt);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedSendDispatchedAt, model.SendDispatchedAt);
        Assert.Equal(expectedTargetID, model.TargetID);
        Assert.Equal(expectedTweetID, model.TweetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmationSource = "read_confirmation",
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TargetID = "1234567890",
            TweetID = "1234567890",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WriteActionRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmationSource = "read_confirmation",
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TargetID = "1234567890",
            TweetID = "1234567890",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WriteActionRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAction = "create_tweet";
        bool expectedCharged = false;
        string expectedChargedCredits = "32";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z");
        WriteActionRetrieveResponseMedia expectedMedia = new()
        {
            Count = 1,
            Credits = "2",
            Kind = Kind.Video,
            TotalBytes = "834921",
        };
        JsonElement expectedRetryable = JsonSerializer.SerializeToElement(false);
        bool expectedSendDispatched = true;
        ApiEnum<string, Status> expectedStatus = Status.PendingConfirmation;
        string expectedWriteActionID = "42";
        long expectedConfirmationAttempts = 2;
        DateTimeOffset expectedConfirmationCheckedAt = DateTimeOffset.Parse(
            "2026-05-08T20:00:05.000Z"
        );
        string expectedConfirmationSource = "read_confirmation";
        DateTimeOffset expectedConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z");
        string expectedMessage = "Confirmation is still pending.";
        string expectedMessageID = "1234567890";
        DateTimeOffset expectedSendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z");
        string expectedTargetID = "1234567890";
        string expectedTweetID = "1234567890";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedCharged, deserialized.Charged);
        Assert.Equal(expectedChargedCredits, deserialized.ChargedCredits);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMedia, deserialized.Media);
        Assert.True(JsonElement.DeepEquals(expectedRetryable, deserialized.Retryable));
        Assert.Equal(expectedSendDispatched, deserialized.SendDispatched);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedWriteActionID, deserialized.WriteActionID);
        Assert.Equal(expectedConfirmationAttempts, deserialized.ConfirmationAttempts);
        Assert.Equal(expectedConfirmationCheckedAt, deserialized.ConfirmationCheckedAt);
        Assert.Equal(expectedConfirmationSource, deserialized.ConfirmationSource);
        Assert.Equal(expectedConfirmedAt, deserialized.ConfirmedAt);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedSendDispatchedAt, deserialized.SendDispatchedAt);
        Assert.Equal(expectedTargetID, deserialized.TargetID);
        Assert.Equal(expectedTweetID, deserialized.TweetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmationSource = "read_confirmation",
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TargetID = "1234567890",
            TweetID = "1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationSource = "read_confirmation",
            TargetID = "1234567890",
        };

        Assert.Null(model.ConfirmationAttempts);
        Assert.False(model.RawData.ContainsKey("confirmationAttempts"));
        Assert.Null(model.ConfirmationCheckedAt);
        Assert.False(model.RawData.ContainsKey("confirmationCheckedAt"));
        Assert.Null(model.ConfirmedAt);
        Assert.False(model.RawData.ContainsKey("confirmedAt"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
        Assert.Null(model.SendDispatchedAt);
        Assert.False(model.RawData.ContainsKey("sendDispatchedAt"));
        Assert.Null(model.TweetID);
        Assert.False(model.RawData.ContainsKey("tweetId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationSource = "read_confirmation",
            TargetID = "1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationSource = "read_confirmation",
            TargetID = "1234567890",

            // Null should be interpreted as omitted for these properties
            ConfirmationAttempts = null,
            ConfirmationCheckedAt = null,
            ConfirmedAt = null,
            Message = null,
            MessageID = null,
            SendDispatchedAt = null,
            TweetID = null,
        };

        Assert.Null(model.ConfirmationAttempts);
        Assert.False(model.RawData.ContainsKey("confirmationAttempts"));
        Assert.Null(model.ConfirmationCheckedAt);
        Assert.False(model.RawData.ContainsKey("confirmationCheckedAt"));
        Assert.Null(model.ConfirmedAt);
        Assert.False(model.RawData.ContainsKey("confirmedAt"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
        Assert.Null(model.SendDispatchedAt);
        Assert.False(model.RawData.ContainsKey("sendDispatchedAt"));
        Assert.Null(model.TweetID);
        Assert.False(model.RawData.ContainsKey("tweetId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationSource = "read_confirmation",
            TargetID = "1234567890",

            // Null should be interpreted as omitted for these properties
            ConfirmationAttempts = null,
            ConfirmationCheckedAt = null,
            ConfirmedAt = null,
            Message = null,
            MessageID = null,
            SendDispatchedAt = null,
            TweetID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TweetID = "1234567890",
        };

        Assert.Null(model.ConfirmationSource);
        Assert.False(model.RawData.ContainsKey("confirmationSource"));
        Assert.Null(model.TargetID);
        Assert.False(model.RawData.ContainsKey("targetId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TweetID = "1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TweetID = "1234567890",

            ConfirmationSource = null,
            TargetID = null,
        };

        Assert.Null(model.ConfirmationSource);
        Assert.True(model.RawData.ContainsKey("confirmationSource"));
        Assert.Null(model.TargetID);
        Assert.True(model.RawData.ContainsKey("targetId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TweetID = "1234567890",

            ConfirmationSource = null,
            TargetID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WriteActionRetrieveResponse
        {
            Action = "create_tweet",
            Charged = false,
            ChargedCredits = "32",
            CreatedAt = DateTimeOffset.Parse("2026-05-08T20:00:00.000Z"),
            Media = new()
            {
                Count = 1,
                Credits = "2",
                Kind = Kind.Video,
                TotalBytes = "834921",
            },
            SendDispatched = true,
            Status = Status.PendingConfirmation,
            WriteActionID = "42",
            ConfirmationAttempts = 2,
            ConfirmationCheckedAt = DateTimeOffset.Parse("2026-05-08T20:00:05.000Z"),
            ConfirmationSource = "read_confirmation",
            ConfirmedAt = DateTimeOffset.Parse("2026-05-08T20:00:06.000Z"),
            Message = "Confirmation is still pending.",
            MessageID = "1234567890",
            SendDispatchedAt = DateTimeOffset.Parse("2026-05-08T20:00:01.000Z"),
            TargetID = "1234567890",
            TweetID = "1234567890",
        };

        WriteActionRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WriteActionRetrieveResponseMediaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WriteActionRetrieveResponseMedia
        {
            Count = 1,
            Credits = "2",
            Kind = Kind.Video,
            TotalBytes = "834921",
        };

        long expectedCount = 1;
        string expectedCredits = "2";
        ApiEnum<string, Kind> expectedKind = Kind.Video;
        string expectedTotalBytes = "834921";

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedCredits, model.Credits);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedTotalBytes, model.TotalBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WriteActionRetrieveResponseMedia
        {
            Count = 1,
            Credits = "2",
            Kind = Kind.Video,
            TotalBytes = "834921",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WriteActionRetrieveResponseMedia>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WriteActionRetrieveResponseMedia
        {
            Count = 1,
            Credits = "2",
            Kind = Kind.Video,
            TotalBytes = "834921",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WriteActionRetrieveResponseMedia>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 1;
        string expectedCredits = "2";
        ApiEnum<string, Kind> expectedKind = Kind.Video;
        string expectedTotalBytes = "834921";

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedCredits, deserialized.Credits);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedTotalBytes, deserialized.TotalBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WriteActionRetrieveResponseMedia
        {
            Count = 1,
            Credits = "2",
            Kind = Kind.Video,
            TotalBytes = "834921",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WriteActionRetrieveResponseMedia
        {
            Count = 1,
            Credits = "2",
            Kind = Kind.Video,
            TotalBytes = "834921",
        };

        WriteActionRetrieveResponseMedia copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class KindTest : TestBase
{
    [Theory]
    [InlineData(Kind.None)]
    [InlineData(Kind.Image)]
    [InlineData(Kind.Video)]
    public void Validation_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Kind.None)]
    [InlineData(Kind.Image)]
    [InlineData(Kind.Video)]
    public void SerializationRoundtrip_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.Failed)]
    [InlineData(Status.PendingConfirmation)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.Failed)]
    [InlineData(Status.PendingConfirmation)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
