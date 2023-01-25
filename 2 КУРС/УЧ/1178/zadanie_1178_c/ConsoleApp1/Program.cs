using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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

		public class City
		{
			public int id;
			public int x;
			public int y;
			public static bool operator <(City ImpliedObject,
								 City other)
			{
				if (ImpliedObject.x < other.x)
				{
					return true;
				}
				else
				{
					if (ImpliedObject.x == other.x)
					{
						return ImpliedObject.y < other.y;
					}
					else
					{
						return false;
					}
				}
			}
			public int dist()
			{
				return x * x + y * y;
			}

			public void print()
			{
				Console.Write(id);
				Console.Write("(");
				Console.Write(x);
				Console.Write(", ");
				Console.Write(y);
				Console.Write("): ");
				Console.Write(dist());
				Console.Write("\n");
			}
		}

		static int Main(string[] args)
        {
			int count;
			count = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			List<City> v = new List<City>(count);
			for (int i = 0; i < count; ++i)
			{
				int x;
				int y;
				x = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
				v[i].id = i + 1;
				v[i].x = x;
				v[i].y = y;
			}
			v.Sort();
			for (int i = 0; i < count / 2; ++i)
			{
				Console.Write(v[i * 2].id);
				Console.Write(' ');
				Console.Write(v[i * 2 + 1].id);
				Console.Write("\n");
			}
			return 0;
		}
    }
}
