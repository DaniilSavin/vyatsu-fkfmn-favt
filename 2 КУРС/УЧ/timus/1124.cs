using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Timus
{
    class Program
    {
        static void Main(string[] args)
        {
            int M, N, e = 0; // Количество ребер
            string []input = Console.ReadLine().Split(' ');
            M = int.Parse(input[0]);
            N = int.Parse(input[1]);

            List<bool> vis = new List<bool>();
            for (int i = 0; i <= M; i++)
                vis.Add(false);
            List<List<int>> adj = new List<List<int>>();
            for (int i = 0; i <= M; i++)
                adj.Add(new List<int>());


            for (int i = 1; i <= M; i++)
            {
                //adj[i].reserve(M);
                string[] allN = Console.ReadLine().Split(' ');
                for (int j = 1; j <= N; j++)
                {
                    int x = int.Parse(allN[j - 1]);
                    if (x != i)
                    {   // Добавьте ребро для каждого цвета не в своей коробке
                        e++;
                        adj[i].Add(x);
                    }
                }
            }

            int c = 0; // Количество связанных компонентов в графике
            List<int> stack = new List<int>();
            for (int i = 0; i < M*N; i++)
                stack.Add(0);
            int top = 0;
            for (int i = 1; i <= M; i++)
            {   // Простой dfs; подсчитайте количество подключенных компонентов
                if (!vis[i] && adj[i].Count != 0)
                {
                    c++;
                    stack[top++] = i;
                    while (top != 0)
                    {
                        int k = stack[--top];
                        vis[k] = true;
                        for (var it = 0; it < adj[k].Count; it++)
                        {
                            if (!vis[adj[k][it]])
                                stack[top++] = adj[k][it];
                        }
                    }
                }
            }

            int ans = e + Math.Max(0, c - 1);
            Console.WriteLine(ans);
        }
    }
}