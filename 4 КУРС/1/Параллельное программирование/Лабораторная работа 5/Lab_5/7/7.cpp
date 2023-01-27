<<<<<<< HEAD
﻿// 7.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <omp.h>

#define SIZE 2000
#define NUM_THREAD 1

using namespace std;

int** matrix_1 = new int*[SIZE];
int** matrix_2 = new int*[SIZE];
int** result_matrix = new int* [SIZE];

void fillMatrixes()
{
    cout << "FILLING.." << endl;
    int max_threads = omp_get_max_threads();
    cout << "FILLING USE " << max_threads << " THREADS." << endl;
    #pragma omp parallel for num_threads(max_threads)
    for (int i = 0; i < SIZE; i++)
    {
        matrix_1[i] = new int[SIZE];
        matrix_2[i] = new int[SIZE];
        result_matrix[i] = new int[SIZE];
        for (int j = 0; j < SIZE; j++)
        {
            matrix_1[i][j] = rand() % 25;
            matrix_2[i][j] = rand() % 25;
            result_matrix[i][j] = 0;
        }
    }
    
    cout << "FILLING ENDED.." << endl << endl;
}


int main()
{
#ifdef _OPENMP
    printf("OpenMP is supported! %d\n", _OPENMP);
#else
    printf("OpenMP is not supported!\n");
#endif
    fillMatrixes();
    double t1 = omp_get_wtime();
#pragma omp parallel for num_threads(NUM_THREAD)
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            for (int k = 0; k < SIZE; k++)
            {
                result_matrix[i][j] += matrix_1[i][k] * matrix_2[k][j];
            }
        }
    }
    double t2 = omp_get_wtime();
    double dt = t2 - t1;
    cout << "time: " << dt << endl;

    for (int i = 0; i < SIZE; i++)
    {
        delete[] matrix_1[i];
        delete[] matrix_2[i];
        delete[] result_matrix[i];
    }
    delete[] matrix_1;
    delete[] matrix_2;
    delete[] result_matrix;
=======
﻿// 7.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <omp.h>

#define SIZE 2000
#define NUM_THREAD 1

using namespace std;

int** matrix_1 = new int*[SIZE];
int** matrix_2 = new int*[SIZE];
int** result_matrix = new int* [SIZE];

void fillMatrixes()
{
    cout << "FILLING.." << endl;
    int max_threads = omp_get_max_threads();
    cout << "FILLING USE " << max_threads << " THREADS." << endl;
    #pragma omp parallel for num_threads(max_threads)
    for (int i = 0; i < SIZE; i++)
    {
        matrix_1[i] = new int[SIZE];
        matrix_2[i] = new int[SIZE];
        result_matrix[i] = new int[SIZE];
        for (int j = 0; j < SIZE; j++)
        {
            matrix_1[i][j] = rand() % 25;
            matrix_2[i][j] = rand() % 25;
            result_matrix[i][j] = 0;
        }
    }
    
    cout << "FILLING ENDED.." << endl << endl;
}


int main()
{
#ifdef _OPENMP
    printf("OpenMP is supported! %d\n", _OPENMP);
#else
    printf("OpenMP is not supported!\n");
#endif
    fillMatrixes();
    double t1 = omp_get_wtime();
#pragma omp parallel for num_threads(NUM_THREAD)
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
        {
            for (int k = 0; k < SIZE; k++)
            {
                result_matrix[i][j] += matrix_1[i][k] * matrix_2[k][j];
            }
        }
    }
    double t2 = omp_get_wtime();
    double dt = t2 - t1;
    cout << "time: " << dt << endl;

    for (int i = 0; i < SIZE; i++)
    {
        delete[] matrix_1[i];
        delete[] matrix_2[i];
        delete[] result_matrix[i];
    }
    delete[] matrix_1;
    delete[] matrix_2;
    delete[] result_matrix;
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
}