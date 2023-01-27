using System;
using System.Collections.Generic;
using System.Text;

namespace Rand
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = unchecked((int)0x9e3779b9); // check out >>> in C#
            //Console.WriteLine("{0:X8}, {1:X8}", n, (uint)n >> 4);

            //jRand.jRand.jmain();
            //Console.WriteLine("---------------------------------");

            int[] seed = new int[256];
            int[] jseed = new int[256];
            Rand x = new Rand(seed);
            jRand.jRand xj = new jRand.jRand(jseed);

            for (int i = 0; i < 2; ++i)
            {
                x.Isaac();
                xj.Isaac();
                for (int j = 0; j < Rand.SIZE; ++j)
                {
                    //String z = Integer.toHexString(x.rsl[j]);
                    //while (z.length() < 8) z = "0"+z;
                    System.Diagnostics.Debug.Assert(x.rsl[j] == xj.rsl[j]);
                    Console.Write("{0:x8}", x.rsl[j]);
                    if ((j & 7) == 7) Console.WriteLine("");
                }
            }
            Console.Write("Press the enter key to end this program");
            Console.ReadLine();
        }
    }
}
