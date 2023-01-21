using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите данные:");
            Console.Write("a= ");
            int a = int.Parse(Console.ReadLine());
            if (a > 0)
            {
                Console.Write("b= ");
                int b = int.Parse(Console.ReadLine());
                if (b > 0)
                {
                    Console.Write("c= ");
                    int c =  int.Parse(Console.ReadLine());
                    if (c > 0)
                    {
                        double s ;
                        double p ;
                        p = (a + b + c) / 2.0;
                        s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                        Console.WriteLine("Площадь треугольника= {0:F2} ", s);
                    }
                    else
                    {
                        Console.WriteLine("Сторона не может быть отрицательной или равной 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Сторона не может быть отрицательной или равной 0.");
                }
            }
            else
            {
                Console.WriteLine("Сторона не может быть отрицательной или равной 0.");
            }
            Console.ReadKey();
        }
    }
}
