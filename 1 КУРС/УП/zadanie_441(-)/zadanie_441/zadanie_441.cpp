#include "pch.h"
#include <iostream>
#include <vector>
#include <algorithm>
#include <stdio.h>

void check(bool e)
{
	if (!e)
	{
		throw 1;
	}
}
struct Pair
{
	int value;
	int index;
	Pair()
	{
		value = 5;
		index = 10;
	}
	Pair(const int value, const int index)
		: value(value),
		index(index)
	{}
};
struct Triple
{
	int value;
	int index1;
	int index2;
	Triple(const int value, const int index1, const int index2)
		: value(value)
		, index1(index1)
		, index2(index2)
	{}
};

struct Set
{
	const int PART = 400;
	std::vector<bool> isMarked;
	std::vector<int> count;
	Set(const int n)
		: isMarked(n, false)
		, count((n + PART - 1) / PART, 0)
	{}

	void mark(const int index)
	{
		check(!isMarked[index]);
		isMarked[index] = true;
		count[index / PART]++;

	}

	int countUP(int index) const
	{
		int range = (index + PART + 1) / PART * PART;
		int res = 0;
		while (index < (int)isMarked.size() && index < range)
		{
			if (isMarked[index])
			{
				res++;
			}
			index++;
		}
		for (int i = range / PART; i < (int)count.size(); i++)
		{
			res += count[i];
		}
		return res;
	}
};

int main()
{
	int n;
	std::cin >> n;
	std::vector<Pair> a;
	for (int i = 0; i < n; i++)
	{
		int value;
		std::cin >> value;
		a.push_back(Pair(value, i));
	}
	std::stable_sort(a.begin(), a.end(), [](const Pair &left, const Pair &right)
	{
		return left.value < right.value;
	});
	std::vector<Pair> b;
	for (int i = 0; i < n; i++)
	{
		int value;
		std::cin >> value;
		b.push_back(Pair(value, i));
	}
	std::stable_sort(b.begin(), b.end(), [](const Pair &left, const Pair &right)
	{
		return left.value < right.value;
	});
	std::vector<Triple> c;
	for (int i = 0; i < n; i++)
	{
		if (a[i].value != b[i].value)
		{
			std::cout << "-1";
			return 0;
		}
		c.push_back(Triple(a[i].value, a[i].index, b[i].index));
	}
	std::sort(c.begin(), c.end(), [](const Triple &left, const Triple &right)
	{
		return left.index2 < right.index2;
	});
	long long ans = 0;
	Set set(n);
	for (const Triple &t : c)
	{
		ans += t.index1 + set.countUP(t.index1 + 1) - t.index2;
		set.mark(t.index1);
		
	}
	std::cout << ans;
	system("pause");
}
