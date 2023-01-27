<<<<<<< HEAD
﻿// 3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <omp.h>

using namespace std;

int main()
{
	double t1, t2, dt;
   
	
	int size = 10000;
	cout << "--> ";
	cin >> size;
	omp_set_num_threads(2);
	int *arr_1 = new int[size];
	int *arr_2 = new int[size];
	int *arr_3 = new int[size];
	for (int i = 0; i < size; i++)
	{
		arr_1[i] = rand() % 25;
		arr_2[i] = rand() % 25;
	}
	t1 = omp_get_wtime();
#pragma omp parallel
	{
#pragma omp for schedule(dynamic, 1000)
		for (int i = 0; i < size; ++i)
		{
			arr_3[i] = arr_1[i] * arr_2[i];
		}
			
	}
	t2 = omp_get_wtime();
	dt = t2 - t1;
	cout << "time: " << dt << endl;
}


=======
﻿// 3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <omp.h>

using namespace std;

int main()
{
	double t1, t2, dt;
   
	
	int size = 10000;
	cout << "--> ";
	cin >> size;
	omp_set_num_threads(2);
	int *arr_1 = new int[size];
	int *arr_2 = new int[size];
	int *arr_3 = new int[size];
	for (int i = 0; i < size; i++)
	{
		arr_1[i] = rand() % 25;
		arr_2[i] = rand() % 25;
	}
	t1 = omp_get_wtime();
#pragma omp parallel
	{
#pragma omp for schedule(dynamic, 1000)
		for (int i = 0; i < size; ++i)
		{
			arr_3[i] = arr_1[i] * arr_2[i];
		}
			
	}
	t2 = omp_get_wtime();
	dt = t2 - t1;
	cout << "time: " << dt << endl;
}


>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
