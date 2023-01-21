#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
void change(int** A, int** B, int DIM1, int DIM2);

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
		int** B;
		B = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(B + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		change(A, B, DIM1, DIM2);
		printf("result: \n");
		display(B, DIM1, DIM2);

	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

void change(int** A, int** B, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			if (*(*(A + k) + i) > 0) *(*(B + k) + i) = *(*(A + k) + i) * *(*(A + k) + 0); 
			else *(*(B + k) + i) = *(*(A + k) + i) * *(*(A + i) + DIM2-1); 
}

void init(int** A, int DIM1, int DIM2)
{
	srand(time(NULL));
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			*(*(A + k) + i) = rand() / 100<100 ? rand() / 100 : rand() / -100;
}

void display(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++) {
		for (int i = 0; i < DIM2; i++)
			printf_s("%d ", *(*(A + k) + i));
		printf("\t\n");
	}
}