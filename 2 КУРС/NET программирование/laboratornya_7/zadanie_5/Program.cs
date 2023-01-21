using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zadanie_5
{
    class Program
    {
        static void Directories(DirectoryInfo dir, string prefix)
        {
            foreach (var x in dir.GetDirectories())
            {
                Console.WriteLine(prefix + x);



                if (x.GetDirectories().Count() > 0)
                {
                    Directories(x, prefix + "    ");
                }

            } 
            foreach (var y in dir.GetFiles())
            {
                Console.WriteLine(prefix + y);
               
            }
        }
        static void Main(string[] args)
        {
             DirectoryInfo dir = new DirectoryInfo(@"D:\Лабораторная работа 7\laboratornya_7");
             string prefix = " ";
             Directories(dir, prefix);

            Console.ReadKey();
        }
    }
}
