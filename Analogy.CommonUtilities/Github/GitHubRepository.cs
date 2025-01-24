using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    public class GitHubRepository
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("node_id")] public string NodeId { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("full_name")] public string FullName { get; set; }
        [JsonPropertyName("private")] public bool Private { get; set; }
        [JsonPropertyName("owner")] public GitHubUser Owner { get; set; }

        [JsonPropertyName("fork")] public bool Fork { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("stargazers_count")] public int Stargazers { get; set; }
        [JsonPropertyName("watchers_count")] public int Watchers { get; set; }
        [JsonPropertyName("subscribers_count")] public int Subscribers { get; set; }
        [JsonPropertyName("forks_count")] public int Forks { get; set; }
        [JsonPropertyName("forks_url")] public string ForksUrl { get; set; }
        [JsonPropertyName("url")] public string ApiUrl { get; set; }
        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
        [JsonPropertyName("commits_url")] public string ApiCommitsUrl { get; set; }

        [JsonPropertyName("open_issues_count")] public int OpenIssues { get; set; }
        [JsonPropertyName("updated_at")] public DateTime UpdateTime { get; set; }
        [JsonPropertyName("pushed_at")] public DateTime PushTime { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Forks)}: {Forks}, {nameof(ApiUrl)}: {ApiUrl}";
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            ApiCommitsUrl = ApiCommitsUrl.Replace(@"{/sha}", "");
        }
    }
}