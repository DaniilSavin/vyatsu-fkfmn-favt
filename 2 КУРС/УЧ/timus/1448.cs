using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, l, m, n;
            double k;
            
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            k = 0;

            for (i =1; i<=n; i++)
            {
                if (i==1 || k / i * 100 < m)
                {
                    k++;
                    Console.Write("1");
                } else
                {
                    Console.Write("0");
                }
            }
        }
    }
}
