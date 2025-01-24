using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    public class GitHubIssue
    {
        [JsonPropertyName("url")] public string URL { get; set; }
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("repository_url")] public string RepositoryUrl { get; set; }
        [JsonPropertyName("labels_url")] public string LabelsUrl { get; set; }
        [JsonPropertyName("comments_url")] public string CommentsUrl { get; set; }
        [JsonPropertyName("events_url")] public string EventsUrl { get; set; }
        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
        [JsonPropertyName("node_id")] public string NodeId { get; set; }
        [JsonPropertyName("number")] public int Number { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("User")] public GitHubUser User { get; set; }
        [JsonPropertyName("labels")] public GitHubLabel[] Labels { get; set; }
        [JsonPropertyName("state")] public string State { get; set; }
        [JsonPropertyName("locked")] public bool Locked { get; set; }
        [JsonPropertyName("assignee")] public object Assignee { get; set; }
        [JsonPropertyName("assignees")] public object[] Assignees { get; set; }
        [JsonPropertyName("milestone")] public object Milestone { get; set; }
        [JsonPropertyName("comments")] public int Comments { get; set; }
        [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }
        [JsonPropertyName("closed_at")] public object ClosedAt { get; set; }
        [JsonPropertyName("author_association")] public string AuthorAssociation { get; set; }
        [JsonPropertyName("body")] public string Body { get; set; }
        [JsonPropertyName("pull_request")] public GitHubPullRequest PullRequest { get; set; }
    }

    public class GitHubPullRequest
    {
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
        [JsonPropertyName("diff_url")] public string DiffUrl { get; set; }
        [JsonPropertyName("patch_url")] public string PatchUrl { get; set; }
    }

    public class GitHubLabel
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("node_id")] public string NodeId { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("color")] public string Color { get; set; }
        [JsonPropertyName("_default")] public bool Default { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
    }
}