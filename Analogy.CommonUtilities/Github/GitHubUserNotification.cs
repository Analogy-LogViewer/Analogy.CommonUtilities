using System.Text.Json.Serialization;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    public class GitHubUserNotification
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("unread")] public bool Unread { get; set; }
        [JsonPropertyName("updated_at")] public DateTime Updated { get; set; }
        [JsonPropertyName("subject")] public GitHubNotificationSubject Subject { get; set; }
        [JsonPropertyName("repository")] public GitHubNotificationRepository Repository { get; set; }
    }

    [Serializable]
    public class GitHubNotificationSubject
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("url")] public string URL { get; set; }
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("latest_comment_url")] public string LatestCommentUrl { get; set; }
    }

    [Serializable]
    public class GitHubNotificationRepository
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("full_name")] public string FullName { get; set; }
        [JsonPropertyName("html_url")] public string RepositoryHtmlUrl { get; set; }
        [JsonPropertyName("description")] public string RepositoryDescription { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
    }
}