using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace task1
{
    class Program
    {
        const int n = 10;
        static void Main(string[] args)
        {
            int[] Arr = new int[n];
            Console.WriteLine("Введите 10 чисел: ");
            for (int i = 0; i < 10; i++)
                Arr[i] = int.Parse(Console.ReadLine());
            int maxval = Arr.Max<int>();
            int minval = Arr.Min<int>();
            int maxind = Array.IndexOf(Arr, maxval);
            int minind = Array.IndexOf(Arr, minval);
            Console.WriteLine("Первый максимальный= " + maxind + "\nПоследний минимальный= " + minind);
            try
            {
                if (minind < maxind)
                    Array.Reverse(Arr, minind + 1, Arr.Length - (Arr.Length - maxind) - 1);
                else
                    Array.Reverse(Arr, maxind + 1, Arr.Length - (Arr.Length - minind) - 1);
            }
            catch
            {
                Console.WriteLine("Нет элементов между максимальным и минимальным или он один.");
            }
            Console.WriteLine("Массив после преобразований: ");
            for (int i = 0; i < n; i++)
                Console.Write(Arr[i] + " ");
        }
    }
}