// zadanie_8.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>
#include "stdlib.h" 

using namespace std;

void del(int A[], int number);
void display(int num[], int size);
void hate(int A[]);

                                                                                                                                                                                                                                     int n;
int main()
{
	cout << "Enter n(size): ";
	cin >> n;
	int *A = new int[n];
	cout << "Старый массив: " << endl;
	if (n > 2)
	{
		srand(time(NULL));
		for (int i = 0; i < n; i++)
		{
			*(A + i) = rand() / 100;
		}
		*(A + 2) = 1337;
		*(A + 3) = 1337;
		display(A, n);
		cout << endl;
		hate(A);
		cout << "Новый массив: " << endl;
		display(A, n);
	}
	else cout << "Error" << endl;
	
	return 0;
}

void hate(int A[])
{
	for (int i = 0; i < n; i++)
	{
		for (int k = 0; k < n; k++)
		{
			if (*(A + k) == *(A + i) && i != k)
			{
				del(A, k);
				cout << "Совпадение " << i << " и " << k << endl; 
			}
		}
	}
}

void display(int num[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << i << "= " << *(num + i) << endl;
	}
}

void del(int A[], int number)
{
    for (int i = number - 1; i <= n - 2; i++)
	{
		*(A + i) = *(A + i + 1);
	}
	*(A + n - 1) = 0;
	--n;
}





