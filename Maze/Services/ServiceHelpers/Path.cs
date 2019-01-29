// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Path.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   The path.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services.ServiceHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Maze.Models;

    /// <summary>
    /// The path.
    /// </summary>
    public class Path
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        public Path(Coordinate start)
        {
            this.Coordinates = new LinkedList<Coordinate>();
            this.Coordinates.AddLast(start);
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        public Path(LinkedList<Coordinate> start)
        {
            this.Coordinates = start;
        }

        /// <summary>Gets or sets the coordinates.</summary>
        public LinkedList<Coordinate> Coordinates { get; set; }

        /// <summary>Gets the last coordinate.
        /// </summary>
        public Coordinate End => this.Coordinates.Last();

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; }
    }
}