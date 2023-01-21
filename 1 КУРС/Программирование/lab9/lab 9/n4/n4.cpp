// n4.cpp: определ€ет точку входа дл€ консольного приложени€.
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
	int sum = 0;
	for (int i = 0; i <= 9; i++)
		if (*(A+i) > 0)
			sum += *(A + i);
	printf("%d\n", sum);
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
 