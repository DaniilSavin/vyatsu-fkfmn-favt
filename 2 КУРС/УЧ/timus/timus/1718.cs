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
            int c1 = 0, c2 = 0, n, j, i, in_, rs = 0, i1, i2;
            string[] rm = new string[10000];
            int[] s = new int[10000];
            string a;
            string b;

            n = int.Parse(Console.ReadLine());

            for (i = 0; i < n; i++)
            {
                string[] input = (Console.ReadLine()).Split(' ');
                a = input[0];
                b = input[1];
                i1 = i2 = 0;
                if (b[0] == 'A') i2 = 1;
                else if (b[0] == 'C') goto nxt;
                else
                {
                    if (b != "AC")
                    {
                        in_ = int.Parse(input[2]);
                    } else
                    {
                        in_ = 0;
                    }
                    if (in_ < 6) goto nxt;
                    else if (in_ == 6) i2 = 1;
                    else
                    {
                        i1 = 1;
                        i2 = 1;
                    }
                }
                for (j = 0; j < rs; j++) if (a == rm[j])
                    {
                        if (i1 == 1 && s[j] == 0)
                        {
                            s[j] = 1;
                            c1++;
                            goto nxt;
                        }
                        goto nxt;
                    }
                rm[rs] = a;
                s[rs] = i1;
                rs++;
            ok:
                c1 += i1;
                c2 += i2;
            nxt:;
            }

            Console.Write("{0} {1}", c1, c2);
        }
    }
}