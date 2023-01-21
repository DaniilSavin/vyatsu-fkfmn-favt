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
            List<char> symb = new List<char>();
            int count1 = 0, count2 = 0;
            Console.WriteLine("Введите строку:");
            string s = Console.ReadLine();
            Console.WriteLine("Введите 2 символа(каждый с новой строки):");
            char c1 = char.Parse(Console.ReadLine());
            char c2 = char.Parse(Console.ReadLine());
            for (int i=0;i<s.Length;i++)
            {
                if (s[i] == c1) count1++;
                else if (s[i] == c2) count2++;
            }
            if (count1 > count2) Console.WriteLine("Чаще встречается символ {0}", c1);
            else if (count1 < count2) Console.WriteLine("Чаще встречается символ {0}", c2);
            else if (count1 == count2)
            {
                symb=s.Distinct().ToList();
                Console.WriteLine("{0} различных символов в строке", symb.Count);
            }
            Console.ReadKey();
        }
    }
}
