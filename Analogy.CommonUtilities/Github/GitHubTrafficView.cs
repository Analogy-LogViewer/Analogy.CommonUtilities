using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    public class GitHubTrafficView
    {
        [JsonPropertyName("count")] public int Count { get; set; }
        [JsonPropertyName("uniques")] public int Uniques { get; set; }
        [JsonPropertyName("timestamp")] public DateTime Timestamp { get; set; }
    }

    [Serializable]
    public class GitHubTrafficViews
    {
        [JsonPropertyName("count")] public int Total { get; set; }
        [JsonPropertyName("views")] public GitHubTrafficView[] Views { get; set; }
    }

    [Serializable]
    public class GitHubTrafficClones
    {
        [JsonPropertyName("count")] public int Total { get; set; }
        [JsonPropertyName("Uniques")] public int uniques { get; set; }
        [JsonPropertyName("clones")] public GitHubClone[] Clones { get; set; }
    }

    public class GitHubClone
    {
        public DateTime timestamp { get; set; }
        public int count { get; set; }
        public int uniques { get; set; }
    }
}