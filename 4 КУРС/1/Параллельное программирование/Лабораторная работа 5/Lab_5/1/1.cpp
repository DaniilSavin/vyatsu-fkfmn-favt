// 1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

#include <omp.h>

using namespace std;

int main() {
	int nthreads, tid;
	// Создание параллельной области
#pragma omp parallel private(tid)
	{
		// печать номера потока
		tid = omp_get_thread_num();
		printf("Hello World from thread = %d\n", tid);
		// Печать количества потоков – только master
		if (tid == 0) {
			nthreads = omp_get_num_threads();
			printf("Number of threads = %d\n", nthreads);
		}

		

	} // Завершение параллельной области
}


//int main() {
//
//
//
//	int nthreads, tid;
//	int num_threads = 0;
//	int normal_num_threads = omp_get_num_procs();
//	cout << "--> ";
//	cin >> num_threads;
//	if (num_threads > normal_num_threads)
//	{
//		cout << "Optimal number of threads: " << normal_num_threads << ", but u want: " << num_threads << endl;
//	}
//	omp_set_num_threads(num_threads);
//	// Создание параллельной области
//#pragma omp parallel private(tid)
//	{
//		// печать номера потока
//		tid = omp_get_thread_num();
//		printf("Hello World from thread = %d\n", tid);
//		// Печать количества потоков – только master
//		if (tid == 0) {
//			nthreads = omp_get_num_threads();
//			printf("Number of threads = %d\n", nthreads);
//		}
//
//		
//
//	} // Завершение параллельной области
//}