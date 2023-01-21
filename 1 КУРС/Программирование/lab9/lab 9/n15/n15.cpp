// n6.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include "stdlib.h"
#include "iostream"
#include "ctime"

void display(int num[10]);

int main()
{
	const int count = 10;
	srand(time(NULL));
	int A[count] = { 0 };
	for (int i = 0; i < count; i++)
	{
		*(A + i) = rand() % 100 - 50;
	}
	int  B[count] = {0};
	for (int i = 0; i <count; i++)
    *(B+i) = *(A+count-i-1);
	printf("A:\n");
	display(A);
	printf("B:\n");
	display(B);
	system("pause");
	return 0;
}

void display(int num[10])
{
	for (int i = 0; i <= 9; i++) printf("%d = %d\n", i, *(num + i));
}