// n5.cpp: ���������� ����� ����� ��� ����������� ����������.
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
	cout << "������� ����������� �������: ";
	cin >> n;
	int *A = new int[n];
	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 100 - 50;
	}
	display(A, n);
	int a, b;
	printf("imput a and b numbers: ");
	scanf_s("%d%d", &a, &b);
	int pr = 1;
	for (int i = 0; i <= 9; i++)
		if (a < *(A + i) && *(A + i) < b)
			pr *= *(A + i);
	printf("%d", pr);
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
