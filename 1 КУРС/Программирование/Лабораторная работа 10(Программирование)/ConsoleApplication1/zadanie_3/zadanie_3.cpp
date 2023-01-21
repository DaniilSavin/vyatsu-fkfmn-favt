// zadanie_3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);
void del(int A[], int n, int j, int k);

int main()
{
	srand(time(NULL));
	int n, k = 0, j = 0, count = 0;
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

	cout << "Введите номер: ";
	cin >> j;
	cout << "Введите кол-во элементов: ";
	cin >> k;

	if (k > 0 && k <= n)
	{
		del(A, n, j, k);
	}
	else cout << "Вы ввели неверное кол-во элементов." << endl;
	return 0;
}



void display(int A[], int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << i << "= " << *(A + i) << endl;
	}
}



void del(int A[], int n, int j, int k)
{
	int count = 1;
	do
	{
		for (int i = j; i < n; i++)
		{
			*(A + i) = *(A + i + 1);

		}

		--n;
		count++;
	} while (count <= k);




	cout << " " << endl;
	cout << "<---------------->" << endl;
	cout << " " << endl;
	cout << "Новый массив:" << endl;
	display(A, n);
}