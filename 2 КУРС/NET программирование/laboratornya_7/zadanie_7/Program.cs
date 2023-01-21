using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zadanie_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string catalog = @"D:\Лабораторная работа 7\laboratornya_7";

            string fileName = "*.doc";
            foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName, SearchOption.AllDirectories))
            {
                FileInfo FI;
                try
                { 
                    FI = new FileInfo(findedFile);
                    Console.WriteLine(FI.Name + " " + FI.FullName + " " + FI.Length + "_байт" + " Создан: " + FI.CreationTime);
                }
                catch
                {
                    Console.WriteLine("Файл не найден.");
                    
                }

            }
            Console.ReadKey();
        }
        
    }
}
