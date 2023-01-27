using System;

namespace zadanie_1
{
    class Program
    {
        static int size = 10;
        static void Main(string[] args)
        {
            Random rand = new Random();
            int []arr =new int [size];
            for(int i=0; i< size; i++)
            {
                arr[i] = rand.Next(100);
                Console.WriteLine("arr[" + i + "]= " + arr[i]);
            }

            Console.WriteLine("\nВведите число для поиска: ");
            int value = int.Parse(Console.ReadLine());
            if (find(arr, value))
            {
                Console.WriteLine("\nTrue");
            }
            else
            {
                Console.WriteLine("\nFalse");
            }

        }


        static bool find(int []arr, int value)
        {
            bool findd = false;
            if (size != 0)
            {
                int last = arr[size - 1]; 
                arr[size - 1] = value;    
                                          
                int i=0;
                while(arr[i] != value)
                {
                    i++;
                }

                arr[size - 1] = last;                  
                if (i != (size - 1) || value == last)  
                {
                    findd = true;
                }
            }
            return findd;
            
        }
    }
}
// 17 79 70 62 33 81 63 55 50 79 (55)
// сохраняем последний элемент массива
// заменяем последний элемент массива на элемент который ищем
// идем по массиву пока не найдем элемент 17==55, 79==55, 62==55..? 
// возвращаем обратно последний элемент в массива
// проверяем не равен ли индекс размеру массива или последний элемент массива равен элементу который ищем
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//