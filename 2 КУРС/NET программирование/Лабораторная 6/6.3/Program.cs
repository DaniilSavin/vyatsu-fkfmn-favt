using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Random r = new Random();
                Console.Write("Введите размер массива: ");
                int K = int.Parse(Console.ReadLine());
                if (K <= 0)
                {
                    Console.WriteLine("Неверные исходные данные.");
                    goto end;
                }
                Console.WriteLine();
                ArrayList arr = new ArrayList();
                int min = 2147483647, max = -2147483648, tmpn = 0;
                Console.WriteLine("Массив чисел из диапазона от -15 до 30");
                for (int i = 0; i < K; i++)
                {
                    arr.Add(/*Convert.ToInt32(r.Next(-15, 30))*/5);
                    Console.Write(arr[i] + " ");
                    if (Convert.ToInt32(arr[i]) >= max)
                        max = Convert.ToInt32(arr[i]);
                    if (Convert.ToInt32(arr[i]) <= min)
                        min = Convert.ToInt32(arr[i]);
                }
                Console.Write("\n");

                for (int i = 0; i < K; i++)
                {
                    tmpn = Convert.ToInt32(arr[i]);
                    if (Convert.ToInt32(max) == Convert.ToInt32(tmpn))
                    {
                        arr.Insert(i, min);
                        i++;
                    }
                }
                Console.WriteLine("\nМинимальный элемент: " + min);
                Console.WriteLine("\nМаксимальный элемент: " + max);
                Console.WriteLine("\nВставлен элемент, равный минимальному элементу всего массива, перед всеми элементами, равными максимальному элементу");
                foreach (object a in arr)
                {
                    Console.Write(a + " ");
                }

                int count = K*2;
                while (count > 0)
                    for (int i = 0; i < arr.Count; i++)
                    {
                        for (int j = i + 1; j < arr.Count; j++)
                            if (arr[i].ToString() == arr[j].ToString())
                                arr.Remove(arr[j]);
                        count--;
                    }
                Console.WriteLine("\nУдалены повторяющиеся элементы");

                foreach (object a in arr)
                {
                    Console.Write(a + " ");
                }
            end:;
            }
            catch
            {
                Console.WriteLine("Ошибка. Неверный формат данных.");
            }
        }
    }
}
