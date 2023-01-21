// zadanie_7.cpp: определяет точку входа для консольного приложения.
//7.Разработать логическую функцию для определения, является ли число совершенным, то есть равно ли оно сумме своих делителей, кроме самого себя. 
//С помощью этой функции найти совершенные числа в диапазоне от 1 до 10000

#include "stdafx.h"
#include "iostream"

using namespace std;

bool sov(int x);

int main()
{
	for (int x = 6; x < 10000; x++)
	{
		if (sov(x))
		cout << x << endl;
	}

    return 0;
}

bool sov(int x)
{
	int sum = 1;
	for (int i = 2; i <= x/2; i++)
	{
		if (fmod(x, i) == 0)
		{
			sum += i;
		}
	}
	if (sum == x) 
		return true;
	else 
		return false;
}


