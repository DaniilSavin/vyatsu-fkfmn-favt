#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
int check(int** A, int DIM1, int DIM2);
void displaystr(int** A, int number, int DIM2);

int main()
{
	start:
	{
	int DIM1, DIM2;
	printf("imput DIM1 and DIM2 numbers: ");
	scanf_s("%d%d", &DIM1, &DIM2);
	if (DIM1 > 1 && DIM2 > 1)\
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i < DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		int result = check(A, DIM1, DIM2);
		if (result != -1)
		{
			printf("est' - %d :\n", result);
			displaystr(A, result, DIM2);
		}
		else printf("nety\n");
	}
	else printf("incorrect values!\n");
	printf("M?\n1 - povtorit'\nany - exit");
	int respone;
	scanf_s("%d", &respone);
	if (respone == 1) goto start; else goto exit;
	}
	exit:
	system("PAUSE");
	return 0;
}

int check(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++)
	{
		bool poloj = true;
		for (int i = 0; i < DIM2; i++) 
			if (*(*(A + k) + i) < 0)
			{
				poloj = false;
				break;
			}
		if (poloj == true) return k;
	}
	return -1;
}

void init(int** A, int DIM1, int DIM2)
{
	srand(time(NULL));
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			*(*(A + k) + i) = rand() / 100>20? rand() / 100 : rand() / -100;
}

void display(int** A, int DIM1, int DIM2)
{
	for (int k = 0; k < DIM1; k++) {
		for (int i = 0; i < DIM2; i++)
			printf_s("%d\t", *(*(A + k) + i));
		printf("\n");
	}
}

void displaystr(int** A, int number, int DIM2)
{
		for (int i = 0; i < DIM2; i++)
			printf_s("%d\t", *(*(A + number) + i));
		printf("\n");

}