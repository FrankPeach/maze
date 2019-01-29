// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveLeft.cs" company="Peach Consulting, Inc">
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
    public class MoveLeft : IMoveDirection
    {
        /// <inheritdoc />
        public Coordinate Move(string[] mazeArray, Coordinate start)
        {
            try
            {
                var result = mazeArray[start.y][start.x - 1];
                if ((result == MazeCharacters.Open) || (result == MazeCharacters.Destination))
                {
                    return new Coordinate()
                    {
                               x = start.x - 1,
                               y = start.y
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