// zadanie_5.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string.h>
#include <conio.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	int a, n;
	int count = 0;
	cout << "Каким способом? (1,2): ";
	cin >> a;
	switch (a) {
	case 1:
	{
		cout << "RAZMER= ";
		cin >> n;
		char *stroka = new char[n];
		
		cout << "Введите строку: ";
        cin >> stroka;
		for (int i = 0; i <= n; i++)
		{
			if (*(stroka + i) == '1' || *(stroka + i) == '2' || *(stroka + i) == '3' || *(stroka + i) == '4' || *(stroka + i) == '5' || *(stroka + i) == '6' || *(stroka + i) == '7' || *(stroka + i) == '8' || *(stroka + i) == '9' || *(stroka + i) == '0')
			{
				count++;
			}
		}
		cout << "Кол-во цифр: " << count << endl;
		break;
	}

	case 2:
		char stroka2 = 'd';
		cout << "Введите строку(конечный символ /): ";
		while (stroka2 != '/')
		{
			cin >> stroka2;
			if (stroka2 == '0' || stroka2 == '1' || stroka2 == '2' || stroka2 == '3' || stroka2 == '4' || stroka2 == '5' || stroka2 == '6' || stroka2 == '7' || stroka2 == '8' || stroka2 == '9')
			{
				count++;
			}
		}
		cout << "Кол-во цифр: " << count << endl;
		break;
	}
}

