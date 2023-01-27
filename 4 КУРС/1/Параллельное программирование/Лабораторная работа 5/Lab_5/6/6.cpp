<<<<<<< HEAD
﻿// 6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <omp.h>
#include <vector>
#include <ctime>

#define MIN pow(10, 5)
#define MAX pow(10, 6)
#define NUM_THREAD 4
#define SIZE 2*pow(10, 4)

using namespace std;

bool isPrime(int number)
{
	for (int i = 2; i < number / 2 + 1; i++)
	{
		if (number % i == 0)
		{
			return false;
		}
	}
	return true;
}

int maxPrimeDivider(int number)
{
	if (isPrime(number))
	{
		return number;
	}
	int max = 1;
	for (int i = number/2; i > 1; i--)
	{
		if (number % i == 0)
		{

			if (isPrime(i) && max < i) max = i;
			if (i != (number / i) && number % (number / i) == 0)
			{

				if (isPrime(
					number % (number / i)
				) && max <
					number % (number / i)
					) max =
					number % (number / i);
			}
		}
	}
	return max;
}


int main()
{
#ifdef _OPENMP
	printf("OpenMP is supported! %d\n", _OPENMP);
#else
	printf("OpenMP is not supported!\n");
#endif

    srand(time(0));
    setlocale(0, "");
	
    int N = SIZE; double t1, t2, dt;
    //cout << "Input (N) >> ";
    //while (!(cin >> N) || (cin.peek() != '\n'))
    //{
    //    cin.clear();
    //    while (cin.get() != '\n');
    //    cout << "Input error! \nRetry input >> ";
    //}
	int *arr = new int [N];
    for (int i = 0; i < N; i++)
    {
		arr[i] = MIN + rand() % (int)MAX;
    }
	
    t1 = omp_get_wtime();
	int nt = NUM_THREAD;
	
#pragma omp parallel for num_threads(NUM_THREAD) 
		for (int i = 0; i < N; i++)
		{
			arr[i] = maxPrimeDivider(arr[i]);
			
		}
    
    t2 = omp_get_wtime();
    dt = t2 - t1;
    cout << "time: " << dt << endl;
	delete[] arr;
}

=======
﻿// 6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <omp.h>
#include <vector>
#include <ctime>

#define MIN pow(10, 5)
#define MAX pow(10, 6)
#define NUM_THREAD 4
#define SIZE 2*pow(10, 4)

using namespace std;

bool isPrime(int number)
{
	for (int i = 2; i < number / 2 + 1; i++)
	{
		if (number % i == 0)
		{
			return false;
		}
	}
	return true;
}

int maxPrimeDivider(int number)
{
	if (isPrime(number))
	{
		return number;
	}
	int max = 1;
	for (int i = number/2; i > 1; i--)
	{
		if (number % i == 0)
		{

			if (isPrime(i) && max < i) max = i;
			if (i != (number / i) && number % (number / i) == 0)
			{

				if (isPrime(
					number % (number / i)
				) && max <
					number % (number / i)
					) max =
					number % (number / i);
			}
		}
	}
	return max;
}


int main()
{
#ifdef _OPENMP
	printf("OpenMP is supported! %d\n", _OPENMP);
#else
	printf("OpenMP is not supported!\n");
#endif

    srand(time(0));
    setlocale(0, "");
	
    int N = SIZE; double t1, t2, dt;
    //cout << "Input (N) >> ";
    //while (!(cin >> N) || (cin.peek() != '\n'))
    //{
    //    cin.clear();
    //    while (cin.get() != '\n');
    //    cout << "Input error! \nRetry input >> ";
    //}
	int *arr = new int [N];
    for (int i = 0; i < N; i++)
    {
		arr[i] = MIN + rand() % (int)MAX;
    }
	
    t1 = omp_get_wtime();
	int nt = NUM_THREAD;
	
#pragma omp parallel for num_threads(NUM_THREAD) 
		for (int i = 0; i < N; i++)
		{
			arr[i] = maxPrimeDivider(arr[i]);
			
		}
    
    t2 = omp_get_wtime();
    dt = t2 - t1;
    cout << "time: " << dt << endl;
	delete[] arr;
}

>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
