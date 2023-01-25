#include <iostream>
#include <thread>
#include <mutex>

using namespace std;

#define TEST_COUNT 3
#define SIZE pow(10,8)
#define MIN_VALUE (int)pow(10,5)
#define MAX_VALUE (int)pow(10,6)
#define THREAD_COUNT 12

std::mutex mx;
int* array_ = new int[SIZE];

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
    for (int i = sqrt(number) + 1; i > 1; i--)
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

void function_(int number)
{
    std::cout << "Thread " << std::this_thread::get_id() << " start..." << std::endl;
    
	for (int i = number; i < SIZE; i += THREAD_COUNT)
	{
		array_[i] = maxPrimeDivider(array_[i]);
	}
    std::cout << "Thread " << std::this_thread::get_id() << " finish!" << std::endl;
    
    return;
}


int main()
{
    double averageTime = 0;
    for (int i = 0; i < TEST_COUNT; i++)
    {
        for (int i = 0; i < SIZE; i++)
        {
         array_[i] = (rand() % (MIN_VALUE + rand() % MAX_VALUE));
        }

        std::chrono::time_point<std::chrono::high_resolution_clock> start, end;
        start = std::chrono::high_resolution_clock::now();

        thread* threads = new thread[THREAD_COUNT];
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
    cin.get();
}