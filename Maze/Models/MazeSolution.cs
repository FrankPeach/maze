// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MazeSolution.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the MazeSolution POCO Object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Models
{
    /// <summary>
    /// The maze solution.
    /// </summary>
    public class MazeSolution
    {
        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        public int? Steps { get; set; }

        /// <summary>
        /// Gets or sets the solution.
        /// </summary>
        public string Solution { get; set; }
    }
}