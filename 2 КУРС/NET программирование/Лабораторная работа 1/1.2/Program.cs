using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные:");
            Console.Write("x= ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y= ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("z= ");
            double z = double.Parse(Console.ReadLine());
            double res = 0;
           res= ((Math.Pow(x, 12)+ Math.Sqrt(Math.Pow(z,6)-5*x*y))/(Math.Abs(-7*Math.Pow(x, 2)*Math.Pow(y,8)+z))+2);
            Console.WriteLine("Результат= {0:F5}", res);
            Console.ReadKey();
        }
    }
}
