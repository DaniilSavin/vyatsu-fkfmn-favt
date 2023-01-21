// zadanie_2.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include "iostream"
#include "stdlib.h" 

int fib(int n);

int main()
{
	int n;
	printf("imput n number:");
	scanf_s("%d", &n);
	for (int i = 1; i <= n; i++) printf("%d ", fib(i));
	system("PAUSE");
	return 0;
}

int fib(int n)
{
	int result;
	if (n == 0 || n == 1) result = 1; else result = fib(n - 1) + fib(n - 2);
	return result;
}




