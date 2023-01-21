using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._10
{
    class Program
    {
        static void Main(string[] args)
        {
            int caseSwitch = 0;
            Console.Write("Введите ваш балл: ");
            caseSwitch =
                int.Parse(Console.ReadLine());

            switch (caseSwitch)
            {
                case 0:                    
                case 1:                   
                case 2:
                    Console.WriteLine("Неудовлетворительно.");
                    break;
                case 3:
                    Console.WriteLine("Удовлетворительно.");
                    break;
                case 4:
                    Console.WriteLine("Хорошо.");
                    break;
                case 5:
                    Console.WriteLine("Отлично.");
                    break;
                default:
                    Console.WriteLine("Такой оценки нет.");
                    break;
            }
        }
    }
}

