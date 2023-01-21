// zadanie_7.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

using namespace std;

int func(int i, int n);

int main()
{
	setlocale(LC_ALL, "rus");
	int n;
	cout << "Введите n: ";
	cin >> n;
	
	func(1,n);
	return 0;
}

int func(int i,int n)
{
	if (i <= n)
	{
		int k = 0;
		while (k != i)
		{
			cout << i << ", ";
			k++;
		}
		return func(i + 1,n);
	}
}
