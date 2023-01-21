using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    class Program
    {
        private static bool flag = false;
        private static int numberofcolumns = 0;
        private static bool flagzero = false;
        static void finding_a_column(int a, int b, int[,] arr) 
        {
            int count = 0;           
            for (int j = 0; j < b; j++)
            {
                count = 0;
                for (int i = 0; i < a; i++)
                {
                    if (arr[i, j] < 0) 
                    {
                        count++;
                    }
                    if (count > 2) 
                    {
                        i = b;
                    }
                }
                if (count == 2) 
                {
                    
                    Console.WriteLine("Cтолбец содержащий 2 отрицательных элемента: " + j );
                    if (j == 0) flagzero = true;
                    numberofcolumns += j;
                    numberofcolumns *= 10;
                    flag = true;
                }
            }
            if (flag == false)  Console.WriteLine("Нет столбцов содержащих 2 отрицательных элемента");
        }
       
        static void change(int[,] arr, int indexColumn)
        {
            if (indexColumn + 1 >= arr.GetLength(1))
                return;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = indexColumn; j < arr.GetLength(1) - 1; j++)
                {
                    int temp = arr[i, j];
                    arr[i, j] = arr[i, j + 1];
                    arr[i, j + 1] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            Random R = new Random();
            Console.WriteLine("Введите количество строк матрицы:");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов матрицы:");
            int size1 = int.Parse(Console.ReadLine());
            int[,] arr = new int[size, size1];
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

            finding_a_column(size, size1, arr);
            numberofcolumns /= 10;

            if (flag == true)
            {
                while (numberofcolumns > 0)
                {
                    if (flagzero == true) change(arr, 0);
                    change(arr, numberofcolumns % 10);
                    numberofcolumns /= 10;
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write("{0}\t", arr[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }        
    }
}
