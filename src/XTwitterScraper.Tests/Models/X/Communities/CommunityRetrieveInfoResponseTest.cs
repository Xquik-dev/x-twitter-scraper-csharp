using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityRetrieveInfoResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = new()
            {
                ID = "1500000000000000000",
                BannerUrl = "banner_url",
                CreatedAt = "created_at",
                Description = "description",
                JoinPolicy = "join_policy",
                MemberCount = 0,
                ModeratorCount = 0,
                Name = "Tesla Fans",
                PrimaryTopic = new() { ID = "id", Name = "name" },
                Rules =
                [
                    new()
                    {
                        ID = "id",
                        Description = "description",
                        Name = "name",
                    },
                ],
            },
        };

        Community expectedCommunity = new()
        {
            ID = "1500000000000000000",
            BannerUrl = "banner_url",
            CreatedAt = "created_at",
            Description = "description",
            JoinPolicy = "join_policy",
            MemberCount = 0,
            ModeratorCount = 0,
            Name = "Tesla Fans",
            PrimaryTopic = new() { ID = "id", Name = "name" },
            Rules =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        Assert.Equal(expectedCommunity, model.Community);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = new()
            {
                ID = "1500000000000000000",
                BannerUrl = "banner_url",
                CreatedAt = "created_at",
                Description = "description",
                JoinPolicy = "join_policy",
                MemberCount = 0,
                ModeratorCount = 0,
                Name = "Tesla Fans",
                PrimaryTopic = new() { ID = "id", Name = "name" },
                Rules =
                [
                    new()
                    {
                        ID = "id",
                        Description = "description",
                        Name = "name",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveInfoResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = new()
            {
                ID = "1500000000000000000",
                BannerUrl = "banner_url",
                CreatedAt = "created_at",
                Description = "description",
                JoinPolicy = "join_policy",
                MemberCount = 0,
                ModeratorCount = 0,
                Name = "Tesla Fans",
                PrimaryTopic = new() { ID = "id", Name = "name" },
                Rules =
                [
                    new()
                    {
                        ID = "id",
                        Description = "description",
                        Name = "name",
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveInfoResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Community expectedCommunity = new()
        {
            ID = "1500000000000000000",
            BannerUrl = "banner_url",
            CreatedAt = "created_at",
            Description = "description",
            JoinPolicy = "join_policy",
            MemberCount = 0,
            ModeratorCount = 0,
            Name = "Tesla Fans",
            PrimaryTopic = new() { ID = "id", Name = "name" },
            Rules =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        Assert.Equal(expectedCommunity, deserialized.Community);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = new()
            {
                ID = "1500000000000000000",
                BannerUrl = "banner_url",
                CreatedAt = "created_at",
                Description = "description",
                JoinPolicy = "join_policy",
                MemberCount = 0,
                ModeratorCount = 0,
                Name = "Tesla Fans",
                PrimaryTopic = new() { ID = "id", Name = "name" },
                Rules =
                [
                    new()
                    {
                        ID = "id",
                        Description = "description",
                        Name = "name",
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = new()
            {
                ID = "1500000000000000000",
                BannerUrl = "banner_url",
                CreatedAt = "created_at",
                Description = "description",
                JoinPolicy = "join_policy",
                MemberCount = 0,
                ModeratorCount = 0,
                Name = "Tesla Fans",
                PrimaryTopic = new() { ID = "id", Name = "name" },
                Rules =
                [
                    new()
                    {
                        ID = "id",
                        Description = "description",
                        Name = "name",
                    },
                ],
            },
        };

        CommunityRetrieveInfoResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CommunityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Community
        {
            ID = "1500000000000000000",
            BannerUrl = "banner_url",
            CreatedAt = "created_at",
            Description = "description",
            JoinPolicy = "join_policy",
            MemberCount = 0,
            ModeratorCount = 0,
            Name = "Tesla Fans",
            PrimaryTopic = new() { ID = "id", Name = "name" },
            Rules =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        string expectedID = "1500000000000000000";
        string expectedBannerUrl = "banner_url";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        string expectedJoinPolicy = "join_policy";
        long expectedMemberCount = 0;
        long expectedModeratorCount = 0;
        string expectedName = "Tesla Fans";
        PrimaryTopic expectedPrimaryTopic = new() { ID = "id", Name = "name" };
        List<Rule> expectedRules =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Name = "name",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBannerUrl, model.BannerUrl);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedJoinPolicy, model.JoinPolicy);
        Assert.Equal(expectedMemberCount, model.MemberCount);
        Assert.Equal(expectedModeratorCount, model.ModeratorCount);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrimaryTopic, model.PrimaryTopic);
        Assert.NotNull(model.Rules);
        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Community
        {
            ID = "1500000000000000000",
            BannerUrl = "banner_url",
            CreatedAt = "created_at",
            Description = "description",
            JoinPolicy = "join_policy",
            MemberCount = 0,
            ModeratorCount = 0,
            Name = "Tesla Fans",
            PrimaryTopic = new() { ID = "id", Name = "name" },
            Rules =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Community>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Community
        {
            ID = "1500000000000000000",
            BannerUrl = "banner_url",
            CreatedAt = "created_at",
            Description = "description",
            JoinPolicy = "join_policy",
            MemberCount = 0,
            ModeratorCount = 0,
            Name = "Tesla Fans",
            PrimaryTopic = new() { ID = "id", Name = "name" },
            Rules =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Community>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "1500000000000000000";
        string expectedBannerUrl = "banner_url";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        string expectedJoinPolicy = "join_policy";
        long expectedMemberCount = 0;
        long expectedModeratorCount = 0;
        string expectedName = "Tesla Fans";
        PrimaryTopic expectedPrimaryTopic = new() { ID = "id", Name = "name" };
        List<Rule> expectedRules =
        [
            new()
            {
                ID = "id",
                Description = "description",
                Name = "name",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBannerUrl, deserialized.BannerUrl);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedJoinPolicy, deserialized.JoinPolicy);
        Assert.Equal(expectedMemberCount, deserialized.MemberCount);
        Assert.Equal(expectedModeratorCount, deserialized.ModeratorCount);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrimaryTopic, deserialized.PrimaryTopic);
        Assert.NotNull(deserialized.Rules);
        Assert.Equal(expectedRules.Count, deserialized.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], deserialized.Rules[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Community
        {
            ID = "1500000000000000000",
            BannerUrl = "banner_url",
            CreatedAt = "created_at",
            Description = "description",
            JoinPolicy = "join_policy",
            MemberCount = 0,
            ModeratorCount = 0,
            Name = "Tesla Fans",
            PrimaryTopic = new() { ID = "id", Name = "name" },
            Rules =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Community { ID = "1500000000000000000" };

        Assert.Null(model.BannerUrl);
        Assert.False(model.RawData.ContainsKey("banner_url"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.JoinPolicy);
        Assert.False(model.RawData.ContainsKey("join_policy"));
        Assert.Null(model.MemberCount);
        Assert.False(model.RawData.ContainsKey("member_count"));
        Assert.Null(model.ModeratorCount);
        Assert.False(model.RawData.ContainsKey("moderator_count"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PrimaryTopic);
        Assert.False(model.RawData.ContainsKey("primary_topic"));
        Assert.Null(model.Rules);
        Assert.False(model.RawData.ContainsKey("rules"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Community { ID = "1500000000000000000" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Community
        {
            ID = "1500000000000000000",

            // Null should be interpreted as omitted for these properties
            BannerUrl = null,
            CreatedAt = null,
            Description = null,
            JoinPolicy = null,
            MemberCount = null,
            ModeratorCount = null,
            Name = null,
            PrimaryTopic = null,
            Rules = null,
        };

        Assert.Null(model.BannerUrl);
        Assert.False(model.RawData.ContainsKey("banner_url"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.JoinPolicy);
        Assert.False(model.RawData.ContainsKey("join_policy"));
        Assert.Null(model.MemberCount);
        Assert.False(model.RawData.ContainsKey("member_count"));
        Assert.Null(model.ModeratorCount);
        Assert.False(model.RawData.ContainsKey("moderator_count"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PrimaryTopic);
        Assert.False(model.RawData.ContainsKey("primary_topic"));
        Assert.Null(model.Rules);
        Assert.False(model.RawData.ContainsKey("rules"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Community
        {
            ID = "1500000000000000000",

            // Null should be interpreted as omitted for these properties
            BannerUrl = null,
            CreatedAt = null,
            Description = null,
            JoinPolicy = null,
            MemberCount = null,
            ModeratorCount = null,
            Name = null,
            PrimaryTopic = null,
            Rules = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Community
        {
            ID = "1500000000000000000",
            BannerUrl = "banner_url",
            CreatedAt = "created_at",
            Description = "description",
            JoinPolicy = "join_policy",
            MemberCount = 0,
            ModeratorCount = 0,
            Name = "Tesla Fans",
            PrimaryTopic = new() { ID = "id", Name = "name" },
            Rules =
            [
                new()
                {
                    ID = "id",
                    Description = "description",
                    Name = "name",
                },
            ],
        };

        Community copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrimaryTopicTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PrimaryTopic { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PrimaryTopic { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PrimaryTopic>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PrimaryTopic { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PrimaryTopic>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PrimaryTopic { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PrimaryTopic { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PrimaryTopic { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PrimaryTopic
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PrimaryTopic
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PrimaryTopic { ID = "id", Name = "name" };

        PrimaryTopic copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rule
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rule
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rule
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rule
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rule { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rule { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Rule
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Description = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rule
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Description = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rule
        {
            ID = "id",
            Description = "description",
            Name = "name",
        };

        Rule copied = new(model);

        Assert.Equal(model, copied);
    }
}
