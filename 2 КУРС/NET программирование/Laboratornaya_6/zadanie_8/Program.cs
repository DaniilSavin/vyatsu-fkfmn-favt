using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string Text = "";
                Console.Write("Введите строку:");
                do
                {
                    Text = Console.ReadLine();
                    if (Text == "") Console.Write("Введена пустая строка! Попробуйте еще раз:");
                }
                while (Text == "");
                char Letter;
                Console.Write("Введите символ:");
                Letter = char.Parse(Console.ReadLine());
                string NewText = FindWords(Text, Letter.ToString());
                Console.WriteLine("Новая строка: " + NewText);
                CountWords(NewText);
            }
            catch
            {
                Console.WriteLine("Некорректный ввод данных!");
            }
        }
        static string FindWords(string Input, string Letter)
        {
            StringBuilder Text = new StringBuilder();
            Text.Append(Input);
            int i = 0;
            bool Check = false;
            int Start = 0, End = 0;
            while (i < Text.Length)
            {
                while (i < Text.Length && ((Text[i] >= 32 && Text[i] <= 34) || (Text[i] >= 39 && Text[i] <= 41) || (Text[i] >= 44 && Text[i] <= 46) || (Text[i] >= 58 && Text[i] <= 59) || Text[i] == 63)) ++i;//пропускаем знаки препинания
                Start = i;
                while (i < Text.Length && ((Text[i] >= '0' && Text[i] <= '9') || (Text[i] >= 'A' && Text[i] <= 'Z') || (Text[i] >= 'a' && Text[i] <= 'z') || (Text[i] >= 'а' && Text[i] <= 'я') || (Text[i] >= 'А' && Text[i] <= 'Я')))
                {
                    if (Text[i].ToString() == Letter.ToLower() || Text[i].ToString() == Letter.ToUpper())
                    {
                        Check = true;
                    }
                    ++i;
                }
                if (i <= Text.Length)
                {
                    End = i - 1;
                    if (Check == true)
                    {
                        Text.Remove(Start, End - Start + 1);
                        i -= (End - Start);
                        Check = false;
                    }
                    else
                    {
                        Start = 0; End = 0;
                        ++i;
                    }
                }
            }
            return Text.ToString();
        }
        static void CountWords(string s)
        {
            string[] Text = s.Split(' ', '.', ',', '!', '?', ':', ';', '-', '"', ')', '(');
            int Count = 0;
            int j = 0;
            string[] Result = new string[Text.Length];
            int k = 0;
            for (int i = 0; i < Text.Count(); i++)
            {
                if (Text[i] != "")
                {
                    while (j < s.Length)
                    {
                        if ((j + Text[i].Length) <= s.Length && Text[i] == s.Substring(j, Text[i].Length))
                        {
                            ++Count;
                            j += Text[i].Length;
                        }
                        ++j;
                    }
                    if (Count >= 3)
                    {
                        if (!Result.Contains(Text[i]))
                        {
                            Result[k] = Text[i];
                            ++k;
                        }
                    }
                    Count = 0;
                    j = 0;
                }
            }
            if (k > 0)
            {
                Console.WriteLine("Слова, которые повторяются в тексте не менее 3-х раз:");
                Array.Sort(Result);
                Result.Reverse();
                foreach (string word in Result)
                {
                    if (word != null && word != "") Console.WriteLine(word);
                }
            }
            else Console.WriteLine("Слова с таким количеством повторов отсутствуют");
        }
    }
}
}
