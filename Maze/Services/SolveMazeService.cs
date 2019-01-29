// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolveMazeService.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the SolveMazeService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Maze.Common;
    using Maze.Models;
    using Maze.Services.MazeDirections;
    using Maze.Services.ServiceHelpers;

    /// <summary>
    /// The Service to solve the maze puzzle.
    /// </summary>
    public class SolveMazeService : ISolveMazeService
    {
        /// <summary>
        /// The move directions.
        /// </summary>
        private IEnumerable<IMoveDirection> MoveDirections => new List<IMoveDirection> { new MoveDown(), new MoveUp(), new MoveRight(), new MoveLeft() };

        /// <summary>The solve maze async.
        /// </summary><param name="maze">The maze.
        /// </param>
        /// <returns>
        /// The <see cref="Task{MazeSolution}"/>.
        /// </returns>
        /// <exception cref="Exception">No Start, End or Solution
        /// </exception>
        public Task<MazeSolution> SolveMazeAsync(string maze)
        {
            var mazeArray = SolveMazeService.BuildMazeArray(maze);
            var start = SolveMazeService.FindStart(mazeArray);

            // TODO create better exception handling and return bad request 
            if (start == null)
            {
                throw new Exception("Cannot find start Location");
            }

            LinkedList<Coordinate> result = this.Solve(mazeArray, start);

            if (result == null)
            {
                throw new Exception("No Solution could be found");
            }

            string[] solution = SolveMazeService.ReplaceSolutionChars(mazeArray, result);

            return Task.FromResult(
                new MazeSolution { Solution = string.Join(Environment.NewLine, solution), Steps = result.Count + 1 });
        }

        /// <summary>The build maze array.</summary>
        /// <param name="maze">The maze.</param>
        /// <returns>The <see cref="T:string[]"/>.</returns>
        private static string[] BuildMazeArray(string maze)
        {
            var mazeList = new List<string>();

            var mazeItem = string.Empty;
            var mazeArray = maze.ToCharArray();
            foreach (var s in mazeArray)
            {
                if (MazeCharacters.CharacterList.Contains(s))
                {
                    mazeItem = mazeItem + s;
                }
                else
                {
                    if (mazeItem.Length > 0)
                    {
                        mazeList.Add(mazeItem);
                        mazeItem = string.Empty;
                    }
                }
            }

            if (mazeItem.Length > 0)
            {
                mazeList.Add(mazeItem);
            }

            return mazeList.ToArray();
        }

        /// <summary>The find the start position.</summary>
        /// <param name="mazeLines">The maze lines.</param>
        /// <returns>The <see cref="Coordinate"/>.</returns>
        private static Coordinate FindStart(string[] mazeLines)
        {
            int lineIndex = 0;
            bool found = false;
            Coordinate coordinates = new Coordinate();
            foreach (var mazeLine in mazeLines)
            {
                var startIndex = mazeLine.IndexOf(MazeCharacters.Starting);
                if (startIndex > 0)
                {
                    coordinates.Y = lineIndex;
                    coordinates.X = startIndex;
                    found = true;
                }

                if (found)
                {
                    break;
                }

                lineIndex++;
            }

            if (found)
            {
                return coordinates;
            }

            return null;
        }

        /// <summary>
        /// Replace the maze with the solution characters
        /// </summary>
        /// <param name="maze">
        /// The maze array
        /// </param>
        /// <param name="solution">The coordinate solution.</param>
        /// <param name="solutionChar">The solution char.</param>
        /// <returns>The <see cref="T:string[]"/>. </returns>
        private static string[] ReplaceSolutionChars(
            string[] maze,
            LinkedList<Coordinate> solution,
            char solutionChar = '@')
        {
            string[] solutionString = new string[maze.Length];

            for (int i = 0; i < maze.Length; i++)
            {
                char[] line = maze[i].ToCharArray();
                foreach (var coordinate in solution.Where(x => x.Y == i))
                {
                    line[coordinate.X] = solutionChar;
                }

                solutionString[i] = new string(line);
            }

            return solutionString;
        }

        /// <summary>Solve the puzzle</summary>
        /// <param name="maze">The maze.</param>
        /// <param name="start">The start.</param>
        /// <returns>The list of coordinates that solves the puzzle<see cref="List{Coordiante}"/>.</returns>
        private LinkedList<Coordinate> Solve(string[] maze, Coordinate start)
        {
            var paths = new Paths();

            paths.PathList.Add(new Path(start));
            var newPathList = paths;
            var starttime = DateTime.Now;

            var distinctcoordinates = new List<Coordinate>();

            do
            {
                paths = new Paths();
                foreach (var path in newPathList.PathList)
                {
                    var pathEndPoint = new Coordinate { X = path.End.X, Y = path.End.Y };
                    var newCoordinates = new List<Coordinate>();
                    foreach (var moveDirection in this.MoveDirections)
                    {
                        var result = moveDirection.Move(maze, pathEndPoint);

                        // If the result is not null then we can move there
                        if (result != null)
                        {
                            // Did we reach the end?
                            if (maze[result.Y][result.X] == MazeCharacters.Destination)
                            {
                                // Remove the starting position from the solution
                                path.Coordinates.RemoveFirst();
                                return path.Coordinates;
                            }

                            // Check if we have come across this point already on another path
                            if (!distinctcoordinates.Any(x => x.Equals(result)))
                            {
                                Debug.WriteLine("after" + starttime.Subtract(DateTime.Now).Milliseconds);
                                newCoordinates.Add(result);
                                distinctcoordinates.Add(result);
                            }
                        }
                    }

                    // A little klugey here but a way to keep from cloning any more than absolutely needed
                    // this is an area ripe for refactoring
                    if (newCoordinates.Any())
                    {
                        Path[] newPaths = new Path[newCoordinates.Count - 1];

                        for (int i = 0; i < newCoordinates.Count; i++)
                        {
                            if (i > 0)
                            {
                                var list = path.Coordinates.Clone();
                                newPaths[i - 1] = new Path(list);
                            }
                        }

                        for (int i = 0; i < newCoordinates.Count; i++)
                        {
                            if (i == 0)
                            {
                                path.Coordinates.AddLast(newCoordinates[i]);
                                paths.PathList.Add(path);
                            }
                            else
                            {
                                newPaths[i - 1].Coordinates.AddLast(newCoordinates[i]);
                                paths.PathList.Add(newPaths[i - 1]);
                            }
                        }
                    }
                }

                newPathList = paths;
            }
            while (paths.PathList.Count > 0);

            return null;
        }
    }
}