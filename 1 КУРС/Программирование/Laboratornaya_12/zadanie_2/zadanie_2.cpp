// zadanie_2.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <iostream>
#include <string.h>
#include <conio.h>
#include <clocale>

using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	cout << "imput n: ";
	int n;
	cin >> n;
	int count1 = 0, count2 = 0;
	char *stroka = new char[n];

	for (int i = 0; i < n; i++)
	{
		cin >> *(stroka + i);
	}
	for (int i = 0; i < n / 2; i++)
	{
		if (*(stroka + i) == '*')
		{
			count1++;
		}
	}
	for (int i = n / 2; i < n; i++)
	{
		if (*(stroka + i) == '*')
		{
			count2++;
		}
	}
	if (count1 == count2)
	{
		cout << "count1 = count2" << endl;
	}
	else
	{
		if (count1 > count2)
		{
			cout << "count1 > count2" << endl;
		}
		else
		{
			cout << "count1 < count2" << endl;
		}
	}

	return 0;
}

