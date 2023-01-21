// zadanie_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);
void del(int A[], int n, int k);

bool t = false;

int main()
{
    srand(time(NULL));
	int n, k;

	cout << "Enter n(size): ";
	cin >> n;
	int *A = new int[n];
	cout << " " << endl;
	cout << "Старый массив:" << endl;
	cout << " " << endl;

	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 101 - 50;
		
	}
	display(A, n);

	cout << "Введите размерность: ";
	cin >> k;
	del(A, n, k);

	return 0;
}


void display(int A[], int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << i << "= " << *(A + i) << endl;
	}
}


void del(int A[], int n, int k)
{
	t = false;
	for (int i = 0; i < n; i++)
	{
		if (*(A + i) == k || t==true)
		{
			*(A + i) = *(A + i + 1);
			t = true;
		}
	}

	if (t == true)
	{
		--n;
	}
	else cout << "Такого нет." << endl;

	if (t == true)
	{
		cout << "Новый массив:" << endl;
		display(A, n);
	}
	else
	{
		cout << "Массив не изменен: " << endl;
		display(A, n);
	}
}