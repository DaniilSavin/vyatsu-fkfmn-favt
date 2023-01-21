// zadanie_7.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);
void display2(int B[], int count);
void perezapis(int A[], int B[], int n);

int main()
{
	srand(time(NULL));
	int n, k = 0, j = 0;
	cout << "N = ";
	cin >> n;
	int *A = new int[n];
	int B[] = { 0 };
	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 1000-50;
	}
	cout << " " << endl;
	cout << "Старый массив:" << endl;
	cout << " " << endl;
	display(A, n);
	perezapis(A, B, n);

	return 0;
}

void display(int A[], int n)
{

	for (int i = 0; i < n; i++)
	{
		cout << i << "= " << *(A + i) << endl;
	}
}


void display2(int B[], int count)
{

	for (int i = 0; i < count; i++)
	{
		cout << i << "= " << *(B + i) << endl;
	}
}

void perezapis(int A[], int B[], int n)
{
	int count = 0;
	for (int i = 0; i < n; i++)
	{
		if (fmod(i,2)==fmod(*(A+i), 2))
		{
			*(B + i) = *(A + i);
			count++;
		}

	}
	cout << " " << endl;
	cout << "Новый массив:" << endl;
	cout << " " << endl;
	display(B, count);
}
