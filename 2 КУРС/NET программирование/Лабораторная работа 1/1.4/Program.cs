using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные:");
            Console.WriteLine("Первое число =");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Второе число =");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Третье число =");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Четвертое число =");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine("Пятое число =");
            double e = double.Parse(Console.ReadLine());

            Console.WriteLine("{0,7}{1,13}{2,20}{3,17}","Число","Модуль","Квадратный корень","В степени 5");
            Console.WriteLine("{0,7}{1,13}{2,20:f}{3,17}", a, Math.Abs(a), Math.Sqrt(a), Math.Pow(a, 5));
            Console.WriteLine("{0,7}{1,13}{2,20:f}{3,17}", b, Math.Abs(b), Math.Sqrt(b), Math.Pow(b, 5));
            Console.WriteLine("{0,7}{1,13}{2,20:f}{3,17}", c, Math.Abs(c), Math.Sqrt(c), Math.Pow(c, 5));
            Console.WriteLine("{0,7}{1,13}{2,20:f}{3,17}", d, Math.Abs(d), Math.Sqrt(d), Math.Pow(d, 5));
            Console.WriteLine("{0,7}{1,13}{2,20:f}{3,17}", e, Math.Abs(e), Math.Sqrt(e), Math.Pow(e, 5));
            Console.ReadKey();
        }
    }
}
