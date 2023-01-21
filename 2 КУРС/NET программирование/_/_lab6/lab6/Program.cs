using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        const int n = 10;
        static int minimum = 10000000;
        static int maximum = -10000000;
        static int[] a = new int[n];
        static void create()
        {
            Console.WriteLine("Исходный массив:");
            string[] my = Console.ReadLine().Split();
            for (int i = 0; i < n; i++) a[i]=int.Parse(my[i]);
        }
        static void solve()
        {
            for (int i = 0; i < n; i++) minimum = Math.Min(minimum, a[i]);
            for (int i = 0; i < n; i++) maximum = Math.Max(maximum, a[i]);
            int frst=Array.IndexOf(a,maximum);
            int lst= Array.LastIndexOf(a,minimum);
            /*int t = a[frst];
            a[frst] = a[lst];
            a[lst] = t;*/
            if (frst<lst) Array.Reverse(a, frst + 1, Math.Abs(n - frst - (n - lst)-1));
            else Array.Reverse(a, lst + 1, Math.Abs(n - lst - (n - frst)-1));
        }
        static void print()
        {
            foreach (int element in a)
            {
                Console.Write("{0} ", element);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                create();
            }
            catch
            {
                Console.WriteLine("Введено не целое число");
            }
            solve();
            print();
            Console.ReadKey();
        }
    }
}
