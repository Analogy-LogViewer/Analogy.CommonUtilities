using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    [JsonObject]
    public class GitHubTrafficView
    {
        [JsonProperty("count")] public int Count { get; set; }
        [JsonProperty("uniques")] public int Uniques { get; set; }
        [JsonProperty("timestamp")] public DateTime Timestamp { get; set; }
    }

    [Serializable]
    [JsonObject]
    public class GitHubTrafficViews
    {
        [JsonProperty("count")] public int Total { get; set; }
        [JsonProperty("views")] public GitHubTrafficView[] Views { get; set; }
    }

    [Serializable]
    [JsonObject]
    public class GitHubTrafficClones
    {
        [JsonProperty("count")] public int Total { get; set; }
        [JsonProperty("Uniques")] public int uniques { get; set; }
        [JsonProperty("clones")] public GitHubClone[] Clones { get; set; }
    }

    public class GitHubClone
    {
        public DateTime timestamp { get; set; }
        public int count { get; set; }
        public int uniques { get; set; }
    }
}
