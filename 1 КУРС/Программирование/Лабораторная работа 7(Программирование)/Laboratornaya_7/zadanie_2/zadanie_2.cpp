// zadanie_2.cpp: определ€ет точку входа дл€ консольного приложени€.
//d^2= (х2Ч х1)^2+ (y2Ч y1)^2

#include "stdafx.h"
#include "iostream"

using namespace std;

void func(int x1, int x2, int x3, int y1, int y2, int y3);
int a, b, c;

int main()
{
	setlocale(LC_ALL, "rus");
	int x1, x2, x3, y1, y2, y3;
	cout << "¬ведите координаты вершин треугольника(x1, y1; x2, y2; x3, y3): ";
	cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3;
	func(x1, x2, x3, y1, y2, y3);
	cout << "a=" << a << endl << "b=" << b << endl << "c=" << c << endl;

	return 0;
}

void func(int x1, int x2, int x3, int y1, int y2, int y3)
{
	a = sqrt(pow((x2 - x1), 2) + pow((y2 - y1), 2));
	b = sqrt(pow((x3 - x2), 2) + pow((y3 - y2), 2));
	c = sqrt(pow((x3 - x1), 2) + pow((y3 - y1), 2));
}

