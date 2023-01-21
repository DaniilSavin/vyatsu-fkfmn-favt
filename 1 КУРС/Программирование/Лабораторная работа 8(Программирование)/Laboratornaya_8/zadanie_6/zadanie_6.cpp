// zadanie_6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

using namespace std;
int rec(int a, int b, int &sum);


int rec(int a, int b, int &sum)
{
	if (a<=b)
	{
		if ((a > 0) && (a % 7 == 0))
		{
			sum += a;	
		}
		return rec(a + 1, b, sum);
	}
}

int main() 
{
	int a, b, sum = 0;
	setlocale(LC_ALL, "rus");
	cout << "Введите начало промежутка: ";
	cin >> a;
	cout << "Введите конец промежутка: ";
	cin >> b;
	rec(a, b, sum);
	cout << "Сумма положительных целых чисел, кратных 7: " << sum << endl;
	
	return 0;
}