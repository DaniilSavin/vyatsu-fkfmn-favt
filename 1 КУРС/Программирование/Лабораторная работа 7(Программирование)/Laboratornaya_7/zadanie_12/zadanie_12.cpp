// zadanie_12.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "stdafx.h"
#include "iostream"

using namespace std;

int NOD(int a, int b);
int NOK(int a, int b);

int main()
{
	int a, b, n;
	cout << "n="; cin >> n;
	cout << "a="; cin >> a;
	cout << "b="; cin >> b;
	int d = NOK(a, b);
	int i = 2;

	while (i<=n)
	{
		cout << "a="; cin >> a;
		d = NOK(a, d);
		i++;
	}
	cout << "NOD=" << d << endl;

}



int NOD(int a, int b)
{
	do {
		int d = a % b;
		a = b;
		b = d;
	} while (b != 0);
	return a;
}


int NOK(int a, int b)
{
	return a*b / NOD(a, b);
}