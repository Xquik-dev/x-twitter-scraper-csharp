using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Services;

/// <inheritdoc/>
public sealed class StyleService : IStyleService
{
    readonly Lazy<IStyleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStyleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IStyleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StyleService(this._client.WithOptions(modifier));
    }

    public StyleService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new StyleServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<StyleProfile> Retrieve(
        StyleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<StyleProfile> Retrieve(
        string username,
        StyleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StyleProfile> Update(
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<StyleProfile> Update(
        string username,
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StyleListResponse> List(
        StyleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(StyleDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string username,
        StyleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { Username = username }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<StyleProfile> Analyze(
        StyleAnalyzeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Analyze(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<StyleCompareResponse> Compare(
        StyleCompareParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Compare(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<StyleGetPerformanceResponse> GetPerformance(
        StyleGetPerformanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetPerformance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<StyleGetPerformanceResponse> GetPerformance(
        string username,
        StyleGetPerformanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetPerformance(parameters with { Username = username }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class StyleServiceWithRawResponse : IStyleServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStyleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StyleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StyleServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StyleProfile>> Retrieve(
        StyleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Username == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.Username' cannot be null");
        }

        HttpRequest<StyleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var styleProfile = await response
                    .Deserialize<StyleProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    styleProfile.Validate();
                }
                return styleProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<StyleProfile>> Retrieve(
        string username,
        StyleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StyleProfile>> Update(
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Username == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.Username' cannot be null");
        }

        HttpRequest<StyleUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var styleProfile = await response
                    .Deserialize<StyleProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    styleProfile.Validate();
                }
                return styleProfile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<StyleProfile>> Update(
        string username,
        StyleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StyleListResponse>> List(
        StyleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StyleListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var styles = await response
                    .Deserialize<StyleListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    styles.Validate();
                }
                return styles;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        StyleDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Username == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.Username' cannot be null");
        }

        HttpRequest<StyleDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string username,
        StyleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StyleProfile>> Analyze(
        StyleAnalyzeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<StyleAnalyzeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var styleProfile = await response
                    .Deserialize<StyleProfile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    styleProfile.Validate();
                }
                return styleProfile;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StyleCompareResponse>> Compare(
        StyleCompareParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<StyleCompareParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<StyleCompareResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<StyleGetPerformanceResponse>> GetPerformance(
        StyleGetPerformanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Username == null)
        {
            throw new XTwitterScraperInvalidDataException("'parameters.Username' cannot be null");
        }

        HttpRequest<StyleGetPerformanceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<StyleGetPerformanceResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<StyleGetPerformanceResponse>> GetPerformance(
        string username,
        StyleGetPerformanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetPerformance(parameters with { Username = username }, cancellationToken);
    }
}
