using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    public class GitHubIssue
    {
        [JsonProperty("url")] public string URL { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("repository_url")] public string RepositoryUrl { get; set; }
        [JsonProperty("labels_url")] public string LabelsUrl { get; set; }
        [JsonProperty("comments_url")] public string CommentsUrl { get; set; }
        [JsonProperty("events_url")] public string EventsUrl { get; set; }
        [JsonProperty("html_url")] public string HtmlUrl { get; set; }
        [JsonProperty("node_id")] public string NodeId { get; set; }
        [JsonProperty("number")] public int Number { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("User")] public GitHubUser User { get; set; }
        [JsonProperty("labels")] public GitHubLabel[] Labels { get; set; }
        [JsonProperty("state")] public string State { get; set; }
        [JsonProperty("locked")] public bool Locked { get; set; }
        [JsonProperty("assignee")] public object Assignee { get; set; }
        [JsonProperty("assignees")] public object[] Assignees { get; set; }
        [JsonProperty("milestone")] public object Milestone { get; set; }
        [JsonProperty("comments")] public int Comments { get; set; }
        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
        [JsonProperty("closed_at")] public object ClosedAt { get; set; }
        [JsonProperty("author_association")] public string AuthorAssociation { get; set; }
        [JsonProperty("body")] public string Body { get; set; }
        [JsonProperty("pull_request")] public GitHubPullRequest PullRequest { get; set; }
    }

    public class GitHubPullRequest
    {
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("html_url")] public string HtmlUrl { get; set; }
        [JsonProperty("diff_url")] public string DiffUrl { get; set; }
        [JsonProperty("patch_url")] public string PatchUrl { get; set; }
    }

    public class GitHubLabel
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("node_id")] public string NodeId { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("color")] public string Color { get; set; }
        [JsonProperty("_default")] public bool Default { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
    }
}