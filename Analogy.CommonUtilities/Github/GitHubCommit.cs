using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Github
{
    public class GitHubCommit
    {
        [JsonProperty("sha")] public string Sha { get; set; }
        [JsonProperty("node_id")] public string NodeId { get; set; }
        [JsonProperty("commit")] public Commit Commit { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("html_url")] public string HtmlUrl { get; set; }
        [JsonProperty("comments_url")] public string CommentsUrl { get; set; }
        [JsonProperty("author")] public GitHubUser Author { get; set; }
        [JsonProperty("committer")] public GitHubUser Committer { get; set; }
        [JsonProperty("parents")] public Parent[] Parents { get; set; }
    }

    public class Commit
    {
        [JsonProperty("author")] public Committer Author { get; set; }
        [JsonProperty("committer")] public Committer Committer { get; set; }
        [JsonProperty("message")] public string Message { get; set; }
        [JsonProperty("Tree")] public Tree Tree { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("comment_count")] public int CommentCount { get; set; }
        [JsonProperty("verification")] public Verification Verification { get; set; }
    }

    public class Committer
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("date")] public DateTime Date { get; set; }
    }

    public class Tree
    {
        [JsonProperty("sha")] public string Sha { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
    }
}

public class Verification
{
    [JsonProperty("verified")] public bool Verified { get; set; }
    [JsonProperty("reason")] public string Reason { get; set; }
    [JsonProperty("signature")] public string Signature { get; set; }
    [JsonProperty("payload")] public string Payload { get; set; }
}

public class Parent
{
    [JsonProperty("sha")] public string Sha { get; set; }
    [JsonProperty("url")] public string Url { get; set; }
    [JsonProperty("html_url")] public string HtmlUrl { get; set; }
}