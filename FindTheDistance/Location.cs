using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheDistance
{
    public class Location : Coordinate
    {
        public string Name { get; set; }
        public Coordinate Coordinate {get; set;}
        public double DistanceFromOrigin { get; set; }
    }
}
