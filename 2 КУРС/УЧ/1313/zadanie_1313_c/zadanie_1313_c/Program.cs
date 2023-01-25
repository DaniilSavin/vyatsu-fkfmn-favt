using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1313_c
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
    internal static class RectangularArrays
    {
        public static int[][] RectangularIntArray(int size1, int size2)
        {
            int[][] newArray = new int[size1][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new int[size2];
            }

            return newArray;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());

            //int[,] array = new int[n+1,n+1];
            int[][] array = RectangularArrays.RectangularIntArray(101, 101);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    array[i][j] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                }
            }
            int i1 = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                     Console.Write(array[i - i1][j] + " ");
                    i1++;
                }
                i1 = 0;
            }
            int j1 = 2, r = 2;
            for (int i = 1; i <= n - 1; i++)
            {
                for (int j = n; j > i; j--)
                {
                    Console.Write(array[j][j1]+" ");  
                    j1++;
                }
                r++;
                j1 = r;
            } 
        }
    }
}
