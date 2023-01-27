<<<<<<< HEAD
﻿// 6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <omp.h>
#include <vector>

#define MIN pow(10, 5)
#define MAX pow(10, 6)
#define NUM_THREAD 8

using namespace std;

int main()
{
    srand(time(0));
    setlocale(0, "");
	vector <int> vector;
    int N = 0; double t1, t2, dt;
    
    cout << "Input (N) >> ";
    while (!(cin >> N) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    for (int i = 0; i < N; i++)
    {
        vector.push_back(MIN + rand() % (int)MAX);
    }
    t1 = omp_get_wtime();
    #pragma omp parallel num_threads(NUM_THREAD)
    {
        int TMP_NUMBER = 0;
        for (int i = 0; i < N; i++)
        {
            if (vector.at(i) % 2 == 0)
                TMP_NUMBER = vector.at(i) / 2 ;
            else
            {
                int i;
                for (i = 3; i * i <= vector.at(i); ++i)
                    if (vector.at(i) % i == 0) 
                        break;
                if (i * i <= vector.at(i))
                    TMP_NUMBER = vector.at(i) / i;
                else cout << "число простое \n";
            }
        }
    }
    t2 = omp_get_wtime();
    dt = t2 - t1;
    cout << "time: " << dt << endl;


}

=======
﻿// 6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <omp.h>
#include <vector>

#define MIN pow(10, 5)
#define MAX pow(10, 6)
#define NUM_THREAD 8

using namespace std;

int main()
{
    srand(time(0));
    setlocale(0, "");
	vector <int> vector;
    int N = 0; double t1, t2, dt;
    
    cout << "Input (N) >> ";
    while (!(cin >> N) || (cin.peek() != '\n'))
    {
        cin.clear();
        while (cin.get() != '\n');
        cout << "Input error! \nRetry input >> ";
    }
    for (int i = 0; i < N; i++)
    {
        vector.push_back(MIN + rand() % (int)MAX);
    }
    t1 = omp_get_wtime();
    #pragma omp parallel num_threads(NUM_THREAD)
    {
        int TMP_NUMBER = 0;
        for (int i = 0; i < N; i++)
        {
            if (vector.at(i) % 2 == 0)
                TMP_NUMBER = vector.at(i) / 2 ;
            else
            {
                int i;
                for (i = 3; i * i <= vector.at(i); ++i)
                    if (vector.at(i) % i == 0) 
                        break;
                if (i * i <= vector.at(i))
                    TMP_NUMBER = vector.at(i) / i;
                else cout << "число простое \n";
            }
        }
    }
    t2 = omp_get_wtime();
    dt = t2 - t1;
    cout << "time: " << dt << endl;


}

>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
