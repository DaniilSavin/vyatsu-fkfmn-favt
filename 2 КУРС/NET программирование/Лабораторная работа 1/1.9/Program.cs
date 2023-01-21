using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime.DaysInMonth()
                
            int day, month, year;
            Console.Write("Введите день: ");
            day = int.Parse(Console.ReadLine());
            if (day <= 31 || day >=1)
            {
                Console.Write("Введите месяц: ");
                month = int.Parse(Console.ReadLine());
                if (month <= 12 || month >= 1)
                {
                    if (month == 4 || month == 6 || month == 9 || month == 11)
                    {
                        if (day == 31)
                        {
                            Console.WriteLine("Вы ввели неверную дату.");
                            Environment.Exit(0);

                        }
                    }
                    Console.Write("Введите год: ");
                    year = int.Parse(Console.ReadLine());
                    int remain = 0;
                    if (month==2 && (year % 4 == 0 && year % 100 != 0 || year % 400 == 0))
                    {
                        if (day>29)
                        {
                            Console.WriteLine("Вы ввели неверную дату.");
                            Environment.Exit(0);

                        }
                    }
                    else
                    if (month==2 && (year % 4 != 0 && year % 100 == 0 || year % 400 != 0))
                    {
                        if (day>28)
                        {
                            Console.WriteLine("Вы ввели неверную дату.");
                            Environment.Exit(0);
                        }
                    }
                    else
                    if (month==1)
                    {
                        remain= 31 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Январь.");
                        Console.WriteLine("Время года: Зима.");
                    }
                    if (month == 2)
                    {
                        if (year % 4 == 0 && year % 100 != 0 && year % 400 == 0)
                        {
                            remain = 29 - day;       
                        }
                        else
                        {
                            remain = 28 - day;
                        }
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Февраль.");
                        Console.WriteLine("Время года: Зима.");
                    }
                    if (month == 3)
                    {
                        remain = 31 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Март.");
                        Console.WriteLine("Время года: Весна.");
                    }
                    if (month == 4)
                    {
                        remain = 30 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Апрель.");
                        Console.WriteLine("Время года: Весна.");
                    }
                    if (month == 5)
                    {
                        remain = 31 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Май.");
                        Console.WriteLine("Время года: Весна.");
                    }
                    if (month == 6)
                    {
                        remain = 30 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Июнь.");
                        Console.WriteLine("Время года: Лето.");
                    }
                    if (month == 7)
                    {
                        remain = 31 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Июль.");
                        Console.WriteLine("Время года: Лето.");
                    }
                    if (month == 8)
                    {
                        remain = 31 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Август.");
                        Console.WriteLine("Время года: Лето.");
                    }
                    if (month == 9)
                    {
                        remain = 30 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Сентябрь.");
                        Console.WriteLine("Время года: Осень.");
                    }
                    if (month == 10)
                    {
                        remain = 31 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Октябрь.");
                        Console.WriteLine("Время года: Осень.");
                    }
                    if (month == 11)
                    {
                        remain = 30 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Ноябрь.");
                        Console.WriteLine("Время года: Осень.");
                    }
                    if (month == 12)
                    {
                        remain = 31 - day;
                        Console.WriteLine("До конца месяца: " + remain + " дней.");
                        Console.WriteLine("Название месяца: Декабрь.");
                        Console.WriteLine("Время года: Зима.");
                    }

                }
                else
                {
                    Console.WriteLine("Число не может превышать 12 или быть ниже 1.");
                }

            }
            else
            {
                Console.WriteLine("Число не может превышать 31 или быть ниже 1.");
            }

        }
    }
}
