using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        const int n = 15;
        static int[] a = new int[n] { 1, 1, 8, 9, 15, 18, 19, 25, 28, 34, 37, 45, 49, 56, 66 };
        static int[] b = new int[n] { 1, 1, 1, 7, 9, 11, 16, 19, 21, 26, 21, 34, 41, 45, 49 };
        static int[] c = new int[n];
        static int solvenew(int ch, int[]a, int size)
        {
            int count = 0;
            bool pp = true;
            for (int i=size;i<a.Length;i++)
            {
                if (a[i] == ch)
                {
                    count++;
                    pp = false;
                }
                else if (!pp) return count;
            }
            return count;
        }
        static void print(int[]mass)
        {
            foreach (int element in mass)
            {
                Console.Write("{0} ", element);
            }
        }
        static void Main(string[] args)
        {
            int[] resultmass = new int[n];
            Console.WriteLine("Первый массив:");
            print(a);
            Console.WriteLine();
            Console.WriteLine("Второй массив:");
            print(b);
            Console.WriteLine();
            int j = 0, k = 0, ch1 = 0, ch2 = 0, rez = 0;
            Console.WriteLine("Результирующий массив:");
            for (int i=0;i<n;i+=ch1,rez+=ch2)
            {
                ch1 = solvenew(a[i],a,i);
                ch2 = solvenew(a[i], b, rez);
                k = Math.Min(ch1, ch2);
                while (k>0)
                {
                    k--;
                    resultmass[j + 1] = a[i];
                    Console.Write("{0} ", a[i]);
                }
            }
            Console.ReadKey();
        }
    }
}

