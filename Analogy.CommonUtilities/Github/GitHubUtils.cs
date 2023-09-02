using System.Net;
using Newtonsoft.Json;

namespace Analogy.CommonUtilities.Github
{
    public class GitHubUtils
    {
        public static event EventHandler<string> OnNameResolutionFailure;

        public static async Task<GitHubRateLimit> GetRateLimit(string? token, string? userAgent)
        {
            var data = await GetAsync<GitHubRateLimit>("https://api.github.com/rate_limit", token, userAgent, DateTime.Now);
            return data.result;
        }
        public static async Task<List<GitHubRepository>> GetForks(GitHubRepository repo, string? gitHubToken, string? userAgent)
        {
            List<GitHubRepository> forks = new List<GitHubRepository>();
            await GetForks(repo, gitHubToken, userAgent, forks);
            return forks;
        }
        private static async Task GetForks(GitHubRepository repo, string? gitHubToken, string? userAgent, List<GitHubRepository> repos)
        {

            List<GitHubRepository> forks = new List<GitHubRepository>();
            int page = 1;
            bool hasMore = true;
            while (hasMore)
            {
                var forksData = await GetAsync<GitHubRepository[]>(repo.ForksUrl + "?per_page=100&page=" + page, gitHubToken, userAgent, DateTime.MinValue);
                if (forksData.result != null)
                {


                    foreach (var fork in forksData.result)
                    {
                        forks.Add(fork);
                    }
                }
                hasMore = forksData.result is { Length: 100 };

                page++;
            }
            repos.AddRange(forks);
            foreach (var fork in forks)
            {
                if (fork.Forks > 0)
                {
                    await GetForks(fork, gitHubToken, userAgent, repos);
                }
            }
        }


        public static async Task<(bool newData, T result)> GetAsync<T>(string uri, string? token, string? userAgent, DateTime lastModified)
        {
            try
            {
                Uri myUri = new Uri(uri);
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                myHttpWebRequest.Accept = "application/json";
                myHttpWebRequest.UserAgent = userAgent ?? "";
                if (!string.IsNullOrEmpty(token))
                {
                    myHttpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Token {token}");
                }

                myHttpWebRequest.IfModifiedSince = lastModified;

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)await myHttpWebRequest.GetResponseAsync();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.NotModified)
                {
                    return (false, default);
                }

                using (var reader = new System.IO.StreamReader(myHttpWebResponse.GetResponseStream()))
                {
                    string responseText = await reader.ReadToEndAsync();
                    return (true, JsonConvert.DeserializeObject<T>(responseText));
                }
            }
            catch (WebException e) when (e.Status == WebExceptionStatus.NameResolutionFailure)
            {
                OnNameResolutionFailure?.Invoke(null, "Error getting " + uri);
                return (false, default);
            }
            catch (WebException e) when (e.Status == WebExceptionStatus.UnknownError)
            {
                return (false, default);
            }
            catch (WebException e) when (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.NotModified)
            {
                return (false, default);
            }
            catch (WebException e) when (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.Unauthorized)
            {
                return (false, default);
            }
            catch (WebException e) when (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.Forbidden)
            {
                return (false, default);
            }
            catch (Exception)
            {
                return (false, default);
            }
        }



    }
}
