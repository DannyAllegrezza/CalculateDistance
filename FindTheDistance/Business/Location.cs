using FindTheDistance.CommonIO;
using System;


namespace FindTheDistance
{
    public class Location : IComparable<Location>
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
            if (String.IsNullOrEmpty(name))
            {
                this.Name = "N/A -- No Location Name Provided!";
            }
            else
            {
                this.Name = name;
            }
            this.Coordinate = coords; 
        }

        public override string ToString()
        {
            return String.Format("{0,-40} {1, 10} {2,10} {3,10}KM from Origin", LocationDisplay.Truncate(Name, 35), Coordinate.Latitude, Coordinate.Longitude, DistanceFromOrigin);
        }

        public int CompareTo(Location other)
        {
            if (this.DistanceFromOrigin == other.DistanceFromOrigin)
            {
                return this.Name.CompareTo(other.Name);
            }
            return this.DistanceFromOrigin.CompareTo(other.DistanceFromOrigin);
        }
    }
}
