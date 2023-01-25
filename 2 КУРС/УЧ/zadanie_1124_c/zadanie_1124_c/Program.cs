using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1124_c
{
    internal static class ConsoleInput
    {
        private static bool goodLastRead = false;
        public static bool LastReadWasGood
        {
            get
            {
                return goodLastRead;
            }
        }

        public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
        {
            string input = "";

            char nextChar;
            while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
            {
                //accumulate leading white space if skipLeadingWhiteSpace is false:
                if (!skipLeadingWhiteSpace)
                    input += nextChar;
            }
            //the first non white space character:
            input += nextChar;

            //accumulate characters until white space is reached:
            while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
            {
                input += nextChar;
            }

            goodLastRead = input.Length > 0;
            return input;
        }

        public static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
        {
            string input = "";

            char nextChar;
            if (unwantedSequence != null)
            {
                nextChar = '\0';
                for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
                {
                    if (char.IsWhiteSpace(unwantedSequence[charIndex]))
                    {
                        //ignore all subsequent white space:
                        while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
                        {
                        }
                    }
                    else
                    {
                        //ensure each character matches the expected character in the sequence:
                        nextChar = (char)System.Console.Read();
                        if (nextChar != unwantedSequence[charIndex])
                            return null;
                    }
                }

                input = nextChar.ToString();
                if (maxFieldLength == 1)
                    return input;
            }

            while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
            {
                input += nextChar;
                if (maxFieldLength == input.Length)
                    return input;
            }

            return input;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int M=0; // Количество ребер
            int N=0;
            int e = 0;
            string tempVar = ConsoleInput.ScanfRead();
            if (tempVar != null)
            {
                M = int.Parse(tempVar);
            }
            string tempVar2 = ConsoleInput.ScanfRead(" ");
            if (tempVar2 != null)
            {
                N = int.Parse(tempVar2);
            }
            List<bool> vis = new List<bool>(M + 1); // Метки посещенных узлов при выполнении dfs
            List<List<int>> adj = new List<List<int>>(M + 1); // матрица смежности

            for (int i = 1; i <= M; i++)
            {
                adj[i].Capacity = M;
                for (int j = 1; j <= N; j++)
                {
                    int x=0;
                    string tempVar3 = ConsoleInput.ScanfRead();
                    if (tempVar3 != null)
                    {
                        x = int.Parse(tempVar3);
                    }
                    if (x != i)
                    { // Добавьте ребро для каждого цвета не в своей коробке
                        e++;
                        adj[i].Add(x);
                    }
                }
            }

            int c = 0; // Количество связанных компонентов в графике
            List<int> stack = new List<int>(M * N);
            int top = 0;
            for (int i = 1; i <= M; i++)
            { // Простой dfs; подсчитайте количество подключенных компонентов
                if (!vis[i] && adj[i].Count > 0)
                {
                    c++;
                    stack[top++] = i;
                    while (top != 0)
                    {
                        int k = stack[--top];
                        vis[k] = true;
                        foreach (int it in adj[k])
                        {
                            if (!vis[it])
                            {
                                stack[top++] = it;
                            }
                        }
                    }
                }
            }

            int ans = e + Math.Max(0, c - 1);
            Console.Write("{0:D}\n", ans);
            
        }
    }
}
