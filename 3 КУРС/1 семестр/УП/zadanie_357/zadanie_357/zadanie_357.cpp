// zadanie_357.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

using namespace std;

int main()
{
	long int num, sum1=0, sum2=0;
	cin >> num;
    sum1 = sum2 = 0;
	do
	{
		sum1 += num % 10;
		num /= 10;
		sum2 += num % 10;
	} while (num /= 10);
    if ((sum1 - sum2) % 11==0)
		cout << "YES";
	else
		cout << "NO";
	return 0;
}

