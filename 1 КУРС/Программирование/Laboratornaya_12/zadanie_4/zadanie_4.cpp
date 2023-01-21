// zadanie_4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string.h>
#include <conio.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	bool t = false;
	cout << "imput n: ";
	int n;
	cin >> n;
	char *stroka = new char[n];
	char c1 = 'd', c2 = 'c';

	cout << "Введите строку: ";
	cin >> stroka;
	
		cout << "Введите c1: ";
		cin >> c1;

		cout << "Введите c2: ";
		cin >> c2;
	

	for (int i = 0; i <= n; i++)
	{
		if (*(stroka + i) == c1)
		{
			*(stroka + i) = c2;
			t = true;
		}
	}
	if (t = false)
	{
		cout << "Что-то пошло не так, или вы ввели неккоректные символы." << endl;
	}
	cout << "stroka -> " << stroka << endl;
}