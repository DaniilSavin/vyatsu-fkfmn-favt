using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zadanie_3
{
    class Program
    {
        static void Main()
        {
            //try
            {
                StreamReader f = new StreamReader("input.txt");
                StreamWriter f2 = new StreamWriter("out1.txt");
                char[] alph2 = { ',', '.', ';', ':', '?', '!', '—' };
                char[] alph = { '[', ']', '(', ')', '-', '{', '}' };
                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();

                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == ' ' && s[i - 1] == ' ')
                        {
                            f2.Write("");
                        }
                        else
                        {
                            f2.Write(s[i]);
                        }
                       /* if (i != s.Length - 4 && s[i]=='.' && s[i+1] == ' ' && s[i+2] == '.')
                        {
                            f2.Write("");
                        }*/
                        if (i != s.Length - 1 && s[i] != ' ' && s[i + 1] == '—')
                        {
                            f2.Write(" ");
                        }
                        for (int j = 0; j < alph2.Length; j++)
                        {
                            if (i != s.Length - 1 && s[i] == alph2[j] && s[i + 1] != ' ')
                            {
                                
                                f2.Write(" ");
                            }
                            if (i != s.Length - 1 && s[i] == ' ' && s[i + 1] == alph[j])
                            {
                                f2.Write("");
                                
                            }

                        }
                    }
                    f2.WriteLine();
                }
                f2.Close();
            }
           /* catch
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }*/
        }
    }
}
