#include "stdafx.h"
#include "stdlib.h"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);

int main()
{
	int DIM1, DIM2;
	printf("imput size matrix: ");
	scanf_s("%d", &DIM1);
	DIM2 = DIM1;
	if (DIM1 > 1 && DIM2 > 1)
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

void init(int** A, int DIM1, int DIM2)
{
	*(*(A + 0) + 0) = 0;
	for (int i = 1; i < DIM1; i++) *(*(A + i) + 0) = i;
	for (int i = 1; i < DIM2; i++) *(*(A + 0) + i) = i;
	for (int k = 1; k < DIM1; k++)
		for (int i = 1; i < DIM2; i++)
			*(*(A + k) + i) = k*i;
}

void display(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++) {
		for (int i = 0; i < DIM2; i++)
			printf_s("%d\t", *(*(A + k) + i));
		printf("\n");
	}
}