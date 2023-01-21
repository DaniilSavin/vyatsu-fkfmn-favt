#include "pch.h"
#include <iostream>
#include <cstdio>
#include <set>
#include <vector>
#include <cstdlib>
#include <algorithm>
#include <cassert>

bool nextSplit(std::vector<std::vector<int>> &a)
{
	std::vector<int> free;
	for (int m = (int)a.size() - 1; m >= 0; m--)
	{
		int last = a[m].back();
		std::sort(free.begin(), free.end());
		int found = -1;
		for (int i = 0; i < (int)free.size(); i++)
		{
			if (free[i] > last)
			{
				found = free[i];

				break;
			}
		}

		if (found != -1)
		{
			a[m].push_back(found);
			for (int x : free)
			{
				if (x != found)
				{
					a.push_back(std::vector<int>(1, x));
				}
			}
			return true;
		}
		if (a[m].size() == 1)
		{
			free.push_back(last);
			a.pop_back();
		}
		else
		{
			free.push_back(last);
			a[m].pop_back();
			for (int i = (int)a[m].size() - 1; i >= 1; i--)
			{
				int cur = a[m][i];
				std::sort(free.begin(), free.end());
				found = -1;
				for (int i = 0; i < (int)free.size(); i++)
				{
					if (free[i] > cur)
					{
						found = free[i];
						break;
					}
				}
				if (found != -1)
				{
					a[m][i] = found;
					for (int x : free)
					{
						if (x == found)
						{
							x = cur;
						}
						a.push_back(std::vector<int>(1, x));
					}
					return true;
				}
				free.push_back(cur);
				a[m].pop_back();
			}
			free.push_back(a[m][0]);
			a.pop_back();
		}
	}
	std::sort(free.begin(), free.end());

	for (int x : free)
	{
        a.push_back(std::vector<int>(1, x));
	}
	return false;
}

int main()
{
	bool first = true;
	while (true)
	{
		int n, nLines;
		scanf("%d %d ",&n, &nLines);
		if (nLines == 0)
		{
			break;
		}
		if (first)
		{
			first = false;
		}
		else
		{
			printf("\n");
		}
		std::vector<std::vector<int>> a(nLines);
		for (int i = 0; i < nLines; i++)
		{
			int cur = 0;
			while (true)
			{
				int c = getchar();
				std::cout << "c= " << c << std::endl;
				if ('0' <= c && c <= '9')
				{
                  cur = cur * 10 + (c - '0');
				  
				}
				else
				{
					if (cur > 0)
					{
						a[i].push_back(cur);
						cur = 0;
						std::cout << "cur= " << cur << std::endl;
					}
					if (c == '\n')
					{
						break;
					}
				}
	

			}
		}
		nextSplit(a);
		printf("%d %d\n", n, (int)a.size());
		for (auto line : a)
		{
			for (int i = 0; i < (int)line.size(); i++)
			{
				if (i > 0)
				{
					printf(" ");
				}
				printf("%d", line[i]);
			}
			printf("\n");
		}
	}
	system("pause");
}
