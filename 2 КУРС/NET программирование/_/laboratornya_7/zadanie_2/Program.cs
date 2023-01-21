using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zadanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] alph = { 'а', 'б', 'в','г','д','е','ё','ж','з','и', 'й','к','л','м','н','о','п','р','с','т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            char[] alph2 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            int code;
            try
            {
                StreamReader f = new StreamReader("input.txt");
                StreamWriter f2 = new StreamWriter("out1.txt");

                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    Console.WriteLine(s);
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == 'z')
                        {
                            f2.Write('a');
                            break;
                        }
                        else
                        {

                            code = char.ConvertToUtf32(s, i);
                            code++;
                            f2.Write((char)code);
                        }
                    }
                    f2.WriteLine();

                }

                f.Close();
                f2.Close();
            }
            catch
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }
    }
}
