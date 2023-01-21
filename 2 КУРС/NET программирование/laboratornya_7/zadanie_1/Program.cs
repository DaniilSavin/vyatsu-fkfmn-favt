using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zadanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader f = new StreamReader("input.txt");
                StreamWriter f2 = new StreamWriter("out1.txt");
                StreamWriter f3 = new StreamWriter("out2.txt");
                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    int num = int.Parse(s);
                    if (num % 2 == 0)
                    {
                        f2.WriteLine(num);
                    }
                    else
                        f3.WriteLine(num);
                }
                f.Close();
                f2.Close();
                f3.Close();
            }
            catch
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }
    }
}
