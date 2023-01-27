using System;
using System.Collections.Generic;
using ClassLibrary2;

namespace ConsoleApp1
{
    class Program
    {

        public static double func1 (double a, double b, double x)
        {
            return Math.Log((3*Math.Pow(x,3) - 2*(Math.Pow(x,2)) + x)/Math.Pow(a*a+b,2)) + a/(Math.Pow(x,3) - 4*Math.Pow(x,2) - x);
        }
        static void Main(string[] args)
        {
            /* double a, b, xmin, xmax, dx;
             Console.WriteLine("Введите а: ");
             a = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите b: ");
             b = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите xmin: ");
             xmin = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите xmax: ");
             xmax = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите dx: ");
             dx = Convert.ToDouble(Console.ReadLine());

             //1
             if (xmin <= 0)
                 Console.WriteLine("Ошибка");

             //2
             if (a * a + b == 0)
                 Console.WriteLine("Ошибка");

             //3
             if (xmin*xmin == 4*xmin+1)
                 Console.WriteLine("Ошибка");

             //4
             if (dx <= 0)
                 Console.WriteLine("Ошибка");

             //5
             if (xmin > xmax)
                 Console.WriteLine("Ошибка");

             //
             if (dx > xmax-xmin)
                 Console.WriteLine("Ошибка");

             Console.WriteLine("x\t\ty\n");
             while (xmin < xmax)
             {
                 Console.WriteLine(Math.Round(xmin,2) + "\t\t" + Math.Round(func1(a, b, xmin),3).ToString());
                 xmin += dx;
             }    */
            Equation eq = new Equation(1, 1, 1, 5, 1);
            List<double> answersX = new List<double>();
            List<double> answersY = new List<double>();
            Equation.Calculation(eq, ref answersX, ref answersY);
            Console.Write("x\t\ty\n");

            for (int i = 0; i < answersX.Count; i++)
            {
                Console.WriteLine(answersX[i] + "\t\t" + answersY[i]);
            }
/*            foreach (double x in answersX)
            {
                Console.Write(x+"\n");
            }
            foreach (double y in answersY)
            {
                Console.WriteLine("\t\t"+y);
            }*/
        }
    }
}
