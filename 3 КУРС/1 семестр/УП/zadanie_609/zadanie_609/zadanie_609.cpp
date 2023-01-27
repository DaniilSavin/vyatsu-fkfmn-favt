
//#include "pch.h"
#include <iostream>
#include <cstdio>
#include <set>
#include <vector>
#include <cstdlib>
#include <algorithm>
#include <cassert>


void research()
{
	std::set<std::set<std::vector<int>>> set;
	{
		std::vector<int> v{ 1, 2, 3, 4, 5 };
		std::set<std::vector<int>> s{ v };
		set.insert(s);
	}
	while (true)
	{
		bool changed = false;
		for (auto x : set)
		{
			for (auto v : x)
			{
				if (v.size() > 1)
				{
					
					for (int code = 1; code < (1 << v.size()) - 1; code++)
					{
						std::vector<int> v0;
						std::vector<int> v1;
						for (int i = 0; i < (int)v.size(); i++)
						{
							if (((code >> i) & 1) == 0)
							{
								v0.push_back(v[i]);

							}
							else
							{
								v1.push_back(v[i]);
							}
						}
						auto y = x;
						y.erase(v);
						y.insert(v0);
						y.insert(v1);
						if (set.count(y) == 0)
						{
							set.insert(y);
							changed = true;
							break;
						}
					}
				}
			}
			if (changed)
			{
				break;
			}
		}
		if (!changed)
		{
			break;
		}
	}
	std::cout << "size= " << (int)set.size() << std::endl;
	for (auto x:set)
	{
		for (auto v : x)
		{
			for (int value : v)
			{
				printf("%d ", value);
			}
			std::cout << "/ ";
		}
		std::cout << std::endl;
	}
	std::exit(0);
}

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
			assert(a[m].size() == 1);
			free.push_back(a[m][0]);
			a.pop_back();
		}
	}
	assert(a.size() == 0);
	std::sort(free.begin(), free.end());

	for (int x : free)
	{

		a.push_back(std::vector<int>(1, x));
	}
	return false;
}


void research2()
{
	std::vector<std::vector<int>> a{
		std::vector<int>{1},
		std::vector<int>{2},
		std::vector<int>{3},
		std::vector<int>{4},
		std::vector<int>{5}};
	bool end = false;
	while (true)
	{
	
		for (auto v : a)
		{
			for (int value : v)
			{
				printf("%d ", value);
			}
			std::cout << ": ";
		}
		std::cout << std::endl;
		if (end)
		{
			break;
		}
		end = !nextSplit(a);
	}
	std::exit(0);
}


int main()
{

	//research();
	//research2();
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
				if ('0' <= c && c <= '9')
				{
                  cur = cur * 10 + (c - '0');
				}
				else
				{
					assert(c == ' ' || c == '\n');
					if (cur > 0)
					{
						a[i].push_back(cur);
						cur = 0;
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
}
