<<<<<<< HEAD
﻿#include <iostream>
#include <queue>
#include <iostream>
#include <thread>
#include <mutex>
#include <random>

using namespace std;


#define READERS_COUNT  2
#define WRITTERS_COUNT 2

std::mutex readerCountAcces;
int storage = 0;
int readerCount = 0;

#define queueMaxSize 10
std::mutex mx;

void ReaderThread(int threadId)
{
	while (true)
	{
		mx.lock();
		if (readerCount != -1)
		{
			readerCount++;
			cout << "reader thread #" << threadId << " read this value: " << storage << " current readers: " << readerCount << endl;
			mx.unlock();
			std::this_thread::sleep_for(std::chrono::milliseconds(rand() % 20000));

			mx.lock();
			readerCount--;
			mx.unlock();
		}
		else mx.unlock();
		std::this_thread::sleep_for(std::chrono::milliseconds(1000 + rand() % 10000));
	}
}

void WriterThread(int threadId)
{
	while (true)
	{
		mx.lock();
		if (readerCount == 0)
		{
			readerCount = -1;
			mx.unlock();
			int oldValue = storage;
			storage = rand() % 100;
			cout << "writer thread #" << threadId << " changed value from " << oldValue << " to " << storage << endl;

			mx.lock();
			readerCount = 0;
			mx.unlock();
		}
		else mx.unlock();
		std::this_thread::sleep_for(std::chrono::milliseconds(1000 + rand() % 10000));
	}
}

int main()
{
	srand(time(NULL));
	setlocale(0, "");
	vector<thread>  readersThreads;
	int idCounter = 0;
	for (int i = 0; i < READERS_COUNT; i++)
	{
		readersThreads.push_back(thread(ReaderThread, i));
	}
	vector<thread>  writersThreads;

	for (int i = 0; i < WRITTERS_COUNT; i++)
	{
		writersThreads.push_back(thread(WriterThread, i));
	}
	for (int i = 0; i < READERS_COUNT; i++)
	{
		readersThreads[i].join();
	}
	for (int i = 0; i < WRITTERS_COUNT; i++)
	{
		writersThreads[i].join();
	}
	cin.get();
}
=======
﻿#include <iostream>
#include <queue>
#include <iostream>
#include <thread>
#include <mutex>
#include <random>

using namespace std;


#define READERS_COUNT  2
#define WRITTERS_COUNT 2

std::mutex readerCountAcces;
int storage = 0;
int readerCount = 0;

#define queueMaxSize 10
std::mutex mx;

void ReaderThread(int threadId)
{
	while (true)
	{
		mx.lock();
		if (readerCount != -1)
		{
			readerCount++;
			cout << "reader thread #" << threadId << " read this value: " << storage << " current readers: " << readerCount << endl;
			mx.unlock();
			std::this_thread::sleep_for(std::chrono::milliseconds(rand() % 20000));

			mx.lock();
			readerCount--;
			mx.unlock();
		}
		else mx.unlock();
		std::this_thread::sleep_for(std::chrono::milliseconds(1000 + rand() % 10000));
	}
}

void WriterThread(int threadId)
{
	while (true)
	{
		mx.lock();
		if (readerCount == 0)
		{
			readerCount = -1;
			mx.unlock();
			int oldValue = storage;
			storage = rand() % 100;
			cout << "writer thread #" << threadId << " changed value from " << oldValue << " to " << storage << endl;

			mx.lock();
			readerCount = 0;
			mx.unlock();
		}
		else mx.unlock();
		std::this_thread::sleep_for(std::chrono::milliseconds(1000 + rand() % 10000));
	}
}

int main()
{
	srand(time(NULL));
	setlocale(0, "");
	vector<thread>  readersThreads;
	int idCounter = 0;
	for (int i = 0; i < READERS_COUNT; i++)
	{
		readersThreads.push_back(thread(ReaderThread, i));
	}
	vector<thread>  writersThreads;

	for (int i = 0; i < WRITTERS_COUNT; i++)
	{
		writersThreads.push_back(thread(WriterThread, i));
	}
	for (int i = 0; i < READERS_COUNT; i++)
	{
		readersThreads[i].join();
	}
	for (int i = 0; i < WRITTERS_COUNT; i++)
	{
		writersThreads[i].join();
	}
	cin.get();
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
