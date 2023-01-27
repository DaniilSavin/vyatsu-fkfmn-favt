<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
