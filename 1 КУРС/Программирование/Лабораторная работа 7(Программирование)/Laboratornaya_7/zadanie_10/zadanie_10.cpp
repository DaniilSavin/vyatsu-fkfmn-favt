// zadanie_10.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include "stdafx.h"
#include "math.h"
#include "clocale"
#include "iostream"

using namespace std;

bool func(long double n);

int kol(int n);

int main()
{
	setlocale (LC_ALL, "rus");
	double n;
	cout << "¬ведите n:" << endl;
	
	cin >> n;
	if (func(n))
		cout<<"+";
}

int kol(int n)
{
	int count = 0;
	while (n > 0)
	{
		n /= 10;
		count++;
	}
	return count;
}

bool func(long double n)
{
	int kv = pow(n, 2);
	int k = kol(n);
	int f = kv % (int)pow(10, k);
	if (f==n)
	{
		return true;
	}
	else 
	return 0;
}
