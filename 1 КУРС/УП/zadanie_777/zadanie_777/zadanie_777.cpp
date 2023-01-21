// zadanie_777.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

int main()
{
	int S, T, result;
	std::cin >> S >> T;
	result = T - S;
	if (result < 0)
	{
		result += 12;
	}
	std::cout << result;
}


