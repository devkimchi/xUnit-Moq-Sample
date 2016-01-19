using System;
using System.Threading.Tasks;

namespace XUnitMoqSampleWeb.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="GitHubApiService"/> class.
    /// </summary>
    public interface IGitHubApiService : IDisposable
    {
        /// <summary>
        /// Gets the list of repositories belong to the organisation.
        /// </summary>
        /// <param name="orgName">Organisation name.</param>
        /// <returns>Returns the response string from GitHub API.</returns>
        Task<string> GetOrgReposAsync(string orgName);
    }
}