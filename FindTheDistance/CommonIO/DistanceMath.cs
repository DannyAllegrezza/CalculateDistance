using System;

namespace FindTheDistance
{
    public class DistanceMath
    {
        public double CalculateDistance(Coordinate coord1, Coordinate coord2)
        {
            return GetDistance(coord1.Latitude, coord1.Longitude, coord2.Latitude, coord2.Longitude, 'K');
        }

        private double GetDistance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double distance = Math.Sin(DegreeToRadian(lat1)) * Math.Sin(DegreeToRadian(lat2)) + Math.Cos(DegreeToRadian(lat1)) * Math.Cos(DegreeToRadian(lat2)) * Math.Cos(DegreeToRadian(theta));

            distance = Math.Acos(distance);
            distance = RadianToDegree(distance);
            distance = distance * 60 * 1.1515;

            if (unit == 'K')
            {
                distance = distance * 1.609344;
            }
            else if (unit == 'N')
            {
                distance = distance * 0.8684;
            }
            return Math.Round(distance, 2);
        }

       
        private double DegreeToRadian(double degree)
        {
            return (degree * Math.PI / 180.0);
        }

        private double RadianToDegree(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
