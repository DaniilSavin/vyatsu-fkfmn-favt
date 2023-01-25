using System;

public static class GlobalMembers
{
	// zadanie_1718.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
	//

	public static char[][] rm = RectangularArrays.RectangularCharArray(10000, 100);
	public static char[] s = {0};
	static int Main()
	{
		int c1 = 0;
		int c2 = 0;
		int n;
		int j;
		int i;
		int @in;
		int rs = 0;
		int i1;
		int i2;
		string a = new string(new char[100]);
		string b = new string(new char[10]);
		string tempVar = ConsoleInput.ScanfRead();
		if (tempVar != null)
		{
			n = int.Parse(tempVar);
		}
		for (i = 0; i < n; i++)
		{
			string tempVar2 = ConsoleInput.ScanfRead();
			if (tempVar2 != null)
			{
				a = tempVar2[0];
			}
			string tempVar3 = ConsoleInput.ScanfRead(" ");
			if (tempVar3 != null)
			{
				b = tempVar3[0];
			}
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
				if (string.Compare(a, rm[j]) == 0)
				{
				if (i1 == 1 && s[j] == 0)
				{
					s[j] = 1;
					c1++;
					goto nxt;
				}
				goto nxt;
				}
			}
			rm[rs] = a;
			s[rs] = i1;
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