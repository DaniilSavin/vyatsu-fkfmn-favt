using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    class Program
    {
        static Random Rand = new Random();

        static int count = 0;
        static bool pp = false;
        static void create(int n, int m, int[,]a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = Rand.Next(-50, 150);
                }
            }
        }
        static void solve(int n, int m, int[,] a)
        {
            for (int j=0;j<m;j++)
            {
                for (int i=0;i<n;i++)
                {
                    int j1 = 0;
                    if (a[i, j1] < 0) count++;
                    j1++;
                    if (count > 2) break;
                }
                if (count == 2)
                {
                    pp = true;
                    Console.WriteLine("{0} столбец с 2 отрицательными элементами", j);
                    change(j, n, m, a);
                    
                }
                //Console.WriteLine();
                //print(n,m,a);
                //count = 0;
                break;
            }
        }
        static void change(int k, int n, int m, int[,] a)
        {
            for (int j =k;j<m-1;j++)
            {
                for (int i=0;i<n;i++)
                {
                    int t = a[i, j];
                    a[i, j] = a[i, j + 1];
                    a[i, j + 1] = t;
                }
            }
        }
        static void print(int n, int m, int[,] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ", a[i, j]+"\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива:");
            try
            {
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                if (n <= 0 || m <= 0) throw new Exception("InputError");
                int[,] a = new int[n, m];
                create(n, m, a);
                print(n, m, a);
                //Console.WriteLine();
                solve(n, m, a);
                Console.WriteLine();
                if (pp)
                {
                    Console.WriteLine("\nИтоговый массив :\n");
                    print(n, m, a);
                }
                else Console.WriteLine("В массиве нет столбцов с 2 отрицательными элементами");
            }
            catch
            {
                Console.WriteLine("Некорректный ввод исходных данных (только натуральное число)");
            }
            
            Console.ReadKey();
        }
    }
}
