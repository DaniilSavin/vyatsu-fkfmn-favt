// zadanie_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

vector<int> z_function(string s);

int main()
{
    string s="aaabbaasffdsss";
	vector <int> r;
	r=z_function(s);
	for (auto q : s)
	{
		cout << q;
	}
	cout << endl;
	for (auto s : r)
	{
		cout << s;
	}
	 
}

vector<int> z_function(string s) 
{
	int n = (int)s.length();
	vector<int> z(n);
	for (int i = 1, l = 0, r = 0; i < n; ++i)
	{
		if (i <= r)
			z[i] = min(r - i + 1, z[i - l]);
		while (i + z[i] < n && s[z[i]] == s[i + z[i]])
			++z[i];
		if (i + z[i] - 1 > r)
			l = i, r = i + z[i] - 1;
	}
	return z;
}
