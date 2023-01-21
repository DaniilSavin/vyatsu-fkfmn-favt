// zadanie_9.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>

using namespace std;

void funk(int k, int s, int i)
{
	int q = pow(10, k - 1);// возводим в степень k-1 для нахождения границы
	int chk = 0;
	int sum = 0;

	for (i; i < q; i++) //цикл перебора с i по q
	{
		sum += k % 10;
		k /= 10;// две строчки на нахождение сумы, вне рекурсии они работают 
		cout << i << " ";
		cout << sum << " ";
		if (s == sum)
		{
			cout << i;
			sum = 0;
			chk++;
			int a = i;
			funk(k, s, a);//стартуем рекурсию с места где закончили
		}
		else
		{
			int a = i;
			sum = 0;
			funk(k, s, a);//стартуем рекурсию с места где закончили
		}


	}
	cout << chk << endl;
}

