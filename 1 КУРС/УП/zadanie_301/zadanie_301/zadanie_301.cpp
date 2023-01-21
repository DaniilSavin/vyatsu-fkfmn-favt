// zadanie_301.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <cstdio>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
	int sum, n;
	cin >> sum >> n;
	vector<int> max(n);
	{
		int s = sum;
		for (int i = 0; i < n; i++)
		{
			max[i] = min(9, s);
			s -= max[i];
		}
	}
	vector<int> min(n);
	{
		int s = sum-1;
		for (int i = n-1; i >= 0; i--)
		{
			min[i] = std::min(9, s);
			s -= min[i];
		}
		min[0]++;
	}
	for (int d : max)
	{
		cout << d;
	}
	cout << endl;
	for (int d : min)
	{
		cout << d;
	}
}

