// zadanie_11.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "iostream"

using namespace std;

int a, b, c, d;

void NOD();

int main()
{
	cout << "a="; cin >> a;
	cout << "b="; cin >> b;
	cout << "c="; cin >> c;
	NOD();
	cout << "NOD=" << a << endl;
}

void NOD()
{
	do {
		d = a % b;
		a = b;
		b = d;
	} while (b != 0);
	do {
		d = a%c;
		a = c;
		c = d;
	} while (c != 0);

}