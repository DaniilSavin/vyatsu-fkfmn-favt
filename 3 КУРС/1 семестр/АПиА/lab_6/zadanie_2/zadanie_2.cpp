// zadanie_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

void z_function(string s);
void func(vector <int> r);
string S = "Hello Word";
string P = "lo Wo";
string K = P + "%" + S;

int main()
{
	for (auto j : S)
	{
		cout << j;
	}
	cout << endl;
	for (auto j : P)
	{
		cout << j;
	}
	cout << endl;
	z_function(K);

}

void func(vector <int> r)
{
	auto size = P.length();
	for (int i = 0; i < size; i++)
	{
		if (r[i + size + 1] == size)
		{
			cout << "vhodit s " << i << endl;
		}
	}
}

void z_function(string s)
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
	func(z);
}