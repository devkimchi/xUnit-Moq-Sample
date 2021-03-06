﻿using System.Threading.Tasks;

using Microsoft.AspNet.Mvc;

using Newtonsoft.Json.Linq;

using XUnitMoqSampleWeb.Services;

namespace XUnitMoqSampleWeb.Controllers
{
    using System;

    /// <summary>
    /// This represents the controller entity for /home.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IGitHubApiService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="service"><see cref="IGitHubApiService"/> instance.</param>
        public HomeController(IGitHubApiService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this._service = service;
        }

        /// <summary>
        /// Gets the <see cref="IActionResult"/> for /home/index.
        /// </summary>
        /// <returns>Returns the <see cref="IActionResult"/>.</returns>
        public async Task<IActionResult> Index()
        {
            var result = await this._service.GetOrgReposAsync("devkimchi").ConfigureAwait(false);

            this.ViewBag.Repos = JArray.Parse(result);

            return this.View();
        }

        /// <summary>
        /// Gets the <see cref="IActionResult"/> for /home/about.
        /// </summary>
        /// <returns>Returns the <see cref="IActionResult"/>.</returns>
        public IActionResult About()
        {
            this.ViewData["Message"] = "Your application description page.";

            return this.View();
        }

        /// <summary>
        /// Gets the <see cref="IActionResult"/> for /home/contact.
        /// </summary>
        /// <returns>Returns the <see cref="IActionResult"/>.</returns>
        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";

            return this.View();
        }

        /// <summary>
        /// Gets the <see cref="IActionResult"/> for /home/error.
        /// </summary>
        /// <returns>Returns the <see cref="IActionResult"/>.</returns>
        public IActionResult Error()
        {
            return this.View();
        }
    }
}