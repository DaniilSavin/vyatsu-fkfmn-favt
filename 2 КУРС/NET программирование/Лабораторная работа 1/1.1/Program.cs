using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные:");
            Console.Write("Длина= ");
            double dl = double.Parse(Console.ReadLine());
            Console.Write("Высота= ");
            double h = double.Parse(Console.ReadLine());
            Console.Write("Ширина= ");
            double sh = double.Parse(Console.ReadLine());
            Console.Write("Стоимость= ");
            double pr = double.Parse(Console.ReadLine());
            double s = 0;
            double sum = 0;
            s = (2 * dl * h) + (2 * sh * h) + (dl * sh);
            sum = s * pr;
            Console.WriteLine("Стоимость оклейки= " + sum+ " руб.");
            Console.ReadKey();
        }
        
    }
}
