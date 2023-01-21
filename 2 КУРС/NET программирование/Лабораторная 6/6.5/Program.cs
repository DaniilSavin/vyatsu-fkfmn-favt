using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void ShowArray(int[,] ar)
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                    Console.Write($"{ar[i, j]}\t");
                Console.WriteLine();
            }
        }
        static void ChangeArray(int[,] ar, int[,] creat)
        {
            int x = int.MaxValue;
            int m = 0;
            int findj = 0;
            while (m < creat.GetLength(1))
            {
                for (int i = 0; i < ar.GetLength(0); i++)
                {
                    for (int j = 0; j < ar.GetLength(1); j++)
                    {
                        if (x > ar[i, j])
                        {
                            x = ar[i, j];
                            findj = j;
                        }
                    }
                }
                x = int.MaxValue;
                for (int k = findj; k < findj + 1; k++)
                {
                    for (int z = 0; z < creat.GetLength(0); z++)
                    {
                        creat[z, m] = ar[z, findj];
                        ar[z, findj] = int.MaxValue;
                    }
                }
                m++;
            }
        }
        static void Main(string[] args)
        {
            {
                Random R = new Random();
                Console.WriteLine("Введите размер матрицы:");
                int size = int.Parse(Console.ReadLine());
                int[,] arr = new int[size, size];
                int[,] creatArry = new int[size, size];
                int flagStrok = 0;
                int flagStolb = 0;                
                Console.WriteLine("Массив чисел:");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = R.Next(-50, 150);
                        Console.Write("{0}\t", arr[i, j]);
                    }
                    Console.WriteLine();
                }

                int[] SumStrok = new int[arr.GetLength(0)];

                for (int z = 0; z < arr.GetLength(0); z++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                        SumStrok[z] += arr[z, j];

                    if (SumStrok[z] == SumStrok[0]) flagStrok++;
                }

                int[] SumStolb = new int[arr.GetLength(1)];

                for (int z = 0; z < arr.GetLength(0); z++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                        SumStolb[z] += arr[z, j];

                    if (SumStolb[z] == SumStolb[0]) flagStolb++;
                }
                if (SumStrok[0] == SumStolb[0] && flagStrok == arr.Length - 1 && flagStolb == arr.Length - 1)
                    Console.WriteLine("Матрица 9-го порядка является магическим квадратом!");
                else Console.WriteLine("Матрица не является магическим квадратом.");
                ChangeArray(arr, creatArry);
                Console.WriteLine();
                Console.WriteLine("Упорядоченная матрица со столбцами по убыванию их минимальных элементов.");
                ShowArray(creatArry);
                Console.ReadLine();
            }
        }
    }
}
