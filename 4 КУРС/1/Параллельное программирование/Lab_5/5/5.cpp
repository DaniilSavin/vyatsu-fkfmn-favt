<<<<<<< HEAD
﻿#include <iostream>
#include <omp.h>
#include <vector>

using namespace std;

int main()
{
    vector <int> vector;
    int M, K, N = 0;

    cout << "Input num of threads (M) >> ";
    while (!(cin >> M) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    cout << "Input num of threads (K) >> ";
    while (!(cin >> K) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    cout << "Input (N) >> ";
    while (!(cin >> N) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    for (int i = 0; i < N; i++)
    {
        vector.push_back(rand() % 25);
    }
    int $ = M + K;
    omp_set_nested(1);
    #pragma omp parallel num_threads($)
    {
        #pragma omp sections
        {
            #pragma omp section
            {
                #pragma omp parallel num_threads(M)
                {
                    int sum = 0;
                    for (int i = 0; i < N; i++)
                    {
                        sum += i;
                    }
                }
            }
            #pragma omp section
            {
                #pragma omp parallel num_threads(K)
                {
                    int sum2 = 0;
                    for (int j = 0; j < N; j++)
                    {
                        sum2 += pow(vector.at(j), 2);
                    }
                    sum2 = sqrt(sum2);
                }
            }
        }
    }
}


=======
﻿#include <iostream>
#include <omp.h>
#include <vector>

using namespace std;

int main()
{
    vector <int> vector;
    int M, K, N = 0;

    cout << "Input num of threads (M) >> ";
    while (!(cin >> M) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    cout << "Input num of threads (K) >> ";
    while (!(cin >> K) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    cout << "Input (N) >> ";
    while (!(cin >> N) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    for (int i = 0; i < N; i++)
    {
        vector.push_back(rand() % 25);
    }
    int $ = M + K;
    omp_set_nested(1);
    #pragma omp parallel num_threads($)
    {
        #pragma omp sections
        {
            #pragma omp section
            {
                #pragma omp parallel num_threads(M)
                {
                    int sum = 0;
                    for (int i = 0; i < N; i++)
                    {
                        sum += i;
                    }
                }
            }
            #pragma omp section
            {
                #pragma omp parallel num_threads(K)
                {
                    int sum2 = 0;
                    for (int j = 0; j < N; j++)
                    {
                        sum2 += pow(vector.at(j), 2);
                    }
                    sum2 = sqrt(sum2);
                }
            }
        }
    }
}


>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
