using System;

namespace zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {

            if (bs(3))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
        static bool bs(int number)
        {
            bool find = false;
            int[] array= { 13, 24, 45, 1, 2, 3, 5, 7, 9 };
            int a = 0, b = array.Length;
            int max = array[0];
            if (number > array[array.Length - 1] && number < array[0])
                return false;
            if (number == array[0])
                return false;
            do
            {
                var mid = Math.Floor((double)(a + b) / 2); //находим середину массива
                if (array[(int)mid] > max) //если средний элемент больше максимального 
                {
                    a =(int) mid; //сохраняем 
                    max = array[(int)mid];
                }
                else b = (int)mid;
            } while (a != b);
            int indexOfMax = a;
            if (number == array[indexOfMax])
                find = true;


            if (number>array[0])
            {
                a = 0;
                b = indexOfMax;
            }
            else
            {
                a = indexOfMax;
                b = array.Length;
            }


       
            int pos = -1;
            do
            {
                var mid = Math.Ceiling((double)(a + b) / 2); 
                if (array[(int)mid] < number)
                {
                    a = (int)mid;
                }
                if (array[(int)mid] > number)
                {
                    b = (int)mid - 1;
                }
                if (array[(int)mid] == number) pos = (int)mid;
            } while (a != b && pos == -1);
            if (pos != -1)
            {
                find = true ;
            }
            return find;
        }

    }
}
