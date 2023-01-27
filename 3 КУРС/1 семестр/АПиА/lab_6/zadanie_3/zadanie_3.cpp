// zadanie_3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

void z_function(string s);
void func(vector <int> r);
string S = "abca%";
int h = S.length();
int k = 0;
int main()	
{
	for (auto j : S)
	{
		cout << j;
	}
	cout << endl;
	reverse(S.begin(), S.end());

	z_function(S);

}	

void func(vector <int> r)
{
	int max = r[0];
	for (int i = 1; i < r.size(); i++) 
	{
		if (r[i] > max)
		{
			max = r[i];
		}
	}
	k = S.length() - max;
	cout << k << endl;

}

void z_function(string s)
{
	int n = s.length();
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

