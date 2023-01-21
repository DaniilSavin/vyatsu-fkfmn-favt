using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7._5
{
    class Program
    {
        static void Directories(DirectoryInfo dir, string prefix)
        {
            foreach (var x in dir.GetDirectories().OrderBy(x => x.Name))
            {
                Console.WriteLine(prefix + x);
                if (x.GetDirectories().Count() > 0)
                {
                    Directories(x, prefix + "    ");
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"H:\lab3");
            Directories(dir," ");
            Console.ReadKey();
        }
    }
}
