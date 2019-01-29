// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolveMazeController.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the SolveMazeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Maze.Services;

    /// <summary>
    /// The solve maze controller.
    /// </summary>
    public class SolveMazeController : ApiController
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly ISolveMazeService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolveMazeController"/> class.
        /// </summary>
        public SolveMazeController()
        {
            // TODO: inject this
            this.service = new SolveMazeService();
        }

        /// <summary>Solve puzzle</summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IHttpActionResult> Post([FromBody] string value)
        {
            var result = await this.service.SolveMazeAsync(value);
            return this.Ok(result);
        }
    }
}
