#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
void swap(int** A, int DIM1, int DIM2, int  pos1,int  pos2);
int search(int** A, int DIM1, int DIM2);
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
		init(A, DIM1, DIM2);
		*(*(A + 3) + 2) = 0; //anti stupid rand
		display(A, DIM1, DIM2);
		int result = search(A, DIM1, DIM2);
		if (result != -1)
		{
			swap(A, DIM1, DIM2, 1, result);
			line(DIM2);
			display(A, DIM1, DIM2);
		}
		else printf("not found!\n");
	}
	else printf("incorrect values!\n");
	system("PAUSE");
	return 0;
}

int search(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++)
		//for (int i = 0; i < DIM2; i++) if (*(*(A + k) + i) == 0)
		if (*(*(A + k) + 0) == 0)
			return k+1;
	return -1;
}

void swap(int** A, int DIM1, int DIM2, int pos1,int pos2)
{
	pos1--;
	pos2--;
	int* TEMP = new int[DIM2];
	for (int i = 0; i < DIM2; i++) *(TEMP + i) = *(*(A + pos1) + i);
	for (int i = 0; i < DIM2; i++) *(*(A + pos1) + i) = *(*(A + pos2) + i);
	for (int i = 0; i < DIM2; i++) *(*(A + pos2) + i) = *(TEMP + i);
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

void line(int lenght)
{
	for (int i = 0; i <= lenght; i++) printf("_");
	printf("\n\n");
}