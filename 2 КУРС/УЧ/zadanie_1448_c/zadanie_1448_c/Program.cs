using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1448_c
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int n = 0;  
            List<int> v = new List<int>(101);
            n=int.Parse(Console.ReadLine());      
            for (int i = 0; i < n; i++)
            {
                v.Add(int.Parse(Console.ReadLine()));
            }
            v.Sort();
            if (n == 2)
            {
                Console.Write(v[1]);
                Console.Write("\n");
            }
            else
            {
                int ans = 0;
                int i;
                for (i = n - 1; i >= 4; i -= 2)
                {
                    ans += Math.Min(v[0] * 2 + v[i - 1] + v[i], v[0] + v[1] * 2 + v[i]);
                }
                if (n % 2 == 1)
                {
                    ans += v[0] + v[i - 1] + v[i];
                }
                else
                {
                    ans += Math.Min(v[0] * 2 + v[1] + v[i - 1] + v[i], v[0] + v[1] * 3 + v[i]);
                }
                Console.Write(ans);
                Console.Write("\n");
            }
        }
    }
}
