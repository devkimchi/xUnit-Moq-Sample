using System;

using Moq;

using XUnitMoqSampleWeb.Helpers;
using XUnitMoqSampleWeb.Services;

namespace XUnitMoqSampleWeb.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="GitHubApiService"/> class.
    /// </summary>
    public class GitHubApiServiceFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubApiServiceFixture"/> class.
        /// </summary>
        public GitHubApiServiceFixture()
        {
            this.HttpClientHelper = new Mock<IHttpClientHelper>();

            this.GitHubApiService = new GitHubApiService(this.HttpClientHelper.Object);
        }

        /// <summary>
        /// Gets the <see cref="Mock{IHttpClientHelper}"/> instance.
        /// </summary>
        public Mock<IHttpClientHelper> HttpClientHelper { get; }

        /// <summary>
        /// Gets the <see cref="IGitHubApiService"/> instance.
        /// </summary>
        public IGitHubApiService GitHubApiService { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this.GitHubApiService.Dispose();

            this._disposed = true;
        }
    }
}