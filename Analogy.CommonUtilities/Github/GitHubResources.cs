using Newtonsoft.Json;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    [JsonObject]
    public class GitHubResources
    {
        [JsonProperty("core")] public GitHubRate Core { get; set; }
        [JsonProperty("graphql")] public GitHubRate Graphql { get; set; }
        [JsonProperty("integration_manifest")] public GitHubRate IntegrationManifest { get; set; }
        [JsonProperty("search")] public GitHubRate Search { get; set; }
    }
}