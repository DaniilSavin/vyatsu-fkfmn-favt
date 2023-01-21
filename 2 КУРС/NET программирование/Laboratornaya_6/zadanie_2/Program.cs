using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_2
{
    class Program
    {
        const int n = 10;
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            int[] mas_2 = new int[n];
            int[] mas_3 = new int[n];
            
            for (int i=0; i<n; i++)
            {             
                mas_2[i] = rnd.Next(0, 100);
                mas_3[i] = rnd.Next(0, 100);
            }
            int ii = 0;
            int[] mas_1 = mas_2.Intersect(mas_3).ToArray();
            foreach (int i in mas_2)
            {
                Console.WriteLine("mas_2[" + ii + "] " + i);
                ii++;
            }
            Console.WriteLine("__________________");
             ii = 0;
            foreach (int i in mas_3)
            {
                Console.WriteLine("mas_3[" + ii + "] " + i);
                ii++;
            }
            Console.WriteLine("__________________");
            ii = 0;
            foreach (int i in mas_1)
            {
                Console.WriteLine("mas_1[" + ii + "] " + i);
                ii++;
            }
        }
    }
}
