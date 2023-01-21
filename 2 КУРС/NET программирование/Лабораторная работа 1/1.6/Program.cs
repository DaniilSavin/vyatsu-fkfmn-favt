using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, x1, x2, x3, x4, x5, x6, x7;
            Console.WriteLine("Введите число:");
            x= int.Parse(Console.ReadLine());
            if (x>=1000000 && x<=9999999)
            {
                x1 = x / 1000000;
                x2 = x / 100000 % 10;
                x3 = x / 10000 % 10;
                x4 = x / 1000 % 10;
                x5 = x / 100 % 10;
                x6 = x / 10 % 10;
                x7 = x % 10;
                Console.WriteLine("x1= " + x1);
                Console.WriteLine("x2= " + x2);
                Console.WriteLine("x3= " + x3);
                Console.WriteLine("x4= " + x4);
                Console.WriteLine("x5= " + x5);
                Console.WriteLine("x6= " + x6);
                Console.WriteLine("x7= " + x7);
                if (x1==x7 && x2==x6 && x3==x5)
                {
                    Console.WriteLine("Палиндром.");     
                }
                else
                {
                    Console.WriteLine("Не палиндром.");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели несемизначное число.");
            }
            Console.ReadKey();
        }
    }
}
