// n6.cpp: определяет точку входа для консольного приложения.
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
	int A[10] = { 0 };
	for (int i = 0; i < 10; i++)
	{
		*(A + i) = rand() % 100 - 50;
	}
	int  Ba[count] = { 0 };
	bool Bb[count] = { 0 };
	int  Bc[count] = { 0 };
	for (int i = 0; i <= 9; i++)
	{
		*(Ba+i) = *(A+i)**(A + i) + 2 * *(A + i) - 1;
		*(Bb+i) = (*(A + i) % 3 == 0) ? true : false;
		for (int k = 0; k <count; k++)
			*(Bc+i) += *(A + k);
	}
	printf("a)\n");
	display(Ba);
	printf("b)\n");
	for (int i = 0; i < count; i++) (*(Bb+i)== true) ? printf("%d - true\n", i) : printf("%d - false\n", i);
	printf("c)\n");
	display(Bc);
	system("pause");
	return 0;
}

void display(int num[10])
{
	for (int i = 0; i <= 9; i++) printf("%d = %d\n", i, *(num + i));
}