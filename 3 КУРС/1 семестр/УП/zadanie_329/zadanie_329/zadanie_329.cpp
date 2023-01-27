#include "pch.h"
#include <iostream>

int main()
{
	int SIZE = 0, sum = 0, count=0;
	std::cin >> SIZE;
	int *Arr = new int [SIZE];
	int *B = new int[SIZE];
    for (int i = 0; i < SIZE; i++)
	{
		std::cin >> *(Arr + i);
	}
	int j = 0;
	for (int i = 0; i < SIZE; i++)
	{
		if (*(Arr + i) > 0)
		{
			sum += *(Arr + i);
			*(B + j) = i+1;
			j++;
		}
	}
	std::cout << sum << std::endl;
	for (int i = 0; i < j; i++)
	{
		std::cout <<*(B+i) << " ";
	}
}

