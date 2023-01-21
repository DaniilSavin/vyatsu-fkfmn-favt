#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
int firstmax(int** A, int DIM1, int DIM2);
int lastmin(int** A, int DIM1, int DIM2);

int i1, i2;

int main()
{
	int DIM1, DIM2;
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
		printf("first max =%d,", firstmax(A, DIM1, DIM2));
		printf(" index's [%d][%d]\n", i1, i2);
		i1 = i2 = 0;
		printf("first min =%d,", lastmin(A, DIM1, DIM2));
		printf(" index's [%d][%d]\n", i1, i2);
	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

int firstmax(int** A, int DIM1, int DIM2)
{
	int max = 0;
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
		{
			if (*(*(A + i) + k) > max)
			{
				i1 = i;
				i2 = k;
				max = *(*(A + i) + k);
			}
		}
	return max;
}

int lastmin(int** A, int DIM1, int DIM2)
{
	int min = 999999;
	for (int k = DIM1-1; k >=0; k--)
		for (int i = DIM2-1; i >=0; i--)
		{
			if (*(*(A + i) + k) < min)
			{
				i1 = i;
				i2 = k;
				min = *(*(A + i) + k);
			}
		}
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
			printf_s("%d ", *(*(A + k) + i));
		printf("\t\n");
	}
}