using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zadanie_8
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"\\lib16\Students\ФИб-2\Новая папка");
            foreach (DirectoryInfo f in dirInfo.GetDirectories())
            {
                f.Delete();
            }
        }
    }
}
