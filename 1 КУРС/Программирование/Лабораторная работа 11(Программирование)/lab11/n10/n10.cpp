#include "stdafx.h"
#include "stdlib.h"
#include "ctime"
#include <Windows.h>

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
void line(int lenght);
void generate(int** A, int** B, int** Ñ, int DIM1, int DIM2);
void line(int lenght);

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
		int** C;
		C = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(C + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		line(DIM2);
		Sleep(500);
		init(B, DIM1, DIM2);
		display(B, DIM1, DIM2);
		line(DIM2);
		generate(A, B, C, DIM1, DIM2);
		display(C, DIM1, DIM2);
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

void generate(int** A, int** B, int** C, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			*(*(C + k) + i) = *(*(A + k) + i)**(*(B + k) + i);
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