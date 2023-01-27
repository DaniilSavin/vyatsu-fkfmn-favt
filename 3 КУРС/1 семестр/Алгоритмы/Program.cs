using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abc abcd abcd abef abc abc";
            string[] array = text.Replace(".", "").Replace(",", "").Split(' ');
            int count = 0;
            int max = 0;
            int min = int.MaxValue;
            SortedDictionary<string, int> container = new SortedDictionary<string, int>();
            foreach (var item in array)
            {
                if (!container.TryAdd(item, 1))
                {
                    container[item]++;
                    if (max < container[item])
                    {
                        max = container[item];
                    }
                }
                else count++;
            }
            foreach (var item in container)
            {
                if (item.Value < min)
                {
                    min = item.Value;
                }

            }
            foreach (var item in container)
            {
                if (item.Value == max)
                {
                    Console.WriteLine("Максимальное количество: ");

                }
                if (item.Value == min)
                {
                    Console.WriteLine("Минимальное количество: ");

                }


            }
            Console.WriteLine("Общее количество уникальных слов: " + count);
        }
    }
}
