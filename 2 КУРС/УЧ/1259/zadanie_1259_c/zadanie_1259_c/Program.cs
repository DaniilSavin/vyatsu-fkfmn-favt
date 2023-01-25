using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1259_c
{
    class Program
    {
        public static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b>0)
            {
                int tmp = a % b;
                a = b;
                b = tmp;
            }
            return (a);
        }
        static void Main(string[] args)
        {
            int s = 0, n;
            n = int.Parse(Console.ReadLine());
            for (int i=1; i<=n/2; i++)
            {
                if (GCD(n, i) % n == 1)
                    s++;
            }
            Console.WriteLine(s);
        }
    }
}
