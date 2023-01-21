using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static int check = 0;
        static int correct = 0;
        static void printAlphabet(int step, int mid,int cur)
        {
            int check = 0;
            if (cur == mid) return;
            for (char i = 'A', j = 'Z'; i <= j; i++)
            {
                check++;
                if (check >= step && check <= 27 - step)
                    Console.Write(i + " ");
                else Console.Write("  ");
            }
    
            Console.WriteLine();
            if (mid % 2 == 0)
            {
                if (cur < (mid / 2) - 1) step++; // две строчки в центре одинаковые ( i = mid/2)
                else step--;
            }
            else
            if (cur <= (mid / 2) - 1) step++; // нет одинаковых строчек
            else step--;
            cur++;
            printAlphabet(step, mid, cur);


        }
        

        static int NextA(int n) 
        {
            return n * n;
        }

        static int Digits(int n) 
        {
            int ch = 0;
            while (n != 0)
            {
                ch++;
                n /= 10;
            }
            return ch;
        }
        static int GetDigitK(int x, int k) 
        {
            int ch = 0;
            ch = x;
            while (Digits(ch) != k)
            {
                ch /= 10;
            }
            return ch % 10;
        }
     
        static void rec()
        {
            {
                int ch = 0;
                try
                {
                    Console.Write("Введите число k : ");
                    ch = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод\n");
                    rec();
                }

                if (ch < 1)
                {
                    Console.WriteLine("Введите k > 0\n");
                    rec();
                }
                int i = 1;
                int s = ch;
                while (i <= s)
                {
                    int x = NextA(i);
                    if (ch - Digits(x) == 0)
                    {
                        Console.WriteLine("{0} - Искомый элемент последовательности\n", GetDigitK(x, Digits(x)));
                        break;
                    }
                    else if (ch - Digits(x) < 0)
                    {
                        Console.WriteLine("{0} - Искомый элемент последовательности\n", GetDigitK(x, ch));
                        break;
                    }
                    else
                        ch -= Digits(x);
                    i++;
                }
            }
        }
        static void menu()
        {
            Console.WriteLine("Choose a task:");
            Console.WriteLine("1 - Подряд идущие числа");
            Console.WriteLine("2 - Дружественные числа");
            Console.WriteLine("3 - Автоморфные числа");
            Console.WriteLine("4 - k-я цифра последовательности");
            Console.WriteLine("5 - Близнецы");
            Console.WriteLine("6 - Формула через рекурсию");
            Console.WriteLine("7 - Латинский алфавит");
            Console.WriteLine("8 - Закрытие приложения");
        }
        static void sumFunc1(int sum, int i, int ch, string s)
        {
            if (sum < ch)
            {
                if (s == "") s = Convert.ToString(i);
                else s += "+" + Convert.ToString(i);
                int j = i + 1;
                sumFunc1(sum + i, j, ch, s);
            }
            if (sum == ch)
            {
                check++;
                if (check == 1) Console.Write("{0}={1}\n", s, ch);
            }

        }
        private static char Alphabet1(int mid, char c1, char c2)
        {
            bool pp1 = true;
            bool pp2 = true;
            for (char i = c1; i <= c2; i++)
            {
                Console.Write("{0} ", i);
            }
            pp1 = false;
            Console.WriteLine();
            if (!pp1) Console.Write("  ");
            //Console.Write("  ");
            if ((int)c2 - (int)c1 > mid)
            {
                return Alphabet1(mid, (char)((int)c1 + 1), (char)((int)c2 - 1));
                
            }
            mid = 26;
            if (c1!='A' && c2!='Z') return Alphabet1(mid, (char)((int)c1 - 1), (char)((int)c2 + 1));
            return ' ';

        }
       
        static long sumFunc2(long n)
        {
            long sum = 1, first = 2, d = 1, rez = n & 1;
            if (rez>0)
            {
                d = 2;
                first = 3;
            }
            for (long i=first;i*i<n;i+=d)
            {
                if (n % i == 0) sum += (i + n / i);
                if (i * i == n) sum += i;
            }
            return sum;
        }
        static bool isAmrph(string s1, string s2)
        {
            int k = 0;
            for (int i=s2.Length-s1.Length;i<s2.Length;i++)
            {
                if (s2[i] != s1[k]) return false;
                k++;
            }
            return true;
        }
        static bool isSimple(int ch)
        {
            int count = 0;
            for (int i=1;i<=ch;i++)
            {
                if (ch % i == 0) count++;
            }
            if (count == 2) return true;
            else return false;
        }
        static double func(int ch)
        {
            if (ch == 0) return 0;
            else
            {
                ch--;
                return Math.Sqrt(2 + func(ch));
            }
        }
        static void Main(string[] args)
        {
            menu();
            int c = int.Parse(Console.ReadLine());
            try
            {
                if (c > 0 && c <= 8)
                {
                    while (c != 8)
                    {
                        if (c == 1)
                        {
                            Console.Write("Введите ch:");
                            int ch = int.Parse(Console.ReadLine());
                            try
                            {
                                if (ch > 0 && ch % 1 == 0)
                                {
                                    for (int i = 1; i < ch / 2 + 1; i++)
                                    {
                                        sumFunc1(0, i, ch, "");
                                    }
                                    //Console.ReadKey();
                                }
                                else throw new Exception("Error");
                            }
                            catch
                            {
                                Console.WriteLine("Некорректный ввод входных данных");
                                //Console.WriteLine("Введите номер задания:");
                                c = int.Parse(Console.ReadLine());
                            }
                        }
                        if (c == 2)
                        {
                            Console.Write("Введите ch:");
                            int ch = int.Parse(Console.ReadLine());
                            try
                            {
                                if (ch > 0 && ch % 1 == 0)
                                {
                                    long n = ch, k = 0;
                                    //Console.Write("Введите n:");
                                    //n = int.Parse(Console.ReadLine());
                                    long[] a = new long[n];
                                    for (int i = 0; i < n; i++) a[i] = sumFunc2(i+1);
                                    for (int i = 0; i < n; i++)
                                    {
                                        if (a[i] >= 1 && a[i] <= n && a[a[i] - 1] == i + 1 && i + 1 < a[i])
                                        {
                                            Console.WriteLine(i + 1 + " " + a[i]);
                                            k++;
                                        }
                                    }
                                    if (k == 0) Console.WriteLine("Нет таких чисел");
                                    //Console.ReadKey();
                                }
                                else throw new Exception("Error");
                            }
                            catch
                            {
                                Console.WriteLine("Некорректный ввод входных данных");
                                //Console.WriteLine("Введите номер задания:");
                                c = int.Parse(Console.ReadLine());
                            }
                        }
                        if (c == 3)
                        {
                            Console.Write("Введите ch:");
                            int ch = int.Parse(Console.ReadLine());
                            try
                            {
                                if (ch > 0 && ch % 1 == 0)
                                {
                                    string s1 = " ", s2 = " ";
                                    for (long i = 1; i < ch; i++)
                                    {
                                        if (isAmrph(i.ToString(), (i * i).ToString())) Console.WriteLine("{0} and {1}", i, i * i);
                                    }
                                    //Console.ReadKey();
                                }
                                else throw new Exception("Error");
                            }
                            catch
                            {
                                Console.WriteLine("Некорректный ввод входных данных");
                                //Console.WriteLine("Нажмите Enter:");
                                c = int.Parse(Console.ReadLine());
                            }
                        }
                        if (c == 4) 
                        {
                            rec();
                        }
                        if (c == 5)
                        {
                            Console.Write("Введите ch:");
                            int ch = int.Parse(Console.ReadLine());
                            bool pp1=false,pp2=false;
                            try
                            {
                                if (ch > 0 && ch % 1 == 0)
                                {
                                    int count = 0;
                                    int k=ch;
                                    if (ch % 2 != 0) k = ch;
                                    else k = ch + 1;
                                    if (isSimple(k)) pp1 = true;

                         
                                    for (int i = k; i <= 2 * ch-2; i+=2)
                                    {
                                       
                                       
                                        if (isSimple(i+2)) pp2 = true;
                                        else pp2 = false;
                                        if (pp1 && pp2)
                                        {
                                            Console.WriteLine(i.ToString() + ' ' + (i + 2).ToString());
                                            count++;
                                           
                                        }
                                        pp1 = pp2;
                                    }
                                    if (count == 0) Console.WriteLine("Таких чисел нет");
                                }
                                else throw new Exception("Error");
                            }
                            catch
                            {
                                Console.WriteLine("Некорректный ввод входных данных");
                                //Console.WriteLine("Введите номер задания:");
                                c = int.Parse(Console.ReadLine());
                            }
                        }
                        if (c == 6)
                        {
                            Console.Write("Введите ch:");
                            int ch = int.Parse(Console.ReadLine());
                            try
                            {
                                if (ch > 0 && ch % 1 == 0)
                                {
                                    double rez = ch / func(ch);
                                    Console.WriteLine("Результат:" + rez.ToString());
                                    //Console.ReadKey();
                                }
                                else throw new Exception("Error");
                            }
                            catch
                            {
                                Console.WriteLine("Некорректный ввод входных данных");
                                //Console.WriteLine("Введите номер задания:");
                                c = int.Parse(Console.ReadLine());
                            }
                        }
                        if (c == 7)
                        {
                            int mid = new Random().Next(1, 27);
                            printAlphabet(1, mid, 0);
                            Console.WriteLine();
                        }
                        menu();
                        c = int.Parse(Console.ReadLine());
                    }
                    if (c == 8) Environment.Exit(0);
                }
                else throw new Exception("Error");
            }
            catch
            {
                Console.WriteLine("Некорректный ввод номера задания");
                Console.WriteLine("Введите номер задания:");
                menu();
                c = int.Parse(Console.ReadLine());
            }
        }
    }
}
