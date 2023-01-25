using System;

public static class GlobalMembers
{
	// zadanie_1313.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
	//

	static int Main()
	{
		int n;
		n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		int[][] x = RectangularArrays.RectangularIntArray(101, 101);
		for (int i = 1; i <= n; i++)
		{
			for (int j = 1; j <= n; j++)
			{
				x[i][j] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			}
		}
		int i1 = 0;
		for (int i = 1; i <= n; i++)
		{
			for (int j = 1; j <= i; j++)
			{
				Console.Write(xConsole.Write(x[i - i1][j]););
				Console.Write(" ");
				i1++;
			}
			i1 = 0;
		}
		int j1 = 2;
		int r = 2;
		for (int i = 1; i <= n - 1; i++)
		{
			for (int j = n; j > i; j--)
			{
				Console.Write(x[j][j1]);
				Console.Write(" ");
				j1++;
			}
			r++;
			j1 = r;
		}
	}
}