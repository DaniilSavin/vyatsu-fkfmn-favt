// zadanie_4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

void z_function(string s);
void func(vector <int> r);
string S = "Hello WordHello WordHello WordHello Word";
string shortString="";
auto sizeofS = S.length();

int main()
{
	setlocale(LC_ALL, "rus");
	for (auto j : S)
	{
		cout << j;
	}
	cout << endl;
	z_function(S);
	cout << endl;
	for (auto j : shortString)
	{
		cout << j;
	}
	cout << endl;
}

void func(vector <int> r)
{
	auto size = r.size();
	int i = 0;
	for (; i < size; i++)
	{
		if (i + r[i] == sizeofS && sizeofS % i == 0)
		{
			cout << "Строку S можно сжать до строки длины " << i << endl;
			break;
		}
	}

	for (int j = 0; j < i; j++)
	{
		shortString += S[j];
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


