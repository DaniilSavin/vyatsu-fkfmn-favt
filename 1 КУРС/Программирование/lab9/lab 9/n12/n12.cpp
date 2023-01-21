// n6.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "stdlib.h"
#include "math.h"
#include "iostream"
#include "ctime"

void display(int num[10]);

int main()
{
	srand(time(NULL));
	int A[10] = { 0};
	for (int i = 0; i < 10; i++)
	{
		*(A + i) = rand() % 100 - 50;
	}
	printf("Before:\n");
	display(A);
	for (int i = 0; i <=9; i++)
	(fmod(i,2) == 0) ? *(A+i) *= 2 : *(A + i) *= *(A + i);
	printf("After:\n");
	display(A);
	system("pause");
	return 0;
}

void display(int num[10])
{
	for (int i = 0; i <=9; i++) printf("%d = %d\n", i, *(num + i));
}