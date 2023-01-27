﻿#include <iostream>
#include <mpi.h>
#include <vector>
#include <clocale>
#include <random>
using namespace std;
int main(int argc, char* argv[])
{
    const int N = 3, M = 3, a = 10, b = 100;
    int rows = N;
    int** array = new int* [rows];
    for (int j = 0; j < rows; j++)
        array[j] = new int[M];
    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<> dis(a, b);
    MPI_Init(&argc, &argv);
    MPI_Request request;
    MPI_Status status;
    int rank, size;
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    //каждый процесс генерирует свою строку массива
    for (int j = 0; j < M; j++)
    {
        array[rank][j] = dis(gen);
        cout << array[rank][j] << " ";
    }
    cout << endl;

    //каждый процесс передает остальным элементы кроме элементов диагонали [0][0] и тд.
    for (int j = 0; j < M; j++)
    {
        if (rank != j)
        {
            MPI_Send(&array[rank][j], 1, MPI_INT, j, 0, MPI_COMM_WORLD);
            cout << "process: " << rank << " send number to process : " << j << ": " << array[rank][j] << endl;
        }
    }

    //каждый процесс принимает элемент кроме элементов диагонали
    for (int j = 0; j < M; j++)
    {
        if (rank != j)
        {
            MPI_Recv(&array[rank][j], 1, MPI_INT, j, 0, MPI_COMM_WORLD, &status);
            cout << "process: " << rank << " recieve number:  " << array[rank][j] << endl;
        }
    }
    cout << endl;
    MPI_Finalize();

    for (int j = 0; j < N; j++)
    {
        cout << array[rank][j] << " ";
    }
    cout << endl;
    return 0;
}
