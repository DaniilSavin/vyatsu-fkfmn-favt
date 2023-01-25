using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1070_c
{
    class Program
    {
        public static int Dif(int h1, int m1, int h2, int m2)
        {
            int d = h2 * 60 + m2 - (h1 * 60 + m1);
            if (d > 60 * 12)
                d -= 60 * 24;
            else if (d < -60 * 12)
                d += 60 * 24;
            return d;
        }
        static void Main(string[] args)
        {
            int d1, d2;
            int h1, m1, h2, m2;
            string st1 = Console.ReadLine();
            string[] s = st1.Split('.');
            string[] s2 = s[1].Split(' ');
             h1 = int.Parse(s[0]);
             m1 = int.Parse(s2[0]);
             h2 = int.Parse(s2[1]);
             m2 = int.Parse(s[2]);
            d1 = Dif(h1, m1, h2, m2);
            st1 = Console.ReadLine();
            s = st1.Split('.');
            s2 = s[1].Split(' ');
            h1 = int.Parse(s[0]);
            m1 = int.Parse(s2[0]);
            h2 = int.Parse(s2[1]);
            m2 = int.Parse(s[2]);
            d2 = Dif(h1, m1, h2, m2);
            for (int d = -5; d <= 5; d++)
            {
                if (d1 - d * 60 >= 0 && d1 - d * 60 <= 6 * 60 && d2 + d * 60 >= 0 && d2 + d * 60 <= 6 * 60 && Math.Abs((d1 - d * 60) - (d2 + d * 60)) <= 10)
                {
                    Console.WriteLine(Math.Abs(d));
                }
            }
        }
    }
}
