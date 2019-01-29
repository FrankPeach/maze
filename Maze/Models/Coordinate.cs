// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Coordinate.cs" company="Peach Consulting, Inc">
//   Copyright © 2019 Peach Consulting, Inc. All rights reserved
// </copyright>
// <summary>
//   Defines the Coordinate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Maze.Models
{
    using System;

    /// <summary>The coordinate.</summary>
    public class Coordinate : ICloneable
    {
        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        public int Y { get; set; }

        /// <summary>The clone.</summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var coordinate = obj as Coordinate;
            if (coordinate == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.X == coordinate.X) && (this.Y == coordinate.Y);
        }

        /// <summary>The equals.</summary>
        /// <param name="coordinate">The p.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Equals(Coordinate coordinate)
        {
            // If parameter is null return false:
            if (coordinate == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.X == coordinate.X) && (this.Y == coordinate.Y);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }
    }
}