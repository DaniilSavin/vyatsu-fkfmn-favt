using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class Program
    {
        public static void PrintArray(int[,] arr)
        {
            int n = arr.GetUpperBound(0) + 1;
            int m = arr.GetUpperBound(1) + 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(arr[i, j].ToString().PadLeft(5));
                Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк массива: ");
            int h = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов массива: ");
            int w = int.Parse(Console.ReadLine());
            int[,] array = new int[h, w];
            int i = 0, j = 0, n = 0, tmp = 0; 
            array[0, 0] = 1;
            for (int c = 2; c < w * h + 1; c++)
            {
                switch (n)
                {
                    case 0:
                        j++;
                        if (i == 0)
                            n = 3;
                        else
                            n = 2;
                        break;

                    case 1:
                        i++;
                        if (j == 0)
                            n = 2;
                        else
                            n = 3;
                        break;

                    case 2:
                        i--;
                        j++;
                        if (j == h - 1)
                            n = 1;
                        else if (i == 0)
                            n = 0;
                        break;

                    case 3:
                        i++;
                        j--;
                        if (i == w - 1)
                            n = 0;
                        else if (j == 0)
                            n = 1;
                        break;
                }
                array[j, i] = c;
            }
            PrintArray(array);
            Console.WriteLine("\nМассив после преобразований: ");
            for (int k = 0; k < h; k++)
            {
                for (int l = 0; l < w; l++)
                {
                    if (array[k, l] % 2 == 0)
                    {
                        int Sum = 0;
                        if (l != 0)
                            Sum += array[k, l - 1];
                        if (l != w - 1)
                            Sum += array[k, l + 1];
                        if (k != 0)
                            Sum += array[k - 1, l];
                        if (k != h - 1)
                            Sum += array[k + 1, l];
                        tmp = Sum;
                        Console.Write(tmp.ToString().PadLeft(5));
                    }
                    else
                        Console.Write(array[k, l].ToString().PadLeft(5));
                }
                Console.WriteLine();
            }
        }
    }
}