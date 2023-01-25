#include <iostream>
#include <thread>

using namespace std;

void foo(int k)
{
	std::cout << " ---- Thread " << k << " start..." << std::endl;
	for (int i = 0; i < 100; ++i)
	{
		std::cout << "Thread id = " << std::this_thread::get_id()
			<< "\t";
		//std::this_thread::sleep_for(std::chrono::milliseconds(1000));
	}
	std::cout << "\n---- Thread " << k << " finish!" << std::endl;
	return;
}

int main()
{
	std::cout << "Main thread id = " << std::this_thread::get_id() << std::endl;
	int P = 10;
	
	cout << "Input P: " << endl;
	cin >> P;
	thread* threads = new thread[P];
	for (int i = 0; i < P; i++)
	{
		threads[i] = thread(foo, i);
	}
	for (int i = 0; i < P; i++)
	{
		threads[i].join();
	}
}
