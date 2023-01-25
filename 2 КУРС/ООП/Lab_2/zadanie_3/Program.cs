using System;

namespace zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            string Start = "\n1 - Ввод 10-ых чисел\n2 - Ввод 8-ых чисел\n3 - Выход";
            Console.WriteLine(Start);
            int start = int.Parse(Console.ReadLine());
            Console.Clear();
            string Menu = "1 - Сложить два числа\n2 - Вычесть два числа\n3 - Операция And\n4 - Операция Or";
            
            switch(start)
            {
                case 1:
                    Console.WriteLine("Введите 2 числа через enter: ");
                    int number1 = int.Parse(Console.ReadLine());
                    int number2 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine(Menu);
                    int switchmenu = int.Parse(Console.ReadLine());
                    switch(switchmenu)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(number1+" "+number2+"\n"+Octal_sys.F10T8(number1) + " + " + Octal_sys.F10T8(number2) + "= " + Octal_sys.Sum(number1, number2));
                            goto start;
                        case 2:
                            Console.Clear();
                            Console.WriteLine(number1 + " - " + number2 + "= " + Octal_sys.Sub(number1, number2));
                            goto start;
                        case 3:
                            Console.Clear();
                            Console.WriteLine(number1 + " And " + number2 + "= " + Octal_sys.And(number1, number2));
                            goto start;
                        case 4:
                            Console.Clear();
                            Console.WriteLine(number1 + " Or " + number2 + "= " + Octal_sys.Or(number1, number2));
                            goto start;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            goto start;
                    }
                case 2:
                    Console.WriteLine("Введите 2 числа через enter: ");
                    string number3 = Console.ReadLine();
                    string number4 = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(Menu);
                    int switchmenu1 = int.Parse(Console.ReadLine());
                    switch (switchmenu1)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(number3 + " + " + number4+"= "+Octal_sys.Sum(number3, number4));
                            goto start;                           
                        case 2:
                            Console.Clear();
                            Console.WriteLine(number3 + " - " + number4 + "= " + Octal_sys.Sub(number3, number4));
                            goto start;
                        case 3:
                            Console.Clear();
                            Console.WriteLine(number3 + " And " + number4 + "= " + Octal_sys.And(number3, number4));
                            goto start;
                        case 4:
                            Console.Clear();
                            Console.WriteLine(number3 + " Or " + number4 + "= " + Octal_sys.Or(number3, number4));
                            goto start;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            goto start; 
                    }                    
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
