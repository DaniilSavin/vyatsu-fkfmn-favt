using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    class Program
    {
        static void sort(String[] s, int n)
        {
            for (int i = 1; i < n; i++)
            {
                String temp = s[i];

                // Insert s[j] at its correct position 
                int j = i - 1;
                while (j >= 0 && temp.Length < s[j].Length)
                {
                    s[j + 1] = s[j];
                    j--;
                }
                s[j + 1] = temp;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();

            Console.WriteLine("Введите символ: ");
            string symbol = char.Parse(Console.ReadLine()).ToString();

            string[] splitted = text.Split(new[] { ' ', '.', '?', '!', ')', '(', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string slovo in splitted)
            {
                if (slovo.ToLower().IndexOf(symbol.ToLower()) > -1)
                {
                    text = text.Replace(slovo, string.Empty);
                }
            }
            string[] s = text.Split(new[] { ' ', '.', '?', '!', ')', '(', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
            int n = s.Length;
            sort(s, n);
            for (int i = 0; i < s.Length; i++) //идет по массиву
            {
                string sss = s[i]; //заносит в sss одно слово
                if (sss != "") //проверяет
                {
                    int d = 0; //переменная, будет изменяться при нахождении одинаковых слов.
                    for (int j = 0; j < s.Length; j++) //цикл проверяет слово, которое в sss с другими словами
                        if (s[j] == sss) //если слово в sss совпало с s[j]
                        {
                            d++; //увеличивает d (показывает количество таких же слов)
                            s[j] = ""; //удаляет это слово, что бы потом оно не мешалось
                        }
                    if (d >= 3) //если найдено 3 слова
                        Console.Write(sss + " "); //выводит это слово на экран
                   
                }
                
            }
            if (s.Length==0) Console.WriteLine("Нет слов которые можно вывести, исходя из условия");
            Console.ReadKey();
        }
    }
}
