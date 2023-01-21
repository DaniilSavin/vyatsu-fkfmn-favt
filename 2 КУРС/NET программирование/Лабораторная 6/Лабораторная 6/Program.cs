using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string s = Console.ReadLine();
            Console.WriteLine("Введите первый символ, который нужно проверить");
            char ch1 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Введите второй символ, который нужно проверить");
            char ch2 = Convert.ToChar(Console.ReadLine());
            int cnt1 = s.Length - s.Replace(ch1.ToString(), "").Length;
            int cnt2 = s.Length - s.Replace(ch2.ToString(), "").Length;
            if (cnt1==cnt2)
                Console.WriteLine(string.Format("Символы встречаются одинаковое количество раз"));
            else
                Console.WriteLine(string.Format("Символ '{0}' встречается чаще", cnt1 < cnt2 ? ch2 : ch1));
        }
    }
}
