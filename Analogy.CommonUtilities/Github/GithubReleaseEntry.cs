﻿using Newtonsoft.Json;

namespace Analogy.CommonUtilities.Github
{
    [Serializable]
    [JsonObject]
    public class GithubReleaseEntry
    {
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("assets_url")]
        public string AssetsUrl { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
        [JsonProperty("target_commitish")]
        public string Branch { get; set; }
        [JsonProperty("name")]
        public string Title { get; set; }
        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("author")]
        public GitHubUser Author { get; set; }

        [JsonProperty("prerelease")]
        public bool PreRelease { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created { get; set; }
        [JsonProperty("published_at")]
        public DateTime Published { get; set; }
        [JsonProperty("assets")]
        public GithubAsset[] Assets { get; set; }
        [JsonProperty("tarball_url")]
        public string TarballUrl { get; set; }
        [JsonProperty("zipball_url")]
        public string ZipballUrl { get; set; }
        [JsonProperty("body")]
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{TagName + Environment.NewLine}{nameof(Title)}: {Title}, {nameof(Content)}: {Content + Environment.NewLine}";
        }
    }
}