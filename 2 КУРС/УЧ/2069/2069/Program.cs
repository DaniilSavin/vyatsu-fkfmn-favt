using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2069
{
    class Program
    {
        public static int[] a = new int[100001];
        public static int[] b = new int[100001];
        public static int max(int a, int b)
        {
            return a >= b ? a : b;
        }
        public static int min(int a, int b)
        {
            return a <= b ? a : b;
        }
        static void Main(string[] args)
        {
            int bv = 0;                     
            int i;
            string[] tempVar = Console.ReadLine().Split(' ');
            int n=int.Parse(tempVar[0]);
            int m = int.Parse(tempVar[1]);
            for (i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            for (i = 0; i < m; i++)
            {
               b[i] = int.Parse(Console.ReadLine());               
            }
            bv = max(min(a[0], b[m - 1]), min(a[n - 1], b[0]));
            for (i = 1; i < n - 1; i++)
            {
                bv = max(bv, min(min(a[i], b[0]), b[m - 1]));
            }
            for (i = 1; i < m - 1; i++)
            {
                bv = max(bv, min(min(b[i], a[0]), a[n - 1]));
            }
            Console.Write("{0:D}\n", bv);
        }
    }
}
