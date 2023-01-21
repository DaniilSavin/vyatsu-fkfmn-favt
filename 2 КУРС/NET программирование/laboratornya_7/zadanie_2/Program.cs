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
            
            int code;
            try
            {
                StreamReader f = new StreamReader("input.txt");
                StreamWriter f2 = new StreamWriter("out1.txt");

                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == 'z')
                        {
                            f2.Write('a');
                            break;
                        }
                        else
                        {
                            if (s[i]=='Z')
                            {
                                f2.Write('A');
                                break;
                            }
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
