using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static double foot, metro;
        static int N;
        static point []F = new point[213];
        static double [,]gr = new double[213,213];
        static double []dp = new double[213];
        static bool []f = new bool[213];
        static int[]r = new int[213];

        static void Main(string[] args)
        {
            string[] input = (Console.ReadLine()).Split(' ');
            foot = double.Parse(input[0]);
            metro = double.Parse(input[1]);

            N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++) {
                input = (Console.ReadLine()).Split(' ');
                F[i].x = double.Parse(input[0]);
                F[i].y = double.Parse(input[1]);
            }
            int a, b;
            input = (Console.ReadLine()).Split(' ');
            a = int.Parse(input[0]);
            b = int.Parse(input[1]);

            while (a != 0 && b != 0)
            {
                gr[a,b] = GetRasst(F[a], F[b]) / metro;
                gr[b,a] = gr[a,b];
                input = (Console.ReadLine()).Split(' ');
                a = int.Parse(input[0]);
                b = int.Parse(input[1]);
            }

            input = (Console.ReadLine()).Split(' ');
            F[N + 1].x = double.Parse(input[0]);
            F[N + 1].y = double.Parse(input[1]);
            input = (Console.ReadLine()).Split(' ');
            F[N + 2].x = double.Parse(input[0]);
            F[N + 2].y = double.Parse(input[1]);

            N += 2;
            for (int i = 1; i <= N; i++)
                for (int j = 1; j <= N; j++)
                    if (gr[i,j] == 0 && i != j)
                    {
                        gr[i,j] = GetRasst(F[i], F[j]) / foot;
                        gr[j,i] = gr[i,j];
                    }

            Dijkstra();

            if (F[N].x != F[N - 1].x || F[N].y != F[N - 1].y)
            {
                Console.WriteLine("{0:#.#######}", dp[N]);
                List<int> rt = new List<int>();
                int G = N;
                while (r[G] != -1)
                {
                    if (r[G] != N && r[G] != N - 1)
                        rt.Add(r[G]); G = r[G];
                }
                Console.Write("{0} ", rt.Count);
                for (int i = rt.Count - 1; i >= 0; i--)
                    Console.Write("{0} ", rt[i]);
            }
            else
            {
                a = 0;
                Console.WriteLine(a);
                Console.WriteLine(0);
            }
        }

        static double GetRasst(point a, point b)
        {
            return Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
        }

        static void Dijkstra() //Алгори́тм Де́йкстры Находит кратчайшие пути от одной из вершин графа до всех остальных
        {
            int u = N - 1;
            r[u] = -1;
            for (int i = 1; i <= N; i++) { dp[i] = 1000000000; f[i] = true; }
            dp[u] = 0;
            for (int i = 1; i <= N; i++)
            {
                double mn = 1000000000;
                for (int j = 1; j <= N; j++)
                    if (dp[j] <= mn && f[j]) { u = j; mn = dp[j]; }
                for (int j = 1; j <= N; j++)
                    if (f[j])
                        if (dp[j] > dp[u] + gr[u,j])
                        {
                            r[j] = u;
                            dp[j] = dp[u] + gr[u,j];
                        }
                f[u] = false;
            }


        }
    }

    struct point
    {
        public double x;
        public double y;
    };
}
