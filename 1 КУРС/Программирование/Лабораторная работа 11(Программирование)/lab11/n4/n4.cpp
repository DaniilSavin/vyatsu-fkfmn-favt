

#include "stdafx.h"
#include "stdlib.h"
#include "ctime"
#include "iostream"

using namespace std;

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
bool check(int** A, int DIM1, int DIM2);

int main()
{
	int DIM1, DIM2;
	cout << "Imput DIM1 and DIM2 numbers: ";
	cin >> DIM1 >> DIM2;
	if (DIM1 > 1 && DIM2 > 1)
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		*(*(A + 3) + 4) = 123;
		*(*(A + 3) + 3) = 123;
		*(*(A + 2) + 1) = 22;
		*(*(A + 3) + 1) = 22;
		display(A, DIM1, DIM2);
		if (check(A, DIM1, DIM2)) cout << "True" << endl; else cout << "False" << endl;
	}
	else cout << "Incorrect values!" << endl;
	system("PAUSE");
	return 0;
}

bool check(int** A, int DIM1, int DIM2)
{
	bool est = false;
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			for (int j = 0; j < DIM1; j++)
				for (int g = 0; g < DIM2; g++) if ((*(*(A + k) + i) == *(*(A + j) + g))&&k!=j&&i!=g)
				{
					printf_s("A[%d][%d]=A[%d][%d] (%d=%d) \n", k, i, j, g, *(*(A + k) + i), *(*(A + j) + g));
					est = true;
				}
	return est;
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