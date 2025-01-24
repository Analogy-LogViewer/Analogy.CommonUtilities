using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    public class GitHubComment
    {
        [JsonPropertyName("url")] public string URL { get; set; }
        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
        [JsonPropertyName("issue_url")] public string IssueUrl { get; set; }
        [JsonPropertyName("id")] public int ID { get; set; }
        [JsonPropertyName("node_id")] public string NodeId { get; set; }
        [JsonPropertyName("user")] public GitHubUser User { get; set; }
        [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }
        [JsonPropertyName("author_association")] public string AuthorAssociation { get; set; }
        [JsonPropertyName("body")] public string Body { get; set; }
    }

    public class GitHubComments
    {
        private GitHubComment[] Comments { get; set; }
    }
}