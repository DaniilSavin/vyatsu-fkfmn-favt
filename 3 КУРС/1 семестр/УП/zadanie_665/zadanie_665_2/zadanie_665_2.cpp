// zadanie_665_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <string.h>
using namespace std;

int main()
{
	char h[6] = "\0"; // формат ввода 00:00
	int a, b; //десятки и еденицы часов
	int c, d; //десятки и еденицы минут

	cin >> h;
	a = h[0] - '0';
	b = h[1] - '0';
	c = h[3] - '0';
	d = h[4] - '0';
	if (strcmp(h, _strrev(h)) == 0)d += 1;
	while (1)
	{
		if (a == d && b == c)
		{
			cout << a << b << ":" << c << d;
			
			return 0;
		}
		d++;
		if (d >= 10)
		{
			d = 0; c++;
		}
		if (c == 6)
		{
			c = 0; b++;
		}
		if (b == 10)
		{
			b = 0; a++;
		}
		if (a == 2 && b == 4)
		{
			a = 0; b = 0;
		}
	}
}
