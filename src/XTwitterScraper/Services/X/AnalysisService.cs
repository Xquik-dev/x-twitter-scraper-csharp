// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using Analysis = XTwitterScraper.Models.X.Analysis;
using Models = XTwitterScraper.Models;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class AnalysisService : IAnalysisService
{
    readonly Lazy<IAnalysisServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAnalysisServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IAnalysisService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnalysisService(this._client.WithOptions(modifier));
    }

    public AnalysisService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AnalysisServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Models::TweetAnalysisPage> Sentiment(
        Analysis::AnalysisSentimentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Sentiment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::TweetAnalysisPage> Brand(
        Analysis::AnalysisBrandParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Brand(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::TweetAnalysisPage> News(
        Analysis::AnalysisNewsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.News(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::TweetAnalysisPage> MarketSignals(
        Analysis::AnalysisMarketSignalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MarketSignals(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::TweetAnalysisPage> ViralScore(
        Analysis::AnalysisViralScoreParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ViralScore(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::TweetAnalysisPage> Classify(
        Analysis::AnalysisClassifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Classify(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AnalysisServiceWithRawResponse : IAnalysisServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAnalysisServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnalysisServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AnalysisServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::TweetAnalysisPage>> Sentiment(
        Analysis::AnalysisSentimentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Analysis::AnalysisSentimentParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::TweetAnalysisPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::TweetAnalysisPage>> Brand(
        Analysis::AnalysisBrandParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Analysis::AnalysisBrandParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::TweetAnalysisPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::TweetAnalysisPage>> News(
        Analysis::AnalysisNewsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Analysis::AnalysisNewsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::TweetAnalysisPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::TweetAnalysisPage>> MarketSignals(
        Analysis::AnalysisMarketSignalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Analysis::AnalysisMarketSignalsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::TweetAnalysisPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::TweetAnalysisPage>> ViralScore(
        Analysis::AnalysisViralScoreParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Analysis::AnalysisViralScoreParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::TweetAnalysisPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::TweetAnalysisPage>> Classify(
        Analysis::AnalysisClassifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Analysis::AnalysisClassifyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<Models::TweetAnalysisPage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }
}
