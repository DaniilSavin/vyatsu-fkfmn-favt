using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int x1, x2, x3;
            Console.Write("Введите X: ");
            x = int.Parse(Console.ReadLine());
            x1 = x / 100;
            x2 = (x / 10) % 10;
            x3 = x % 10;
            Console.WriteLine(x1 * 100 + x2 * 10 + x3);
            if (x2!=x3) Console.WriteLine(x1 * 100 + x3 * 10 + x2);
            if (x2 != 0 && x2!=x3 && x1!=x2)
            {
                Console.WriteLine(x2 * 100 + x1 * 10 + x3);
                if ( x1!=x3 && x1!=x2)
                Console.WriteLine(x2 * 100 + x3 * 10 + x1);
            }
            if (x3 != 0)
            {
                if (x1 != x3)
                {
                    Console.WriteLine(x3 * 100 + x2 * 10 + x1);
                    if (x1!=x2)
                    Console.WriteLine(x3 * 100 + x1 * 10 + x2);
                }
            }
        }
    }
}