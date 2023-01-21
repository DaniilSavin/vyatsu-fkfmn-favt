using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int check = 0;
            while (check == 0)
            {
                Console.WriteLine("Введите строку:");

                s = Console.ReadLine();
                if (s == "") Console.WriteLine("Некорректный ввод\n");
                else check = 1;
            }
            int checkneg = 0;
            int part = 0, sum = 0;
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {

                if (Char.IsNumber(s[i]))
                {
                    if (i != 0 && s[i - 1] == '-') checkneg = 1;
                    while (Char.IsNumber(s[i]))
                    {

                        i++;
                        k++;
                        if (i == s.Length) break;
                    }
                    for (int j = 0; j < k; j++)
                        part += int.Parse(s[i - j - 1].ToString()) * (int)Math.Pow(10, j);

                    if (checkneg == 1) part = -part;
                    sum += part;
                    part = 0;
                    k = 0;
                    checkneg = 0;
                }
            }
            Console.WriteLine("Сумма чисел = " + sum);
            Console.ReadKey();
        }
    }
}
