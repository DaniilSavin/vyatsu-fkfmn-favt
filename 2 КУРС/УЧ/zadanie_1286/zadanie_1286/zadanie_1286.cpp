// zadanie_1286.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <stdio.h>
#include <iostream>
using namespace std;
long long P, Q, SL, SC, X, Y;


long cmmdc(long a, long b)
{
	return !b ? a : cmmdc(b, a % b);
}

int main()
{
	long d;

	cin >> P >> Q >> SL >> SC >> X >> Y;
	
	X -= SL; Y -= SC;
	if (X < 0) X = -X;
	if (Y < 0) Y = -Y;

	d = cmmdc(P, Q);

	if (X % d || Y % d)
	{
		cout << "NO";
		return 0;
	}

	X /= d; Y /= d; P /= d; Q /= d;

	if (!((P + Q) % 2 == 0 && (X + Y) % 2))
		cout << "YES";
	else
		cout << "NO";
	return 0;
}
