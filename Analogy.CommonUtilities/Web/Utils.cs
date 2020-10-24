using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                    myHttpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Token {token}");

                myHttpWebRequest.IfModifiedSince = lastModified;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)await myHttpWebRequest.GetResponseAsync();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.NotModified)
                    return (false, default)!;

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
        public static async Task<(bool newData, GithubObjects.GithubReleaseEntry? release)> CheckVersion(string repositoryPath, string userAgent, string optionalGithubToken, DateTime lastUpdate)
        {
            var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubObjects.GithubReleaseEntry[]>(repositoryPath + "/releases", userAgent, optionalGithubToken, lastUpdate);
            if (entries != null)
            {
                GithubObjects.GithubReleaseEntry? release = entries.OrderByDescending(r => r.Published).FirstOrDefault();
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
        public static async Task<(bool newData, GithubObjects.GithubReleaseEntry[] release)> GetAllReleases(string repositoryPath, string userAgent, string optionalGithubToken)
        {
            try
            {
                var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubObjects.GithubReleaseEntry[]>(repositoryPath + "/releases", userAgent, optionalGithubToken, DateTime.MinValue);
                return (newData, entries);
            }
            catch (Exception)
            {
                return (false, new GithubObjects.GithubReleaseEntry[0]);
            }

        }

    }
}
