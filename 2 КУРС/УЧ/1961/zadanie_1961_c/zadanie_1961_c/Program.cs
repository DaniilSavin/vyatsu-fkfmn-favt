using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1961_c
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n, m, N;
            string[] s=Console.ReadLine().Split(' ');
            n = ulong.Parse(s[0]); m = ulong.Parse(s[1]); N = ulong.Parse(s[2]);
            Console.Write(Math.Min((N + 1) * m / n, N));
            
        }
    }
}
