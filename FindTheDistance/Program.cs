using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FindTheDistance
{
    class Program
    {
        static void Main(string[] args)
        {

            // Read all the locations from the file and returns a String array
            var locationData = FileHelper.ReadAllLines("../../Data/location data.txt");

            // List which will hold Locations which are extracted from the locationData string[]
            var listOfLocations = new List<Location>();

            // Parses each row, creates a new Location object and adds it to the List
            foreach (string line in locationData)
            {
                string[] rowValue = line.Split(',');
                var name = rowValue[0];
                var latitude = Convert.ToDouble(rowValue[1]);
                var longitude = Convert.ToDouble(rowValue[2]);

                var coordinate = new Coordinate(latitude, longitude);

                var location = new Location(name, coordinate);
                listOfLocations.Add(location);
            }

            // Test 1: Shows the original clean and unsorted Data
            Console.WriteLine("-------- Original List ---------");
            foreach (Location location in listOfLocations)
            {
                Console.WriteLine(location.ToString());
            }

            // Test 2: Shows the Sorted Data
            Console.WriteLine();
            Console.WriteLine("After Sort()");
            listOfLocations.Sort();
            foreach (Location location in listOfLocations)
            {
                Console.WriteLine(location.ToString());
            }

            // Prevents the console window from closing
            Console.ReadLine();
        }
    }
}
