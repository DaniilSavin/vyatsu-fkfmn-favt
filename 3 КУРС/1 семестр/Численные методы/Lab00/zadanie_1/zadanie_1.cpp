// zadanie_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	setlocale(LC_ALL, "rus");
	double A, B, y = 0;
	double h=0;
	double min = 999999, max = 0, absMin = 99999, absMax = 0;
	double znak = 1;
	bool fl = false;
	cout << "Введите A, B, h:" << endl;
	cin >> A >> B >> h;
	if (h <= 0)
	{
		return -1;

	}
	double* arr = new double[A + B];
	cout << endl;
	int i = 0;
	int H = (B - A) / h;
	double x = A;
	for (int b = 0; b <= H; b++)
	{
		y = (pow(x, 2) - 2 * x - 2);
		arr[i] = y;
		i++;
		cout << "x= " << x << "\ty= " << y << endl;
		x += h;
	}
	max = arr[0];
	min = arr[0];
	znak = arr[0];
	absMax = arr[0];
	absMin = arr[0];
	double k = arr[0];
	for (int j = 0; j < i; j++)
	{
		if (max < arr[j])
		{
			max = arr[j];
			if (absMin > max)
			{
				absMin = max;
			}
		}
		if (min > arr[j])
		{
			min = arr[j];

		}
		if (absMin > min&& min > 0)
		{
			absMin = min;
		}
		if ((znak<0 && arr[j]>0) || (znak>0 && arr[j]<0))
		{
			fl = true;
			cout << "\nФункция меняет знак на отрезке [" << j - h << ", " << j << "]" << endl;
			znak = arr[j];
			if ((arr[j - 1] * -1) < arr[j])
			{
				absMin = arr[j - 1] * -1;
				k = j - h;
			}
			else
			{
				absMin = arr[j];
				k = j;
			}
		}

	}
	if (min * -1 > max)
	{
		absMax = min * -1;
	}
	else
	{
		absMax = max;
	}
	bool fl1 = false;
	if (fl == false && znak >= 0)
	{
		cout << "\nФункция имеет постоянный знак +" << endl;
		i = 0;
		for (double x = A; x <= B; x = x + h)
		{
			if (arr[i] == min)
			{
				k = x;
			}
			i++;
		}
		fl1 = true;
	}
	else
	{
		if (fl == false && znak < 0)
		{
			cout << "\nФункция имеет постоянный знак -" << endl;
			i = 0;
			for (double x = A; x <= B; x = x + h)
			{
				if (arr[i] == max)
				{
					k = x;
				}
				i++;
			}
			fl1 = true;
		}
	}
	cout << "Min: " << min << endl;
	cout << "Max: " << max << endl;
	cout << "absMin: " << absMin << endl;
	if (fl1)
	{
		if (max < 0)
		{
			absMax = max * -1;
		}
		else
		{
			absMax = max;
		}
	}
	cout << "absMax: " << absMax << endl;
	cout << "x, при котором функция принимает значение близкое к 0: " << k << endl;

	delete arr;
	return 0;
}

