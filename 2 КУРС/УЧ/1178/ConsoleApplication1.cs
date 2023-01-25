using System;

// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//


public class City
{
	public int id;
	public int x;
	public int y;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator <(const City& other) const
	public static bool operator < (City ImpliedObject, City other)
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

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: int dist() const
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