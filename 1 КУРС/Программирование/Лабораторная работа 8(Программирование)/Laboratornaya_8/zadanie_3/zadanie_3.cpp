// zadanie_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "iostream"
#include "clocale"
#include <cstdlib>

using namespace std;

int sumAr(int a, int d, int N);
int sumGe(int a, int q, int N);

int main()
{
	int a, d, N, p, q;
	system("color 0a");
	setlocale(LC_ALL, "rus");
	cout << "Какая прогрессия вам нужна?" << endl;
	cout << "1 - Арифметическая.\n2 - Геометрическая.\n";
	cin >> p;
	cout << "Введите первый член последовательности: ";
	cin >> a;
	cout << "Сколько членов последовательности вам надо? --> ";
	cin >> N;
	if (p == 1)
	{
		cout << "Введите разность: ";
		cin >> d;
		cout << sumAr( a, d, N);
	}
	if (p == 2)
	{
		cout << "Введите знаменатель: ";
		cin >> q;
		cout << sumGe(a, q, N);
	}
    return 0;
}

int sumAr(int a, int d, int N)
{
	if (N == 1) {
		return a;
	}
	return sumAr(a, d, N - 1) + (a + d*(N - 1));
}

int sumGe(int a, int q, int N)
{
	if (N == 1) {
		return a;
	}
	return sumGe(a, q, N - 1) + (a*pow(q, N - 1));
}