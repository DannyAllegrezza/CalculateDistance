using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheDistance
{
    public class Location 
    {
        public string Name { get; set; }
        public Coordinate Coordinate {get; set;}
        public double DistanceFromOrigin
        {
            get
            {
                var math = new DistanceMath();
                return math.CalculateDistance(Coordinate, new Coordinate(0, 0));

            }
        }

        public Location(string name, Coordinate coords)
        {
            this.Name = name;
            this.Coordinate = coords; 
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2} - Distance from Origin (0, 0): {3}", Name, Coordinate.Latitude, Coordinate.Longitude, DistanceFromOrigin);
        }
    }
}
