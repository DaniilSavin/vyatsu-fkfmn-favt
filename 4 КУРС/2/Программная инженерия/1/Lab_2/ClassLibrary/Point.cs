using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Point
    {
        double _latitude = -1, _longitude = -1;

        public double Latitude //wirota
        {
            get => _latitude;
            set
            {
                if (value >= -180 && value <= 180)
                    _longitude = value;
            }
        }
        public double Longitude //dolgota
        {
            get => _longitude;
            set
            {
                if (value >= -90 && value <= 90)
                    _longitude = value;
            }

        }
        public double Distance(Point point)
        {
            double distance;
            try
            {
                double R = 6371; double rad = Math.PI / 180;
                double delta_PHI = point.Latitude - _latitude; double delta_Lambda = point.Longitude - _longitude;
                double a = Math.Pow(Math.Sin(delta_PHI / 2.0 * rad), 2) + Math.Cos(_latitude * rad) * Math.Cos(point.Latitude * rad) * Math.Pow(Math.Sin(delta_Lambda / 2.0 * rad), 2);
                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                distance = R * c;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return distance;
        }

        public string Azimuth(Point point)
        {
            double azimuth;
            try
            {
                if (point.Longitude == _longitude && _latitude == point.Latitude)
                {
                    return "none";
                }
                if (((_latitude + point.Latitude == 0) && (_longitude + point.Longitude == 180)) || (_latitude == -1 * point.Latitude && _latitude != 0))
                {
                    return "any";
                }
                if ((_latitude == 90) || (point._latitude == 90) || (_latitude == -90) || (point._latitude == -90))
                {

                    return 180.ToString();
                }

                if (_latitude == 0 && point.Latitude == 0)
                {
                    if (_longitude > point.Longitude)
                    {
                        return 270.ToString();
                    }
                    else
                    {
                        return 90.ToString();
                    }
                }
                if (_longitude == point.Longitude)
                {
                    if (_latitude > point.Latitude)
                    {
                        return 0.ToString() + " (идем на север)";
                    }
                    else
                    {
                        return 180.ToString() + " (идем на юг)";
                    }
                }

                double rad = Math.PI / 180;
                double delta_Lambda = point.Longitude - _longitude;
                azimuth = Math.Atan2(Math.Sin(delta_Lambda * rad) * Math.Cos(point.Latitude * rad),
                    Math.Cos(_latitude * rad) * Math.Sin(point.Latitude * rad) - Math.Sin(_latitude * rad) * Math.Cos(point.Latitude * rad) * Math.Cos(delta_Lambda * rad));
                if (azimuth < 0 || azimuth > 360)
                {
                    return "none";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0.ToString();
            }
            return azimuth.ToString();
        }

        public Point(double latitude, double longitude)
        {
            try
            {

                if (latitude >= -90 && latitude <= 90) this._latitude = latitude;
                else
                {
                    throw new ArgumentException(latitude + " - Incorrect value.");
                }
                if (longitude >= -180 && longitude <= 180) this._longitude = longitude;
                else
                {
                    throw new ArgumentException(longitude + " - Incorrect value.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
