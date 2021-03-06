﻿using System;

namespace FindTheDistance
{
    public class Coordinate
    {
        private double _latitude;
        private double _longitude;


        public double Latitude {
            get
            {
                return _latitude;
            }
            set
            {
                if (value > 90)
                {
                    throw new ArgumentOutOfRangeException(null, "The Latitude cannot be greater than 90. Please adjust the value accordingly!");
                }
                if (value < -90)
                {
                    throw new ArgumentOutOfRangeException(null, "The Latitude cannot be less than -90. Please adjust the value accordingly!");
                }
                _latitude = value;
            }
        }
        
        public double Longitude {
            get
            {
                return _longitude;
            }
            set
            {
                if (value > 180)
                {
                    throw new ArgumentOutOfRangeException(null, "The Longitude cannot be greater than 180. Please adjust the value accordingly!");
                }
                if (value < -180)
                {
                    throw new ArgumentOutOfRangeException(null, "The Longitude cannot be less than -180. Please adjust the value accordingly!");
                }
                _longitude = value;
            }
        }


        public Coordinate()
        {

        }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }        
    }
}
