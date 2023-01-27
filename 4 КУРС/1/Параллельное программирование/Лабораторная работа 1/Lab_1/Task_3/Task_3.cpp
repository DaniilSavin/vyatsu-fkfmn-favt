<<<<<<< HEAD
﻿#include <iostream>
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

void kij(int* A, int* B)
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

void ijk(int* A, int* B)
{
	for (int i = 0; i < DIMM; i++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			for (int k = 0; k < DIMM; k++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void ikj(int* A, int* B)
{
	for (int i = 0; i < DIMM; i++)
	{
		for (int k = 0; k < DIMM; k++)
		{
			for (int j = 0; j < DIMM; j++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void jik(int* A, int* B)
{
	for (int j = 0; j < DIMM; j++)
	{
		for (int i = 0; i < DIMM; i++)
		{
			for (int k = 0; k < DIMM; k++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void jki(int* A, int* B)
{
	for (int j = 0; j < DIMM; j++)
	{
		for (int k = 0; k < DIMM; k++)
		{
			for (int i = 0; i < DIMM; i++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void kji(int* A, int* B)
{
	for (int k = 0; k < DIMM; k++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			for (int i = 0; i < DIMM; i++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

int main()
{
	int h = 0;
	while (h<3)
	{
		cout << endl;
		{
			init2();
			start = chrono::high_resolution_clock::now();
			ijk(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time ijk: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			ikj(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time ikj: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			jik(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time jik: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			jki(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time jki: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			kij(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time kij: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			kji(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time kji: " << diff.count() << endl;
		}
		h++;
	}
	delete[]A1;
	delete[]B1;
	delete[]C1;
}
=======
﻿#include <iostream>
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

void kij(int* A, int* B)
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

void ijk(int* A, int* B)
{
	for (int i = 0; i < DIMM; i++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			for (int k = 0; k < DIMM; k++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void ikj(int* A, int* B)
{
	for (int i = 0; i < DIMM; i++)
	{
		for (int k = 0; k < DIMM; k++)
		{
			for (int j = 0; j < DIMM; j++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void jik(int* A, int* B)
{
	for (int j = 0; j < DIMM; j++)
	{
		for (int i = 0; i < DIMM; i++)
		{
			for (int k = 0; k < DIMM; k++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void jki(int* A, int* B)
{
	for (int j = 0; j < DIMM; j++)
	{
		for (int k = 0; k < DIMM; k++)
		{
			for (int i = 0; i < DIMM; i++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

void kji(int* A, int* B)
{
	for (int k = 0; k < DIMM; k++)
	{
		for (int j = 0; j < DIMM; j++)
		{
			for (int i = 0; i < DIMM; i++)
			{
				C1[DIMM * i + j] += A[DIMM * i + k] * B[DIMM * k + j];
			}
		}
	}
}

int main()
{
	int h = 0;
	while (h<3)
	{
		cout << endl;
		{
			init2();
			start = chrono::high_resolution_clock::now();
			ijk(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time ijk: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			ikj(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time ikj: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			jik(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time jik: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			jki(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time jki: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			kij(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time kij: " << diff.count() << endl;
		}

		{
			init2();
			start = chrono::high_resolution_clock::now();
			kji(A1, B1);
			ennd = chrono::high_resolution_clock::now();
			chrono::duration<double> diff = ennd - start;
			cout << "time kji: " << diff.count() << endl;
		}
		h++;
	}
	delete[]A1;
	delete[]B1;
	delete[]C1;
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
