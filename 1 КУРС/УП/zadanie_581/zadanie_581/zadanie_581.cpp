
//#include "pch.h"
#include <iostream>
#include <cstdio>
#include <vector>

int main()
{
	int n;
	std::cin >> n;
	int x0, y0, x1, y1;
	std::cin >> x0 >> y0 >> x1 >> y1;
	int a = y1 - y0;
	int b = x0 - x1;
	int c = y0 * x1 - x0 * y1;
	std::vector<int> ans;
	for (int i = 1; i <= n; i++)
	{
		int x, y, r;
		std::cin >> x >> y >> r;
		if (1LL*(a*x + b * y + c)*(a*x + b * y + c) <= 1LL*(r * r)*(a*a + b * b))
		{
			ans.push_back(i);
		}
	}
	std::cout << int(ans.size())<< std::endl;
	for (int i = 0; i < (int)ans.size(); i++)
	{
		if (i > 0)
		{
			std::cout << " ";
		}
		std::cout << ans[i];
	}
}
