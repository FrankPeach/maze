// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveRight.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   The move left.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services.MazeDirections
{
    using System;

    using Maze.Models;

    /// <summary>
    /// The move left.
    /// </summary>
    public class MoveRight : IMoveDirection
    {
        /// <inheritdoc />
        public Coordinate Move(string[] mazeArray, Coordinate start)
        {
            try
            {
                var result = mazeArray[start.Y][start.X + 1];
                if ((result == MazeCharacters.Open) || (result == MazeCharacters.Destination))
                {
                    return new Coordinate()
                           {
                               X = start.X + 1,
                               Y = start.Y
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