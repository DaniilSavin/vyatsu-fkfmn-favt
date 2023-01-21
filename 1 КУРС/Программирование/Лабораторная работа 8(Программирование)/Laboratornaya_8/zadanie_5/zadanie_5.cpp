// zadanie_5.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <clocale>

using namespace std;

void calk(int N, int &Max);

void calk(int N, int &Max)
{
	int c = N % 10; 
	if (N > 9) 
		calk(N / 10, Max); 
	if (c > Max) 
	{ 
		Max = c;
	}
	
}

int main()
{
	int N, Max = 0; 
	setlocale(LC_ALL, "rus");

	cout << "Введите целое число N (N>0): ";
	cin >> N;

	calk(N, Max); 
	cout << "Максимальная цифра = " << Max << endl;

	return 0;
}

