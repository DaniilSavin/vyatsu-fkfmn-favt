// n6.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include "stdafx.h"
#include "stdlib.h"
#include "iostream"
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);

int main()
{
	printf("imput number: ");
	int x;
	scanf_s("%d", &x);
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
	bool have = false;
	for (int i = 0; i <= n; i++)
	{
		if (*(A+i)==x)
		{
			printf("%d\n", i);
			have = true;
		}
	}
	if (have == false) printf("nety");
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