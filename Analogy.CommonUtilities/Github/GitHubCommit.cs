using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    public class GitHubCommit
    {
        [JsonPropertyName("sha")] public string Sha { get; set; }
        [JsonPropertyName("node_id")] public string NodeId { get; set; }
        [JsonPropertyName("commit")] public Commit Commit { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
        [JsonPropertyName("comments_url")] public string CommentsUrl { get; set; }
        [JsonPropertyName("author")] public GitHubUser Author { get; set; }
        [JsonPropertyName("committer")] public GitHubUser Committer { get; set; }
        [JsonPropertyName("parents")] public Parent[] Parents { get; set; }
    }

    public class Commit
    {
        [JsonPropertyName("author")] public Committer Author { get; set; }
        [JsonPropertyName("committer")] public Committer Committer { get; set; }
        [JsonPropertyName("message")] public string Message { get; set; }
        [JsonPropertyName("Tree")] public Tree Tree { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("comment_count")] public int CommentCount { get; set; }
        [JsonPropertyName("verification")] public Verification Verification { get; set; }
    }

    public class Committer
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("date")] public DateTime Date { get; set; }
    }

    public class Tree
    {
        [JsonPropertyName("sha")] public string Sha { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
    }
}

public class Verification
{
    [JsonPropertyName("verified")] public bool Verified { get; set; }
    [JsonPropertyName("reason")] public string Reason { get; set; }
    [JsonPropertyName("signature")] public string Signature { get; set; }
    [JsonPropertyName("payload")] public string Payload { get; set; }
}

public class Parent
{
    [JsonPropertyName("sha")] public string Sha { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }
    [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
}