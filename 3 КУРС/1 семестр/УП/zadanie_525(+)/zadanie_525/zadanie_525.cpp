
//#include "pch.h"
#include <iostream>
#include <vector>
#include <cstdio>
#include <cassert>

int main()
{
	int n;
	std::cin >> n;
	const int MAX_P = 9;
	assert(n < (1 << (MAX_P + 1)));
	std::vector<std::vector<int>> count(1 + n, std::vector<int>(1+MAX_P));
	
	for (int num = 0; num <= n; num++) {
		for (int maxP = 0; maxP<10; maxP++)
		{
			if (num == 0 && maxP==0)
			{
				count[num][maxP] = 1;
			}
			else {
				count[num][maxP] = 0;
				if (maxP - 1 >= 0) {
					count[num][maxP] += count[num][maxP - 1];
				}
				if (num - (1 << maxP) >= 0)
				{
					count[num][maxP] += count[num - (1 << maxP)][maxP];
				}
				
			}
		}
	}
	std::cout << count.back().back();
}
