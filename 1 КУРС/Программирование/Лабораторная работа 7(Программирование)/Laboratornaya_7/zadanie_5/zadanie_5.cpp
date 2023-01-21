// zadanie_5.cpp: определяет точку входа для консольного приложения.
//5.Дано натуральное число. Найти все его делители. Подсчитать их количество. Найти сумму всех делителей

#include "stdafx.h"
#include <iostream> 

using namespace std;

void func(int x, int &sum, int &k);


int main()
{
	setlocale(LC_ALL, "rus");
	int x;
	cout << "Введите ваше число: ";
	cin >> x;
	int sum = 1, k = 1;
	func(x, sum, k);
	cout << "Количество= " << k << endl << "Сумма=" << sum << endl;
}


void func(int x, int &sum , int &k)
{
	for (int i = 2; i < x; i++)
	{
		if (fmod(x, i) == 0)
		{
			k++;
			sum += i;
		}
	}
	
}
