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
	int sum = 0;
	double sum2 = 0;
    double t1, t2, dt;
    t1 = omp_get_wtime();
    #pragma omp parallel num_threads($)
    {
        #pragma omp sections
        {
            #pragma omp section
            {
                #pragma omp parallel for num_threads(M)
                
                    //int sum = 0;
                    for (int i = 0; i < N; i++)
                    {
                        sum += i;
                    }
                
            }
            #pragma omp section
            {
                #pragma omp parallel for num_threads(K)
                
                    
                    for (int j = 0; j < N; j++)
                    {
                        sum2 += pow(vector.at(j), 2);
                    }
                    sum2 = sqrt(sum2);
                
            }
        }
    }
    t2 = omp_get_wtime();
    dt = t2 - t1;
    cout << "time: " << dt << endl;
	//cout <<sum << " " <<sum2 << endl;
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
	int sum = 0;
	double sum2 = 0;
    double t1, t2, dt;
    t1 = omp_get_wtime();
    #pragma omp parallel num_threads($)
    {
        #pragma omp sections
        {
            #pragma omp section
            {
                #pragma omp parallel for num_threads(M)
                
                    //int sum = 0;
                    for (int i = 0; i < N; i++)
                    {
                        sum += i;
                    }
                
            }
            #pragma omp section
            {
                #pragma omp parallel for num_threads(K)
                
                    
                    for (int j = 0; j < N; j++)
                    {
                        sum2 += pow(vector.at(j), 2);
                    }
                    sum2 = sqrt(sum2);
                
            }
        }
    }
    t2 = omp_get_wtime();
    dt = t2 - t1;
    cout << "time: " << dt << endl;
	//cout <<sum << " " <<sum2 << endl;
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
}