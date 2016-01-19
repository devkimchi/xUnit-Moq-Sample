using System;
using System.Net.Http;

namespace XUnitMoqSampleWeb.Helpers
{
    /// <summary>
    /// This provides interfaces to the <see cref="HttpClientHelper"/> class.
    /// </summary>
    public interface IHttpClientHelper : IDisposable
    {
        /// <summary>
        /// Creates the <see cref="HttpClient"/> instance.
        /// </summary>
        /// <param name="handler"><see cref="HttpMessageHandler"/> instance.</param>
        /// <returns>Returns the <see cref="HttpClient"/> instance created.</returns>
        HttpClient CreateInstance(HttpMessageHandler handler = null);
    }
}