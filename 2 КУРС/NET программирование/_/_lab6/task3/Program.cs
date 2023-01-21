using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static int n;
        static void PrintArray(int[] array, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int n1 = n;
            bool pp = false;
            int[] A;
            int check = 0, count=0;
           
            int uniq = 0;
            while (check == 0)
            {
                try
                {
                    Console.WriteLine("Введите размерность массива: ");
                    n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("Некорректный ввод.\n");
                    }
                    else check = 1;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод.");
                }

            }
            A = new int[2 * n];
            Random rnd = new Random();
            int min = 31;
            int max = -16;
            for (int i = 0; i < n; i++)
            {
                A[i] = 7;// rnd.Next(-15, 30);
                if (A[i] > max) max = A[i];
                else if (A[i] < min) min = A[i];
            }
            Console.WriteLine("\nИсходный массив:");
            PrintArray(A, n);
            for (int i=0;i<n-1;i++)
            {
                if (A[i] == A[i + 1]) count++;
            }
            if (count == n - 1)
            {
                pp = true;
                n1 = 1;
            }
            Console.WriteLine("Минимум = {0} Максимум = {1}", min, max + "\n");
            int k = 0;
            for (int i = 0; i < n; ++i)
            {
                if (A[i] == max)
                {
                    k = 0;
                    for (int j = n; j - k != i;)
                        A[j - k++] = A[j - k];

                    A[i] = min;
                    n++; ++i;
                }
            }
            Console.Write("Массив после вставки минимума: ");
            PrintArray(A, n);
            List<int> IsFindSame = new List<int>();
            foreach (int c in A)
                if (IsFindSame.IndexOf(c) == -1)
                {
                    IsFindSame.Add(c);
                    uniq++;
                }
            Console.Write("Конечный массив: ");
            if (pp) for (int i = 0; i < n1; i++) Console.WriteLine("{0}",A[i]);
            else for (int i = 0; i < uniq - 1; i++) Console.Write(IsFindSame[i] + " ");
            Console.ReadKey();
        }
    }
}
