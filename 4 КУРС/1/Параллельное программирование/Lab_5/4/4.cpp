// 4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <omp.h>
#include <vector>
#include <stdlib.h>

using namespace std;

int main()
{
	int size = 1000; int maxx = -1; double t1, t2, dt;
	vector <int> array_;
	for (int i = 0; i < size; i++)
	{
		array_.push_back(rand() % 25);
		//cout << array_.at(i) << " ";
	}
	t1 = omp_get_wtime();
	#pragma omp parallel reduction(max: maxx)
	{
		for (int i = 0; i < size; i++)
		{
			//if (array_.at(i) > maxx)
			{
				//maxx = array_.at(i);
				maxx = max(array_.at(i), maxx);
			}
		}
	}
	t2 = omp_get_wtime();
	dt = t2 - t1;
	cout << "time reduction: " << dt << endl;

	for (int i = 0; i < size; i++)
	{
		array_.push_back(rand() % 25);
		//cout << array_.at(i) << " ";
	}

	t1 = omp_get_wtime();
	#pragma omp parallel
	{
		for (int i = 0; i < size; i++)
		{
			//if (array_.at(i) > maxx)
			{
				//maxx = array_.at(i);
				#pragma omp critical
				{
					maxx = max(array_.at(i), maxx);
				}
			}
		}
	}
	t2 = omp_get_wtime();
	dt = t2 - t1;
	cout << "time critical: " << dt << endl;
	
}


