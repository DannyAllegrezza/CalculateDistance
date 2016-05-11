using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheDistance
{
    public static class FileHelper
    {
        public static string[] ReadAllLines(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                throw new NullReferenceException();
            }
            
            var readText = File.ReadAllLines(filePath);
            var cleanData = CleanData(readText);

            return cleanData;
        }

        public static string[] CleanData(string[] locationsData)
        {
            var latitude = "";
            var longitude = "";
            var cleanedUpDataList = new List<string>();

            // Skip first line in Array
            for(int i = 1; i < locationsData.Length; i++)
            {
                if (String.IsNullOrEmpty(locationsData[i].ToString()))
                {
                    continue;
                }
                // Split the current line to find each value
                string[] rowValue = locationsData[i].Split(',');

                latitude = rowValue[1].ToLower();
                longitude = rowValue[2].ToLower();

                if (latitude.Contains("s") || latitude.Contains("n"))
                {                                        
                    rowValue[1] = ConvertCoordinateToDegreesValue(latitude);
                }
                if (longitude.Contains("e") || longitude.Contains("w"))
                {
                    rowValue[2] = ConvertCoordinateToDegreesValue(longitude);
                }

                locationsData[i] = String.Join("," , rowValue);
                cleanedUpDataList.Add(locationsData[i]);
            }

            return cleanedUpDataList.ToArray();
        }
        
        public static string ConvertCoordinateToDegreesValue(string coordinate)
        {
            if (coordinate.Contains("s"))
            {
                // Drop last digit and make negative
                coordinate = coordinate.Remove(coordinate.Length - 1);
                coordinate = "-" + coordinate;
            }

            else if (coordinate.Contains("w"))
            {
                // Drop last digit and make negative
                coordinate = coordinate.Remove(coordinate.Length - 1);
                coordinate = "-" + coordinate;
            }
            
            else
            {
                coordinate = coordinate.Remove(coordinate.Length - 1);
            }

            return coordinate;
        }
       
    }
}
