using System;
using System.Collections.Generic;

namespace zadanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a=Console.ReadLine();
            List <int> p = KMP(a);
            //vector<int> p = KMP(a);
            for (int i = 0; i < p.Count; ++i)
                Console.WriteLine(p[i]);
            Console.WriteLine();
            
            
        }
        static List<int> KMP(string s)
        {
            int n = s.Length;
            List<int> pi = new List<int>(n);

            for (int i = 1; i < n; i++)
            {
                int j = pi[i - 1];
                while (j > 0 && s[i] != s[j])
                    j = pi[j - 1];
                if (s[i] == s[j])
                    j++;
                pi[i] = j;
            }
            return pi;
        }
    }
}
