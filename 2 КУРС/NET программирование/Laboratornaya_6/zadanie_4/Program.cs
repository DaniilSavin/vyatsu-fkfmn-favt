using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_4
{
    class Program
    {
        const int Rows0 = 6;
        const int Rows1 = 9;
        static void Main(string[] args)
        {
            try
            {
                int[,] Arr = new int[Rows0, Rows1];
                FillArr(Arr);
                Console.WriteLine("Массив:");
                PrintArr(Arr);
                ChangeArr(Arr);
                Console.WriteLine("Измененный массив:");
                int[,] NewArr = ChangeArr(Arr);
                PrintArr(NewArr);
            }
            catch
            {
                Console.WriteLine("Некорректный ввод данных");
            }
        }
        static void FillArr(int[,] Arr)
        {
            int i = 0, j = 0;
            int k = 0;
            int directionX = 1, directionY = -1;//начальные направления
            bool Change = false;
            do
            {
                ++k;
                if (i == Rows0 && j < 0)
                {
                    i--;
                    j = 1;
                    Change = true;
                }
                else if (j == Rows1 && i < 0)
                {
                    j--;
                    i = 1;
                    Change = true;
                }
                else if (i < 0)
                {
                    i = 0;
                    Change = true;
                }
                else if (j < 0)
                {
                    j = 0;
                    Change = true;
                }
                else if (i == Rows0)
                {
                    Change = true;
                    i = Rows0 - 1;
                    j += 2;
                }
                else if (j == Rows1)
                {
                    Change = true;
                    j = Rows1 - 1;
                    i += 2;
                }
                if (i == Rows0 || j == Rows1)
                {
                    break;
                }
                Arr[i, j] = k;

                if (Change)
                {
                    directionX *= -1;
                    directionY *= -1;
                    Change = false;
                }
                i += directionX;
                j += directionY;
            } while (true);
        }
        static int[,] ChangeArr(int[,] Arr)
        {
            int[,] NewArr = new int[Rows0, Rows1];
            for (int i = 0; i < Rows0; i++)
            {
                for (int j = 0; j < Rows1; j++)
                {
                    if (Arr[i, j] % 2 == 0)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                NewArr[i, j] = Arr[i + 1, j] + Arr[i, j + 1];
                            }
                            else if (j == Rows1 - 1)
                            {
                                NewArr[i, j] = Arr[i + 1, j] + Arr[i, j - 1];
                            }
                            else
                            {
                                NewArr[i, j] = Arr[i + 1, j] + Arr[i, j - 1] + Arr[i, j + 1];
                            }
                        }
                        else if (i == Rows0 - 1)
                        {
                            if (j == 0)
                            {
                                NewArr[i, j] = Arr[i - 1, j] + Arr[i, j + 1];
                            }
                            else if (j == Rows1 - 1)
                            {
                                NewArr[i, j] = Arr[i - 1, j] + Arr[i, j - 1];
                            }
                            else
                            {
                                NewArr[i, j] = Arr[i - 1, j] + Arr[i, j - 1] + Arr[i, j + 1];
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                NewArr[i, j] = Arr[i - 1, j] + Arr[i + 1, j] + Arr[i, j + 1];
                            }
                            else if (j == Rows1 - 1)
                            {
                                NewArr[i, j] = Arr[i - 1, j] + Arr[i + 1, j] + Arr[i, j - 1];
                            }
                            else
                            {
                                NewArr[i, j] = Arr[i - 1, j] + Arr[i + 1, j] + Arr[i, j - 1] + Arr[i, j + 1];
                            }
                        }
                    }
                    else NewArr[i, j] = Arr[i, j];
                }
            }
            return NewArr;
        }
        static void PrintArr(int[,] Arr)
        {
            for (int i = 0; i < Rows0; i++)
            {
                for (int j = 0; j < Rows1; j++)
                {
                    Console.Write("{0,5}", Arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
