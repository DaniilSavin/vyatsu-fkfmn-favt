// zadanie_4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);
void perezapis(int A[], int n, int k, int j);

int main()
{
	srand(time(NULL));
	int n, k = 0, j = 0;
	cout << "Enter n(size): ";
	cin >> n;
	int *A = new int[n];
	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 101 - 50;
	}
	cout << " " << endl;
	cout << "Старый массив:" << endl;
	cout << " " << endl;
	display(A, n);

	cout << "Введите номер массива в который хотите записать свое значение j: ";
	cin >> k;
	cout << "j="; 
	cin >> j;
	if (k >= 0 && k <= n)
	{
		perezapis(A, n, k, j);
	}
	else cout << "Неверный элемент." << endl;

	return 0;
}

void display(int A[], int n)
{

	for (int i = 0; i < n; i++)
	{
		cout << i << "= " << *(A + i) << endl;
	}
}

void perezapis(int A[], int n, int k, int j)
{
	bool t = false;
	for (int i = k; t == false; i++)
	{
		*(A + i) = j;
		t = true;
	}
	
	cout << "Новый массив:" << endl;
	display(A, n);
}
