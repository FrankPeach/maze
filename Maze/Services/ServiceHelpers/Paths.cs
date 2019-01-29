// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Paths.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the Paths type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services.ServiceHelpers
{
    using System.Collections.Generic;

    /// TODO eliminate this class
    /// <summary>
    /// The paths.
    /// </summary>
    public class Paths
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Paths"/> class.
        /// </summary>
        public Paths()
        {
            this.PathList = new List<Path>();
        }
        
        /// <summary>
        /// Gets or sets the path list.
        /// </summary>
        public List<Path> PathList { get; set; }
    }
}