// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "stdlib.h" 
#include "math.h" 

using namespace std;

int to_binary(int n);
int calculate(int N, int K);

int rezcount = 0;

int main()
{
	
	int N, K;
	cin >> N >> K;
	calculate(N, K);
	int result = rezcount;
	cout << result;
	return 0;
}

int calculate(int N, int K)
{
	for (int i = 1; i <= N; i++)
	{
		int count = 0;
		int temp = to_binary(i);
		
		while (temp != 0)
		{
			if (temp % 10 == 0) count++;
			temp /= 10;
		}
		
		if (count == K) rezcount++;
	}
	return rezcount;
}

int to_binary(int n)
{
	int c;
	int* A;
	int size = 0;
	int ndublicate = n;
	while (n != 0) {
		c = n % 2;
		n /= 2;
		size++;
	}
	A = new int[size];
	int i = 0;
	while (ndublicate != 0) {
		*(A + i) = ndublicate % 2;
		ndublicate /= 2;
		i++;
	}
	int result = 0;
	for (i = 0; i < size; i++)
	{
		result += *(A + i)*(pow(10, i));
	}
	return result;
}