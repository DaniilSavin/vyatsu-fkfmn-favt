using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runge_kutta
{
    class Program
    {
        //2
        static double Function_f(double x, double y)
        {
            return ((-5*Math.Pow(x,2) + 3) * Math.Pow(y,3) - 12*y) / 8*x;
        }

        static void Main(string[] args)
        {
            double x = 1.0, y = 1.0,
                k1, k2, k3, k4;
            double h = 0.1;
            Console.WriteLine("\tX\t\t\t\tZ");
            for (int i = 0; i < 10; i++)
            {
                k1 = h * Function_f(x,y);
                k2 = h * Function_f(x + h / 2, y + h * k1/2);
                k3 = h * Function_f(x + h / 2, y + h * k2/2);
                k4 = h * Function_f(x + h, y + h * k3);

                double fRez = (Function_f(x,y));

                Console.WriteLine(Convert.ToString("\t\t\t" + fRez));
                //Console.WriteLine(Convert.ToString("\t" + gRez + "\t\t"));

                x += h;
                y = y + h/6 * (k1 + 2*k2 + 2*k3 + k4);
            }


        }
    }
}
