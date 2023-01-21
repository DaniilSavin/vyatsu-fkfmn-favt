// zadanie_6.cpp: определяет точку входа для консольного приложения.
//6.Найти числа из промежутка от А до В, у которых больше всего делителей

#include "stdafx.h"
#include "iostream"

using namespace std;

void func(int A, int B);
int nummax = 0, dmax = 0;

int main()
{
	setlocale(LC_ALL, "rus");
	int A, B;
check_prom:
	cout << "Введите промежуток от A до B: ";
	cin >> A >> B;
	if (A > B)
	{
		cout << "Вы ввели неверно промежуток.";
		goto check_prom;
	}
	func(A, B);
	cout << "nummax=" << nummax << endl;
    return 0;
}

void func(int A, int B)
{

	for (int num = A; num < B; num++)
	{
		int k = 0;
		for (int d = 2; d < num / 2; d++)
			if (fmod(num, d) == 0) k++;

		if (k > dmax)
		{
			dmax = k;
			nummax = num;
		}

	}
}
