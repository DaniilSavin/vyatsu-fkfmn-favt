using System;
using System.Collections.Generic;

public static class GlobalMembers
{
	static int Main()
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
	}


}