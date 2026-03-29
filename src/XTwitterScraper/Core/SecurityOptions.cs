using System;

namespace XTwitterScraper.Core;

readonly record struct SecurityOptions
{
    public SecurityOptions() { }

    public Boolean ApiKey { get; init; } = false;

    public Boolean OAuthBearer { get; init; } = false;

    public static SecurityOptions All() => new() { ApiKey = true, OAuthBearer = true };
}
