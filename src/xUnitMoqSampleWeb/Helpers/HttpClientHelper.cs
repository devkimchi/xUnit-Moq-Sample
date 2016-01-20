using System.Net.Http;

namespace XUnitMoqSampleWeb.Helpers
{
    /// <summary>
    /// This represents the helper entity for the <see cref="HttpClient"/> class.
    /// </summary>
    public class HttpClientHelper : IHttpClientHelper
    {
        private bool _disposed;

        /// <summary>
        /// Creates the <see cref="HttpClient"/> instance.
        /// </summary>
        /// <param name="handler"><see cref="HttpMessageHandler"/> instance.</param>
        /// <returns>Returns the <see cref="HttpClient"/> instance created.</returns>
        public HttpClient CreateInstance(HttpMessageHandler handler = null)
        {
            var client = handler == null ? new HttpClient() : new HttpClient(handler);
            return client;
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