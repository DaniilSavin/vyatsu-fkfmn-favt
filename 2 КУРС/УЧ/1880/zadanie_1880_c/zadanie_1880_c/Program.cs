using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1880_c
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c ,count = 0;
            
            a = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            int []A = input.Select(int.Parse).ToArray();
            b = int.Parse(Console.ReadLine());
            input = Console.ReadLine().Split();
            int[] B = input.Select(int.Parse).ToArray();
            c = int.Parse(Console.ReadLine());
            input = Console.ReadLine().Split();
            int[] C = input.Select(int.Parse).ToArray();

            for (int i = 0; i < a; i++)
            {
                for (int k = 0; k < b; k++)
                {
                    if (A[i] == B[k])
                    {
                        for (int j = 0; j < c; j++)
                        {
                            if (B[k] == C[j])
                            {
                                count++;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
