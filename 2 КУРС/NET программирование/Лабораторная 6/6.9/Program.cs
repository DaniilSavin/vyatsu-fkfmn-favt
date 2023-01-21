using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите строку");
                string s = Console.ReadLine();
                int result = Regex.Matches(s, "-?[0-9]+").Cast<Match>().Sum(x => int.Parse(x.Value));
                Console.WriteLine("Сумма чисел в строке: " + result);

                int[] numbers = new int[100];
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                    if (char.IsNumber(s[i]))
                        numbers[count] = (int)(s[i]) - (int)('0');
            }
            catch
            {
                Console.WriteLine("Ошибка ввода данных.");
            }
        }
    }

}