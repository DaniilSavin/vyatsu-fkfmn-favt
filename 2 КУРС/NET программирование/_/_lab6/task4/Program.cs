using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        const int n = 6;
        //static int m = int.Parse(Console.ReadLine());
        const int m = n;
        static int[,] a = new int[n, m];
        static int[,] b = new int[n, m];
        static void solve(int [,]a)
        {
            int k = 1;
            bool ch = false;
            int i = 0;
            int j = 0;
            while ((i <= n - 1) && (j <= n - 1))
            {
                if (ch)
                {
                    int rez = (Math.Abs(i) < Math.Abs(j - (n - 1))) ? Math.Abs(i) : Math.Abs(j - (n - 1));
                    for (int t = 0; t <= rez; t++)
                    {
                        a[i,j] = k;
                        k++;
                        if (t != rez)
                        {
                            i--;
                            j++;
                        }
                    }
                    if (j < n - 1)
                        j++;
                    else i++;
                    ch = false;
                }
                else
                {
                    int rez = (Math.Abs(i - (n - 1)) < Math.Abs(j)) ? Math.Abs(i - (n - 1)) : Math.Abs(j);
                    for (int t = 0; t <= rez; t++)
                    {
                        a[i,j] = k;
                        k++;
                        if (t != rez)
                        {
                            j--;
                            i++;
                        }
                    }
                    if (i < n - 1)
                        i++;
                    else j++;
                    ch = true;
                }
            }
        }
        static void change()
        {
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<m;j++)
                {
                    if (a[i,j]%2==0)
                    {
                        if (i == 0 && j == 0) b[i, j] = a[i + 1, j] + a[i, j + 1];
                        else if (i == 0 && j == m - 1) b[i, j] = a[i, j - 1] + a[i + 1, j];
                        else if (i == n - 1 && j == 0) b[i, j] = a[i - 1, j] + a[i, j + 1];
                        else if (i == n - 1 && j == m - 1) b[i, j] = a[i - 1, j] + a[i, j - 1];
                        else if (i == 0 && j != 0 && j != m - 1) b[i, j] = a[i, j - 1] + a[i, j + 1] + a[i + 1, j];
                        else if (j == 0 && i != 0 && i != n - 1) b[i, j] = a[i - 1, j] + a[i + 1, j] + a[i, j + 1];
                        else if (i == n - 1 && j != 0 && j != m - 1) b[i, j] = a[i, j - 1] + a[i, j + 1] + a[i - 1, j];
                        else if (j == m - 1 && i != 0 && i != n - 1) b[i, j] = a[i - 1, j] + a[i + 1, j] + a[i, j - 1];
                        else b[i, j] = a[i - 1, j] + a[i + 1, j] + a[i, j - 1] + a[i, j + 1];
                    }
                }
            }
        }
        static void print(int[,] a)
        {
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<m;j++)
                {
                    Console.Write("{0} ", a[i, j]+"\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            solve(a);
            print(a);
            Console.WriteLine();
            solve(b);
            change();
            print(b);
            Console.ReadKey();
        }
    }
}
