#include <iostream>
#include <thread>
#include <mutex>
#include <random>

using namespace std;

const int DIMM = 10000;

int** A = new int* [DIMM];
int* B = new int [DIMM];
int* res = new int[DIMM];

#define TEST_COUNT 3
int thread_count = 12;

void clear()
{
    //cout << "Start clear.." << endl;
    for (int i = 0; i < DIMM; i++)
    {
        B[i] = 0;
        res[i] = 0;
       // A2[i] = 0;
        for (int j = 0; j < DIMM; j++)
        {
            A[i][j] = 0;
        }
    }
}

void display(int** A)
{
    cout << endl;
    for (int i = 0; i < DIMM; i++)
    {
        for (int j = 0; j < DIMM; j++)
        {
           cout << A[i][j] << " ";
        }
        cout << endl;
    }
}

void display(int* A)
{
    cout << endl;
    for (int i = 0; i < DIMM; i++)
    {
        
            cout << A[i] << " ";
        
    }
}

void start_()
{
    srand(time(0));
    for (int i = 0; i < DIMM; i++)
    {
        A[i] = new int[DIMM];
    }
}

void init()
{
	srand(time(0));
	for (int i = 0; i < DIMM; i++)
	{
        B[i] = rand() % 25;
        res[i] = 0;
		for (int j = 0; j < DIMM; j++)
		{
			A[i][j] = rand() % 25;          
		}
	}
}

void multiplication(int** A, int* B)
{
    cout << "Start mult.." << endl;
    for (int i = 0; i < DIMM; ++i)
    { 
        for (int j = 0; j < DIMM; ++j)
        {
            res[i] += A[i][j] * B[j];
        }
    }
}

void multiplication2(int number)
{
    cout << "Start mult2.." << endl;
    int i, j;
        for (i = number; i < DIMM;i+= thread_count) {
            
            for ( j = 0; j < DIMM; ++j)
            {
				res[i] += A[i][j] * B[j];
            }
        }
}

int main()
{
	std::cout << "The number of concurrent threads is " << thread_count << "\n";
    std::chrono::time_point<std::chrono::high_resolution_clock> start, end;
    double averageTime = 0;
    start_();
   /* for (int i = 0; i < TEST_COUNT; i++)
    {
        init();
        start = std::chrono::high_resolution_clock::now();
        multiplication(A, B);
        end = std::chrono::high_resolution_clock::now();
        std::chrono::duration<double> diff = end - start;
        averageTime += diff.count();
        cout << diff.count() << endl;
        clear();
    }
    cout << "average time = " << (averageTime / TEST_COUNT) << endl;*/
    averageTime = 0;
	thread *threads = new thread[thread_count];
    for (int i = 0; i < TEST_COUNT; i++)
    {
        init();
        start = std::chrono::high_resolution_clock::now();
		for (int i = 0; i < thread_count; i++)
		{
			threads[i] = thread(multiplication2, i);
		}
		for (int i = 0; i < thread_count; i++)
		{
			threads[i].join();
		}
        end = std::chrono::high_resolution_clock::now();

        std::chrono::duration<double> diff = end - start;
        averageTime += diff.count();
        cout << diff.count() << endl;
        clear();
    }
    cout << "average time = " << (averageTime / TEST_COUNT) << endl;
    for (int i = 0; i < DIMM; ++i) {
        delete[] A[i];
    }
    delete[] A;
    delete[] B;
    delete[] res;
    cin.get();
}