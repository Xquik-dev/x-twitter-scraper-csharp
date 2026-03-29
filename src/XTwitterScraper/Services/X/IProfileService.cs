using System;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Services.X;

/// <summary>
/// X write actions (tweets, likes, follows, DMs)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Update X profile
    /// </summary>
    Task<ProfilePatchAllResponse> PatchAll(
        ProfilePatchAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update profile avatar
    /// </summary>
    Task<ProfileUpdateAvatarResponse> UpdateAvatar(
        ProfileUpdateAvatarParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update profile banner
    /// </summary>
    Task<ProfileUpdateBannerResponse> UpdateBanner(
        ProfileUpdateBannerParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /x/profile</c>, but is otherwise the
    /// same as <see cref="IProfileService.PatchAll(ProfilePatchAllParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProfilePatchAllResponse>> PatchAll(
        ProfilePatchAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /x/profile/avatar</c>, but is otherwise the
    /// same as <see cref="IProfileService.UpdateAvatar(ProfileUpdateAvatarParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProfileUpdateAvatarResponse>> UpdateAvatar(
        ProfileUpdateAvatarParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /x/profile/banner</c>, but is otherwise the
    /// same as <see cref="IProfileService.UpdateBanner(ProfileUpdateBannerParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProfileUpdateBannerResponse>> UpdateBanner(
        ProfileUpdateBannerParams parameters,
        CancellationToken cancellationToken = default
    );
}
