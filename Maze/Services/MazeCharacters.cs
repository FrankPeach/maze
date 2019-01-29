// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MazeCharacters.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   The maze characters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Services
{
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// The maze characters.
    /// </summary>
    public static class MazeCharacters
    {
        /// <summary>
        /// The open.
        /// </summary>
        public const char Open = '.';

        /// <summary>
        /// The blocked.
        /// </summary>
        public const char Blocked = '#';

        /// <summary>
        /// The starting.
        /// </summary>
        public const char Starting = 'A';

        /// <summary>
        /// The destination.
        /// </summary>
        public const char Destination = 'B';

        /// <summary>
        /// The character list.
        /// </summary>
        public static char[] CharacterList =>
            new[]
            {
                MazeCharacters.Open, MazeCharacters.Blocked, MazeCharacters.Starting, MazeCharacters.Destination
            };
    }
}