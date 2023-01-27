// zadanie_77.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

using namespace std;

void f(int n, int p, bool t, int K, bool tt);
void mass(int n, int p, bool tt, int K);

int arr[16] = { 555, 555, 555, 555, 555, 555, 555, 555, 555, 555, 555, 555, 555, 555, 555, 555 };
int g = 0, count_ = 0;


int main()
{
	setlocale(LC_ALL, "rus");
	int N = 0, K = 0, count = 0;
	int p = 2;
	bool t = false;
	bool tt = false;
    cout << "Vvedite N and K: ";
	cin >> N >> K;
	for (int i = 1; i <= N; i++)
	{
		t = true;
		f(i, p, t, K,tt);
	}
	cout << " " << endl;
	for (int i = 0; i <= 16; i++)
	{
		cout << *(arr + i) << endl;
	}
	cout << count_ << endl;
}

void f(int n, int p, bool t, int K, bool tt)
{
	
	int count = 0;
	if (n > 0)
	{
		if (t==true)
		{
			cout << " " << endl;
			cout << n << "-e число" << endl;
			tt = true;
		}
		t = false;

		f(n / p, p, t, K,tt);
		
		mass(n,p, tt, K);
		
		cout << ' ' << n % p;

	}
}

void mass(int n, int p, bool tt, int K)
{
	
		*(arr + g) = n % p;
		g++;
		if (tt == true)
		{
			for (int i = 0; i <= g; i++)
			{
				if (*(arr + i) == 0)
				{
					count_++;
				}
			}
		}
		tt = false;
}