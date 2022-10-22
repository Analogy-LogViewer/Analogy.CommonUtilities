using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Analogy.CommonUtilities.Web
{
    public class GithubObjects
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
            public GithubUser Author { get; set; }

            [JsonPropertyName("prerelease")]
            public bool PreRelease { get; set; }

            [JsonPropertyName("created_at")]
            public DateTime Created { get; set; }
            [JsonPropertyName("published_at")]
            public DateTime Published { get; set; }
            [JsonPropertyName("assets")]
            public GithubAsset[] Assets { get; set; }
            [JsonPropertyName("tarball_url")]
            public string tarball_url { get; set; }
            [JsonPropertyName("zipball_url")]
            public string zipball_url { get; set; }
            [JsonPropertyName("body")]
            public string Content { get; set; }

            public override string ToString()
            {
                return $"{TagName + Environment.NewLine}{nameof(Title)}: {Title}, {nameof(Content)}: {Content + Environment.NewLine}";
            }
        }
        [Serializable]
        public class GithubUser
        {
            [JsonPropertyName("login")]
            public string Login { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("avatar_url")]
            public string avatarUrl { get; set; }

            [JsonPropertyName("html_url")]
            public string HtmlUrl { get; set; }
        }

        [Serializable]
        public class GithubAsset
        {
            [JsonPropertyName("url")]
            public string URL { get; set; }
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("content_type")]
            public string ContentType { get; set; }
            [JsonPropertyName("size")]
            public long Size { get; set; }
            [JsonPropertyName("download_count")]
            public int Downloads { get; set; }
            [JsonPropertyName("created_at")]
            public DateTime Created { get; set; }
            [JsonPropertyName("updated_at")]
            public DateTime Updated { get; set; }
            [JsonPropertyName("browser_download_url")]
            public string BrowserDownloadUrl { get; set; }

            public override string ToString() => $"Asset Name: {Name}, URL: {URL}, Size: {Size}, Downloads: {Downloads}, Created: {Created}";
        }
    }
}
