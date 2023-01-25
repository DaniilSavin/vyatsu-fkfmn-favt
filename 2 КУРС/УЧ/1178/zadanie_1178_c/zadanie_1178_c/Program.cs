using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1178_c
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
    public static class Node dum{int x, y, num;
};

    public static bool func(node i, node j)
    {
        if (i.y > j.y)
        {
            return true;
        }
        return false;
    }

    static int Main()
    {
        LinkedList<node> city = new LinkedList<node>();
        int n;
        n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
        for (int i = 0; i < n; i++)
        {
            dum.x = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            dum.y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            dum.num = (i + 1);
            city.AddLast(dum);
        }
        if (n == 0)
        {
            Console.Write("0");
            return 0;
        }
        city.Sort(func);
        for (int i = 0; i < n; i += 2)
        {
            Console.Write(city[i].num);
            Console.Write(" ");
            Console.Write(city[i + 1].num);
            Console.Write("\n");
        }
    }

}

