using System;

public static class GlobalMembers
{
	static int Main()
	{
		long n;
		long s;
		long k;
		long l;
		long r;
		string tempVar = ConsoleInput.ScanfRead();
		if (tempVar != null)
		{
			n = long.Parse(tempVar);
		}
		string tempVar2 = ConsoleInput.ScanfRead(" ");
		if (tempVar2 != null)
		{
			s = long.Parse(tempVar2);
		}
		string tempVar3 = ConsoleInput.ScanfRead(" ");
		if (tempVar3 != null)
		{
			k = long.Parse(tempVar3);
		}
		SegmentTree st = new SegmentTree((int)n);
		st.set < -1>(1, s, s - 1);
		st.set < 1>(s, n, 0);

		while ((k--) != 0)
		{
			string tempVar4 = ConsoleInput.ScanfRead();
			if (tempVar4 != null)
			{
				l = long.Parse(tempVar4);
			}
			string tempVar5 = ConsoleInput.ScanfRead(" ");
			if (tempVar5 != null)
			{
				r = long.Parse(tempVar5);
			}
			// Мы обновляем диапазон, как показано в заголовке комментария
			long a = l > 1 ? st.query((int)(l - 1)) : -1;
			long b = r < n ? st.query((int)(r + 1)) : -1;
			long t = (b - a + l + r) / 2;
			if (l > 1 && r < n)
			{
				st.set < 1>(l - 1, t, a);
				st.set < -1>(t, r + 1, a + t - l + 1);
			}
			else if (l == 1)
			{
				st.set < -1>(l, r, r + 1 - l + b);
			}
			else if (r == n)
			{
				st.set < 1>(l, r, a + 1);
			}
		}
		long min = long.MaxValue;
		for (int i = 1; i <= n; i++)
		{
			min = Math.Min(min, st.query(i));
		}
		Console.Write("{0:D}", min);
	}

}