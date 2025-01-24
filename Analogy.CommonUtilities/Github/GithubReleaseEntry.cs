using System.Text.Json.Serialization;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    public class GithubReleaseEntry
    {
        [JsonPropertyName("url")]
        public string URL { get; set; }
        [JsonPropertyName("assets_url")]
        public string AssetsUrl { get; set; }
        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("tag_name")]
        public string TagName { get; set; }
        [JsonPropertyName("target_commitish")]
        public string Branch { get; set; }
        [JsonPropertyName("name")]
        public string Title { get; set; }
        [JsonPropertyName("draft")]
        public bool Draft { get; set; }

        [JsonPropertyName("author")]
        public GitHubUser Author { get; set; }

        [JsonPropertyName("prerelease")]
        public bool PreRelease { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Created { get; set; }
        [JsonPropertyName("published_at")]
        public DateTime Published { get; set; }
        [JsonPropertyName("assets")]
        public GithubAsset[] Assets { get; set; }
        [JsonPropertyName("tarball_url")]
        public string TarballUrl { get; set; }
        [JsonPropertyName("zipball_url")]
        public string ZipballUrl { get; set; }
        [JsonPropertyName("body")]
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{TagName + Environment.NewLine}{nameof(Title)}: {Title}, {nameof(Content)}: {Content + Environment.NewLine}";
        }
    }
}