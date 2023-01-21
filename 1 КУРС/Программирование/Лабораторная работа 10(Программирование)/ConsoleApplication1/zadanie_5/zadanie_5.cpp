// zadanie_5.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);
void perezapis(int A[], int n);

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
    perezapis(A, n);

	return 0;
}

void display(int A[], int n)
{

	for (int i = 0; i < n; i++)
	{
		cout << i << "= " << *(A + i) << endl;
	}
}

void perezapis(int A[], int n)
{
	bool t = false;
	for (int i = 3; i<n; i++)
	{
		if (i % 3 != 0 && t==false)
		{
			*(A + i) = pow(*(A + i), 2);
			t = true;
		}
		else t = false;
	}
	cout << " " << endl;
	cout << "Новый массив:" << endl;
	cout << " " << endl;
	display(A, n);
}
