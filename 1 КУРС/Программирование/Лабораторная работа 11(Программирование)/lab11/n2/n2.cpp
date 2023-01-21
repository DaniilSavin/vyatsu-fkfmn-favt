#include "stdafx.h"
#include "stdlib.h"
#include "ctime"

#include "iostream"

using namespace std;

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
int sum(int** A, int DIM1, int DIM2, int stolb);
int count(int** A, int DIM1, int DIM2, int stolb);
bool prost(int number);
void mainsum(int** A, int DIM1, int DIM2);
void maincount(int** A, int DIM1, int DIM2);

int main()
{
	int DIM1, DIM2;
	cout << "imput size of matrix: ";
	cin >> DIM1;
	DIM2 = DIM1;
	if (DIM1 > 1 && DIM2 > 1)
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i <DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		mainsum(A, DIM1, DIM2);
		maincount(A, DIM1, DIM2);
	}
	else cout << "Incorrect values!" << endl;
	system("PAUSE");
	return 0;
}

void mainsum(int** A, int DIM1, int DIM2)
{
	cout << "Calculation of count..." << endl;
	cout << "\t";
	for (int i = 1; i < DIM2; i++)
	{
		printf("%d\t", count(A, DIM1, DIM2, i));
	}
	cout << endl;
}

void maincount(int** A, int DIM1, int DIM2)
{
	cout << "Calculation of sum..." << endl;
	cout << "\t";
	for (int i = 1; i < DIM2; i++)
	{
		printf("%d\t", sum(A, DIM1, DIM2, i));
	}
	cout << endl;
}

int sum(int** A, int DIM1, int DIM2, int stolb)
{
	int sum = 0;
	for (int k = 0; k < stolb; k++)
		{
			if (prost(*(*(A + k) + stolb))) 
			sum+= (*(*(A + k) + stolb));
		}
	return sum;
}

int count(int** A, int DIM1, int DIM2, int stolb)
{
	int count = 0;
	for (int k = 0; k < stolb; k++)
	{
		if (prost(*(*(A + k) + stolb)))
			count++;
	}
	return count;
}

bool prost(int number)
{
	for (int i = 2; i<number /2; i++) {
		if (number % i == 0) {
			return false;
			break;
		}
	}
	return true;
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