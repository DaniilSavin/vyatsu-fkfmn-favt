#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

void display(int** A, int DIM1, int DIM2);
void init(int** A, int type);

int main()
{
	int DIM1 = 4, DIM2 = 7;
	int** A;
	A = new int*[DIM1];
	for (int i = 0; i <DIM1; i++)
		*(A + i) = new int[DIM2];
	init(A, 1);
	display(A, DIM1, DIM2);
	printf("\n");

	DIM1 = 6, DIM2 = 6;
	int** B;
	B = new int*[DIM1];
	for (int i = 0; i <DIM1; i++)
		*(B + i) = new int[DIM2];
	init(B, 2);
	display(B, DIM1, DIM2);

	printf("\n");
	DIM1 = 6, DIM2 = 6;
	int** C;
	C = new int*[DIM1];
	for (int i = 0; i <DIM1; i++)
		*(C + i) = new int[DIM2];
	init(C, 3);
	display(C, DIM1, DIM2);	
	system("PAUSE");
	return 0;
}

void init(int** A, int type)
{
	srand(time(NULL));
	switch (type)
	{
	case 1:
	{
		int j = 1;
		bool zero = false;
		for (int k = 0; k < 4; k++)
			for (int i = 0; i < 7; i++)
				*(*(A + k) + i) = 0;
		for (int k = 0; k < 4; k++)
			for (int i = 0; i < 7; i++)
			{
				if (zero == false)
				{
					*(*(A + k) + i) = j;
					j++;
					zero = true;
				}
				else zero = false;
			}
	}
	break;
	case 2:
	{
		int j = 1;
		bool zero = false;
		for (int k = 0; k < 6; k++)
			if (zero == false)
				for (int i = 0; i < 6; i++)
				{
					*(*(A + i) + k) = j;
					j++;
					zero = true;
				}
			else
				for (int i = 5; i >= 0; i--)
				{
					*(*(A + i) + k) = j;
					j++;
					zero = false;
				}
	}
	break;
	case 3:
	{
		for (int k = 0; k < 6; k++)
			for (int i = 0; i < 6; i++)
				*(*(A + k) + i) = 0;
		int j = 1;
		int dx = 0, dy = 0;
		for (int i = 1; i < 7; i++)
		{
			if (i % 2 == 1)
			{
				int k = 0;
				dx = 0;
				dy = i - 1;
				while (k < i)
				{
					*(*(A + dx) + dy) = j;
					j++;
					dx++;
					dy--;
					k++;
				}
			}
			else
			{
				int k = 0;
				dy = 0;
				dx = i - 1;
				while (dx >= 0)
				{
					*(*(A + dx) + dy) = j;
					j++;
					dx--;
					dy++;
					k++;
				}
			}
		}
		for (int i = 7; i >= 0; i--)
		{
			if (i % 2 == 1)
			{
				int k = 0;
				dx = 0;
				dy = i - 1;
				while (k < i)
				{
					*(*(A + dx) + dy) = j;
					j++;
					dx++;
					dy--;
					k++;
				}
			}
			else
			{
				int k = 0;
				dy = 0;
				dx = i - 1;
				while (dx >= 0)
				{
					*(*(A + dx) + dy) = j;
					j++;
					dx--;
					dy++;
					k++;
				}
			}
		}

		break;
	}
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