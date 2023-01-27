using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runge_kutta
{
    class Program
    {
        static double Function_x1(double a1, double b12, double c1, double x1, double x2)
        {
            return x1 * (a1 + b12 * x2 - c1 * x1);
        }

        static double Function_x2(double a2, double b21, double c2, double x1, double x2)
        {
            return x2 * (a2 + b21 * x1 - c2 * x2);
        }
        static void Main(string[] args)
        {
            double x1 = 0.5, x2 = 0.4,
                   a1 = 0.5, b12 = 0.4, c1 = 0.2,
                   a2 = 0.3, b21 = 0.5, c2 = 0.1, h = 0.1,
                   k1, k2, k3, k4, l1, l2, l3, l4;
            Console.WriteLine("\tX1\t\t\t\tX2");
            for (int i = 0; i < 100; i++)
            {
                k1 = h * Function_x1(a1, b12, c1, x1, x2);
                l1 = h * Function_x2(a2, b21, c2, x1, x2);
                k2 = h * Function_x1(a1, b12, c1, x1 + k1 / 2, x2 + l1 / 2);
                l2 = h * Function_x2(a2, b21, c2, x1 + k1 / 2, x2 + l1 / 2);
                k3 = h * Function_x1(a1, b12, c1, x1 + k2 / 2, x2 + l2 / 2);
                l3 = h * Function_x2(a2, b21, c2, x1 + k2 / 2, x2 + l2 / 2);
                k4 = h * Function_x1(a1, b12, c1, x1 + k3 / 2, x2 + l3 / 2);
                l4 = h * Function_x2(a2, b21, c2, x1 + k3 / 2, x2 + l3 / 2);

                double fRez = Function_x1(a1, b12, c1, x1, x2);
                double gRez = Function_x2(a2, b21, c2, x1, x2);

                //Console.WriteLine(Convert.ToString("\t" + gRez + "\t\t"));

                x1 += 1 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
                x2 += 1 / 6.0 * (l1 + 2 * l2 + 2 * l3 + l4);
                Console.WriteLine(Convert.ToString("\t" + x1 + "\t\t\t" + x2));
            }


        }
    }
}
