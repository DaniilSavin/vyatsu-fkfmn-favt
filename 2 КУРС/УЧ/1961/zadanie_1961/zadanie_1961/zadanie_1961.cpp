﻿// zadanie_1961.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

/* Стратегия:
 * Решить (M / N) * n = m для M и округлить вверх.
 *
 * Представление:
 * Константа, работает в 0,015 с использованием памяти 260 КБ.
 * /*/



#include <iostream>
#include <algorithm>

int main()
{
	long long n, m, N;
	std::cin >> n >> m >> N;
	std::cout << std::min((N + 1) * m / n, N);
}
