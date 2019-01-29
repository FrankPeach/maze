using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maze.Models
{
    using System.Runtime.CompilerServices;

    public class Paths
    {
        
        public List<Path> PathList { get; set; }

        public Paths()
        {
            this.PathList = new List<Path>();
        }

        public bool CoordianteExists(Coordinate coordinate)
        {
            IEnumerable<Coordinate> coordinates = this.PathList.SelectMany(x => x.Coordinates);
            return coordinates.Any(x => x.Equals(coordinate));
        }
    }
}