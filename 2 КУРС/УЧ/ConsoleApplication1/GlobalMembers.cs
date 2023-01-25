using System;

public static class GlobalMembers
{
	// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
	//

	public static int[] a = new int[100001];
	public static int[] b = new int[100001];

	public static int max(int a, int b)
	{
		return a >= b ? a : b;
	}
	public static int min(int a, int b)
	{
		return a <= b ? a : b;
	}
	static int Main()
	{
		int bv = 0;
		int n;
		int m;
		int i;
		string tempVar = ConsoleInput.ScanfRead();
		if (tempVar != null)
		{
			n = int.Parse(tempVar);
		}
		string tempVar2 = ConsoleInput.ScanfRead();
		if (tempVar2 != null)
		{
			m = int.Parse(tempVar2);
		}
		for (i = 0; i < n; i++)
		{
			string tempVar3 = ConsoleInput.ScanfRead();
			if (tempVar3 != null)
			{
				a + i = tempVar3;
			}
		}
		for (i = 0; i < m; i++)
		{
			string tempVar4 = ConsoleInput.ScanfRead();
			if (tempVar4 != null)
			{
				b + i = tempVar4;
			}
		}
		bv = max(min(a[0], b[m - 1]), min(a[n - 1], b[0]));
		for (i = 1; i < n - 1; i++)
		{
			bv = max(bv, min(min(a[i], b[0]), b[m - 1]));
		}
		for (i = 1; i < m - 1; i++)
		{
			bv = max(bv, min(min(b[i], a[0]), a[n - 1]));
		}
		Console.Write("{0:D}\n", bv);
		return 0;
	}


}