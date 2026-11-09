// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using Analysis = XTwitterScraper.Models.X.Analysis;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <summary>
/// Analysis operations of the Xquik API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions.</para>
/// </summary>
public interface IAnalysisService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAnalysisServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAnalysisService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Answers each post's attitude, its intensity &amp; its sarcasm probability. Sentiment analysis names each post's main emotion, such as joy or anger. Send post IDs, an X search, an account, a List, a post's replies or quotes, or your own texts. Each analyzed post costs 2 credits. A post without an analysis costs nothing.
    /// </summary>
    Task<Models::TweetAnalysisPage> Sentiment(
        Analysis::AnalysisSentimentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Answers whether each post is about your brand, the author's attitude toward it &amp; the author's relationship with it. Name the brand in analysis.targets. Each analyzed post costs 2 credits.
    /// </summary>
    Task<Models::TweetAnalysisPage> Brand(
        Analysis::AnalysisBrandParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Answers each post's format, such as reporting, commentary or speculation, its source attribution &amp; its relevance to your topic. Name the topic in analysis.targets. Each analyzed post costs 2 credits.
    /// </summary>
    Task<Models::TweetAnalysisPage> News(
        Analysis::AnalysisNewsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Answers each post's stance on an asset, its content type, its conviction &amp; its relevance. The summary counts bullish &amp; bearish posts per cashtag. Name the asset in analysis.targets. Each analyzed post costs 2 credits.
    /// </summary>
    Task<Models::TweetAnalysisPage> MarketSignals(
        Analysis::AnalysisMarketSignalsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Answers each post's hook, clarity, payoff, humor, spam risk &amp; likely reaction, &amp; adds a Viral Score from 0 to 100 with a verdict. The score rates the wording. It does not predict likes or views. Send drafts in texts to score them before posting. Each analyzed post costs 2 credits.
    ///
    /// `viralAlgorithmScore` turns a post's public counts into 1 comparable number.
    /// </summary>
    Task<Models::TweetAnalysisPage> ViralScore(
        Analysis::AnalysisViralScoreParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Answers 1 to 8 questions you write in analysis.questions. A choice picks a category, such as a topic. A score picks a level. A probability answers yes or no. Without questions it answers the sentiment questions. Each analyzed post costs 2 credits.
    /// </summary>
    Task<Models::TweetAnalysisPage> Classify(
        Analysis::AnalysisClassifyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAnalysisService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAnalysisServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAnalysisServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/analysis/sentiment</c>, but is otherwise the
    /// same as <see cref="IAnalysisService.Sentiment(Analysis::AnalysisSentimentParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::TweetAnalysisPage>> Sentiment(
        Analysis::AnalysisSentimentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/analysis/brand</c>, but is otherwise the
    /// same as <see cref="IAnalysisService.Brand(Analysis::AnalysisBrandParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::TweetAnalysisPage>> Brand(
        Analysis::AnalysisBrandParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/analysis/news</c>, but is otherwise the
    /// same as <see cref="IAnalysisService.News(Analysis::AnalysisNewsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::TweetAnalysisPage>> News(
        Analysis::AnalysisNewsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/analysis/market-signals</c>, but is otherwise the
    /// same as <see cref="IAnalysisService.MarketSignals(Analysis::AnalysisMarketSignalsParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::TweetAnalysisPage>> MarketSignals(
        Analysis::AnalysisMarketSignalsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/analysis/viral-score</c>, but is otherwise the
    /// same as <see cref="IAnalysisService.ViralScore(Analysis::AnalysisViralScoreParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::TweetAnalysisPage>> ViralScore(
        Analysis::AnalysisViralScoreParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /x/analysis/classify</c>, but is otherwise the
    /// same as <see cref="IAnalysisService.Classify(Analysis::AnalysisClassifyParams, CancellationToken)"/>
    /// </summary>
    Task<HttpResponse<Models::TweetAnalysisPage>> Classify(
        Analysis::AnalysisClassifyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
