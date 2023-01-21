#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
void del(int** A, int number);
int hate(int** A, int DIM1, int DIM2, int number);
void line(int lenght);

int DIM1, DIM2;

int main()
{
	printf("imput DIM1 and DIM2 numbers: ");
	scanf_s("%d%d", &DIM1, &DIM2);
	if (DIM1 > 1 && DIM2 > 1)\
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		int number; 
		printf_s("imput number: ");
		scanf_s("%d", &number);
		int rez = hate(A, DIM1, DIM2, number);
		if (rez != 0)
			printf("str deleted: %d\n", rez); else printf("not found!\n");
		line(DIM2);
		display(A, DIM1, DIM2);
	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

int hate(int** A, int DIM1, int DIM2, int number)
{
	int count = 0;
	for (int k = 0; k < DIM1 - 1; k++)
		for (int i = 0; i < DIM2; i++)
		{
			if (*(*(A + k) + i) == number)
			{
				del(A, k);
				count++;
			}
		}
	return count;
}

void del(int** A, int number)
{
	for (int k = number; k < DIM1 - 1; k++)
		for (int i = 0; i < DIM2; i++) *(*(A + k) + i) = *(*(A + k + 1) + i);
	DIM1--;
}

void init(int** A, int DIM1, int DIM2)
{
	srand(time(NULL));
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			*(*(A + k) + i) = rand() / 100;
}

void display(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++) {
		for (int i = 0; i < DIM2; i++)
			printf_s("%d \t", *(*(A + k) + i));
		printf("\n");
	}
}

void line(int lenght)
{
	for (int i = 0; i <= lenght; i++) printf("_");
	printf("\n\n");
}