using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static long[] sr = new long[110];
        static long[] sc = new long[110];
        static long[,]ans = new long[110,110];
        static long n;

        static void Main(string[] args)
        {
            long i, j, a, b, m, ret;
            bool aans;
            aans = true;
            n = int.Parse(Console.ReadLine());

            string[] srStr = Console.ReadLine().Split(' ');
            for (i = 1; i <= n; i++)
            {
                sr[i] = int.Parse(srStr[i-1]);
            }
            for (i = 1; i <= n; i++)
            {
                if (sr[i] > n * 100) aans = false;
                sr[0] += sr[i];
            }

            string[] scStr = Console.ReadLine().Split(' ');
            for (i = 1; i <= n; i++)
            {
                sc[i] = int.Parse(scStr[i - 1]);
            }
            for (i = 1; i <= n; i++)
            {
                if (sc[i] > n * 100) aans = false;
                sc[0] += sc[i];
            }
            if (sc[0] != sr[0]) aans = false;

            if (aans)
            {
                for (i = 1; i <= n; i++)
                {
                    a = 0;
                    if (sr[i] == 0) continue;
                    if (check(0) < sr[i])
                    {
                        aans = false;
                        break;
                    }
                    b = 10010;
                    while (a + 1 != b)
                    {
                        m = (a + b) >> 1;
                        ret = check(m);
                        if (sr[i] <= ret)
                        {
                            a = m;
                        }
                        else
                        {
                            b = m;
                        }
                    }
                    ret = check(a);
                    for (j = 1; j <= n; j++)
                    {
                        if (sc[j] > a)
                        {
                            if ((sc[j] - a) > 100)
                            {
                                sc[j] -= 100;
                                ans[i,j] = 100;
                            }
                            else
                            {
                                ans[i,j] = (sc[j] - a);
                                sc[j] = a;
                            }
                        }
                    }
                    ret -= sr[i];
                    for (j = 1; ret > 0; j++)
                    {
                        if ((ans[i,j] > 0) && (sc[j] == a))
                        {
                            ans[i,j]--;
                            sc[j]++;
                            ret--;
                        }
                    }
                }

                if (aans)
                {
                    Console.WriteLine("YES");
                    for (i = 1; i <= n; i++)
                    {
                        for (j = 1; j < n; j++)
                        {
                            Console.WriteLine("{0} ", ans[i,j]);
                        }
                        Console.WriteLine("{0}\n", ans[i,j]);
                    }
                    return;
                }
            }
            Console.WriteLine("NO");
        }

        static long check(long d)
        {
            long i;
            long s;
            s = 0;
            for (i = 1; i <= n; i++)
            {
                if (sc[i] > d)
                {
                    if ((sc[i] - d) > 100)
                    {
                        s += 100;
                    }
                    else
                    {
                        s += (sc[i] - d);
                    }
                }
            }
            return s;
        }
    }
}
