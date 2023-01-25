#include <iostream>
#include <ctime>
#include <chrono>

using namespace std;

const int DIMM = 2048;

int* A1 = new int[DIMM * DIMM];
int* B1 = new int[DIMM * DIMM];
int* C1 = new int[DIMM * DIMM];

chrono::time_point<chrono::high_resolution_clock>start, ennd;

void init2()
{
	srand(time(0));
	for (int i = 0; i < DIMM; i++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			A1[DIMM * i + j] = rand() % 25;
			B1[DIMM * i + j] = rand() % 25;
			C1[DIMM * i + j] = 0;
		}
	}
}

void display1(int* A)
{
	for (int i = 0; i < DIMM; i++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			cout << A[DIMM * i + j] << " ";
		}
		cout << "" << endl;
	}
	cout << "" << endl;
}

void matr1(int* A, int* B)
{
	for (int k = 0; k < DIMM; k++)
	{
		for (int i = 0; i < DIMM; i++)
		{
			for (int j = 0; j < DIMM; j++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

int main()
{
	init2();
	//display1(A1);
	//display1(B1);
	start = chrono::high_resolution_clock::now();
	matr1(A1, B1);
	ennd = chrono::high_resolution_clock::now();
	chrono::duration<double> diff = ennd - start;
	cout << "time: " << diff.count() << endl;
	//cout << " res = " << endl;
	//display1(C1);

	delete[]A1;
	delete[]B1;
	delete[]C1;
}
