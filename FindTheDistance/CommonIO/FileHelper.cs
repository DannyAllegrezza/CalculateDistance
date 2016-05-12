using System;
using System.Collections.Generic;
using System.IO;

namespace FindTheDistance
{
    public class FileHelper
    {
        public string[] ReadTextFile(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Unable to read file path. Please ensure file is located in the Data folder", "filePath");
            }

            var readText = new string[] { };

            try
            {
                readText = File.ReadAllLines(filePath);
            }
            catch (IOException ex)
            {
                throw new FileNotFoundException(String.Format("File not found! \n{0} \nPlease place your file in the directory listed above.", ex.Message));

            }

            var cleanData = CleanData(readText);

            return cleanData;
        }

        private string[] CleanData(string[] locationsData)
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
        
        private string ConvertCoordinateToDegreesValue(string coordinate)
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
                // Just drop the last digit (the cardinal value)
                coordinate = coordinate.Remove(coordinate.Length - 1);
            }

            return coordinate;
        }
       
    }
}
