using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Point
    {
        double _latitude, _longitude;

        public double Latitude
        {
            get => _latitude;
             set => _latitude = value;
        }
        public double Longitude
        {
            get => _longitude;
             set => _longitude = value;
        }

        public Point(double latitude, double longitude)
        {
            this._latitude = latitude;
            this._longitude = longitude;
        }
    }
}
