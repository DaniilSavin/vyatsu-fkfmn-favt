using System;
using System.Collections.Generic;

public static class GlobalMembers
{
	public static node dum = new node();

	public static bool func(node i, node j)
	{
		if (i.y > j.y)
		{
			return true;
		}
		return false;
	}

	static int Main()
	{
		LinkedList<node> city = new LinkedList<node>();
		int n;
		n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		for (int i = 0; i < n; i++)
		{
			dum.x = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			dum.y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			dum.num = (i + 1);
			city.AddLast(dum);
		}
		if (n == 0)
		{
			Console.Write("0");
			return 0;
		}
//C++ TO C# CONVERTER TODO TASK: The 'Compare' parameter of std::sort produces a boolean value, while the .NET Comparison parameter produces a tri-state result:
//ORIGINAL LINE: sort(city.begin(), city.end(), func);
		city.Sort(func);
		for (int i = 0; i < n; i += 2)
		{
			Console.Write(city[i].num);
			Console.Write(" ");
			Console.Write(city[i + 1].num);
			Console.Write("\n");
		}
	}

}