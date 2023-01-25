﻿// 2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <omp.h>
using namespace std;
int main()
{
	int N = 0;
	cout << "--> ";
	cin >> N;
	omp_set_num_threads(2);
#pragma omp parallel
	{
		// Код внутри блока выполняется параллельно
#pragma omp sections
		{
#pragma omp section
			{
#pragma omp parallel num_threads(1)
				for (int i=0; i<N; i++)
				cout << i << " ";
			}
#pragma omp section
			{
#pragma omp parallel num_threads(1)
				for (int i = 0; i < N; i++)
					cout << "Hello\n";
			}
		}


	}
}


