using Newtonsoft.Json;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    [JsonObject]
    public class GitHubRateLimit
    {
        [JsonProperty("resources")] public GitHubResources Resources { get; set; }
        [JsonProperty("rate")] public GitHubRate Rate { get; set; }
    }

    public class GitHubRate
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }
        [JsonProperty("used")]
        public int Used { get; set; }
        [JsonProperty("remaining")]
        public int Remaining { get; set; }
        [JsonProperty("reset")]
        public int Reset { get; set; }
    }
}