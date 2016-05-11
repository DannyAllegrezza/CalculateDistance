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

            
            var listOfLocations = new List<Location>();

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


            Console.WriteLine("Unsorted Original List");
            foreach (string line in locationData)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Sorted List");
            foreach (Location location in listOfLocations)
            {
                Console.WriteLine(location.ToString());
            }
            Console.ReadLine();
        }
    }
}
