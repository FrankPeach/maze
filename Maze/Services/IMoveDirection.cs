// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMoveDirection.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the IMoveDirection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services
{
    using Maze.Models;

    /// <summary>The MoveDirection interface.</summary>
    public interface IMoveDirection
    {
        /// <summary>The move.</summary>
        /// <param name="mazeArray">The maze array.</param>
        /// <param name="startCoordinate">The start coordinate.</param>
        /// <returns> If we can move then the new <see cref="Coordinate"/>. otherwise null</returns>
        Coordinate Move(string[] mazeArray, Coordinate startCoordinate);
    }
}