#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
void change(int** A, int DIM1, int DIM2, int x, int y);

int main()
{
	int DIM1=8, DIM2=8;
	printf("imput x, y numbers: ");
	int x, y;
	scanf_s("%d%d", &x, &y);
	if (x >= 1 && y >= 1&& x<=8&& y<=8)
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		*(*(A + x-1) + y-1) = 8;
		display(A, DIM1, DIM2);
		change(A, DIM1, DIM2, x, y);
		printf("________________\n\n");
		display(A, DIM1, DIM2);
	}
	else printf("incorrect value!\n");
	system("PAUSE");
	return 0;
}

void change(int** A, int DIM1, int DIM2, int x, int y)
{
	x--;
	y--;
	if (x - 1>0 && y + 2 <8) *(*(A + x - 1) + y + 2) = 1;
	if (x + 1<8 && y + 2 <8) *(*(A + x + 1) + y + 2) = 1;
	if (x + 2<8 && y + 1 <8) *(*(A + x + 2) + y + 1) = 1;
	if (x + 2<8 && y - 1 >0) *(*(A + x + 2) + y - 1) = 1;
	if (x + 1<8 && y - 2 >0) *(*(A + x + 1) + y - 2) = 1;
	if (x - 1>0 && y - 2 >0) *(*(A + x - 1) + y - 2) = 1;	
	if (x - 2>0 && y - 1 >0) *(*(A + x - 2) + y - 1) = 1;
	if (x - 2>0 && y + 1 <8) *(*(A + x - 2) + y + 1) = 1;
}

void init(int** A, int DIM1, int DIM2)
{
	srand(time(NULL));
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			*(*(A + k) + i) = 0;
}

void display(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++) {
		for (int i = 0; i < DIM2; i++)
			printf_s("%d ", *(*(A + k) + i));
		printf("\t\n");
	}
}