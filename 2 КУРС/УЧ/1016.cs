using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static byte[] A = { 14, 11, 20, 17, 12, 19, 22, 9, 13, 7, 21, 1,
                4, 8, 0, 16, 15, 3, 23, 5, 2, 10, 6, 18 };

        private static int[,,] min = new int[8, 8, 4 * 6]; // Minimum cost to each configuration of the cube

        private static int[,,] P = new int[8, 8, 4 * 6]; // Parent graph
        private static int[] cube = new int[6]; // The numbers written on the cube
        private static int[] opp = { 1, 0, 4, 5, 2, 3 }; // Opposite side of each face
        private static (int first, int second)[] dir = { (1, 0), (0, 1), (-1, 0), (0, -1) };

        // The result of rotating the given orientation of the die d*90 degrees. The orientation is
        // expressed as the edge facing east
        private static int rotate(int i, int d)
        {
            int f = i / 4, s = i % 4;
            return f * 4 + (s + d) % 4;
        }

        // The new orientation resulting from moving the die with the given orientation in the given
        // direction. The direction is 0 towards the east, 1 to the north, etc
        private static int move(int i, int d)
        {
            if (d == 0)
                return A[rotate(i, 2)];
            else if (d == 1)
                return rotate(A[rotate(i, 3)], 3);
            else if (d == 2)
                return rotate(A[i], 2);
            return rotate(A[rotate(i, 1)], 1);
        }

        // Does a depth-first search of all configurations of the die from position (x, y) with orientation
        // s and initial value val
        private static bool dfs(int s, int x, int y, int val)
        {
            if (val + cube[opp[s / 4]] >= min[x, y, s])
                return false; // Optimal already reached, make sure we don't update the predecessor matrix
            min[x, y, s] = val + cube[opp[s / 4]];
            for (int i = 0; i < 4; i++)
            {
                int dx = dir[i].first, dy = dir[i].second;
                if (x + dx < 0 || x + dx > 7 || y + dy < 0 || y + dy > 7)
                    continue;
                if (dfs(move(s, i), x + dx, y + dy, min[x, y, s]))
                    P[x + dx, y + dy, move(s, i)] = 1 + (i + 2) % 4; // New optimal in that direction, update P
            }
            return true;
        }

        private static void Memset(int[,,] min, int value)
        {
            for (int z = 0; z < min.GetLength(0); ++z)
            {
                for (int y = 0; y < min.GetLength(1); ++y)
                {
                    for (int x = 0; x < min.GetLength(2); ++x)
                    {
                        min[z, y, x] = value;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            Memset(min, 0x7f);
            var input = Console.ReadLine().Split(' ');
            (string s, string e) = (input[0], input[1]);
            cube = input.Skip(2).Select(i => int.Parse(i)).ToArray();
            int sx = s[0] - 'a', sy = s[1] - '1';
            int ex = e[0] - 'a', ey = e[1] - '1';
            dfs(8, sx, sy, 0); // Die starts with top edge number 8 facing east.
            int ans = int.MaxValue;
            int anss = 0;
            for (int i = 0; i < 24; i++)
            {
                if (min[ex, ey, i] < ans)
                {
                    ans = min[ex, ey, i];
                    anss = i;
                }
            }
            Console.Write($"{ans} ");

            // Print out the optimal path
            List<(int first, int second)> v = new List<(int, int)>
            {
                (ex, ey)
            };
            while (P[ex, ey, anss] > 0)
            {
                var d = P[ex, ey, anss];
                ex += dir[d - 1].first;
                ey += dir[d - 1].second;
                anss = move(anss, d - 1);
                v.Add((ex, ey));
            }
            v.Reverse();
            foreach (var it in v)
                Console.Write($"{(char)(it.first + 'a')}{it.second + 1} ");
        }
    }
}