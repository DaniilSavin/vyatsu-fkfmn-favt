#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void init(int** A, int DIM1, int DIM2);
int min(int** A, int DIM1, int DIM2);
void display(int** A, int DIM1, int DIM2);
void del(int** A, int number);
void hate(int** A, int number);

int DIM1, DIM2;
int minimal;

int main()
{
	printf("imput DIM1 and DIM2 numbers: ");
	scanf_s("%d%d", &DIM1, &DIM2);
	if (DIM1 > 1 && DIM2 > 1)
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i < DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		minimal = min(A, DIM1, DIM2);
		printf("min = %d\n", minimal);
		hate(A, 2);
		display(A, DIM1, DIM2);
	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

void hate(int** A, int number)
{
	for (int k = 0; k < DIM2; k++)
		for (int i = 0; i < DIM1; i++)
		{
			if ((*(*(A + i) + k)) == minimal)
			{
			del(A, k);
			}
		}
}

void del(int** A, int number)
{
		for (int k = number; k < DIM2-1; k++)
		{
			for (int i = 0; i < DIM1; i++)
			{
				*(*(A + i) + k) = *(*(A + i) + k + 1);
			}
		}
		DIM2--;
	
}

int min(int** A, int DIM1, int DIM2)
{
	int min = 999999;
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			if (*(*(A + k) + i)<min) min = *(*(A + k) + i);
	return min;
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
			printf_s("%d\t ", *(*(A + k) + i));
		printf("\n");
	}
}