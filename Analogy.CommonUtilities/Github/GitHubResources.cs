using System.Text.Json.Serialization;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    public class GitHubResources
    {
        [JsonPropertyName("core")] public GitHubRate Core { get; set; }
        [JsonPropertyName("graphql")] public GitHubRate Graphql { get; set; }
        [JsonPropertyName("integration_manifest")] public GitHubRate IntegrationManifest { get; set; }
        [JsonPropertyName("search")] public GitHubRate Search { get; set; }
    }
}