using System;
using System.Collections.Generic;

public static class GlobalMembers
{
	// zadanie_1246.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
	//


	public static readonly double pi = 3.141592653589793238462643383279502884;

	public static List<point> v = new List<point>();

	public static double angle(int i)
	{
		point[] p = Arrays.InitializeWithDefaultInstances<point>(3);
		for (int j = 0; j < 3; j++)
		{
			p[j] = v[(v.Count + i - 1 + j) % v.Count];
		}
		double d1x = p[0].x - p[1].x;
		double d1y = p[0].y - p[1].y;
		double d2x = p[2].x - p[1].x;
		double d2y = p[2].y - p[1].y;
		double k = d1x * d2y - d2x * d1y;
		double ang = Math.Acos(((d1x * d2x) + (d1y * d2y)) / (Math.Sqrt((d1x * d1x + d1y * d1y) * (d2x * d2x + d2y * d2y))));
		return k < 0 ? 2 * pi - ang : ang;
	}

	static int Main()
	{
		int n;
		string tempVar = ConsoleInput.ScanfRead();
		if (tempVar != null)
		{
			n = int.Parse(tempVar);
		}
//C++ TO C# CONVERTER TODO TASK: There is no direct equivalent to the STL vector 'insert' method in C#:
		v.insert(v.GetEnumerator(), n, new point());
		for (int i = 0; i < n; i++)
		{
			string tempVar2 = ConsoleInput.ScanfRead();
			if (tempVar2 != null)
			{
				v[i].x = double.Parse(tempVar2);
			}
			string tempVar3 = ConsoleInput.ScanfRead(" ");
			if (tempVar3 != null)
			{
				v[i].y = double.Parse(tempVar3);
			}
		}
		double ang = 0.0;
		for (int i = 0; i < n; i++)
		{
			ang += angle(i);
		}
		if (Math.Abs((2 * pi * n - (n - 2) * pi) - ang) < Math.Abs((n - 2) * pi - ang))
		{
			Console.Write("ccw\n");
		}
		else
		{
			Console.Write("cw\n");
		}
		return 0;
	}

}