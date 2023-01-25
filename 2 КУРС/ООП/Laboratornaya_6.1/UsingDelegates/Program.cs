using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CalcLibrary;
namespace UsingDelegates
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.Write("Введите пример: ");
            string a = Console.ReadLine();
            Console.Write("Результат: ");
            Console.WriteLine(Calc.DoOperation(a, true, a.First(), a.First()+1, a.Length-1)); 
            Console.ReadKey();
        }
    }
}
