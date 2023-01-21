// zadanie_273.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <vector>
#include <string>
#include <cstdio>

int main()
{
	char buffer[101 + 1];
	std::cin >> buffer;
	std::string s(buffer);
	std::vector<bool> was(1000, false);
	for (int i = 0; i < (int)s.size(); i++)
	{
		for (int j = i + 1; j < (int)s.size(); j++)
		{
			for (int k = j + 1; k < (int)s.size(); k++)
			{
				was[(s[i] - '0') * 100 + (s[j] - '0') * 10 + (s[k] - '0')] = true;
			}
 		}

	}
	int count = 0;
	for (int i = 100; i <= 999; i++)
	{
		if (was[i])
		{
			count++;
		}
 	}
	std::cout << count;
	system("pause");
	return 0;
}

