using System;

namespace zadanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            int x = -5; int y = 5;
            Array arr1 = new Array(x, y);
            for (int i = arr1.LowRange; i <= arr1.HighRange; i++)
            {
                arr1[i] = rand.Next(-70, 70);
            }
            Console.WriteLine("Первый массив: "+ arr1);

            Array arr2 = new Array(x, y);
            for (int i = arr2.LowRange; i <= arr2.HighRange; i++)
            {
                arr2[i] = rand.Next(0, 25);
            }         
            Console.WriteLine("Второй массив: "+ arr2);
            Console.Write("Введите элемент, индекс которого хотите найти в первом массиве: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Поиск индекса элемента в первом массиве: " + arr1.FindInd(n));

            Console.Write("Введите элемент, индекс которого хотите найти в первом массиве: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Поиск индекса элемента во втором массиве: " + arr2.FindInd(n));      
            
            Console.WriteLine("Сложение значений массивов: "+ (arr1 + arr2).ToString());
            Console.WriteLine("Вычитание значений массивов: "+ (arr1 - arr2).ToString());

            Console.Write("Введите число, на которое хотите умножить первый массив: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Умножение первого массива на "+n+"= "+ (arr1 * n).ToString());

            Console.Write("Введите число, на которое хотите умножить второй массив: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Умножение второго массива на " + n + "= " + (arr2 * n).ToString());

            Console.Write("Введите число, на которое хотите разделить первый массив: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Деление первого массива на "+n+" = "+ (arr1 / n).ToString());

            Console.Write("Введите число, на которое хотите разделить второй массив: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Деление второго массива на " + n + " = " + (arr2 / n).ToString());

            Console.Write("[Массив 1] Вывод значения по индексу/Введите индекс от "+x+" до "+y+": ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Array1["+n+"]= "+ arr1[n]);

            Console.Write("[Массив 2] Вывод значения по индексу/Введите индекс от " + x + " до " + y + ": ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Array2[" + n + "]= " + arr2[n]);
            Console.ReadKey();
        }
    }
}
