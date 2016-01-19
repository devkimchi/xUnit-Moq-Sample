using System;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

using XUnitMoqSampleWeb.Services;
using XUnitMoqSampleWeb.Tests.Fixtures;

namespace XUnitMoqSampleWeb.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="GitHubApiService"/> class.
    /// </summary>
    public class GitHubApiServiceTest : IClassFixture<GitHubApiServiceFixture>
    {
        private readonly IGitHubApiService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubApiServiceTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="GitHubApiServiceFixture"/> instance.</param>
        public GitHubApiServiceTest(GitHubApiServiceFixture fixture)
        {
            this._service = fixture.GitHubApiService;
        }

        /// <summary>
        /// Tests whether GotOrgReposAsync should throw an exception or not.
        /// </summary>
        [Fact]
        public void Given_NullOrgName_GetOrgReposAsync_ShouldThrow_ArgumentNullException()
        {
            // Arrange
            var orgName = string.Empty;

            // Act
            Func<Task> func = async () => { var result = await this._service.GetOrgReposAsync(orgName).ConfigureAwait(false); };

            // Assert
            func.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Tests whether GetOrgReposAsync should return result or not.
        /// </summary>
        /// <param name="orgName">Organisation name value.</param>
        [Theory]
        [InlineData("devkimchi")]
        public async void GIven_OrgName_GetOrgReposAsync_ShouldReturn_Result(string orgName)
        {
            // Arrange

            // Act
            var result = await this._service.GetOrgReposAsync(orgName).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        #region something
        //var message = new HttpResponseMessage { Content = new StringContent(html) };

        //var handler = new HttpResponseHandlerFake(message);
        //var client = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:5080") };
        #endregion
    }
}