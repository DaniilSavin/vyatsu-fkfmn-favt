using System;

namespace zadanie_4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (bs(27))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }


            if (linearsearch(27))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
        static bool bs(int element)
        {
            bool find = false;
            int[,] array = {
            { 1, 3, 6 },
            { 2, 4, 13 },
            { 3, 5, 14},
            { 4, 6, 15},
            { 5, 9, 21}
            };

            if (array.GetLength(0) > array.Length)
            {
                int[] tmpArray = new int[array.Length];
                int k = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        tmpArray[k] = array[i, j];
                        k++;
                    }

                }
                for (int i = 0; i < array.Length; i++)
                {
                    var a = 0;
                    var b = array.GetLength(0) - 1;

                    do
                    {
                        int mid = (int)Math.Floor((double)(a + b) / 2);
                        if (tmpArray[mid] > element)
                        {
                            b = mid;
                        }
                        else a = mid;

                        if (tmpArray[a] == element)
                            find = true;//  Console.WriteLine("i= " + i + "a=" + a); // return  i, a ;
                        else
                        if (tmpArray[b] == element) find = true;// Console.WriteLine("i= " + i + "b=" + b);
                    } while (a != b - 1);
                }
            }
            else
            {
                int[] tmpArray = new int[array.Length];
                int k = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j=0; j<array.GetLength(1); j++)
                    {
                        tmpArray[k] = array[i, j];
                        k++;
                    }
                    
                }
                for (int i = 0; i < array.Length; i++)
                {
                    int a = 0;
                    int b = array.Length - 1;

                    do
                    {
                        int mid = (int)Math.Floor((double)(a + b) / 2);
                        if (tmpArray[mid] > element)
                        {
                            b = mid;
                        }
                        else
                            a = mid;

                        if (tmpArray[a] == element)
                            find = true;
                        else
                        if (tmpArray[b] == element)
                            find = true;
                    } while (a != b - 1);
                }
            }
            return find;
        }
        static bool linearsearch(int element)
        {

            bool find = false;
            int[,] array = {
            { 1, 3, 6 },
            { 2, 4, 13 },
            { 3, 5, 14},
            { 4, 6, 15},
            { 5, 9, 21}
            };
            int i = array.GetLength(1) - 1;
            for (; i >= 0; i--)
            {
                if (array[array.GetLength(0) - 1, i] < element) continue;
                
                for (int j = array.GetLength(0) - 1; j >= 0; j--)
                {
                    if (array[j, i] == element)
                    {
                        find = true; 
                    }
                }
            }
            return find;
        }

    }
}
