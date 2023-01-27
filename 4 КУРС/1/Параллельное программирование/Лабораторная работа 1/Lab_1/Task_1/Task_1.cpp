<<<<<<< HEAD
﻿#include <iostream>
#include <ctime>
#include <chrono>

using namespace std;

const int DIMM = 2048;

int** A = new int* [DIMM];
int** B = new int* [DIMM];
int** C = new int* [DIMM];

chrono::time_point<chrono::high_resolution_clock>start, ennd;

void init()
{
	srand(time(0));
	for (int i = 0; i < DIMM; i++)
	{
		A[i] = new int[DIMM];
		B[i] = new int[DIMM];
		C[i] = new int[DIMM];
		for (int j = 0; j < DIMM; j++)
		{

			A[i][j] = rand() % 25;
			B[i][j] = rand() % 25;
			C[i][j] = 0;
		}
	}
}

void display(int** A)
{
	for (int i = 0; i < DIMM; i++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			cout << A[i][j] << " ";
		}
		cout << "" << endl;
	}
	cout << "" << endl;
}


void matr(int** A, int** B)
{
	for (int k = 0; k < DIMM; k++)
	{
		for (int i = 0; i < DIMM; i++)
		{
			for (int j = 0; j < DIMM; j++)
			{
				C[i][j] += A[i][k] * B[k][j];
			}
		}
	}
}

int main()
{
	init();
	//display(A);
	//display(B);
	start = chrono::high_resolution_clock::now();
	matr(A, B);
	ennd = chrono::high_resolution_clock::now();
	chrono::duration<double> diff = ennd - start;
	cout << "time: " << diff.count() << endl;
	//cout << " res = " << endl;
	//display(C);

	delete[]A;
	delete[]B;
	delete[]C;
}
=======
﻿#include <iostream>
#include <ctime>
#include <chrono>

using namespace std;

const int DIMM = 2048;

int** A = new int* [DIMM];
int** B = new int* [DIMM];
int** C = new int* [DIMM];

chrono::time_point<chrono::high_resolution_clock>start, ennd;

void init()
{
	srand(time(0));
	for (int i = 0; i < DIMM; i++)
	{
		A[i] = new int[DIMM];
		B[i] = new int[DIMM];
		C[i] = new int[DIMM];
		for (int j = 0; j < DIMM; j++)
		{

			A[i][j] = rand() % 25;
			B[i][j] = rand() % 25;
			C[i][j] = 0;
		}
	}
}

void display(int** A)
{
	for (int i = 0; i < DIMM; i++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			cout << A[i][j] << " ";
		}
		cout << "" << endl;
	}
	cout << "" << endl;
}


void matr(int** A, int** B)
{
	for (int k = 0; k < DIMM; k++)
	{
		for (int i = 0; i < DIMM; i++)
		{
			for (int j = 0; j < DIMM; j++)
			{
				C[i][j] += A[i][k] * B[k][j];
			}
		}
	}
}

int main()
{
	init();
	//display(A);
	//display(B);
	start = chrono::high_resolution_clock::now();
	matr(A, B);
	ennd = chrono::high_resolution_clock::now();
	chrono::duration<double> diff = ennd - start;
	cout << "time: " << diff.count() << endl;
	//cout << " res = " << endl;
	//display(C);

	delete[]A;
	delete[]B;
	delete[]C;
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
