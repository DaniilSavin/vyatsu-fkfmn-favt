using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_1718_c
{
    class Program
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
			public static char[][] RectangularCharArray(int size1, int size2)
			{
				char[][] newArray = new char[size1][];
				for (int array1 = 0; array1 < size1; array1++)
				{
					newArray[array1] = new char[size2];
				}

				return newArray;
			}
		}
		public static char[][] rm = RectangularArrays.RectangularCharArray(10000, 100);
		public static char[] s = { '0' };
		static void Main()
		{
			int c1 = 0;
			int c2 = 0;
			int n = 0 ;
			int j;
			int i;
			int @in=0;
			int rs = 0;
			int i1;
			int i2;
			char[] a=new char [100];
			char []b=new char [10];
			string tempVar = ConsoleInput.ScanfRead();
			if (tempVar != null)
			{
				n = int.Parse(tempVar);
			}
			for (i = 0; i < n; i++)
			{
				//string tempVar2 = ConsoleInput.ScanfRead();
				a[0] = Console.ReadKey().KeyChar;

				/*if (tempVar2 != null)
				{
					a = tempVar2[0];
				}*/
				//string tempVar3 = ConsoleInput.ScanfRead(" ");
				b[0]= Console.ReadKey().KeyChar;
				/*if (tempVar3 != null)
				{
					b = tempVar3[0];
				}*/
				i1 = i2 = 0;
				if (b[0] == 'A')
				{
					i2 = 1;
				}
				else if (b[0] == 'C')
				{
					goto nxt;
				}
				else
				{
					string tempVar4 = ConsoleInput.ScanfRead();
					if (tempVar4 != null)
					{
						@in = int.Parse(tempVar4);
					}
					if (@in < 6)
					{
						goto nxt;
					}
					else if (@in == 6)
					{
						i2 = 1;
					}
					else
					{
						i1 = 1;
						i2 = 1;
					}
				}
				

				for (j = 0; j < rs; j++)
				{
					string txt = new string(a);
					string txt2 = new string(rm[j]);
					if (string.Compare(txt, txt2) == 0)
					{
						if (i1 == 1 && s[j] == 0)
						{
							s[j] = '1';
							c1++;
							goto nxt;
						}
						goto nxt;
					}
				}
				rm[rs] = a;
				s[rs] = (char)i1;
				rs++;
			ok:
				c1 += i1;
				c2 += i2;
			nxt:
				;
			}
			Console.Write("{0:D} {1:D}\n", c1, c2);
		}
	}
}
