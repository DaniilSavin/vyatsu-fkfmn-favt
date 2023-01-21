using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._11
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age = 0;
            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            age = int.Parse(Console.ReadLine());
            int caseSwitch = 0;
            
           Console.WriteLine("Месяцев - 1 \nЛет - 2");
           caseSwitch = int.Parse(Console.ReadLine());
            string agecat = "";
            string month = "";
            string year = "";
            switch (caseSwitch)
            {
                case 1:
                    agecat = " младенец.";
                    if (age == 1)
                    {
                        month = " месяц.";
                    }
                    else
                    if (age > 1 && age < 5)
                    {
                        month = " месяца.";
                    }
                    else
                    if (age > 4)
                    {
                        month = " месяцев.";
                    }
                    Console.WriteLine(name + " -" + agecat + " Ему " + age + month);
                    break;

                case 2:
                    if (age > 1 && age < 5)
                    {
                        agecat = " ребенок.";
                        year = " года.";
                    }
                    else
                    if (age > 4 && age < 12)
                    {
                        agecat = " ребенок.";
                        year = " лет.";
                    }
                    if (age > 11 && age < 16)
                    {
                        agecat = " подросток.";
                        year = " лет.";
                    }
                    else
                    if (age > 15 && age < 21 || age == 25)
                    {
                        agecat = " юноша.";
                        year = " лет.";
                    }
                    else
                    if (age > 20 && age < 26 && age != 25)
                    {
                        agecat = " юноша.";
                        year = " год.";
                    }
                    else
                    {
                        if ((age > 25 && age < 70) && (age % 10 != 1 && age % 10 != 2 && age % 10 != 3 && age % 10 != 4))
                        {
                            agecat = " мужчина.";
                            year = " лет.";
                        }
                        else
                        {
                            if (age<70)
                            agecat = " мужчина.";
                            year = " год.";
                        }
                        if ((age > 25 && age < 70) && age %10 !=1)
                        {
                            agecat = " мужчина.";
                            year = " года.";
                        }
                        else
                        {
                            if ((age > 69 && age < 99) && (age % 10 != 1 && age % 10 != 2 && age % 10 != 3 && age % 10 != 4))
                            {
                                //Console.WriteLine(name + " - старик. Ему " + age + " лет.");
                                agecat = " старик.";
                                year = " лет.";
                            }
                            else
                            if (age > 69 && age < 99)
                            {
                                //Console.WriteLine(name + " - старик. Ему " + age + " года.");
                                agecat = " старик.";
                                year = " лет.";
                            }
                            if (age > 99 &&  (age/10 % 10 > 1))
                            {
                                // Console.WriteLine(name + " - долгожитель. Ему " + age + " лет.");
                                agecat = " долгожитель.";
                                year = " лет.";
                            }
                            else
                            {
                                if (age > 100 && (age/10 % 10 > 1 && age/10 % 10 != 9))
                                {
                                    //Console.WriteLine(name + " - долгожитель. Ему " + age + " года.");
                                    agecat = " долгожитель.";
                                    year = " года.";
                                }
                                else
                                {
                                    //Console.WriteLine(name + " - долгожитель. Ему " + age + " лет.");
                                    agecat = " долгожитель.";
                                    year = " год.";
                                }
                            }
                        }
                    }
                    Console.WriteLine(name + " -" + agecat + " Ему " + age + year);
                    break;

            }
        }
    }
}
