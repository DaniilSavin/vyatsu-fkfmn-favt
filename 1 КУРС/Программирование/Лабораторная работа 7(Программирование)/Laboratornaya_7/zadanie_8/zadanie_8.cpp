// zadanie_8.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "iostream"

using namespace std;


int func(int i);

int main()
{
	setlocale(LC_ALL, "rus");
	int A, B, count = 0;
	do {
		cout << "Введите промежуток от A до B: ";
		cin >> A >> B;
	} while (A > B);
	cout << "Простые числа:" << endl;
	for (int i = A; i < B; i++)
	{
		func(i);
	}

	return 0;
}

int func(int i)
{
	int count = 0;
	for (int k = 2; k <= i / 2; k++)
	{
		if (fmod(i, k) == 0)
		{
			count += 1;
		}
	}
	if (count == 0)
	{
		cout << i << "  ";

	}
	return 0;
}
