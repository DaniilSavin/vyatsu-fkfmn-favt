// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <stdio.h>
#include <vector>
#include <algorithm>
using namespace std;

struct City
{
public:
	int id;
	int x;
	int y;

	bool operator <(const City& other) const
	{
		if (x < other.x)
			return true;
		else
			if (x == other.x)
				return y < other.y;
			else
				return false;
	}

	int dist() const
	{
		return x * x + y * y;
	}

	void print()
	{
		cout << id << "(" << x << ", " << y << "): " << dist() << endl;
	}
};

int main()
{
	int count;
	cin >> count;
	std::vector<City> v(count);
	for (int i = 0; i < count; ++i)
	{
		int x, y;
		cin >> x >> y;
		v[i].id = i + 1;
		v[i].x = x;
		v[i].y = y;
	}
	sort(v.begin(), v.end());
	for (int i = 0; i < count / 2; ++i)
		cout << v[i * 2].id << ' ' << v[i * 2 + 1].id << endl;
}

