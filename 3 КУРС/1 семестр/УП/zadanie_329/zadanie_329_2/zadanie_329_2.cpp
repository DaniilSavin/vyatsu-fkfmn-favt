
#include "pch.h"
#include <iostream>
#include <vector>

int main()
{
	int n;
	std::cin >> n;
	std::vector<int> a(1 + n);
	a[0] = 0;
	for (int i = 1; i <= n; i++)
	{
		std::cin >> a[i];
	}
	std::vector<int> maxsumfron(1 + n);
	std::vector<int> next(1 + n);
	maxsumfron[n] = a[n];
	next[n] = 0;
	maxsumfron[n-1] = a[n-1]+a[n];
	next[n-1] = n;
	for (int i = n - 2; i >= 0; i--)
	{
		if (maxsumfron[i + 1] > maxsumfron[i + 2])
		{
			maxsumfron[i] = a[i] + maxsumfron[i + 1];
			next[i] = i + 1;
		}
		else
		{
			maxsumfron[i] = a[i] + maxsumfron[i + 2];
			next[i] = i + 2;
		}
	}
	std::cout << maxsumfron[0]<<std::endl;
	for (int i = next[0]; i != n; i = next[i])
	{
		std::cout << i <<" ";
	}
	std::cout << n;
}


