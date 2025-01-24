using System.Text.Json.Serialization;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    public class GitHubRateLimit
    {
        [JsonPropertyName("resources")] public GitHubResources Resources { get; set; }
        [JsonPropertyName("rate")] public GitHubRate Rate { get; set; }
    }

    public class GitHubRate
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        [JsonPropertyName("used")]
        public int Used { get; set; }
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }
        [JsonPropertyName("reset")]
        public int Reset { get; set; }
    }
}