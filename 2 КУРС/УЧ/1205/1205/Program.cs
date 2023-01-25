using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1205
{
    class Program
    {
        internal static class RectangularArrays
        {
            public static double[][] RectangularDoubleArray(int size1, int size2)
            {
                double[][] newArray = new double[size1][];
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new double[size2];
                }

                return newArray;
            }
        }
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
        internal static class Arrays
        {
            public static T[] InitializeWithDefaultInstances<T>(int length) where T : new()
            {
                T[] array = new T[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = new T();
                }
                return array;
            }

            public static void DeleteArray<T>(T[] array) where T : System.IDisposable
            {
                foreach (T element in array)
                {
                    if (element != null)
                        element.Dispose();
                }
            }
        }
       
        public static double foot;
        public static double metro;
        public static int N;
        public static int[] F = Arrays.InitializeWithDefaultInstances<int>(213);
        public static double[][] gr = RectangularArrays.RectangularDoubleArray(213, 213);
        public static double[] dp = new double[213];
        public static bool[] f = new bool[213];
        public static int[] r = new int[213];

        public static double GetRasst(int a, int b)
        {
            return Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
        }
        public static void Dijkstra() //Алгори́тм Де́йкстры Находит кратчайшие пути от одной из вершин графа до всех остальных
        {
            //C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
            //memset(r, 0, sizeof(int));
            int u = N - 1;
            r[u] = -1;
            for (int i = 1; i <= N; i++)
            {
                dp[i] = 1000000000;
                f[i] = true;
            }
            dp[u] = 0;
            for (int i = 1; i <= N; i++)
            {
                double mn = 1000000000;
                for (int j = 1; j <= N; j++)
                {
                    if (dp[j] <= mn && f[j])
                    {
                        u = j;
                        mn = dp[j];
                    }
                }
                for (int j = 1; j <= N; j++)
                {
                    if (f[j])
                    {
                        if (dp[j] > dp[u] + gr[u][j])
                        {
                            r[j] = u;
                            dp[j] = dp[u] + gr[u][j];
                        }
                    }
                }
                f[u] = false;
            }


        }
        static int Main(string[] args)
        {
            {
                //C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
                //memset(gr, 0, sizeof(double));
                foot = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                metro = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                N = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                for (int i = 1; i <= N; i++)
                {
                    F[i].x = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                    F[i].y = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                }
                int a;
                int b;
                a = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                b = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                while (a != 0 && b != 0)
                {
                    gr[a][b] = GetRasst(F[a], F[b]) / metro;
                    gr[b][a] = gr[a][b];
                    a = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                    b = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                }
                F[N + 1].x = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                F[N + 1].y = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                F[N + 2].x = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                F[N + 2].y = double.Parse(ConsoleInput.ReadToWhiteSpace(true));
                N += 2;
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        if (gr[i][j] == 0 && i != j)
                        {
                            gr[i][j] = GetRasst(F[i], F[j]) / foot;
                            gr[j][i] = gr[i][j];
                        }
                    }
                }
                Dijkstra();
                if (F[N].x != F[N - 1].x || F[N].y != F[N - 1].y)
                {
                    Console.Write("{0:7}", dp[N]);
                    Console.Write("{0:7}", "\n");
                    List<int> rt = new List<int>();
                    int G = N;
                    while (r[G] != -1)
                    {
                        if (r[G] != N && r[G] != N - 1)
                        {
                            rt.Add(r[G]);
                        }
                        G = r[G];
                    }
                    Console.Write("{0:7}", rt.Count);
                    Console.Write("{0:7}", ' ');
                    for (int i = rt.Count - 1; i >= 0; i--)
                    {
                        Console.Write("{0:7}", rt[i]);
                        Console.Write("{0:7}", ' ');
                    }
                }
                else
                {
                    a = 0;
                    Console.Write("{0:7}", a);
                    Console.Write("{0:7}", "\n");
                    Console.Write("{0:7}", 0);
                }
                return 0;
            }
        }
    }
}
