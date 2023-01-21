using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static int n;
        static int[,] a;
        static Random Rand = new Random();

        static void print(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static bool equalz(int n)
        {
            int[] sumi = new int[n]; 
            int[] sumj = new int[n]; 
            int[] sumd = new int[2]; 

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    sumi[i] += a[i, j];
            int k = 0;
            for (int i = 0; i < n; i++)
                if (sumi[i] == sumi[0]) k++;
            if (k == n)
            {
                k = 0;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        sumj[i] += a[j, i];
                for (int i = 0; i < n; i++)
                    if (sumj[i] == sumj[0]) k++;
                if (k == n)
                {
                    for (int i = 0; i < n; i++)
                        sumd[0] += a[i, i]; 
                    for (int i = 0; i < n; i++)
                        sumd[1] += a[n - 1 - i, i];
                    if (sumd[0] == sumd[1]) return true;
                    else return false;
                }
                else return false;
            }
            else return false;

        }
        static void solve(int n)
        {
            int[] minimum = new int[n];

            for (int i = 0; i < n; i++)
            {
                int min = 151;
                for (int j = 0; j < n; j++)
                    if (a[j, i] < min) min = a[j, i];
                minimum[i] = min;
            }
            Console.WriteLine("\nМинимальные элементы каждого столбца");
            for (int i = 0; i < n; i++)
                Console.Write(minimum[i] + "\t");

            int t = 0;
            int[,] sortedm = new int[n, n];
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (minimum[j] > minimum[j + 1])
                    {
                        t = minimum[j];
                        minimum[j] = minimum[j + 1];
                        minimum[j + 1] = t;
                        for (int z = 0; z < n; z++)
                        {
                            t = a[z, j];
                            a[z, j] = a[z, j + 1];
                            a[z, j + 1] = t;
                        }
                    }
                }

            Console.WriteLine("\n\nМинимальные элементы каждого столбца по неубыванию");
            for (int i = 0; i < n; i++)
                Console.Write(minimum[i] + "\t");

            Console.WriteLine("\n\nИзмененный массив:");
            print(a, n);
        }

        static void Main(string[] args)
        {
            int[] sumi1 = new int[n];
            int[] sumj1 = new int[n];
            int[] sumd1 = new int[n];
            bool check = false;
            Console.WriteLine("Введите размерность массива:");
            while (check == false)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());

                    if (n < 0)
                        Console.WriteLine("Некорректный ввод");
                    else
                        check = true;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = Rand.Next(-50, 150);
            Console.WriteLine("\nИсходный массив:");
            print(a, n);

            if (equalz(n) == true) Console.WriteLine("\nМассив является магическим квадратом:\n");
            else
            {
                Console.WriteLine("\nМассив не является магическим квадратом:\n");
                solve(n);
            }
            for (int i=0;i<n;i++)
            {
               
            }
            Console.ReadKey();
        }
    }
}
