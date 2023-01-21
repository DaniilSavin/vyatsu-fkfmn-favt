#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
void del(int** A, int DIM1, int DIM2, int number);
void line(int lenght);

int main()
{
	int DIM1, DIM2;
	printf("imput DIM1 and DIM2 numbers: ");
	scanf_s("%d%d", &DIM1, &DIM2);
	if (DIM1 > 1 && DIM2 > 1)\
	{
		int number;
		printf("imput number for delte: ");
		scanf_s("%d", &number);
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		line(DIM2);
		del(A, DIM1, DIM2, number);
		display(A, DIM1-1, DIM2);
	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

void line(int lenght)
{
	for (int i = 0; i <= lenght; i++) printf("_");
	printf("\n\n");
}

void del(int** A, int DIM1, int DIM2, int number)
{
	number--;
	for (int k = number; k < DIM1-1; k++)
		for (int i = 0; i < DIM2; i++) *(*(A + k) + i) = *(*(A + k + 1) + i);

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