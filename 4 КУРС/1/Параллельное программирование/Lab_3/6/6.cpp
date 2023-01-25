#include <iostream>
#include <thread>
#include <mutex>

using namespace std;

#define SIZE pow(10, 9)
#define TEST_COUNT 3
#define THREAD_COUNT 8

int* array_ = new int[SIZE];
std::mutex mx; int itterator = 0;
double sum = 0;

void function_(int number)
{
	double sum2 = 0;
	for (int i = number; i <= SIZE; i += THREAD_COUNT)
	{	
		sum2 += i;	
	}
	mx.lock();
	sum+=sum2;
	mx.unlock();
}

int main()
{
    std::chrono::time_point<std::chrono::high_resolution_clock> start, end;
    double averageTime = 0;
    thread* threads = new thread[THREAD_COUNT];
    for (int i = 0; i < TEST_COUNT; i++)
    {
        sum = 0;
        start = std::chrono::high_resolution_clock::now();
        for (int i = 0; i < THREAD_COUNT; i++)
        {
            threads[i] = thread(function_, i);
        }
        for (int i = 0; i < THREAD_COUNT; i++)
        {
            threads[i].join();
        }
        end = std::chrono::high_resolution_clock::now();
        std::chrono::duration<double> diff = end - start;
        averageTime += diff.count();
        cout << diff.count() << endl;
    }
    cout << "average time = " << (averageTime / TEST_COUNT) << endl;
    cout << "SUM = " << sum << endl;
}