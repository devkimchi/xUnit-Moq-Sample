using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace XUnitMoqSampleWeb.Services
{
    /// <summary>
    /// This represents the service entity for the GitHub API.
    /// </summary>
    public class GitHubApiService : IGitHubApiService
    {
        private bool _disposed;

        /// <summary>
        /// Gets the list of repositories belong to the ogranisation.
        /// </summary>
        /// <param name="orgName">Organisation name.</param>
        /// <returns>Returns the response string from GitHub API.</returns>
        public async Task<string> GetOrgReposAsync(string orgName)
        {
            if (string.IsNullOrWhiteSpace(orgName))
            {
                throw new ArgumentNullException(nameof(orgName));
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "xUnitMoqSample");

                var result = await client.GetStringAsync($"https://api.github.com/orgs/{orgName}/repos").ConfigureAwait(false);

                return result;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}