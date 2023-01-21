#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void insertstr(int** A);
void insertstr(int** A);
void init(int** A, int DIM1, int DIM2);
void insertstr(int** A, int number);
void str(int** A);
void insertstolb(int** A, int number);
void stolb(int** A);

int DIM1, DIM2;
int realSIZEDIM1, realSIZEDIM2;

int main()
{
	printf("imput size of matrix: ");
	scanf_s("%d", &DIM1);
	realSIZEDIM1 = DIM1;
	realSIZEDIM2 = realSIZEDIM1;
	DIM1 *= 2;
	DIM2 = DIM1;
	if (DIM1 > 1 && DIM2 > 1)
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, realSIZEDIM1, realSIZEDIM2);
		*(*(A + 2) + 2) = 0;
		*(*(A + 3) + 2) = 0;
		*(*(A + 6) + 3) = -5;
		*(*(A + 3) + 5) = -9;
		display(A, realSIZEDIM1, realSIZEDIM2);
		printf("--------------\n");
		str(A);
		stolb(A);
		printf("--------------\n");
		display(A, realSIZEDIM1, realSIZEDIM2);
	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

void stolb(int** A)
{
	for (int i =0; i<DIM1; i++)
		for (int k = 0; k < DIM2; k++)
		{
			if (*(*(A + k) + i) < 0 && *(*(A + k) + i) > -1000)
			{
				printf("number<0 detected in %d %d\n", k, i);
				insertstolb(A, i);
				k++;
			}
		}
}

void insertstolb(int** A, int number)
{
	for (int k = realSIZEDIM2 + 1; k > number; k--)
	{
		for (int i = 0; i < realSIZEDIM1; i++)
		{
			*(*(A + i) + k) = *(*(A + i) + k-1);
		}
	}
	for (int i = 0; i < realSIZEDIM1; i++)
		{
			*(*(A + i) + number + 1) = *(*(A + i) + 0);
		}

	realSIZEDIM2++;
}

void str(int** A)
{
	for (int k =0; k <DIM1; k++)
		for (int i = 0; i < DIM2; i++)
		{
			if (*(*(A + k) + i) == 0)
			{
				printf("0 number detected in %d %d\n", k, i);
				insertstr(A, k);
				k++;
			}
		}
}

void insertstr(int** A, int number)
{
	for (int k = realSIZEDIM1; k >= number; k--)
		for (int i = 0; i < realSIZEDIM2; i++)
		{
			*(*(A + k) + i) = *(*(A + k - 1) + i);
		}
	for (int i = 0; i < realSIZEDIM2; i++)
	{
		*(*(A + number) + i) = *(*(A + 0) + i);
	}
	realSIZEDIM1++;
}

void insertstr(int** A)
{

}


void init(int** A, int DIM1, int DIM2)
{
	srand(time(NULL));
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
		{
			*(*(A + k) + i) = rand() / 100;
		}
}


void display(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++) {
		for (int i = 0; i < DIM2; i++)
			printf_s("%d \t", *(*(A + k) + i));
		printf("\n");
	}
}