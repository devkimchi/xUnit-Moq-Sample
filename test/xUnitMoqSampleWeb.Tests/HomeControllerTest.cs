using System;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNet.Mvc;

using Moq;

using Newtonsoft.Json.Linq;

using Xunit;

using XUnitMoqSampleWeb.Controllers;
using XUnitMoqSampleWeb.Services;
using XUnitMoqSampleWeb.Tests.Fixtures;

namespace XUnitMoqSampleWeb.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="HomeController"/> class.
    /// </summary>
    public class HomeControllerTest : IClassFixture<HomeControllerFixture>
    {
        private readonly Mock<IGitHubApiService> _service;
        private readonly HomeController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeControllerTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="HomeControllerFixture"/> instance.</param>
        public HomeControllerTest(HomeControllerFixture fixture)
        {
            this._service = fixture.GitHubApiService;
            this._controller = fixture.HomeController;
        }

        #region controller
        /// <summary>
        /// Tests whether the constructor shoult throw an exception or not.
        /// </summary>
        [Fact]
        public void Given_NullParameter_Constructor_ShouldThrow_ArgumentNullException()
        {
            // Arrange
            IGitHubApiService service = null;

            // Action
            Action action = () => { var controller = new HomeController(service); };

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }
        #endregion

        /// <summary>
        /// Tests whether Index should return result or not.
        /// </summary>
        /// <param name="repo"></param>
        [Theory]
        [InlineData("Hello-World")]
        public async void Given_Index_ShouldReturn_Result(string repo)
        {
            // Arrange
            var json = $"[{{\"name\": \"{repo}\"}}]";
            this._service.Setup(p => p.GetOrgReposAsync(It.IsAny<string>())).Returns(Task.FromResult(json));

            // Action
            var result = await this._controller.Index().ConfigureAwait(false) as ViewResult;

            // Assert
            result.Should().NotBeNull();

            var jarray = this._controller.ViewBag.Repos as JArray;
            jarray.Should().NotBeNullOrEmpty();
            jarray.Count.Should().Be(1);
            jarray[0]["name"].Value<string>().Should().BeEquivalentTo(repo);
        }
    }
}