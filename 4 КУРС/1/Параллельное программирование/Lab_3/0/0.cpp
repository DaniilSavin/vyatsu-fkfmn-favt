<<<<<<< HEAD
﻿#include <iostream>
#include <thread>

using namespace std;

void foo(void)
{
	std::cout << "Thread start..." << std::endl;
	for (int i = 0; i < 10; ++i)
	{
		std::cout << "Thread id = " << std::this_thread::get_id()

			<< std::endl;

		std::this_thread::sleep_for(std::chrono::seconds(1));
	}
	std::cout << "Thread finish!" << std::endl;
	return;
}
int main()
{
	std::thread myTh(foo);
	std::cout << "Main thread id = " << std::this_thread::get_id()
		<< std::endl;
	myTh.detach();
=======
﻿#include <iostream>
#include <thread>

using namespace std;

void foo(void)
{
	std::cout << "Thread start..." << std::endl;
	for (int i = 0; i < 10; ++i)
	{
		std::cout << "Thread id = " << std::this_thread::get_id()

			<< std::endl;

		std::this_thread::sleep_for(std::chrono::seconds(1));
	}
	std::cout << "Thread finish!" << std::endl;
	return;
}
int main()
{
	std::thread myTh(foo);
	std::cout << "Main thread id = " << std::this_thread::get_id()
		<< std::endl;
	myTh.detach();
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
}