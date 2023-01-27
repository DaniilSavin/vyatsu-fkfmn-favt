using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc c = new Calc();

            List<double> res = Calc.Calculation(2.0, 5.0, 1.0, 5.0, 1.0);//1
            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
    }
    public class Calc
    {
        //public List<double> X = new List<double> { };
        public static List<double> Y = new List<double> { };

        public static List<double> Calculation(double a, double b, double x_min, double x_max, double dx)
        {
            if (b == 0)//2
            {
                throw new ArgumentException("b == 0");
            }
            if (dx == 0)//3
            {
                throw new ArgumentException("x == 0");
            }
            if (x_min > x_max)//4
            {
                throw new ArgumentException("x_min < x_max");
            }
            if (dx > (x_max-x_min))//5
            {
                throw new ArgumentException("dx > (x_max-x_min)");
            }

            while (x_min < x_max)//6 9
            {
                if (x_min == b)//7
                {
                    throw new ArgumentException("x == b");
                }
                Y.Add(Math.Floor(getRes(a, b, x_min)));//8
                x_min += dx;
            }
            return Y;//10
        }

        public static double getRes(double a, double b, double x)
        {
            double y = 2 * Math.Atan((25 * a) / b) + (3 * Math.Cos(9 * x * x / (b - x)) * Math.Cos(9 * x * x / (b - x)));//9
            return y;
        }
    }
}
