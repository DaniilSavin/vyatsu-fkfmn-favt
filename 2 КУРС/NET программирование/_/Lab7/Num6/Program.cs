using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Num6
{
    class Program
    {
        static void Directories(DirectoryInfo dir)
        {
            foreach (var y in dir.GetFiles())
            {
                string st = dir.FullName;
                string g = "";
                try
                {
                    string h = Convert.ToString(y.CreationTime);
                    foreach(var x in h)
                    {
                        if (x == ' ')
                        {
                            g += '_';
                        }
                       else if (x == ':')
                        {
                            g += '_';
                        }
                        else g += x;
                    }
                    dir.CreateSubdirectory(g);
                    st += "\\" + g;
                    y.MoveTo(st + "\\" + y.Name);
                }
                catch
                {
                    st += "\\" + g;
                    y.MoveTo(st + "\\" + y.Name);
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\zagos\source\repos\Num5\Num6\pyp");
           
            Directories(dir);
            Console.ReadKey();
        }
    }
}

