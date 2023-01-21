using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7new
{
    class Program
    {
        static Random Rand = new Random();
        static int n, m;
        static void print(int[,] a) 
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ",a[i, j]+"\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int check = 0;
            int n1=n, m1=m;
            while (check == 0)
            {
                try
                {
                    Console.WriteLine("Введите количество строк в массиве");
                    string s = Console.ReadLine();
                    n = int.Parse(s);
                    n1 = n;
                    if (n < 1 || n % 1 != 0 || (s.Length != 1 && s[0] == '0'))
                        Console.WriteLine("Некорректный ввод \n");
                    else
                        check = 1;
                }
                catch
                {
                    check = 0;
                    Console.WriteLine("Некорректный ввод\n");
                }
            }
            check = 0; 
            while (check == 0)
            {
                try
                {
                    
                    Console.WriteLine("Введите количество столбцов в массиве");
                    string s = Console.ReadLine();
                    m = int.Parse(s);
                    m1 = m;
                    if (m < 1 || m % 1 != 0 || (s.Length != 1 && s[0] == '0'))
                        Console.WriteLine("Некорректный ввод \n");
                    else
                        check = 1;
                }
                catch
                {
                    check = 0;
                    Console.WriteLine("Некорректный ввод\n");
                }
            }
            int nm = (int)m;
            int nn = (int)n;
            int[,] a = new int[nn, nm];
            for (int i = 0; i < n; i++) 
                for (int j = 0; j < m; j++)
                    a[i, j] = Rand.Next(-50, 150);
            Console.WriteLine();
            print(a);

            int minimum = Int32.MaxValue, minn = 0, minm = 0;

            for (int i = 0; i < n; i++) 
                for (int j = 0; j < m; j++)
                    if (a[i, j] < minimum)
                    {
                        minimum = a[i, j];
                        minn = i;
                        minm = j;
                    }
            Console.WriteLine("[{0}][{1}]-минимальный элемент и равен {2}", minm, minn, minimum);
            m--; n--;
            int[,] b = new int[nn - 1, nm - 1];

            for (int i = 0; i < nn; i++) 
                for (int j = 0; j < nm; j++)
                {
                    if (i < minn)
                    {
                        if (j < minm) b[i, j] = a[i, j];
                        if (j > minm) b[i, j - 1] = a[i, j];
                    }
                    else
                    if (i != minn)
                    {
                        if (j < minm) b[i - 1, j] = a[i, j];
                        if (j > minm) b[i - 1, j - 1] = a[i, j];
                    }
                }
            print(a);
            if ((nm - 1) % 2 == 0 && (nn - 1) % 2 == 0) 
            {
                m++; n++;
                int[,] c = new int[nn, nm];
                int midn = (nn - 1) / 2;
                int midm = (nm - 1) / 2;

                for (int i = 0; i < nn; i++) 
                    for (int j = 0; j < nm; j++)
                    {
                        if (i < midn)
                        {
                            if (j < midm) c[i, j] = b[i, j];
                            if (j == midm) c[i, j] = 0;
                            if (j > midm) c[i, j] = b[i, j - 1];
                        }
                        if (i == midn) c[i, j] = 0;
                        if (i > midn)
                        {
                            if (j < midm) c[i, j] = b[i - 1, j];
                            if (j == midm) c[i, j] = 0;
                            if (j > midm) c[i, j] = b[i - 1, j - 1];
                        }

                    }
               
                Console.WriteLine("\nИтоговый массив :\n");
                bool pp = false;
                if ((int)n1 % 2 != 0 || (int)m1 % 2 != 0 || (n1 % 2 != 0 && m1 % 2 != 0))
                {
                    Console.WriteLine("Есть возможность заполнить пересечение нулями");
                    pp = true;
                }
                if (!pp) Console.WriteLine("Нет возможности заполнить пересечение нулями");
                print(c);
            }
            else
            {
                Console.WriteLine("\nИтоговый массив :\n");
                bool pp = false;
                if ((int)n1 % 2 != 0 || (int)m1 % 2 != 0 || (n1 % 2 != 0 && m1 % 2 != 0))
                {
                    Console.WriteLine("Есть возможность заполнить пересечение нулями");
                    pp = true;
                }
                if (!pp) Console.WriteLine("Нет возможности заполнить пересечение нулями");
                print(b);
            }
            Console.ReadKey();
        }
    }
}

