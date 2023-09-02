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
        public int limit { get; set; }
        public int used { get; set; }
        public int remaining { get; set; }
        public int reset { get; set; }
    }

}
