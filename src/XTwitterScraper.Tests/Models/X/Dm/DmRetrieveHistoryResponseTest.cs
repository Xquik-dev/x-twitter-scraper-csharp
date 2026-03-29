using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Dm;

namespace XTwitterScraper.Tests.Models.X.Dm;

public class DmRetrieveHistoryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DmRetrieveHistoryResponse
        {
            HasNextPage = true,
            Messages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    ReceiverID = "receiverId",
                    SenderID = "senderId",
                    Text = "text",
                },
            ],
            NextCursor = "next_cursor",
        };

        bool expectedHasNextPage = true;
        List<Message> expectedMessages =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                ReceiverID = "receiverId",
                SenderID = "senderId",
                Text = "text",
            },
        ];
        string expectedNextCursor = "next_cursor";

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedMessages.Count, model.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], model.Messages[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DmRetrieveHistoryResponse
        {
            HasNextPage = true,
            Messages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    ReceiverID = "receiverId",
                    SenderID = "senderId",
                    Text = "text",
                },
            ],
            NextCursor = "next_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DmRetrieveHistoryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DmRetrieveHistoryResponse
        {
            HasNextPage = true,
            Messages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    ReceiverID = "receiverId",
                    SenderID = "senderId",
                    Text = "text",
                },
            ],
            NextCursor = "next_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DmRetrieveHistoryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        List<Message> expectedMessages =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                ReceiverID = "receiverId",
                SenderID = "senderId",
                Text = "text",
            },
        ];
        string expectedNextCursor = "next_cursor";

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedMessages.Count, deserialized.Messages.Count);
        for (int i = 0; i < expectedMessages.Count; i++)
        {
            Assert.Equal(expectedMessages[i], deserialized.Messages[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DmRetrieveHistoryResponse
        {
            HasNextPage = true,
            Messages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    ReceiverID = "receiverId",
                    SenderID = "senderId",
                    Text = "text",
                },
            ],
            NextCursor = "next_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DmRetrieveHistoryResponse
        {
            HasNextPage = true,
            Messages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    ReceiverID = "receiverId",
                    SenderID = "senderId",
                    Text = "text",
                },
            ],
            NextCursor = "next_cursor",
        };

        DmRetrieveHistoryResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
        {
            ID = "id",
            CreatedAt = "createdAt",
            ReceiverID = "receiverId",
            SenderID = "senderId",
            Text = "text",
        };

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedReceiverID = "receiverId";
        string expectedSenderID = "senderId";
        string expectedText = "text";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedReceiverID, model.ReceiverID);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
        {
            ID = "id",
            CreatedAt = "createdAt",
            ReceiverID = "receiverId",
            SenderID = "senderId",
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
        {
            ID = "id",
            CreatedAt = "createdAt",
            ReceiverID = "receiverId",
            SenderID = "senderId",
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedReceiverID = "receiverId";
        string expectedSenderID = "senderId";
        string expectedText = "text";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedReceiverID, deserialized.ReceiverID);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
        {
            ID = "id",
            CreatedAt = "createdAt",
            ReceiverID = "receiverId",
            SenderID = "senderId",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message { ID = "id" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.ReceiverID);
        Assert.False(model.RawData.ContainsKey("receiverId"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            ReceiverID = null,
            SenderID = null,
            Text = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.ReceiverID);
        Assert.False(model.RawData.ContainsKey("receiverId"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            ReceiverID = null,
            SenderID = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
        {
            ID = "id",
            CreatedAt = "createdAt",
            ReceiverID = "receiverId",
            SenderID = "senderId",
            Text = "text",
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}
