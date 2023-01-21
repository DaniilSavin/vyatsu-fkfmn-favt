// zadanie_4.cpp: определяет точку входа для консольного приложения.
//4.Определить, чему равна максимальная первая цифра n введенных с клавиатуры чисел. Количество и сами числа вводит пользователь

#include "stdafx.h"
#include <iostream> 

using namespace std;

int f(int n);

int main()
{
	int n, m, max = 0;
	cout << "Введите количество чисел: " << endl;
	cout << "n = ";
	cin >> n;
	cout << "Вводите числа: " << endl;
	for (int i = 0; i < n; i++)
	{
		cin >> m;
		if (f(m) > max)
		{
			max = f(m);
		}
	}
	cout << "Максимальное число: " << max << endl;
	return 0;
}

int f(int n)
{
	while (n > 10)
	{
		n /= 10;
	}
	return n;
}