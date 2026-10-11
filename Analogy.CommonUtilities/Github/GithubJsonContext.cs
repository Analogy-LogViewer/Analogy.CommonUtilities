using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Analogy.CommonUtilities.Github
{
    [JsonSerializable(typeof(GitHubRateLimit))]
    [JsonSerializable(typeof(GitHubRepository[]))]
    [JsonSerializable(typeof(GithubReleaseEntry[]))]
    internal sealed partial class GithubJsonContext : JsonSerializerContext
    {
    }
}