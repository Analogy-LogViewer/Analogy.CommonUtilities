using System;
using System.Linq;
using System.Net;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Analogy.CommonUtilities.Github;
using Newtonsoft.Json;


namespace Analogy.CommonUtilities.Web
{
   public static class Utils
    {
        public static async Task<(bool newData, T result)> GetAsync<T>(string uri,string userAgent, string token, DateTime lastModified)
        {
            try
            {
                Uri myUri = new Uri(uri);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                myHttpWebRequest.Accept = "application/json";
                myHttpWebRequest.UserAgent = userAgent;
                if (!string.IsNullOrEmpty(token))
                {
                    myHttpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Token {token}");
                }

                myHttpWebRequest.IfModifiedSince = lastModified;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)await myHttpWebRequest.GetResponseAsync();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.NotModified)
                {
                    return (false, default)!;
                }

                using (var reader = new System.IO.StreamReader(myHttpWebResponse.GetResponseStream()))
                {
                    string responseText = await reader.ReadToEndAsync();
                    return (true, JsonConvert.DeserializeObject<T>(responseText));
                }
            }
            catch (WebException e) when (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotModified)
            {
                return (false, default)!;
            }
            catch (Exception)
            {
                return (false, default)!;
            }
        }

        ///  <summary>
        /// Get latest release info
        ///  </summary>
        ///  <param name="repositoryPath">url to repository (e.g: "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer")</param>
        ///  <param name="userAgent"></param>
        ///  <param name="optionalGithubToken"></param>
        ///  <param name="lastUpdate"></param>
        ///  <returns></returns>
        public static async Task<(bool newData, GithubReleaseEntry? release)> CheckVersion(string repositoryPath, string userAgent, string optionalGithubToken, DateTime lastUpdate)
        {
            var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubReleaseEntry[]>(repositoryPath + "/releases", userAgent, optionalGithubToken, lastUpdate);
            if (entries != null)
            {
                GithubReleaseEntry? release = entries.OrderByDescending(r => r.Published).FirstOrDefault();
                return (newData, release);
            }
            return (false, null);
        }

        ///  <summary>
        /// Get latest release info
        ///  </summary>
        ///  <param name="repositoryPath">url to repository (e.g: "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer")</param>
        ///  <param name="userAgent"></param>
        ///  <param name="optionalGithubToken"></param>
        ///  <returns></returns>
        public static async Task<(bool newData, GithubReleaseEntry[] release)> GetAllReleases(string repositoryPath, string userAgent, string optionalGithubToken)
        {
            try
            {
                var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubReleaseEntry[]>(repositoryPath + "/releases", userAgent, optionalGithubToken, DateTime.MinValue);
                return (newData, entries);
            }
            catch (Exception)
            {
                return (false, new GithubReleaseEntry[0]);
            }

        }
        public static GithubAsset? GetMatchingAsset(GithubReleaseEntry githubRelease, TargetFrameworkAttribute frameworkAttribute)
        {
            GithubAsset? asset = null;
            if (frameworkAttribute.FrameworkName.EndsWith("4.7.1"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("471") || a.Name.Contains("471"));
            }
            else if (frameworkAttribute.FrameworkName.EndsWith("4.7.2"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("472") || a.Name.Contains("472"));
            }
            else if (frameworkAttribute.FrameworkName.EndsWith("4.8"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("48") || a.Name.Contains("48"));
            }
            else if (frameworkAttribute.FrameworkName.EndsWith("3.1"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("3.1") || a.Name.Contains("netcoreapp3.1"));
            }
            else if (frameworkAttribute.FrameworkName.EndsWith("v5.0"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("net5.0"));
            }
            else if (frameworkAttribute.FrameworkName.EndsWith("v6.0"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("net6.0"));
            }
            else if (frameworkAttribute.FrameworkName.EndsWith("v7.0"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("net7.0"));
            }
            else if (frameworkAttribute.FrameworkName.EndsWith("v8.0"))
            {
                asset = githubRelease.Assets
                    .FirstOrDefault(a => a.Name.Contains("net8.0"));
            }
            return asset;
        }


    }
}
