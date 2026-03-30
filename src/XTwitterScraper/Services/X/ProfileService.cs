using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Services.X;

/// <inheritdoc/>
public sealed class ProfileService : IProfileService
{
    readonly Lazy<IProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IXTwitterScraperClient _client;

    /// <inheritdoc/>
    public IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProfileService(this._client.WithOptions(modifier));
    }

    public ProfileService(IXTwitterScraperClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProfileServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ProfileUpdateResponse> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProfileUpdateAvatarResponse> UpdateAvatar(
        ProfileUpdateAvatarParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateAvatar(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProfileUpdateBannerResponse> UpdateBanner(
        ProfileUpdateBannerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateBanner(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ProfileServiceWithRawResponse : IProfileServiceWithRawResponse
{
    readonly IXTwitterScraperClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProfileServiceWithRawResponse(IXTwitterScraperClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileUpdateResponse>> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProfileUpdateParams> request = new()
        {
            Method = XTwitterScraperClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var profile = await response
                    .Deserialize<ProfileUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    profile.Validate();
                }
                return profile;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileUpdateAvatarResponse>> UpdateAvatar(
        ProfileUpdateAvatarParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProfileUpdateAvatarParams> request = new()
        {
            Method = XTwitterScraperClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ProfileUpdateAvatarResponse>(token)
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
    public async Task<HttpResponse<ProfileUpdateBannerResponse>> UpdateBanner(
        ProfileUpdateBannerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProfileUpdateBannerParams> request = new()
        {
            Method = XTwitterScraperClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ProfileUpdateBannerResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
