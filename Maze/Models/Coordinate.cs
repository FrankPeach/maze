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

    public class Coordinate : ICloneable
    {
        public int x { get; set; }
        public int y { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Coordinate p = obj as Coordinate;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (x == p.x) && (y == p.y);
        }

        public bool Equals(Coordinate p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }
    }
}