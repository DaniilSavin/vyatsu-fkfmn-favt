#include "pch.h"
#include <cstdio>
#include <string>
#include <vector>
#include <iostream>
using namespace std;
int main()
{
	vector<string> possible(128);
	possible['0'] = "0";
	possible['1'] = "1";
	possible['2'] = "2";
	possible['3'] = "3";
	possible['4'] = "4";
	possible['5'] = "5";
	possible['6'] = "6";
	possible['7'] = "7";
	possible['8'] = "8";
	possible['9'] = "9";
	possible['a'] = "0123";
	possible['b'] = "1234";
	possible['c'] = "2345";
	possible['d'] = "3456";
	possible['e'] = "4567";
	possible['f'] = "5678";
	possible['g'] = "6789";
	possible['?'] = "0123456789";
	char buffer[9 + 1];
	cin >> buffer;
	string s1(buffer);
	cin >> buffer;
	string s2(buffer);
	int p = 1;
	for (int i = 0; i < (int)s1.size(); i++)
	{
		int c1 = s1[i];
		int c2 = s2[i];
		int digit = 0;
		for (char d = '0'; d <= '9'; d++)
		{
			if ((int)possible[c1].find(d) != -1 && (int)possible[c2].find(d) != -1)
			{
				digit++;
			}
		}
		p *= digit;
	}
	cout << p;
	return 0;
}