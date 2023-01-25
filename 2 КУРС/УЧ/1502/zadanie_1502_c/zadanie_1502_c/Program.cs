using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1502_c
{
    class Program
    {
        static void Main(string[] args)
        {
            long n=int.Parse(Console.ReadLine());
            Console.WriteLine(n * (n + 1) * (n + 2) / 2);
            
        }
    }
}
