using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB6
{
    class Program
    {
        static double Function_x1(double a, double b, double x, double y)
        {
            return a - (b + 1)*x + Math.Pow(x,2)*y;
        }

        static double Function_x2(double b, double x, double y)
        {
            return b*x - Math.Pow(x, 2) * y;
        }
        static void Main(string[] args)
        {
            double a = 2,b = 1,x = 2, y = 1/2;
            double h = 0.1,
                   k1, k2, k3, k4, l1, l2, l3, l4;
            Console.WriteLine("\tX1\t\t\t\tX2");
            for (int i = 0; i < 100; i++)
            {
                k1 = h * Function_x1(a, b, x, y);
                l1 = h * Function_x2(b, x, y);
                k2 = h * Function_x1(a, b, x + k1 / 2, y + l1 / 2);
                l2 = h * Function_x2(b, x + k1 / 2, y + l1 / 2);
                k3 = h * Function_x1(a, b, x + k2 / 2, y + l2 / 2);
                l3 = h * Function_x2(b, x + k2 / 2, y + l2 / 2);
                k4 = h * Function_x1(a, b, x + k3 / 2, y + l3 / 2);
                l4 = h * Function_x2(b, x + k3 / 2, y + l3 / 2);

                double fRez = Function_x1(a, b, x, y);
                double gRez = Function_x2(b, x, y);

                Console.WriteLine(Convert.ToString("\t" + fRez + "\t\t\t" + gRez));
                //Console.WriteLine(Convert.ToString("\t" + gRez + "\t\t"));

                x += 1 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
                y += 1 / 6.0 * (l1 + 2 * l2 + 2 * l3 + l4);
            }


        }
    }
}
