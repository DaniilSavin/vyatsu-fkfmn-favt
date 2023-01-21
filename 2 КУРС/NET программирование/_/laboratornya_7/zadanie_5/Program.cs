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
            int i = 0;
            foreach (var x in dir.GetDirectories())
            {
                Console.WriteLine(prefix + x);


                i++;
                if (x.GetDirectories().Count() > 0)
                {
                    Directories(x, prefix + "    ");
                }

            } 
            foreach (var y in dir.GetFiles())
            {
                Console.WriteLine(prefix + y);
                i++;
            }
            if(i == 0)
            {
                Console.WriteLine("Пусто");
            }
        }
        static void Main(string[] args)
        {
             DirectoryInfo dir = new DirectoryInfo(@"E:\laboratornya_7\as");
             string prefix = " ";
             Directories(dir, prefix);
            Console.ReadKey();
        }
    }
}
