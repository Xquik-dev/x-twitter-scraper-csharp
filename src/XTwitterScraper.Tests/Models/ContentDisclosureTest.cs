// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class ContentDisclosureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentDisclosure
        {
            Advertising = new() { IsPaidPromotion = true },
            AIGenerated = new()
            {
                CanEdit = true,
                DetectionSource = "UserDeclared",
                HasAIGeneratedMedia = true,
            },
        };

        Advertising expectedAdvertising = new() { IsPaidPromotion = true };
        AIGenerated expectedAIGenerated = new()
        {
            CanEdit = true,
            DetectionSource = "UserDeclared",
            HasAIGeneratedMedia = true,
        };

        Assert.Equal(expectedAdvertising, model.Advertising);
        Assert.Equal(expectedAIGenerated, model.AIGenerated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContentDisclosure
        {
            Advertising = new() { IsPaidPromotion = true },
            AIGenerated = new()
            {
                CanEdit = true,
                DetectionSource = "UserDeclared",
                HasAIGeneratedMedia = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentDisclosure>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContentDisclosure
        {
            Advertising = new() { IsPaidPromotion = true },
            AIGenerated = new()
            {
                CanEdit = true,
                DetectionSource = "UserDeclared",
                HasAIGeneratedMedia = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentDisclosure>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Advertising expectedAdvertising = new() { IsPaidPromotion = true };
        AIGenerated expectedAIGenerated = new()
        {
            CanEdit = true,
            DetectionSource = "UserDeclared",
            HasAIGeneratedMedia = true,
        };

        Assert.Equal(expectedAdvertising, deserialized.Advertising);
        Assert.Equal(expectedAIGenerated, deserialized.AIGenerated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContentDisclosure
        {
            Advertising = new() { IsPaidPromotion = true },
            AIGenerated = new()
            {
                CanEdit = true,
                DetectionSource = "UserDeclared",
                HasAIGeneratedMedia = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContentDisclosure { };

        Assert.Null(model.Advertising);
        Assert.False(model.RawData.ContainsKey("advertising"));
        Assert.Null(model.AIGenerated);
        Assert.False(model.RawData.ContainsKey("aiGenerated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContentDisclosure { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContentDisclosure
        {
            // Null should be interpreted as omitted for these properties
            Advertising = null,
            AIGenerated = null,
        };

        Assert.Null(model.Advertising);
        Assert.False(model.RawData.ContainsKey("advertising"));
        Assert.Null(model.AIGenerated);
        Assert.False(model.RawData.ContainsKey("aiGenerated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContentDisclosure
        {
            // Null should be interpreted as omitted for these properties
            Advertising = null,
            AIGenerated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContentDisclosure
        {
            Advertising = new() { IsPaidPromotion = true },
            AIGenerated = new()
            {
                CanEdit = true,
                DetectionSource = "UserDeclared",
                HasAIGeneratedMedia = true,
            },
        };

        ContentDisclosure copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AdvertisingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Advertising { IsPaidPromotion = true };

        bool expectedIsPaidPromotion = true;

        Assert.Equal(expectedIsPaidPromotion, model.IsPaidPromotion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Advertising { IsPaidPromotion = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Advertising>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Advertising { IsPaidPromotion = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Advertising>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsPaidPromotion = true;

        Assert.Equal(expectedIsPaidPromotion, deserialized.IsPaidPromotion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Advertising { IsPaidPromotion = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Advertising { };

        Assert.Null(model.IsPaidPromotion);
        Assert.False(model.RawData.ContainsKey("isPaidPromotion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Advertising { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Advertising
        {
            // Null should be interpreted as omitted for these properties
            IsPaidPromotion = null,
        };

        Assert.Null(model.IsPaidPromotion);
        Assert.False(model.RawData.ContainsKey("isPaidPromotion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Advertising
        {
            // Null should be interpreted as omitted for these properties
            IsPaidPromotion = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Advertising { IsPaidPromotion = true };

        Advertising copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AIGeneratedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AIGenerated
        {
            CanEdit = true,
            DetectionSource = "UserDeclared",
            HasAIGeneratedMedia = true,
        };

        bool expectedCanEdit = true;
        string expectedDetectionSource = "UserDeclared";
        bool expectedHasAIGeneratedMedia = true;

        Assert.Equal(expectedCanEdit, model.CanEdit);
        Assert.Equal(expectedDetectionSource, model.DetectionSource);
        Assert.Equal(expectedHasAIGeneratedMedia, model.HasAIGeneratedMedia);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AIGenerated
        {
            CanEdit = true,
            DetectionSource = "UserDeclared",
            HasAIGeneratedMedia = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIGenerated>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AIGenerated
        {
            CanEdit = true,
            DetectionSource = "UserDeclared",
            HasAIGeneratedMedia = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIGenerated>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanEdit = true;
        string expectedDetectionSource = "UserDeclared";
        bool expectedHasAIGeneratedMedia = true;

        Assert.Equal(expectedCanEdit, deserialized.CanEdit);
        Assert.Equal(expectedDetectionSource, deserialized.DetectionSource);
        Assert.Equal(expectedHasAIGeneratedMedia, deserialized.HasAIGeneratedMedia);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AIGenerated
        {
            CanEdit = true,
            DetectionSource = "UserDeclared",
            HasAIGeneratedMedia = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AIGenerated { };

        Assert.Null(model.CanEdit);
        Assert.False(model.RawData.ContainsKey("canEdit"));
        Assert.Null(model.DetectionSource);
        Assert.False(model.RawData.ContainsKey("detectionSource"));
        Assert.Null(model.HasAIGeneratedMedia);
        Assert.False(model.RawData.ContainsKey("hasAiGeneratedMedia"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AIGenerated { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AIGenerated
        {
            // Null should be interpreted as omitted for these properties
            CanEdit = null,
            DetectionSource = null,
            HasAIGeneratedMedia = null,
        };

        Assert.Null(model.CanEdit);
        Assert.False(model.RawData.ContainsKey("canEdit"));
        Assert.Null(model.DetectionSource);
        Assert.False(model.RawData.ContainsKey("detectionSource"));
        Assert.Null(model.HasAIGeneratedMedia);
        Assert.False(model.RawData.ContainsKey("hasAiGeneratedMedia"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AIGenerated
        {
            // Null should be interpreted as omitted for these properties
            CanEdit = null,
            DetectionSource = null,
            HasAIGeneratedMedia = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AIGenerated
        {
            CanEdit = true,
            DetectionSource = "UserDeclared",
            HasAIGeneratedMedia = true,
        };

        AIGenerated copied = new(model);

        Assert.Equal(model, copied);
    }
}
