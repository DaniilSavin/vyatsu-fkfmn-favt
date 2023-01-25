using System;

public static class GlobalMembers
{
	// zadanie_1826.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
	//



	static int Main()
	{
		int n;
		int[] v = new int[101];
		n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		for (int i = 0; i < n; i++)
		{
			v[i] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		}
		sort(v, v + n);
		if (n == 2)
		{
			Console.Write(v[1]);
			Console.Write("\n");
		}
		else
		{
			int ans = 0;
			int i;
			for (i = n - 1; i >= 4; i -= 2)
			{
				ans += Math.Min(v[0] * 2 + v[i - 1] + v[i], v[0] + v[1] * 2 + v[i]);
			}
			if (n % 2 == 1)
			{
				ans += v[0] + v[i - 1] + v[i];
			}
			else
			{
				ans += Math.Min(v[0] * 2 + v[1] + v[i - 1] + v[i], v[0] + v[1] * 3 + v[i]);
			}
			Console.Write(ans);
			Console.Write("\n");
		}
		return 0;
	}

}