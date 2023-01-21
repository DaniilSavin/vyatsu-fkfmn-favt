// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);
void del(int A[], int n, int k);

int main()
{
	srand(time(NULL));
	int n, k=0;
	cout << "Enter n(size): ";
	cin >> n;
	int *A = new int [n];
	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 101 - 50;
	}
	cout << " " << endl;
	cout << "Старый массив:" << endl;
	cout << " " << endl;
	display(A, n);

		cout << "Введите номер элемента: ";
		cin >> k;
		if (k >= 0 && k <= n)
		{
			del(A, n, k);
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

void del(int A[], int n, int k)
{
	for (int i = k; i < n; i++)
	{
		*(A + i) = *(A + i + 1);
	}
	--n;
	cout << "Новый массив:" << endl;
	display(A, n);
}