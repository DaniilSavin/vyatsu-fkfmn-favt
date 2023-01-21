// zadanie_21.cpp : В отделе работают 3 сотрудника, которые получают заработную плату в рублях. Требуется определить: на сколько зарплата самого высокооплачиваемого из них отличается от самого низкооплачиваемого.
//

#include "pch.h"
#include <iostream>

using namespace std;

int main()
{
	int n = 3, max = 0, min = 999999, result = 0;
	int *A = new int[n];
	for (int i = 0; i < n; i++)
	{
		cin >> *(A + i);
	}
	for (int i = 0; i < n; i++)
	{
		if (max < *(A + i))
		{
			max = *(A + i);
		}
		if (min > *(A + i))
		{
			min = *(A + i);
		}
	}
	result = max - min;
	cout << "result= " << max - min << endl;
	return 0;
}

