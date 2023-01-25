#include "pch.h"
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <thread>
#include <mutex>

using namespace std;

int countOfArrays = 0;
int sumByLine = 0;
string inputFileName = "input.txt";
string outputFileName = "output.txt";
vector <string> numbers;
vector <int> sum;
mutex inputMutex, outputMutex;
thread thread1, thread2;
string line = "";

void calcSum();
void writingToFile(string outputFileName);

void readingFromFile(string inputFileName)
{
	cout << "Первый поток стартовал. " << endl;
	ifstream in;
	int numberOfLinesRead = 0;
	in.open(inputFileName);
	getline(in, line);
	countOfArrays = stoi(line);
	inputMutex.lock();
	while (numberOfLinesRead != countOfArrays)
	{
		getline(in, line);
		numbers.push_back(line);
		numberOfLinesRead++;
	}
	inputMutex.unlock();
	while (sum.size() == 0)	{}	
	outputMutex.lock();
	writingToFile(outputFileName);
	outputMutex.unlock();
	cout << "Первый поток закончился. " << endl;
	in.close();
}

void writingToFile(string outputFileName)
{
	ofstream myfile;
	myfile.open(outputFileName, std::ios::app);
	for (int i = 0; i < sum.size(); i++)
	{
		myfile << sum[i] << "\n";
	}
	myfile.close();
}
//sum += atoi(string({ (char)strV[i][j] }).c_str());
void calcSum()
{
	while (numbers.size()==0)	{	}
	cout << "Второй поток стартовал. " << endl;
	char* ptr = 0;
	char* arr = new char[numbers[0].size()];
	outputMutex.lock();
	for (int i = 0; i < numbers.size(); i++)
	{
		sumByLine = 0;		
		strcpy(arr, numbers[i].c_str());
		//inputMutex.lock();
		ptr = strtok(arr, " ");
		//inputMutex.unlock();
		while (ptr)
		{
			sumByLine += atoi(ptr);
			ptr = strtok(0, " ");
		}
		sum.push_back(sumByLine);
	}
	cout << "Второй поток закончился." << endl;
	outputMutex.unlock();
}

int main()
{
	setlocale(LC_ALL, "rus");
	thread2 = thread(calcSum);
	readingFromFile(inputFileName);
	//thread1 = thread(readingFromFile, inputFileName);
	//thread1.join();

	thread2.detach();
	
	//cin.get();
}

