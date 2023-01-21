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
	int k1, k2;
	printf("imput k1 and k2 numers: ");
	scanf_s("%d%d", &k1, &k2);
	int sum = 0;
	if (k1 > k2 || ((k1||k2 > 10) || (k1 || k2 < 0))) 
		printf("incorrent values!"); 
	else
	{
		for (int i = k1; i <= k2; i++) sum += *(A + i);
	}
	printf("sum = %d", sum);
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