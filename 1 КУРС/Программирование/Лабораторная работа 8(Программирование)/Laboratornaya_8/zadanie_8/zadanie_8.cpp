// zadanie_8.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <clocale>

using namespace std;

void f(int n, int p);

int main()
{
	setlocale(LC_ALL, "rus");
	int n, p;
	cout << "Введите число, а затем систему, в которую надо перевести число: ";
	cin >> n >> p;

	f(n, p);
	/*for (int i = 0; n >= 1; i++)
	{
		ch += (n % p)* pow(10, i);
		n /= p;
	}*/

}

/*int func(int n, int p, int &ch, int i)
{
	ch = 0;
	i = 0;
	
	while (n <= 1)
	{
		
		ch += (n % p)* pow(10, i);
		n /= p;
	}
	return func(n, p, ch, i + 1);
}*/



void f(int n, int p)
{
	if (n > 0)
	{
		f(n/p, p);
		cout << ' ' << n%p;
	}
}