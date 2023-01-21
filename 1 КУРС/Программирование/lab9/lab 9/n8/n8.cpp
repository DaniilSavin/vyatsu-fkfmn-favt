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
	bool have = false;
	int i = 1;
	while ((i <= 9)&&(!have))
	{
		if (*(A + i)>0&&*(A + i-1)>0)
		{
			printf("%d and %d >0\n", i, i-1);
			have = true;
			}
		i++;
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