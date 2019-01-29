using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maze.Models
{
    using Maze.Services;

    public class Path 
    {
        public Guid Id { get; private set; }

        public Path(Coordinate start)
        {
            this.Coordinates = new LinkedList<Coordinate>();
            this.Coordinates.AddLast(start);
            this.Id = Guid.NewGuid();
        }

        public Path(LinkedList<Coordinate> start)
        {
            this.Coordinates = start;
        }

        public LinkedList<Coordinate> Coordinates { get; set; }

        public bool Duplicate (Coordinate coordinate)
        {
            return this.Coordinates.Any(x => x.x == coordinate.x && x.y == coordinate.y);
        }

        public Coordinate End
        {
            get
            {
                return this.Coordinates.Last();
            }
        }
    }
}