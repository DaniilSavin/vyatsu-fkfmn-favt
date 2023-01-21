// n6.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include "stdafx.h"
#include "stdlib.h"
#include "iostream"
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);

int abs(int n);

int main()
{
	setlocale(LC_ALL, "rus");
	srand(time(NULL));
	int n;
	cout << "¬ведите размерность массива: ";
	cin >> n;
	int *A = new int[n];
	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 100 - 50;
	}
	display(A, n);
	int max = 0, min = 999999999;
	for (int i = 0; i <= 9; i++)
	{
		if (abs(*(A+i)) > max) max = *(A+i);
		if (abs(*(A+i)) < min) min = *(A+i);
	}
	printf("sum = %d\n", max + min);
	system("pause");
	return 0;
}

void display(int A[], int n)
{

	for (int i = 0; i < n; i++)
	{
		cout << i << "= " << *(A + i) << endl;
	}
}

int abs(int n)
{
	if (n < 0) n *= -1;
	return n;
}