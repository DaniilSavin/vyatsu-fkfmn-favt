﻿using System;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i <= n; i++)
            {
                int x = 0;
                int y = i;
                while(y>=0)
                {
                    Console.Write("{" + y + ";" + x + "} ");
                    x++;
                    y--;
                }
                Console.WriteLine();
            }
        }
    }
}
