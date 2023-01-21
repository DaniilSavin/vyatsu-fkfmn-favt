// zadanie_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string.h>
#include <conio.h>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	char stroka='d';
    int count = 0;
	cout << "Введите строку: ";
    while (stroka != '/')
	{
		cin >> stroka;
		if (stroka == '!') count++;
	}
    cout << "Кол-во восклицателных знаков: "<< count << endl;
}