<<<<<<< HEAD
﻿#include <iostream>
#include <omp.h>

#define SIZE 1000
#define NUM_THREAD 12

using namespace std;

int** matrix_1 = new int* [SIZE];
//int** matrix_2 = new int* [SIZE];
int* result_matrix = new int[SIZE];

void fillMatrixes()
{
    cout << "FILLING.." << endl;
    int max_threads = omp_get_max_threads();
    cout << "FILLING USE " << max_threads << " THREADS." << endl;
#pragma omp parallel num_threads(max_threads)
    {
        for (int i = 0; i < SIZE; i++)
        {
            matrix_1[i] = new int[SIZE];
           // matrix_2[i] = new int[SIZE];
           // result_matrix[i] = new int[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                matrix_1[i][j] = rand() % 25;
            //    matrix_2[i][j] = rand() % 25;
            //    result_matrix[i][j] = 0;
            }
        }
    }
    cout << "FILLING ENDED.." << endl << endl;
}

void findMin()
{
    int max = -1;
#pragma omp parallel num_threads(NUM_THREAD)
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (matrix_1[i][j] > max)
                {
                    max = matrix_1[i][j];
                }
            }
            result_matrix[i] = max;
            max = -1;
        }
    }
    max = -1;
#pragma omp parallel num_threads(NUM_THREAD)
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (result_matrix[i] > max)
            {
                max = result_matrix[i];
            }
        }
    }
}


int main()
{
    for (int i = 0; i < SIZE; i++)
    {
        delete[] matrix_1[i];
       // delete[] matrix_2[i];
       // delete[] result_matrix[i];
    }
    delete[] matrix_1;
  //  delete[] matrix_2;
  //  delete[] result_matrix;
}

=======
﻿#include <iostream>
#include <omp.h>

#define SIZE 1000
#define NUM_THREAD 12

using namespace std;

int** matrix_1 = new int* [SIZE];
//int** matrix_2 = new int* [SIZE];
int* result_matrix = new int[SIZE];

void fillMatrixes()
{
    cout << "FILLING.." << endl;
    int max_threads = omp_get_max_threads();
    cout << "FILLING USE " << max_threads << " THREADS." << endl;
#pragma omp parallel num_threads(max_threads)
    {
        for (int i = 0; i < SIZE; i++)
        {
            matrix_1[i] = new int[SIZE];
           // matrix_2[i] = new int[SIZE];
           // result_matrix[i] = new int[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                matrix_1[i][j] = rand() % 25;
            //    matrix_2[i][j] = rand() % 25;
            //    result_matrix[i][j] = 0;
            }
        }
    }
    cout << "FILLING ENDED.." << endl << endl;
}

void findMin()
{
    int max = -1;
#pragma omp parallel num_threads(NUM_THREAD)
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if (matrix_1[i][j] > max)
                {
                    max = matrix_1[i][j];
                }
            }
            result_matrix[i] = max;
            max = -1;
        }
    }
    max = -1;
#pragma omp parallel num_threads(NUM_THREAD)
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (result_matrix[i] > max)
            {
                max = result_matrix[i];
            }
        }
    }
}


int main()
{
    for (int i = 0; i < SIZE; i++)
    {
        delete[] matrix_1[i];
       // delete[] matrix_2[i];
       // delete[] result_matrix[i];
    }
    delete[] matrix_1;
  //  delete[] matrix_2;
  //  delete[] result_matrix;
}

>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
