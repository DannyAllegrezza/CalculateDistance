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
            var allLocations = FileHelper.ReadAllLines("../../Data/location data.txt");


            foreach (string line in allLocations)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }
    }
}
