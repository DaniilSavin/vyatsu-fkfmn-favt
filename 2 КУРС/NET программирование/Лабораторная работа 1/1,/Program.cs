using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            Console.Write("Введите X: ");
            x= double.Parse(Console.ReadLine());
            Console.Write("Введите Y: ");
            y = double.Parse(Console.ReadLine());


            if (x*y==0)
            {
                if (x+y==x)
                {
                    Console.WriteLine("На оси X.");
                }
                else
                {
                    Console.WriteLine("На оси Y.");
                }
                if (x+y==0)
                {
                    Console.WriteLine("Начало координат.");
                }
            }
            else
            {
                if (x>0)
                {
                    if (y>0)
                    {
                        Console.WriteLine("I четверть.");
                    }
                    else
                    {
                        Console.WriteLine("IV четверть.");
                    }
                }
                else
                {
                    if (y>0)
                    {
                        Console.WriteLine("II четверть.");
                    }
                    else
                    {
                        Console.WriteLine("III четверть.");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
