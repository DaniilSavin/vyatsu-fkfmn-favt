// zadanie_7.cpp: ���������� ����� ����� ��� ����������� ����������.
//7.����������� ���������� ������� ��� �����������, �������� �� ����� �����������, �� ���� ����� �� ��� ����� ����� ���������, ����� ������ ����. 
//� ������� ���� ������� ����� ����������� ����� � ��������� �� 1 �� 10000

#include "stdafx.h"
#include "iostream"

using namespace std;

bool sov(int x);

int main()
{
	for (int x = 6; x < 10000; x++)
	{
		if (sov(x))
		cout << x << endl;
	}

    return 0;
}

bool sov(int x)
{
	int sum = 1;
	for (int i = 2; i <= x/2; i++)
	{
		if (fmod(x, i) == 0)
		{
			sum += i;
		}
	}
	if (sum == x) 
		return true;
	else 
		return false;
}


