// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISolveMazeService.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the ISolveMazeService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services
{
    using System.Threading.Tasks;

    using Maze.Models;

    /// <summary>
    /// The SolveMazeService interface.
    /// </summary>
    public interface ISolveMazeService
    {
        /// <summary>
        /// The solve maze async.
        /// </summary>
        /// <param name="maze">
        /// The maze.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<MazeSolution> SolveMazeAsync(string maze);
    }
}
