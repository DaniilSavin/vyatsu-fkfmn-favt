#include <iostream>
#include <thread>

using namespace std;

void foo(void)
{
	std::cout << "Thread 1 start..." << std::endl;
	for (int i = 0; i < 100; ++i)
	{
		if (i % 2 == 0)
		{
			cout << i << " - thread 1" << endl;
		}
		//std::this_thread::sleep_for(std::chrono::milliseconds(1000));
	}
	std::cout << "Thread 1 finish!" << std::endl;
	return;
}

void foo2(void)
{
	std::cout << "Thread 2 start..." << std::endl;
	for (int j = 0; j < 100; ++j)
	{
		if (j % 2 != 0)
		{
			cout << j << " - thread 2" << endl;
		}
		//std::this_thread::sleep_for(std::chrono::milliseconds(1000));

	}
	std::cout << "Thread 2 finish!" << std::endl;
	return;
}


int main()
{
	std::thread myTh(foo), myTh2(foo2);
	std::cout << "Main thread id = " << std::this_thread::get_id() << std::endl;


	myTh.join();
	myTh2.join();
}