using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_6
{
    class Program
    {
        static int Rows, Cols;
        static bool Check = true;
        static bool ColsCheck = true;
        static int before = 0;

        static void Main()
        {
            try
            {
                Rows = 0; Cols = 0;
                Console.Write("Введите количество строк массива: ");
                Rows = int.Parse(Console.ReadLine());
                Console.Write("Введите количество столбцов массива: ");
                Cols = int.Parse(Console.ReadLine());
            }
            catch
            {
                Check = false;
            }
            if (Rows > 0 && Cols > 0 && Check)
            {
                int[,] Numbers = new int[Rows, Cols];
                FillArr(Numbers);
                Console.WriteLine("Двумерный массив:");
                PrintArr(Numbers);
                ChangeCols(Numbers);
                if (ColsCheck)
                {
                    Console.WriteLine();
                    Console.WriteLine("Измененный массив:");
                    PrintArr(Numbers);
                    Console.WriteLine("\nСтолбец №{0} был перенесён в конец массива", before + 1);
                    // Console.WriteLine("\nСтолбец №{0} теперь является столбцом №{1}", before + 1, Cols);
                }
            }
            else Console.WriteLine("Некорректный ввод данных!");
            Console.ReadLine();
        }
        static void FillArr(int[,] Arr)
        {
            Random Rand = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Arr[i, j] = Rand.Next(-50, 150);
                }
            }
        }
        static void PrintArr(int[,] Arr)
        {
            Random Rand = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write("{0,5}", Arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int FindCol(int[,] Arr)
        {
            int Count = 0;
            for (int j = 0; j < Cols; j++)
            {
                for (int i = 0; i < Rows; i++)
                {
                    if (Arr[i, j] < 0) ++Count;
                    if (Count > 2) break;
                }
                if (Count == 2)
                {
                    return before = j;
                }
                Count = 0;
            }
            Check = false;
            return -1;
        }

        static void ChangeCols(int[,] Arr)
        {
            int Index = FindCol(Arr);
            if (Index != -1)
            {
                for (int z = Index; z < Cols - 1; z++)
                {
                    for (int j = z + 1; j < Cols; j++)
                    {
                        for (int i = 0; i < Rows; i++)
                        {
                            int tmp = Arr[i, z];
                            Arr[i, z] = Arr[i, j];
                            Arr[i, j] = tmp;
                        }
                        ++z;
                    }
                }
            }
            else
            {
                Console.WriteLine("Указанных столбцов не нашлось");
                ColsCheck = false;
            }
        }
    }
} 
}
