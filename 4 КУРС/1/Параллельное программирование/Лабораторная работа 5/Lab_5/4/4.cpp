#include "pch.h"
#include <iostream>
#include <omp.h>
#include <vector>
#include <stdlib.h>
#include <cmath>

using namespace std;

int main()
{
	int size = pow(10, 6); int maxx = -1; double t1, t2, dt;
	vector <int> array_;
	for (int i = 0; i < size; i++)
	{
		array_.push_back(rand() % 25);
		//cout << array_.at(i) << " ";
	}
	//t1 = omp_get_wtime();
	//#pragma omp parallel reduction(max: maxx)
	//{
	//	for (int i = 0; i < size; i++)
	//	{
	//		//if (array_.at(i) > maxx)
	//		{
	//			//maxx = array_.at(i);
	//			maxx = max(array_.at(i), maxx);
	//		}
	//	}
	//}
	//t2 = omp_get_wtime();
	//dt = t2 - t1;
	//cout << "time reduction: " << dt << endl;

	for (int i = 0; i < size; i++)
	{
		array_.push_back(rand() % 25);
		//cout << array_.at(i) << " ";
	}

	t1 = omp_get_wtime();
#pragma omp parallel num_threads(12)
	{
		for (int i = 0; i < size; i++)
		{
#pragma omp critical
			{
				maxx = max(array_.at(i), maxx);
			}

		}
	}
	t2 = omp_get_wtime();
	dt = t2 - t1;
	cout << "time critical: " << dt << endl;

//	t1 = omp_get_wtime();
//#pragma omp parallel
//	{
//		for (int i = 0; i < size; i++)
//		{
//			#pragma omp atomic
//			maxx = max(array_.at(i), maxx);
//		}
//	}
//	t2 = omp_get_wtime();
//	dt = t2 - t1;
//	cout << "time atomic: " << dt << endl;
}