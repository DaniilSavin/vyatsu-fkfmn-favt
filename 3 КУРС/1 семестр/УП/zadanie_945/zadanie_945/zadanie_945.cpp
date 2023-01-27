// zadanie_945.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <vector>
#include <algorithm>
#include <cassert>
int main()
{
	int n, q;
	std::cin >> n >> q;
	std::vector<long long> a(n);
	for (int i = 0; i < n; i++)
	{
		std::cin >> a[i];
		
	}
	for (int i = 0; i < q; i++)
	{
		long long x;
		std::cin >> x;
		if (i > 0)
		{
			std::cout << std::endl;
		}
		if (std::binary_search(a.begin(), a.end(), x))
		{
			std::cout << "YES";
		}
		else
		{
			std::cout << "NO";
		}
	}
	return 0;
}


