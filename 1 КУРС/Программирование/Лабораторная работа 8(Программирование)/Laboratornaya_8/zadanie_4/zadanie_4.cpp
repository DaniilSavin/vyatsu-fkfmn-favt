// zadanie_4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <clocale>

using namespace std;

void f();

void f() 
{
	int n;
	cout << "Вводите числа: "<< endl;
	cin >> n;
	if (n != 0)
	{
		f();
		cout << ' ' << n;
	}
}

int main()
{
	setlocale(LC_ALL, "rus");
	system("color 0a");
	f();
	cout << '\n';
}

