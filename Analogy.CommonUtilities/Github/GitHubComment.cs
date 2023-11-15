using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    public class GitHubComment
    {
        [JsonProperty("url")] public string URL { get; set; }
        [JsonProperty("html_url")] public string HtmlUrl { get; set; }
        [JsonProperty("issue_url")] public string IssueUrl { get; set; }
        [JsonProperty("id")] public int ID { get; set; }
        [JsonProperty("node_id")] public string NodeId { get; set; }
        [JsonProperty("user")] public GitHubUser User { get; set; }
        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
        [JsonProperty("author_association")] public string AuthorAssociation { get; set; }
        [JsonProperty("body")] public string Body { get; set; }
    }

    public class GitHubComments
    {
        private GitHubComment[] Comments { get; set; }
    }
}