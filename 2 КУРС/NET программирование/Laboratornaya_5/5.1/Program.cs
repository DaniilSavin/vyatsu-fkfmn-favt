using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace _5._1
{
    class Program
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static int SumDel(int x)
        {
            int res = 0;
            for (int i = 1; i <= x / 2; i++)
                if (x % i == 0) res += i;
            return res;
        }
        static bool IsAutomorphic(string temp, string temp_sqr)
        {
            for (int j = temp_sqr.Length - temp.Length, k = 0; j < temp_sqr.Length; ++j, ++k)
                if (temp_sqr[j] != temp[k])
                    return false;
            return true;
        }
        static int S1mple(int x)
        {
            double t = Math.Sqrt(x);
            for (int i=2; i<=t; i++)
            {
                if (x % i == 0) return 1;
                
            }
            return 0;
        }
        static double Func(int N, int Begin = 0)
        {
            if (Begin == 0)
            {
                return N / Math.Sqrt(Func(N, ++Begin));
            }
            else
            {
                return N == Begin ? N : Begin + Math.Sqrt(Func(N, ++Begin));
            }
        }
        private static void ShowAlphabet(int center, int offset, bool reverse)
        {
            if (offset * 2 >= alphabet.Length - center)
                reverse = true;
            if (reverse && offset + 1 == 0)
                return;
            else
            {
                Console.WriteLine(new string(' ', offset * 2) + String.Join(" ", alphabet.Skip(offset).Take(alphabet.Length - offset * 2).Select(s => s.ToString())));
                ShowAlphabet(center, reverse ? offset - 1 : offset + 1, reverse);
            }
        }
        static void Main(string[] args)
        {
            int caseswitch = 0;
            Console.WriteLine("Упражнение 5.1\n");
        menu:
            {
                Console.WriteLine("Меню:\nЗадание 1 - 1\nЗадание 2 - 2\nЗадание 3 - 3\nЗадание 4 - 4\nЗадание 5 - 5\nЗадание 6 - 6\nЗадание 7 - 7\nВыход - 8\n");
                try
                {
                    Console.Write("Введите число (1-8): ");
                    caseswitch = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error");
                    Environment.Exit(0);
                }
            }
            switch(caseswitch)
            {
                case 1:
                    int a;
                    Console.Write("Можно ли сложить несколько подряд идущих натуральных чисел.\nВведите А: ");
                    try
                    {
                        a = int.Parse(Console.ReadLine());

                        bool b = false;
                        for (int i = 1; i < a / 2; i++)
                        {
                            if (i + i + 1 + i + 2 == a)
                            {
                                Console.WriteLine("{0}+{1}+{2}={3}", i, i + 1, i + 2, a);
                                b = true;
                                break;
                            }
                        }
                        if (!b)
                        {
                            Console.WriteLine("Невозможно.");
                        }
                        Console.WriteLine("3 секунды и вы вернетесь в меню.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        goto menu;
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                        Console.WriteLine("3 секунды и вы вернетесь в меню.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        goto menu;
                    }
                 
                //////////////////////////////////////////////////////////////////
                case 2:
                    Console.WriteLine("Нахождение дружественных пар от 1 до A.");
                    Console.Write("Введите A: ");
                    try
                    {
                        int A = int.Parse(Console.ReadLine());
                        if (A >= 220)
                        {
                            int tmp = 1;
                            for (int i = 1; i <= A; i++)
                            {
                                if (SumDel(SumDel(i)) == i && SumDel(i) != i && tmp != i)
                                {
                                    Console.WriteLine(i + " and " + SumDel(i));
                                    tmp = SumDel(i);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Число должно быть больше 219.\n3 секунды и вы вернетесь в меню."); 
                            Thread.Sleep(3000);
                            Console.Clear();
                            goto menu;

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                        Console.WriteLine("3 секунды и вы вернетесь в меню.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        goto menu;
                    }
                    Console.WriteLine("3 секунды и вы вернетесь в меню.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto menu;

                ///////////////////////////////////////////////////////////////////
                case 3:
                    try
                    {
                        Console.Write("Поиск автоморфных чисел меньших А.\nВведите А:");
                        a = int.Parse(Console.ReadLine());                       
                        for (long i = 1; i <= a; ++i)
                        {
                            if (IsAutomorphic(i.ToString(), (i * i).ToString()))
                                Console.WriteLine("{0}  Automorphic  {1}", i, i * i);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                        Console.WriteLine("3 секунды и вы вернетесь в меню.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        goto menu;
                    }
                    Console.WriteLine("5 секунды и вы вернетесь в меню.");
                    Thread.Sleep(5000);
                    Console.Clear();
                    goto menu;
                ///////////////////////////////////////////////////////////////////
                case 4:
                    Console.WriteLine("еще не готово.");
                    Console.WriteLine("1 секунды и вы вернетесь в меню.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto menu;
                ///////////////////////////////////////////////////////////////////
                case 5:
                    Console.Write("Нахождение близнецов от A до A*A\nВведите A:");
                    try
                    {
                        Console.Write("Введите A: ");
                        a = int.Parse(Console.ReadLine());
                        for (int i = a; i < a * a; i = i + 2)
                        {
                            if (S1mple(i) == 1 && S1mple(i + 2) == 1)
                            {
                                Console.WriteLine(i + " " + (i + 2));
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                        Console.WriteLine("3 секунды и вы вернетесь в меню.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        goto menu;
                    }                  
                    Console.WriteLine("5 секунды и вы вернетесь в меню.");
                    Thread.Sleep(5000);
                    Console.Clear();
                    goto menu;
                    
                ///////////////////////////////////////////////////////////////////
                case 6:
                    try
                    {
                        Console.Write("Вычисление значения функции.\nВведите A: ");
                        a = int.Parse(Console.ReadLine());
                        Console.WriteLine("{0:#.######}", Func(a));
                    }
                    catch
                    {
                        Console.WriteLine("3 секунды и вы вернетесь в меню.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        goto menu;
                    }
                    Console.WriteLine("3 секунды и вы вернетесь в меню.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto menu;
                ///////////////////////////////////////////////////////////////////
                case 7:
                    int center = new Random().Next(1, 27);
                    Console.WriteLine("Символов в центре: {0}", center);
                    ShowAlphabet(center, 0, false);
                    Console.WriteLine("3 секунды и вы вернетесь в меню.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto menu;
                ///////////////////////////////////////////////////////////////////
                case 8:
                    Console.WriteLine("Завершение работы.");
                    Environment.Exit(0);
                    break;
                 default:
                    Console.WriteLine("Такого нет.");
                    Console.WriteLine("3 секунды и вы вернетесь в меню.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto menu;

            }
            Console.ReadKey();
        }
    }
}
