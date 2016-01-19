using System;

using Moq;

using XUnitMoqSampleWeb.Controllers;
using XUnitMoqSampleWeb.Services;

namespace XUnitMoqSampleWeb.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="HomeController"/> class.
    /// </summary>
    public class HomeControllerFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeControllerFixture"/> class.
        /// </summary>
        public HomeControllerFixture()
        {
            this.GitHubApiService = new Mock<IGitHubApiService>();
            this.HomeController = new HomeController(this.GitHubApiService.Object);
        }

        /// <summary>
        /// Gets the <see cref="Mock{IGitHubApiService}"/> instance.
        /// </summary>
        public Mock<IGitHubApiService> GitHubApiService { get; }

        /// <summary>
        /// Gets the <see cref="HomeController"/> instance.
        /// </summary>
        public HomeController HomeController { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this.HomeController.Dispose();

            this._disposed = true;
        }
    }
}