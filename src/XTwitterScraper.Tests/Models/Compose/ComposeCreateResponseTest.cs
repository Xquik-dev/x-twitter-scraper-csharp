using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Compose;

namespace XTwitterScraper.Tests.Models.Compose;

public class ComposeCreateResponseTest : TestBase
{
    [Fact]
    public void PrepareResultValidationWorks()
    {
        ComposeCreateResponse value = new ComposePrepareResult()
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
            SavedStyles = [new() { TweetCount = 0, Username = "username" }],
            StyleNote = "styleNote",
            StyleTweets = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void RefineResultValidationWorks()
    {
        ComposeCreateResponse value = new ComposeRefineResult()
        {
            CompositionGuidance = ["string"],
            ExamplePatterns =
            [
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
            ],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
        };
        value.Validate();
    }

    [Fact]
    public void ScoreResultValidationWorks()
    {
        ComposeCreateResponse value = new ComposeScoreResult()
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
            IntentUrl = "https://example.com",
        };
        value.Validate();
    }

    [Fact]
    public void PrepareResultSerializationRoundtripWorks()
    {
        ComposeCreateResponse value = new ComposePrepareResult()
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
            SavedStyles = [new() { TweetCount = 0, Username = "username" }],
            StyleNote = "styleNote",
            StyleTweets = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RefineResultSerializationRoundtripWorks()
    {
        ComposeCreateResponse value = new ComposeRefineResult()
        {
            CompositionGuidance = ["string"],
            ExamplePatterns =
            [
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
            ],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScoreResultSerializationRoundtripWorks()
    {
        ComposeCreateResponse value = new ComposeScoreResult()
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
            IntentUrl = "https://example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ComposePrepareResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
            SavedStyles = [new() { TweetCount = 0, Username = "username" }],
            StyleNote = "styleNote",
            StyleTweets = ["string"],
        };

        List<ContentRule> expectedContentRules =
        [
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
        ];
        List<EngagementMultiplier> expectedEngagementMultipliers =
        [
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
        ];
        string expectedEngagementVelocity = "engagementVelocity";
        List<string> expectedFollowUpQuestions = ["string", "string", "string", "string"];
        string expectedIntentUrl = "https://example.com";
        string expectedNextStep = "nextStep";
        List<ScorerWeight> expectedScorerWeights =
        [
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
        ];
        string expectedSource = "source";
        List<string> expectedTopPenalties = ["string", "string", "string", "string"];
        List<SavedStyle> expectedSavedStyles = [new() { TweetCount = 0, Username = "username" }];
        string expectedStyleNote = "styleNote";
        List<string> expectedStyleTweets = ["string"];

        Assert.Equal(expectedContentRules.Count, model.ContentRules.Count);
        for (int i = 0; i < expectedContentRules.Count; i++)
        {
            Assert.Equal(expectedContentRules[i], model.ContentRules[i]);
        }
        Assert.Equal(expectedEngagementMultipliers.Count, model.EngagementMultipliers.Count);
        for (int i = 0; i < expectedEngagementMultipliers.Count; i++)
        {
            Assert.Equal(expectedEngagementMultipliers[i], model.EngagementMultipliers[i]);
        }
        Assert.Equal(expectedEngagementVelocity, model.EngagementVelocity);
        Assert.Equal(expectedFollowUpQuestions.Count, model.FollowUpQuestions.Count);
        for (int i = 0; i < expectedFollowUpQuestions.Count; i++)
        {
            Assert.Equal(expectedFollowUpQuestions[i], model.FollowUpQuestions[i]);
        }
        Assert.Equal(expectedIntentUrl, model.IntentUrl);
        Assert.Equal(expectedNextStep, model.NextStep);
        Assert.Equal(expectedScorerWeights.Count, model.ScorerWeights.Count);
        for (int i = 0; i < expectedScorerWeights.Count; i++)
        {
            Assert.Equal(expectedScorerWeights[i], model.ScorerWeights[i]);
        }
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTopPenalties.Count, model.TopPenalties.Count);
        for (int i = 0; i < expectedTopPenalties.Count; i++)
        {
            Assert.Equal(expectedTopPenalties[i], model.TopPenalties[i]);
        }
        Assert.NotNull(model.SavedStyles);
        Assert.Equal(expectedSavedStyles.Count, model.SavedStyles.Count);
        for (int i = 0; i < expectedSavedStyles.Count; i++)
        {
            Assert.Equal(expectedSavedStyles[i], model.SavedStyles[i]);
        }
        Assert.Equal(expectedStyleNote, model.StyleNote);
        Assert.NotNull(model.StyleTweets);
        Assert.Equal(expectedStyleTweets.Count, model.StyleTweets.Count);
        for (int i = 0; i < expectedStyleTweets.Count; i++)
        {
            Assert.Equal(expectedStyleTweets[i], model.StyleTweets[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
            SavedStyles = [new() { TweetCount = 0, Username = "username" }],
            StyleNote = "styleNote",
            StyleTweets = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposePrepareResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
            SavedStyles = [new() { TweetCount = 0, Username = "username" }],
            StyleNote = "styleNote",
            StyleTweets = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposePrepareResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ContentRule> expectedContentRules =
        [
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
            new("rule"),
        ];
        List<EngagementMultiplier> expectedEngagementMultipliers =
        [
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
            new("action"),
        ];
        string expectedEngagementVelocity = "engagementVelocity";
        List<string> expectedFollowUpQuestions = ["string", "string", "string", "string"];
        string expectedIntentUrl = "https://example.com";
        string expectedNextStep = "nextStep";
        List<ScorerWeight> expectedScorerWeights =
        [
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
            new()
            {
                Context = "context",
                Signal = "signal",
                Weight = null,
            },
        ];
        string expectedSource = "source";
        List<string> expectedTopPenalties = ["string", "string", "string", "string"];
        List<SavedStyle> expectedSavedStyles = [new() { TweetCount = 0, Username = "username" }];
        string expectedStyleNote = "styleNote";
        List<string> expectedStyleTweets = ["string"];

        Assert.Equal(expectedContentRules.Count, deserialized.ContentRules.Count);
        for (int i = 0; i < expectedContentRules.Count; i++)
        {
            Assert.Equal(expectedContentRules[i], deserialized.ContentRules[i]);
        }
        Assert.Equal(expectedEngagementMultipliers.Count, deserialized.EngagementMultipliers.Count);
        for (int i = 0; i < expectedEngagementMultipliers.Count; i++)
        {
            Assert.Equal(expectedEngagementMultipliers[i], deserialized.EngagementMultipliers[i]);
        }
        Assert.Equal(expectedEngagementVelocity, deserialized.EngagementVelocity);
        Assert.Equal(expectedFollowUpQuestions.Count, deserialized.FollowUpQuestions.Count);
        for (int i = 0; i < expectedFollowUpQuestions.Count; i++)
        {
            Assert.Equal(expectedFollowUpQuestions[i], deserialized.FollowUpQuestions[i]);
        }
        Assert.Equal(expectedIntentUrl, deserialized.IntentUrl);
        Assert.Equal(expectedNextStep, deserialized.NextStep);
        Assert.Equal(expectedScorerWeights.Count, deserialized.ScorerWeights.Count);
        for (int i = 0; i < expectedScorerWeights.Count; i++)
        {
            Assert.Equal(expectedScorerWeights[i], deserialized.ScorerWeights[i]);
        }
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTopPenalties.Count, deserialized.TopPenalties.Count);
        for (int i = 0; i < expectedTopPenalties.Count; i++)
        {
            Assert.Equal(expectedTopPenalties[i], deserialized.TopPenalties[i]);
        }
        Assert.NotNull(deserialized.SavedStyles);
        Assert.Equal(expectedSavedStyles.Count, deserialized.SavedStyles.Count);
        for (int i = 0; i < expectedSavedStyles.Count; i++)
        {
            Assert.Equal(expectedSavedStyles[i], deserialized.SavedStyles[i]);
        }
        Assert.Equal(expectedStyleNote, deserialized.StyleNote);
        Assert.NotNull(deserialized.StyleTweets);
        Assert.Equal(expectedStyleTweets.Count, deserialized.StyleTweets.Count);
        for (int i = 0; i < expectedStyleTweets.Count; i++)
        {
            Assert.Equal(expectedStyleTweets[i], deserialized.StyleTweets[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
            SavedStyles = [new() { TweetCount = 0, Username = "username" }],
            StyleNote = "styleNote",
            StyleTweets = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
        };

        Assert.Null(model.SavedStyles);
        Assert.False(model.RawData.ContainsKey("savedStyles"));
        Assert.Null(model.StyleNote);
        Assert.False(model.RawData.ContainsKey("styleNote"));
        Assert.Null(model.StyleTweets);
        Assert.False(model.RawData.ContainsKey("styleTweets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],

            // Null should be interpreted as omitted for these properties
            SavedStyles = null,
            StyleNote = null,
            StyleTweets = null,
        };

        Assert.Null(model.SavedStyles);
        Assert.False(model.RawData.ContainsKey("savedStyles"));
        Assert.Null(model.StyleNote);
        Assert.False(model.RawData.ContainsKey("styleNote"));
        Assert.Null(model.StyleTweets);
        Assert.False(model.RawData.ContainsKey("styleTweets"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],

            // Null should be interpreted as omitted for these properties
            SavedStyles = null,
            StyleNote = null,
            StyleTweets = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComposePrepareResult
        {
            ContentRules =
            [
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
                new("rule"),
            ],
            EngagementMultipliers =
            [
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
                new("action"),
            ],
            EngagementVelocity = "engagementVelocity",
            FollowUpQuestions = ["string", "string", "string", "string"],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
            ScorerWeights =
            [
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
                new()
                {
                    Context = "context",
                    Signal = "signal",
                    Weight = null,
                },
            ],
            Source = "source",
            TopPenalties = ["string", "string", "string", "string"],
            SavedStyles = [new() { TweetCount = 0, Username = "username" }],
            StyleNote = "styleNote",
            StyleTweets = ["string"],
        };

        ComposePrepareResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentRuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentRule { Rule = "rule" };

        string expectedRule = "rule";

        Assert.Equal(expectedRule, model.Rule);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContentRule { Rule = "rule" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentRule>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContentRule { Rule = "rule" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentRule>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRule = "rule";

        Assert.Equal(expectedRule, deserialized.Rule);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContentRule { Rule = "rule" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContentRule { Rule = "rule" };

        ContentRule copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EngagementMultiplierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EngagementMultiplier { Action = "action" };

        string expectedAction = "action";
        JsonElement expectedMultiplier = JsonSerializer.SerializeToElement(
            "Production weight not published by X"
        );

        Assert.Equal(expectedAction, model.Action);
        Assert.True(JsonElement.DeepEquals(expectedMultiplier, model.Multiplier));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EngagementMultiplier { Action = "action" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EngagementMultiplier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EngagementMultiplier { Action = "action" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EngagementMultiplier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAction = "action";
        JsonElement expectedMultiplier = JsonSerializer.SerializeToElement(
            "Production weight not published by X"
        );

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.True(JsonElement.DeepEquals(expectedMultiplier, deserialized.Multiplier));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EngagementMultiplier { Action = "action" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EngagementMultiplier { Action = "action" };

        EngagementMultiplier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScorerWeightTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScorerWeight
        {
            Context = "context",
            Signal = "signal",
            Weight = null,
        };

        string expectedContext = "context";
        string expectedSignal = "signal";

        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedSignal, model.Signal);
        Assert.Null(model.Weight);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ScorerWeight
        {
            Context = "context",
            Signal = "signal",
            Weight = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScorerWeight>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScorerWeight
        {
            Context = "context",
            Signal = "signal",
            Weight = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScorerWeight>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContext = "context";
        string expectedSignal = "signal";

        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedSignal, deserialized.Signal);
        Assert.Null(deserialized.Weight);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ScorerWeight
        {
            Context = "context",
            Signal = "signal",
            Weight = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ScorerWeight
        {
            Context = "context",
            Signal = "signal",
            Weight = null,
        };

        ScorerWeight copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SavedStyleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SavedStyle { TweetCount = 0, Username = "username" };

        long expectedTweetCount = 0;
        string expectedUsername = "username";

        Assert.Equal(expectedTweetCount, model.TweetCount);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SavedStyle { TweetCount = 0, Username = "username" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SavedStyle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SavedStyle { TweetCount = 0, Username = "username" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SavedStyle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedTweetCount = 0;
        string expectedUsername = "username";

        Assert.Equal(expectedTweetCount, deserialized.TweetCount);
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SavedStyle { TweetCount = 0, Username = "username" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SavedStyle { TweetCount = 0, Username = "username" };

        SavedStyle copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComposeRefineResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComposeRefineResult
        {
            CompositionGuidance = ["string"],
            ExamplePatterns =
            [
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
            ],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
        };

        List<string> expectedCompositionGuidance = ["string"];
        List<ExamplePattern> expectedExamplePatterns =
        [
            new() { Description = "description", Pattern = "pattern" },
            new() { Description = "description", Pattern = "pattern" },
            new() { Description = "description", Pattern = "pattern" },
        ];
        string expectedIntentUrl = "https://example.com";
        string expectedNextStep = "nextStep";

        Assert.Equal(expectedCompositionGuidance.Count, model.CompositionGuidance.Count);
        for (int i = 0; i < expectedCompositionGuidance.Count; i++)
        {
            Assert.Equal(expectedCompositionGuidance[i], model.CompositionGuidance[i]);
        }
        Assert.Equal(expectedExamplePatterns.Count, model.ExamplePatterns.Count);
        for (int i = 0; i < expectedExamplePatterns.Count; i++)
        {
            Assert.Equal(expectedExamplePatterns[i], model.ExamplePatterns[i]);
        }
        Assert.Equal(expectedIntentUrl, model.IntentUrl);
        Assert.Equal(expectedNextStep, model.NextStep);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComposeRefineResult
        {
            CompositionGuidance = ["string"],
            ExamplePatterns =
            [
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
            ],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeRefineResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComposeRefineResult
        {
            CompositionGuidance = ["string"],
            ExamplePatterns =
            [
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
            ],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeRefineResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedCompositionGuidance = ["string"];
        List<ExamplePattern> expectedExamplePatterns =
        [
            new() { Description = "description", Pattern = "pattern" },
            new() { Description = "description", Pattern = "pattern" },
            new() { Description = "description", Pattern = "pattern" },
        ];
        string expectedIntentUrl = "https://example.com";
        string expectedNextStep = "nextStep";

        Assert.Equal(expectedCompositionGuidance.Count, deserialized.CompositionGuidance.Count);
        for (int i = 0; i < expectedCompositionGuidance.Count; i++)
        {
            Assert.Equal(expectedCompositionGuidance[i], deserialized.CompositionGuidance[i]);
        }
        Assert.Equal(expectedExamplePatterns.Count, deserialized.ExamplePatterns.Count);
        for (int i = 0; i < expectedExamplePatterns.Count; i++)
        {
            Assert.Equal(expectedExamplePatterns[i], deserialized.ExamplePatterns[i]);
        }
        Assert.Equal(expectedIntentUrl, deserialized.IntentUrl);
        Assert.Equal(expectedNextStep, deserialized.NextStep);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComposeRefineResult
        {
            CompositionGuidance = ["string"],
            ExamplePatterns =
            [
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
            ],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComposeRefineResult
        {
            CompositionGuidance = ["string"],
            ExamplePatterns =
            [
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
                new() { Description = "description", Pattern = "pattern" },
            ],
            IntentUrl = "https://example.com",
            NextStep = "nextStep",
        };

        ComposeRefineResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExamplePatternTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExamplePattern { Description = "description", Pattern = "pattern" };

        string expectedDescription = "description";
        string expectedPattern = "pattern";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedPattern, model.Pattern);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExamplePattern { Description = "description", Pattern = "pattern" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExamplePattern>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExamplePattern { Description = "description", Pattern = "pattern" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExamplePattern>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedPattern = "pattern";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedPattern, deserialized.Pattern);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExamplePattern { Description = "description", Pattern = "pattern" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExamplePattern { Description = "description", Pattern = "pattern" };

        ExamplePattern copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComposeScoreResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
            IntentUrl = "https://example.com",
        };

        List<Checklist> expectedChecklist =
        [
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
        ];
        string expectedNextStep = "nextStep";
        bool expectedPassed = true;
        long expectedPassedCount = 0;
        string expectedTopSuggestion = "topSuggestion";
        JsonElement expectedTotalChecks = JsonSerializer.SerializeToElement(9);
        string expectedIntentUrl = "https://example.com";

        Assert.Equal(expectedChecklist.Count, model.Checklist.Count);
        for (int i = 0; i < expectedChecklist.Count; i++)
        {
            Assert.Equal(expectedChecklist[i], model.Checklist[i]);
        }
        Assert.Equal(expectedNextStep, model.NextStep);
        Assert.Equal(expectedPassed, model.Passed);
        Assert.Equal(expectedPassedCount, model.PassedCount);
        Assert.Equal(expectedTopSuggestion, model.TopSuggestion);
        Assert.True(JsonElement.DeepEquals(expectedTotalChecks, model.TotalChecks));
        Assert.Equal(expectedIntentUrl, model.IntentUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
            IntentUrl = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeScoreResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
            IntentUrl = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeScoreResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Checklist> expectedChecklist =
        [
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
            new()
            {
                Factor = "factor",
                Passed = true,
                Suggestion = "suggestion",
            },
        ];
        string expectedNextStep = "nextStep";
        bool expectedPassed = true;
        long expectedPassedCount = 0;
        string expectedTopSuggestion = "topSuggestion";
        JsonElement expectedTotalChecks = JsonSerializer.SerializeToElement(9);
        string expectedIntentUrl = "https://example.com";

        Assert.Equal(expectedChecklist.Count, deserialized.Checklist.Count);
        for (int i = 0; i < expectedChecklist.Count; i++)
        {
            Assert.Equal(expectedChecklist[i], deserialized.Checklist[i]);
        }
        Assert.Equal(expectedNextStep, deserialized.NextStep);
        Assert.Equal(expectedPassed, deserialized.Passed);
        Assert.Equal(expectedPassedCount, deserialized.PassedCount);
        Assert.Equal(expectedTopSuggestion, deserialized.TopSuggestion);
        Assert.True(JsonElement.DeepEquals(expectedTotalChecks, deserialized.TotalChecks));
        Assert.Equal(expectedIntentUrl, deserialized.IntentUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
            IntentUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
        };

        Assert.Null(model.IntentUrl);
        Assert.False(model.RawData.ContainsKey("intentUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",

            // Null should be interpreted as omitted for these properties
            IntentUrl = null,
        };

        Assert.Null(model.IntentUrl);
        Assert.False(model.RawData.ContainsKey("intentUrl"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",

            // Null should be interpreted as omitted for these properties
            IntentUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComposeScoreResult
        {
            Checklist =
            [
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
                new()
                {
                    Factor = "factor",
                    Passed = true,
                    Suggestion = "suggestion",
                },
            ],
            NextStep = "nextStep",
            Passed = true,
            PassedCount = 0,
            TopSuggestion = "topSuggestion",
            IntentUrl = "https://example.com",
        };

        ComposeScoreResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChecklistTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Checklist
        {
            Factor = "factor",
            Passed = true,
            Suggestion = "suggestion",
        };

        string expectedFactor = "factor";
        bool expectedPassed = true;
        string expectedSuggestion = "suggestion";

        Assert.Equal(expectedFactor, model.Factor);
        Assert.Equal(expectedPassed, model.Passed);
        Assert.Equal(expectedSuggestion, model.Suggestion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Checklist
        {
            Factor = "factor",
            Passed = true,
            Suggestion = "suggestion",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checklist>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Checklist
        {
            Factor = "factor",
            Passed = true,
            Suggestion = "suggestion",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checklist>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFactor = "factor";
        bool expectedPassed = true;
        string expectedSuggestion = "suggestion";

        Assert.Equal(expectedFactor, deserialized.Factor);
        Assert.Equal(expectedPassed, deserialized.Passed);
        Assert.Equal(expectedSuggestion, deserialized.Suggestion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Checklist
        {
            Factor = "factor",
            Passed = true,
            Suggestion = "suggestion",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Checklist { Factor = "factor", Passed = true };

        Assert.Null(model.Suggestion);
        Assert.False(model.RawData.ContainsKey("suggestion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Checklist { Factor = "factor", Passed = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Checklist
        {
            Factor = "factor",
            Passed = true,

            // Null should be interpreted as omitted for these properties
            Suggestion = null,
        };

        Assert.Null(model.Suggestion);
        Assert.False(model.RawData.ContainsKey("suggestion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Checklist
        {
            Factor = "factor",
            Passed = true,

            // Null should be interpreted as omitted for these properties
            Suggestion = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Checklist
        {
            Factor = "factor",
            Passed = true,
            Suggestion = "suggestion",
        };

        Checklist copied = new(model);

        Assert.Equal(model, copied);
    }
}
