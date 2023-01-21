// zadanie_889.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

//#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <vector>
#include <algorithm>

struct Hor {
	int x, y;
};

int main()
{
	int start, n;
	std::cin >> start >> n;
	std::vector<Hor> h(n);
	for (int i = 0; i < n; i++)
	{
		std::cin >> h[i].x >> h[i].y;
	}
	std::sort(h.begin(), h.end(), [](const Hor &left, const Hor &right)
	{
		return left.y > right.y;
	});
	int cur = start;
	for (Hor hor : h)
	{
		if (hor.x == cur)
		{
			cur++;

		}
		else
		{
			if (hor.x + 1 == cur)
			{
				cur--;
			}
		}
		
	}
	std::cout << cur;
}


