using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        const int Number = 15;
        static bool Check = false;
        static void FillArr(int[] arr, Random Rand)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Rand.Next(0, 25);
        }
        static void PrintArr(int[] A)
        {
            foreach (int tmp in A)
                Console.Write(tmp + " ");
            Console.WriteLine();
        }
        static int[] NewArr(int[] a, int[] b)
        {
            int[] New = new int[Number];
            int k = 0;
            int i = 0, j = 0;
            while (i < Number && j < Number)
            {
                if (a[i] < b[j])
                {
                    ++i;
                }
                else if (a[i] > b[j])
                {
                    ++j;
                }
                else
                {
                    New[k] = a[i];
                    ++k;
                    ++i;
                    ++j;
                    Check = true;
                }
            }
            int[] tmp = new int[k];
            for (int z = 0; z < k; z++)
                tmp[z] = New[z];
            return tmp;
        }
        static void Main(string[] args)
        {
            Random Rand = new Random();
            int[] First = new int[Number];
            FillArr(First, Rand);
            int[] Second = new int[Number];
            FillArr(Second, Rand);
            Console.Write("Первый массив:");
            PrintArr(First);
            Console.Write("\nВторой массив:");
            PrintArr(Second);
            int[] Intersection = NewArr(First, Second);
            if (Check)
            {
                Console.Write("\nМассив пересечений:");
                PrintArr(Intersection);
                Console.WriteLine();
            }
            else
                Console.WriteLine("\nПересечение массивов отсутствует");
        }
    }
}

