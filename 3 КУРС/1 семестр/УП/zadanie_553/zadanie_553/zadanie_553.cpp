// zadanie_553.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

//#include "pch.h"
#include <iostream>
#include <cstdio>
#include <vector>


int main()
{
	int n;
	std::cin >> n;
	std::vector<int> leftPar(1 + n);
	std::vector<int> rightPar(1 + n);
	for (int i = 1; i <= n; i++)
	{
		std::cin >> leftPar[i] >> rightPar[i];

	}
	std::vector<std::vector<int>>cost(1 + n, std::vector<int>(1 + n));
	for (int len = 1; len <= n; len++)
	{
		for (int left = 1; left + len - 1 <= n; left++)
		{
			int right = left + len - 1;
			if (len == 1)
			{
				cost[left][right] = 0;
			}
			else
			{
			 int min = 1000*1000*1000;
				for (int right1 = left; right1 < right; right1++)
				{
					int left2 = right1 + 1;
					min = std::min(min, cost[left][right1] + cost[left2][right]);
				}
				cost[left][right] = min + leftPar[left] * rightPar[right];
			}
		}
	}
	std::cout << cost[1][n];
	return 0;
}
