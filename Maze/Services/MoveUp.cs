// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveUp.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   The move left.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services
{
    using System;

    using Maze.Models;

    /// <summary>
    /// The move left.
    /// </summary>
    public class MoveUp : IMoveDirection
    {
        /// <inheritdoc />
        public Coordinate Move(string[] mazeArray, Coordinate start)
        {
            try
            {
                var result = mazeArray[start.y - 1][start.x];
                if (result == MazeCharacters.Open || result == MazeCharacters.Destination)
                {
                    return new Coordinate()
                           {
                               x = start.x,
                               y = start.y - 1
                    };
                }
            }
            catch (IndexOutOfRangeException)
            {
                // We got outside the bounds of the array
                return null;
            }

            return null;
        }
    }
}