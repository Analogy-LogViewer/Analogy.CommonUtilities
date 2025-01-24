using System.Text.Json;
using System.Text.Json.Serialization;

namespace Analogy.CommonUtilities.Github
{
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