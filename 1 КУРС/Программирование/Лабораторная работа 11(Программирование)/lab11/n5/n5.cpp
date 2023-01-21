#include "stdafx.h"
#include "stdlib.h"
#include "ctime"
#include "iostream"

using namespace std;

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
bool _A(int** A, int DIM1, int DIM2, int Anumer);
bool _B(int** A, int DIM1, int DIM2, int Anumer);
bool _C(int** A, int DIM1, int DIM2, int Anumer, int k1, int k2, int l1, int l2);

int k1, k2, l1, l2;

int main()
{
	int DIM1, DIM2;
	printf("imput size of matrix: ");
	scanf_s("%d", &DIM1);
	DIM2 = DIM1;
	if (DIM1 > 1 && DIM2 > 1)
	{
		int Anumer;
		scanf_s("%d", &Anumer);
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		A[2][0] = 228;
		display(A, DIM1, DIM2);
		(_A(A, DIM1, DIM2, Anumer)) ? printf("A)true\n") : printf("A)false\n");
		(_B(A, DIM1, DIM2, Anumer)) ? printf("B)true\n") : printf("B)false\n");
		printf("imput k1, k2, l1, l2 values: ");
		scanf_s("%d%d%d%d", &k1, &k2, &l1, &l2);
		if (k1 >= 0 && k2 >= 0 && l1 >= 0 && l2 >= 0 && k2 > k1&&l2 > l1&&k2 < DIM1&&l2 < DIM1)
		(_C(A, DIM1, DIM2, Anumer, k1, k2, l1, l2)) ? cout << "C)True\n" : cout << "C)False\n";
		else cout << "Incorrect values!" << endl;
	}
	else cout << "Incorrect values!" << endl;
	system("PAUSE");
	return 0;
}

bool _A(int** A, int DIM1, int DIM2, int Anumer)
{
	for (int i = 0; i < DIM2; i++)
		for (int k = 0; k <= i; k++)
			if (*(*(A + i) + k) == Anumer)
			{
				return true;
				break;
			}
	return false;
}

bool _B(int** A, int DIM1, int DIM2, int Anumer)
{
	int counter = 0;
	for (int i = 0; i < DIM1; i++)
	{
		for (int k = counter; k < DIM2 - counter; k++)
		if (*(*(A + i) + k) == Anumer)
			{
				return true;
				break;
			}
		counter++;
	}
	counter = 0;
	for (int i = DIM1-1; i >0; i--)
	{
		for (int k = counter; k < DIM2 - counter; k++)
		if (*(*(A + i) + k) == Anumer)
			{
				return true;
				break;
			}
		counter++;
	}
	return false;
}

bool _C(int** A, int DIM1, int DIM2, int Anumer, int k1, int k2, int l1, int l2)
{
	for (int i = k1; i < k2; i++)
		for (int k = l1; k < l2; k++)
			if (*(*(A + i) + k) == Anumer)
			{
				return true;
				break;
			}
	return false;
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
			cout << *(*(A + k) + i) << "\t";
		cout << endl;
	}
}