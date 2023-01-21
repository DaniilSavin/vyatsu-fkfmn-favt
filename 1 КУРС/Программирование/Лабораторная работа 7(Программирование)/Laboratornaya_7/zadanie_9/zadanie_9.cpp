// zadanie_9.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include "stdafx.h"
#include "math.h"
#include "clocale"
#include "iostream"

using namespace std;

bool func(int n);

int main()
{
	setlocale(LC_ALL, "rus");
	int  n;
	cout << "¬ведите ваше число" << endl;
	cin >> n;
	if (func(n))
		cout << "+";
}

bool func (int n)
{
	int p = 0, x=n;
	while (n > 0)
	{
		p = p * 10 + n % 10;
		n /= 10;
	}
		return p==x;
}
