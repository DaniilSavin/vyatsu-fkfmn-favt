#include "stdafx.h"
#include "stdlib.h"
#include "ctime"
#include "iostream"

using namespace std;

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);

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
		display(A, DIM1, DIM2);
	}
	else cout << "Incorrect values!" << endl;
	system("PAUSE");
	return 0;
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