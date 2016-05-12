using System;
using System.Collections.Generic;

namespace FindTheDistance.CommonIO
{
    public class LocationDisplay
    {
        public List<Location> listOfLocations { get; set; }

        public void DisplayToConsole()
        {
            var pathToTextFile = "../../Data/location data.txt";

            var fileHelper = new FileHelper();
            var locationData = fileHelper.ReadTextFile(pathToTextFile);

            CreateLocationsFromData(locationData);
            DisplayOriginalUnsortedData();
            DisplaySortedData();

            // Prevents the console window from closing
            Console.ReadLine();
        }

        private void CreateLocationsFromData(string[] locationData)
        {
            listOfLocations = new List<Location>();
            foreach (string line in locationData)
            {
                string[] rowValue = line.Split(',');
                var name = rowValue[0];
                var latitude = Convert.ToDouble(rowValue[1]);
                var longitude = Convert.ToDouble(rowValue[2]);
                var coordinate = new Coordinate();
                try
                {
                    coordinate = new Coordinate(latitude, longitude);
                }
                catch (Exception)
                {
                    name += "(NOT VALID LOCATION!)";  
                }

                var location = new Location(name, coordinate);
                listOfLocations.Add(location);
            }
        }

        private void DisplaySortedData()
        {            
            Console.WriteLine();
            PrintHeaders("Sorted Data");
            listOfLocations.Sort();
            foreach (Location location in listOfLocations)
            {
                Console.WriteLine(location.ToString());
            }
        }

        private void DisplayOriginalUnsortedData()
        {
            
            PrintHeaders("Original Unsorted List");
            foreach (Location location in listOfLocations)
            {
                Console.WriteLine(location.ToString());
            }
        }


        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
                source += "....";
            }
            return source;
        }

        private void PrintHeaders(string message)
        {
            Console.WriteLine(String.Format("----------------------------------- {0} -----------------------------------", message));
            Console.WriteLine(String.Format("{0,-40} {1, 10} {2,10} {3,25}", "Location Name", "Latitude", "Longitude", "Distance from Origin"));
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
    }
}
