using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = "26 декабря 2019 г.org";
            
            string FileNameO = "out.txt";
            File.Create(FileNameO).Close();
            using (StreamReader sr = new StreamReader(FileName))
            {
                using (StreamWriter sw = new StreamWriter(FileNameO))
                {
                    var str = File.ReadAllLines(FileName);
                    foreach (var s in str.Distinct())
                    {
                        sw.WriteLine(s);
                    }

                    sw.Close();
                }
                sr.Close();
            }



            Console.ReadKey();
        }
    }
}
