using FluentAssertions;

using Xunit;

using XUnitMoqSampleWeb.Helpers;
using XUnitMoqSampleWeb.Tests.Fixtures;

namespace XUnitMoqSampleWeb.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="HttpClientHelper"/> class.
    /// </summary>
    public class HttpClientHelperTest : IClassFixture<HttpClientHelperFixture>
    {
        private readonly IHttpClientHelper _helper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientHelperTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="HttpClientHelperFixture"/> instance.</param>
        public HttpClientHelperTest(HttpClientHelperFixture fixture)
        {
            this._helper = fixture.HttpClientHelper;
        }

        /// <summary>
        /// Tests whether CreateInstance should return result or not.
        /// </summary>
        [Fact]
        public void Given_CreateInstance_ShouldReturn_Result()
        {
            // Arrange

            // Act
            var result = this._helper.CreateInstance();

            // Assert
            result.Should().NotBeNull();
        }
    }
}